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
        /// <summary>
        /// constructor que inicializa el form
        /// </summary>
        public FormComprarMonedas()
        {
            InitializeComponent();
        }
        /// <summary>
        /// constructor que inicializa el form pasandole un casino
        /// </summary>
        /// <param name="c"></param>
        public FormComprarMonedas(Casino c)
            :this()
        {
            this.ca = c;
        }
        /// <summary>
        /// carga el form y el combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Al apretar el botn aceptar se efectua una compra si los datos estan correctos y se genera la nueva informacion del
        /// usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {        
            try
            {
                string seleccionado;
                this.participante = Casino.BuscarJugador(this.ca, txtBoxIDJugador.Text);
                if (this.participante==null)
                {
                    this.participante = new Jugador(txtBoxIDJugador.Text);
                }
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
                                        participante += moni;                          
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
                                this.primera.Varianza = Jugada.CalcularVarianza(moni, cant, ETipoTransaccion.compra);
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                try
                                {
                                    BoletoChances boletonew = new BoletoChances(cant);
                                    this.participante += boletonew;
                                    this.primera.Varianza = BoletoChances.GastoBoleto(cant, Moneda.SacarPrecio(ETipoMoneda.bronce));
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
        /// <summary>
        /// cancela la compra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelarCompra_Click(object sender, EventArgs e)
        {          
            this.Close();
        }
        /// <summary>
        /// muestra los precios vigentes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreguntaPrecio_Click(object sender, EventArgs e)//devuelve precios de monedas
        {
            MessageBox.Show(Extension.MostrarMonedas(this.ca));
        }
    }
}
