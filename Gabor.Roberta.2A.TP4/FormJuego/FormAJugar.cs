using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using FormRuleta;
using System.Threading;
using Excepciones;

namespace FormJuego
{
    public partial class FormJugar : Form
    {
        Thread hilo;
        FormRule ruleta;
        private bool invoked = false;
        bool control = false;
        public Jugada segunda=null;//hago getter?
        public Jugador victima;
        private int winLo;
        static Random ganoperdio;
        private Casino ca;
        

        static FormJugar()
        {
            FormJugar.ganoperdio = new Random();
        }
        public FormJugar(Casino c)
            : this()
        {
            this.ca = c;
        }
        public FormJugar()
        {
            InitializeComponent();
            lblBoletos.Text = "";
            rdoButtonBoleto.Checked = false;

        }

        private void FormJugar_Load(object sender, EventArgs e)
        {
            foreach (ETipoMoneda item in Enum.GetValues(typeof(ETipoMoneda)))
            {
                this.cmbBoxAJugar.Items.Add(item);
            }
            this.cmbBoxAJugar.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbBoxAJugar.SelectedItem = ETipoMoneda.oro;
        }

        private void btnIniciativaJugar_Focus(object sender, EventArgs e)
        {
            btnAJugar.BackColor = Color.LawnGreen;
        }

        private void btnIniciativaDejarJugar_Focus(object sender, EventArgs e)
        {
            btnAJugar.BackColor = Control.DefaultBackColor;
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            //creo jugador auxiliar 
            //if() si el boton esta checked y no tiene boletos que salte exception
            int cantidadJ;
            
            if (!invoked)
            {
                ///if--> chequear que el id este, si esta lo busco en casino jugadores, y traigo todos los datos
                ///veo que si la cantidad del tipo de moneda que esta apostando coincide
                ///si tiene apretado boleto y tiene boleto esta bien, sino no puede
                ///si usa boleto resto boleto
                

                try
                {
                    if ((this.victima = Extension.BuscarJugador(this.ca, txtBoxIDAJugar.Text)) != null)
                    {
                        try
                        {
                            cantidadJ = int.Parse(txtCantidadAJugar.Text);
                            ETipoMoneda money = (ETipoMoneda)cmbBoxAJugar.SelectedItem;
                            int ganancia = Moneda.SacarGanancia(money);
                            if (this.victima.CantidadMonedasSegunTipo(money) >= cantidadJ)
                            {

                                //recorrer billetera y buscar la moneda con el mismo tipo, y de ahi sacar su info
                                if ((rdoButtonBoleto.Checked&&this.victima.Boletos.Cantidad>0)|| rdoButtonBoleto.Checked==false)
                                {
                                    this.ruleta = new FormRule();
                                    this.ruleta.frenacion += spinStop;
                                    this.invoked = true;
                                    ruleta.Show();
                                    this.InicioThread();

                                    if((rdoButtonBoleto.Checked && this.victima.Boletos.Cantidad > 0))//arreglar
                                    {
                                        BoletoChances apuesto = new BoletoChances(1);
                                        this.victima -= apuesto;
                                    }
                                    

                                    Moneda apostada = new Moneda(Moneda.SacarPrecio(money), cantidadJ, money, ganancia);
                                    this.segunda = new Jugada(this.victima);
                                    this.winLo = ganoperdio.Next(0, 50);
                                    if (this.winLo > 35)
                                    {
                                        this.segunda.Varianza = Jugada.CalcularVarianza(apostada, cantidadJ, ETipoTransaccion.gana);
                                        apostada.Cantidad = apostada.Cantidad * ganancia;//genero las ganancias
                                        this.victima += apostada;//como ya existe solo suma cantidad
                                        //sacar saldo y actualizarlo en ganancias
                                        //poner transaccion gano
                                        this.segunda.Movimiento = ETipoTransaccion.gana;
                                    }
                                    else
                                    {
                                        ///ver que declaraciones uso abajo y aca
                                        this.segunda.Movimiento = ETipoTransaccion.pierde;
                                        this.segunda.Varianza = Jugada.CalcularVarianza(apostada, cantidadJ, ETipoTransaccion.pierde);
                                        this.victima -= apostada;
                                    }
                                    this.victima.Saldo = this.victima.SacarSaldo(this.victima.Billetera);
                      
                                }
                                else
                                {
                                    MessageBox.Show("No le alcanzan los boletos");
                                }

                            }
                            else
                            {
                                MessageBox.Show("No tiene las monedas suficientes para jugar");
                            }
                        }
                        catch (FormatException)
                        {
                            throw new cantidadInvalidaException();
                        }

                    }
                    else
                    {
                        MessageBox.Show("No se encuentra ese dni en la lista de jugadores disponibles");
                    }
                }
                catch(cantidadInvalidaException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch(dniInvalidoException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch(insuficienteParaBoletoException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                    
            }
 
        }

        private void InicioThread()
        {
            this.hilo = new Thread(this.ruleta.spinRoulette);
            hilo.Start();
        }
        public void spinStop(object sender, EventArgs e)
        {
            if(this.hilo.IsAlive)
            {

                this.hilo.Abort();

                if(e==EventArgs.Empty)
                {
                    if (this.winLo > 35)//mas posibilidades de perder que ganar
                    {
                        MessageBox.Show("Ganó");
                    }
                    else
                    {
                        MessageBox.Show("Perdió");
                    }
                }

            }
            
            if(e!=EventArgs.Empty)
            {
                //FormClosingEventArgs cerra = new FormClosingEventArgs(CloseReason.None, false);
                invoked = false;
                //this.ClosingJugar_Asegurar(sender,cerra);
            }
            
        }

        private void rdioBtnChecked_Click(object sender, EventArgs e)
        {
            //cuando esta checked mostrar cantidad de boletos del jugador
        }

        private void txtJugador_NoTrampa(object sender, EventArgs e)
        {
            //si boleto esta checked que no me deje cambiar
            if(rdoButtonBoleto.Checked)
            {
                rdoButtonBoleto.Checked = false;
                this.control = !this.control;
            }
        }

        private void rdoBtnCambio_Click(object sender, EventArgs e)
        {
           if(!this.control)
           {
                rdoButtonBoleto.Checked = true;
           }
           else
           {
                rdoButtonBoleto.Checked = false;
           }
            this.control = !this.control;
        }

        private void ClosingJugar_Asegurar(object sender, FormClosingEventArgs e)
        {
            if(this.hilo!=null&& this.hilo.IsAlive)
            {
                e.Cancel = true;
            }

        }
    }
}
