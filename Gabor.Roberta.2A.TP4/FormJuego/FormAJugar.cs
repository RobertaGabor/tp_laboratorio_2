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

namespace FormJuego
{
    public partial class FormJugar : Form
    {
        Thread hilo;
        FormRule ruleta;
        private bool invoked = false;
        bool control = false;
        Jugada segunda;
        Jugador victima;
        private int winLo;
        static Random ganoperdio;
        

        static FormJugar()
        {
            FormJugar.ganoperdio = new Random();
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
            
            if (!invoked)
            {
                    ///if--> chequear que el id este, si esta lo busco en casino jugadores, y traigo todos los datos
                    ///veo que si la cantidad del tipo de moneda que esta apostando coincide
                    ///si tiene apretado boleto y tiene boleto esta bien, sino no puede
                    ///si usa boleto resto boleto
                    ///
                    this.ruleta = new FormRule();
                    this.ruleta.frenacion += spinStop;
                    this.invoked = true;
                    ruleta.Show();
                    this.InicioThread();
                    this.winLo = ganoperdio.Next(0, 50);//ya se puede guardar la variable aunque siga el hilo
        

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
