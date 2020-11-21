using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace FormRuleta
{
    public partial class FormRule : Form
    {
        public delegate void frenarRuleta(object sender, EventArgs e);
        public event frenarRuleta frenacion;
        private bool closing;//chequea si puso frenar o no

        public FormRule()
        {
            InitializeComponent();
        }


        public void spinRoulette()
        {
            Image flipImage = picBoxRuleta.Image;
            Bitmap bitmap = new Bitmap(flipImage);
            this.closing = false;
            
            do
            {
                bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
                this.picBoxRuleta.Image = bitmap;
                Thread.Sleep(150);


            } while (true);
            
        }

        private void btnSpinParar_Click(object sender, EventArgs e)
        {
            this.frenacion(frenacion, EventArgs.Empty);
            this.closing = true;
        }

        private void btnClosingForm_Click(object sender, FormClosingEventArgs e)
        {
          if(!this.closing)
          {
                if (MessageBox.Show("Seguro que desea salir? No se guardaran las apuestas", "No se olvide de jugar!",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.frenacion(frenacion, e);
                }
                else
                {
                    e.Cancel = true;
                }
          } 
          else
          {
                this.frenacion(frenacion, e);
          }
        }
    }
}
