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
using System.Media;

namespace FormJuego
{
    public partial class FormJugar : Form
    {
        Thread hilo;
        FormRule ruleta;
        private bool invoked = false;
        private bool control = false;
        public Jugada segunda=null;
        public Jugador victima;
        private int winLo;
        static Random ganoperdio;
        private Casino ca;
        
        /// <summary>
        /// constructor que inicializa el numero Random
        /// </summary>
        static FormJugar()
        {
            FormJugar.ganoperdio = new Random();
        }
        /// <summary>
        /// constructor que le pasa un casino
        /// </summary>
        /// <param name="c"></param>
        public FormJugar(Casino c)
            : this()
        {
            this.ca = c;
        }
        /// <summary>
        /// constructor que inicializa el form
        /// </summary>
        public FormJugar()
        {
            InitializeComponent();
            lblBoletos.Text = "";
            rdoButtonBoleto.Checked = false;

        }
        /// <summary>
        /// evento que carga el combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormJugar_Load(object sender, EventArgs e)
        {
            foreach (ETipoMoneda item in Enum.GetValues(typeof(ETipoMoneda)))
            {
                this.cmbBoxAJugar.Items.Add(item);
            }
            this.cmbBoxAJugar.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbBoxAJugar.SelectedItem = ETipoMoneda.oro;
        }
        /// <summary>
        /// evento que al darle focus al boton jugar se ponga verde
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIniciativaJugar_Focus(object sender, EventArgs e)
        {
            btnAJugar.BackColor = Color.LawnGreen;
        }
        /// <summary>
        /// iniciativa que el boton de jugar sea por default el como de la app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIniciativaDejarJugar_Focus(object sender, EventArgs e)
        {
            btnAJugar.BackColor = Control.DefaultBackColor;
        }
        /// <summary>
        /// al apretar Jugar en este form se abrira un form ruleta y se armara la partida y los nuevos datos del jugador
        /// segun si el random perdio o gano. solo se podra abrir un form de ruleta si no existe uno ya corriendo y 
        /// si todos los datos son correctos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJugar_Click(object sender, EventArgs e)
        {
            
            if (!invoked)
            {
                try
                {
                    if ((this.victima = Casino.BuscarJugador(this.ca, txtBoxIDAJugar.Text)) != null)
                    {
                        try
                        {
                            int cantidadJ;
                            cantidadJ = int.Parse(txtCantidadAJugar.Text);


                            if(cantidadJ<0)
                            {
                                throw new FormatException();
                            }

                            ETipoMoneda money = (ETipoMoneda)cmbBoxAJugar.SelectedItem;
                            int ganancia = Moneda.SacarGanancia(money);
                            
                            if (this.victima.CantidadMonedasSegunTipo(money) >= cantidadJ)
                            {
                                if ((rdoButtonBoleto.Checked&&this.victima.Boletos.Cantidad>0)|| rdoButtonBoleto.Checked==false)
                                {
                                    /*base del form*/
                                    this.ruleta = new FormRule();
                                    this.ruleta.frenacion += spinStop;
                                    this.invoked = true;//si ya se abrio una ruleta y no se cerro de ninguna forma no se puede generar otro form
                                    ruleta.Show();
                                    this.InicioThread();
                                    /**/

                                    if((rdoButtonBoleto.Checked && this.victima.Boletos.Cantidad > 0))
                                    {
                                        BoletoChances apuesto = new BoletoChances(1);
                                        this.victima -= apuesto;
                                    }
                                    

                                    Moneda apostada = new Moneda(Moneda.SacarPrecio(money), cantidadJ, money, ganancia);
                                    this.segunda = new Jugada(this.victima);
                                    
                                    this.winLo = ganoperdio.Next(0, 50);
                                    
                                    if (this.winLo > 35)/*15 veces mas de perder que de ganar*/
                                    {
                                        this.segunda.Varianza = Jugada.CalcularVarianza(apostada, cantidadJ, ETipoTransaccion.gana);
                                        apostada.Cantidad = apostada.Cantidad * ganancia;
                                        this.victima += apostada;
                                        this.segunda.Movimiento = ETipoTransaccion.gana;
                                    }
                                    else
                                    {
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
        /// <summary>
        /// metodo que inicia el thread
        /// </summary>
        private void InicioThread()
        {
            this.hilo = new Thread(this.ruleta.spinRoulette);
            hilo.Start();
        }
        /// <summary>
        /// manejador de eventos que al lanzarle el stop aborta el hilo y avisa si se gano o se perdio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void spinStop(object sender, EventArgs e)
        {
            if(this.hilo.IsAlive)
            {

                this.hilo.Abort();
                SoundPlayer sp;
                if(e==EventArgs.Empty)
                {
                    if (this.winLo > 35)
                    {
                        sp = new SoundPlayer("winner.wav");
                        sp.Play();
                        MessageBox.Show("Ganó");
                    }
                    else
                    {
                        sp = new SoundPlayer("loser.wav");
                        sp.Play();
                        MessageBox.Show("Perdió");
                    }
                }

            }
            ///si no es empty significa que se cerró por closing y ya no es visible, se puede crear otro
            ///si es empt significa que solo se dio PARARpero sigue visible, no se puede abrir otro
            if(e!=EventArgs.Empty)
            {
                invoked = false;
            }
            
        }
        /// <summary>
        /// cuando el radio buton ese checked mostrara si es posible la cantidad de boletos que tiene el usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdioBtnChecked_Click(object sender, EventArgs e)
        {
            string dni = txtBoxIDAJugar.Text;
            Jugador verBoletos=Casino.BuscarJugador(this.ca, dni);
            if(verBoletos!=null&&rdoButtonBoleto.Checked==true)
            {
                lblBoletos.Text = verBoletos.Boletos.Cantidad.ToString() + " boletos disponibles";
            }
            else
            {
                lblBoletos.Text = "";
            }
        }
        /// <summary>
        /// verifica que al cambiar el id se limpie la informacion contenida en radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtJugador_NoTrampa(object sender, EventArgs e)
        {
            if(rdoButtonBoleto.Checked)
            {
                rdoButtonBoleto.Checked = false;
                this.control = !this.control;
            }
        }
        /// <summary>
        /// al cambiar el id se limpia el radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoBtnCambio_Click(object sender, EventArgs e)
        {
           if(!this.control)
           {
                rdoButtonBoleto.Checked = true;
           }
           else
           {
                rdoButtonBoleto.Checked = false;
                lblBoletos.Text = "";
           }
            this.control = !this.control;
        }
        /// <summary>
        /// al cerrar el form si el hilo sigue vivo y la ruleta form tambien no se puede cerrar
        /// si cierro este form y el otro esta cerrado se cierra normalmente
        /// si cierro este form y el form rule sigue visible cierra ambos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClosingJugar_Asegurar(object sender, FormClosingEventArgs e)
        {
            if(this.hilo!=null&& this.hilo.IsAlive)
            {
                e.Cancel = true;
            }
            else if(this.ruleta==null)//si cuando cierro, el hilo termino, y el form de ruleta sigue abierto se cierra automaticamente
            {
               
            }
            else
            {
                this.ruleta.Close();
            }

        }
    }
}
