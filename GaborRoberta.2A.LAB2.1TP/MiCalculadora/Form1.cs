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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string txtUno = this.txtBoxNum1.Text;
            string txtDos = this.txtBoxNum2.Text;
            string op = this.cboBoxOperador.Text;
            string aux = Convert.ToString(FormCalculadora.Operar(txtUno, txtDos, op));
            if(aux!="-1")
            {
                this.lblResultado.Text = aux;
            }
            else
            {
                MessageBox.Show("Ingrese un operador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }  
        }

        private static Double Operar(string num1,string num2,string operador)
        {
            double retorno;
            Numero numeroUno = new Numero(num1);
            Numero numeroDos = new Numero(num2);
            retorno = Calculadora.Operar(numeroUno, numeroDos, operador);
            return retorno;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtBoxNum2.Clear();
            this.txtBoxNum1.Clear();
            this.cboBoxOperador.SelectedIndex = -1;
            this.lblResultado.Text = "";
        }

    }
}
