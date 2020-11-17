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
        private Casino ca;
        public FormComprarMonedas()
        {
            InitializeComponent();
        }
        public FormComprarMonedas(Casino c)
            :this()
        {
            this.ca = c;
        }
        private void FormComprarMonedas_Load_1(object sender, EventArgs e)
        {
            foreach (ETipoMoneda item in Enum.GetValues(typeof(ETipoMoneda)))
            {
                this.cmbBoxTipoMoneda.Items.Add(item);
            }
            this.cmbBoxTipoMoneda.Items.Add("PLUSCHANCESTICKET");
            this.cmbBoxTipoMoneda.SelectedItem = ETipoMoneda.oro;
            this.cmbBoxTipoMoneda.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Jugador victima = new Jugador();
            //si compro boleto debo tener monedas de bronce ya compradas
            //revisar columna dni en dataadapter y si existe sumarle a ese sino crearlo en la bd
            //si quiere comprar boletos debe tener al menos 5 monedas de bronce
            try
            {

                Jugador participante = new Jugador(txtBoxIDJugador.Text);
                string seleccionado;
                if(ca!=participante)
                {
                    try
                    {
                        if(int.Parse(txtBoxCantidadMonedas.Text) > 0)
                        {
                            seleccionado = cmbBoxTipoMoneda.SelectedItem.ToString();
                            BoletoChances bc = new BoletoChances();
                            if (seleccionado!= "PLUSCHANCESTICKET")
                            {
                                
                                switch (cmbBoxTipoMoneda.SelectedItem)
                                {
                                    case ETipoMoneda.bronce:
                                        Moneda moni = new Moneda(20, int.Parse(txtBoxCantidadMonedas.Text), ETipoMoneda.bronce, 3);//gana 3 veces mas
                                        participante += moni;
                                        break;
                                    case ETipoMoneda.oro:
                                        Moneda moni2 = new Moneda(65, int.Parse(txtBoxCantidadMonedas.Text), ETipoMoneda.oro, 10);//gana 3 veces mas
                                        participante += moni2;
                                        break;
                                    case ETipoMoneda.plata:
                                        Moneda moni3 = new Moneda(45, int.Parse(txtBoxCantidadMonedas.Text), ETipoMoneda.plata, 7);//gana 3 veces mas
                                        participante += moni3;
                                        break;
                                }
                                participante.Boletos = (BoletoChances)0;
                                participante.Saldo=participante.SacarSaldo(participante.Billetera);
                                //hacer jugada
                                MessageBox.Show(participante.Saldo.ToString());
                                MessageBox.Show(participante.DNI.ToString());
                                MessageBox.Show(participante.Boletos.Cantidad.ToString());
                                foreach(Moneda item in participante.Billetera)
                                {
                                    MessageBox.Show(item.Moneyda.ToString());
                                    MessageBox.Show(item.Precio.ToString());
                                    MessageBox.Show(item.Cantidad.ToString());
                                    
                                }
                            }
                            else
                            {
                                MessageBox.Show("Antes de comprar boletos debe tener monedas de bronce en la billetera");
                            }

                        }
                        else
                        {
                            throw new cantidadInvalidaException();
                        }
                    }
                    catch(Exception ex)
                    {
                        throw new cantidadInvalidaException(ex);
                    }
                }
                else
                {
                    //ya esta acá
                }
                
            }
            catch(dniInvalidoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(cantidadInvalidaException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }
    }
}
