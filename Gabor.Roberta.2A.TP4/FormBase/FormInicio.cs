using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormCompra;
using FormJuego;

namespace FormBase
{
    public partial class FormPadre : Form
    {
        public FormPadre()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            FormComprarMonedas comprar = new FormComprarMonedas();
            comprar.ShowDialog();
        }

        private void btnAJugar_Click(object sender, EventArgs e)
        {
            FormJugar juego = new FormJugar();
            juego.ShowDialog();
        }
    }
}
