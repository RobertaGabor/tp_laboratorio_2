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
        public FormJugar()
        {
            InitializeComponent();
        }

        private void FormJugar_Load(object sender, EventArgs e)
        {
            foreach (ETipoMoneda item in Enum.GetValues(typeof(ETipoMoneda)))
            {
                this.cmbBoxAJugar.Items.Add(item);
            }
            this.cmbBoxAJugar.DropDownStyle = ComboBoxStyle.DropDownList;
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
    }
}
