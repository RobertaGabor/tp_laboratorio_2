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
        private bool invoked = false;
        bool control = false;
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
            
            if(!invoked)
            {
                FormRule ruleta = new FormRule();
                hilo = new Thread(ruleta.spinRoulette);

                    ruleta.Show();
                    /*llamar hilo aca?*/
                    hilo.Start();
                    /*llamo evento que frena ruleta*/
                    ruleta.frenacion += spinStop;
               
                this.invoked = true;
                if(rdoButtonBoleto.Checked)
                {
                    //resto cantidad boletos al jugador
                }
            }
            else
            {
                //throw excception
            }

 
        }

        public void spinStop(object sender, EventArgs e)
        {
            if(this.hilo.IsAlive)
            {
                this.hilo.Abort();
            }
            
            if(e!=EventArgs.Empty)
            {
                invoked = false;
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
