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
using System.IO;
using System.Data.SqlClient;
using Entidades;
using Excepciones;



namespace FormBase
{
    public partial class FormPadre : Form
    {
        private AccesoDatos acces; 
        private DataTable dt;
        private Casino empresa;//lista de jugadores y lista de jugadas
        FormJugar juego;
        FormComprarMonedas comprar;
        private const String PATH_XML_JUGADAS = @"DataTableJugadasDatos.xml";
        private const String PATH_XML_JUGADAS_SCHEMA = @"DataTableJugadasSchema.xml";
        
        public FormPadre()
        {
            InitializeComponent();
            this.empresa = new Casino();
            acces = new AccesoDatos();
            

            try
            {

                this.dt = new DataTable("jugadas");
                this.dt.Columns.Add("dni", typeof(int));
                this.dt.Columns.Add("saldo", typeof(float));
                this.dt.Columns.Add("variacion", typeof(float));
                this.dt.Columns.Add("transaccion", typeof(string));
                this.dt.PrimaryKey = new DataColumn[] { this.dt.Columns[0] };

                try
                {
                    this.dtaGridView.DataSource = this.dt;
                    this.dtaGridView.MultiSelect = false;
                    this.dtaGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

                try
                {
                    this.empresa = SerializacionJugadores.Leer();
                    this.empresa.Jugadas.Clear();
                    this.CargarDataTable();

                }
                catch
                {
                    MessageBox.Show("Bienvenido a su primer casino!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            
            this.comprar = new FormComprarMonedas(this.empresa);
            this.comprar.ShowDialog();
            
            if(this.comprar.DialogResult==DialogResult.OK)
            {
                if(this.empresa==this.comprar.participante)//si ya esta en el casino
                {
                    //update row
                    DataRow fila = this.dt.Rows.Find(this.comprar.participante.DNI);
                    this.empresa += this.comprar.primera;
                    this.LlenarFilaComprar(fila);
                    this.dt.AcceptChanges();
                    this.acces.ModificarJuego(this.comprar.primera);
                    
                }
                else//si no esta
                {
                    this.empresa += this.comprar.participante;
                    this.empresa += this.comprar.primera;
                    DataRow fila = this.dt.NewRow();
                    this.LlenarFilaComprar(fila);
                    this.dt.Rows.Add(fila);
                    this.dt.AcceptChanges();
                    this.acces.InsertarJugada(this.comprar.primera);
                    
                    
                }
            }  
        }
        private void LlenarFilaComprar(DataRow fila)
        {
            fila["dni"] = this.comprar.participante.DNI;
            fila["saldo"] = this.comprar.participante.Saldo;
            fila["variacion"] = this.comprar.primera.Varianza;
            fila["transaccion"] = this.comprar.primera.Movimiento;
            
        }
        private void LlenarFilaJugar(DataRow fila)
        {
            fila["dni"] = this.juego.victima.DNI;
            fila["saldo"] = this.juego.victima.Saldo;
            fila["variacion"] = this.juego.segunda.Varianza;
            fila["transaccion"] = this.juego.segunda.Movimiento;
        }

        private void btnAJugar_Click(object sender, EventArgs e)
        {
            this.juego = new FormJugar(this.empresa);
            this.juego.ShowDialog();

            if(this.juego.segunda!=null)
            {
                this.empresa += this.juego.segunda;
                DataRow filajuego = this.dt.Rows.Find(this.juego.victima.DNI);
                this.LlenarFilaJugar(filajuego);
                this.dt.AcceptChanges();
                this.acces.ModificarJuego(this.juego.segunda);
                
            }

          

        }

        private void DobleClick(object sender, DataGridViewCellMouseEventArgs e)
        {      
            int i = this.dtaGridView.SelectedRows[0].Index;
            DataRow fila = this.dt.Rows[i];
            string dni=fila[0].ToString();
            Jugador buscado=Casino.BuscarJugador(this.empresa, dni);
            
            MessageBox.Show(buscado.ToString());
        }

        private void ClosingGuardado_FormBase(object sender, FormClosingEventArgs e)
        {
            try
            {
                foreach (Jugada item in this.empresa.Jugadas)
                {
                    SerializacionPartidas.Guardar(item);
                }

                SerializacionJugadores.Guardar(this.empresa);
            } 
            catch(ArchivosException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            try
            {
                this.GuardarDataTable();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GuardarDataTable()
        {
            try
            {
                this.dt.WriteXmlSchema(PATH_XML_JUGADAS_SCHEMA);

                this.dt.WriteXml(PATH_XML_JUGADAS);

            }
            catch
            {
                MessageBox.Show("Error al guardar el DataTable. ",
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDataTable()
        {
            try
            {
                if (File.Exists(PATH_XML_JUGADAS_SCHEMA))
                {
                    this.dt = new DataTable();
                    this.dt.ReadXmlSchema(PATH_XML_JUGADAS_SCHEMA);
                }
                else
                {
                    MessageBox.Show("No existe ningún documento XML");
                }


                if (File.Exists(PATH_XML_JUGADAS))
                {
                    this.dt.ReadXml(PATH_XML_JUGADAS);

                }
                else
                {
                    MessageBox.Show("No existe ningún documento XML");
                }

                this.dtaGridView.DataSource = this.dt;
            }
            catch
            {
                MessageBox.Show("Error al cargar el DataTable. ",
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
