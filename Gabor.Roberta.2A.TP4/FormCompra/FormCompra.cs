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
using Excepciones;


namespace FormCompra
{
    public partial class FormComprarMonedas : Form
    {
        private Casino ca;
        public Jugada primera;
        public Jugador participante;

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
                string seleccionado;
                this.participante = Extension.BuscarJugador(this.ca, txtBoxIDJugador.Text);
                if (this.participante==null)
                {
                    this.participante = new Jugador(txtBoxIDJugador.Text);
                }//aca si existe cargo los datos del jugador
                    try
                    {
                        if (int.Parse(txtBoxCantidadMonedas.Text) > 0)
                        {
                            
                            seleccionado = cmbBoxTipoMoneda.SelectedItem.ToString();
                            int cant = int.Parse(txtBoxCantidadMonedas.Text);
                            this.primera = new Jugada(participante);
                            if (seleccionado != "PLUSCHANCESTICKET")
                            {
                                Moneda moni = null;

                                switch (cmbBoxTipoMoneda.SelectedItem)
                                {
                                    case ETipoMoneda.bronce:
                                        moni = new Moneda(Moneda.SacarPrecio(ETipoMoneda.bronce), cant, ETipoMoneda.bronce, Moneda.SacarGanancia(ETipoMoneda.bronce));//gana 3 veces mas
                                        participante += moni;   //si ya existe suma cantidad                        
                                        break;
                                    case ETipoMoneda.oro:
                                        moni = new Moneda(Moneda.SacarPrecio(ETipoMoneda.oro), cant, ETipoMoneda.oro, Moneda.SacarGanancia(ETipoMoneda.oro));//gana 3 veces mas
                                        participante += moni;
                                        break;
                                    case ETipoMoneda.plata:
                                        moni = new Moneda(Moneda.SacarPrecio(ETipoMoneda.plata), cant, ETipoMoneda.plata, Moneda.SacarGanancia(ETipoMoneda.plata));//gana 3 veces mas
                                        participante += moni;
                                        break;
                                }


                                //armar jugada

                                //agrego varianza y tipo transaccion

                                this.primera.Varianza = Jugada.CalcularVarianza(moni, cant, ETipoTransaccion.compra);
                                ///updateo data table-->que con mismo dni update esa fila, si no existe la creo
                                //tiro evento a form principal? para que cree una fila 
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                try
                                {
                                    BoletoChances boletonew = new BoletoChances(cant);
                                    this.participante += boletonew;
                                    this.primera.Varianza = BoletoChances.GastoBoleto(cant,20);
                                    this.DialogResult = DialogResult.OK;
                                }
                                catch (insuficienteParaBoletoException)
                                {
                                    throw new insuficienteParaBoletoException($" Usted tiene en total {this.participante.CantidadMonedasSegunTipo(ETipoMoneda.bronce)} monedas de bronce");
                                }
                            }
                             
                            this.participante.Saldo = participante.SacarSaldo(participante.Billetera);
                            this.primera.Movimiento = ETipoTransaccion.compra;
                            this.Close();

                        }
                        else
                        {
                            throw new cantidadInvalidaException();
                        }
                    }
                    catch(FormatException)
                    {
                        throw new cantidadInvalidaException();
                    }
                               
            }
            catch(insuficienteParaBoletoException ex)
            {
                MessageBox.Show(ex.Message);
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

        private void CancelarCompra_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
