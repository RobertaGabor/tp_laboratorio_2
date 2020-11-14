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
        

        private bool win=true;
        public FormRule()
        {
            InitializeComponent();
        }

        /*hacer hilo aca?*/
        public void spinRoulette()
        {
            Image flipImage = picBoxRuleta.Image;
            Bitmap bitmap = new Bitmap(flipImage);
            do
            {
                bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
                this.picBoxRuleta.Image = bitmap;
                win = !win;/*si cerró por evento closing no gana ni pierde*/
                Thread.Sleep(150);

            } while (true);
        }

        private void btnSpinParar_Click(object sender, EventArgs e)
        {
            this.frenacion(frenacion, EventArgs.Empty);
        }

        private void btnClosingForm_Click(object sender, FormClosingEventArgs e)
        {
            this.frenacion(frenacion, e);/*cerrar hilo cuando cierro*/
        }
    }
}
