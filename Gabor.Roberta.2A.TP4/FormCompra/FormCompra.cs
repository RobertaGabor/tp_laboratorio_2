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


namespace FormCompra
{
    public partial class FormComprarMonedas : Form
    {
        public FormComprarMonedas()
        {
            InitializeComponent();
        }
        private void FormComprarMonedas_Load_1(object sender, EventArgs e)
        {
            foreach (ETipoMoneda item in Enum.GetValues(typeof(ETipoMoneda)))
            {
                this.cmbBoxTipoMoneda.Items.Add(item);
            }

            this.cmbBoxTipoMoneda.SelectedItem = ETipoMoneda.oro;
            this.cmbBoxTipoMoneda.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Jugador victima = new Jugador();
        }
    }
}
