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
        private SqlConnection cn;
        private SqlDataAdapter da;
        private DataTable dt;
        private Casino empresa;//lista de jugadores y lista de jugadas
        FormJugar juego;
        FormComprarMonedas comprar;

        public FormPadre()
        {
            InitializeComponent();
            this.empresa = new Casino();
            try
            {
                if(!this.ConfigurarDataAdapter())
                {
                    MessageBox.Show("ERROR AL CONFIGURAR EL DATAADAPTER!!!");//hacer exception?
                    this.Close();
                }
                     
                this.dt = new DataTable("jugadas");
                this.dt.Columns.Add("dni", typeof(int));
                this.dt.Columns.Add("saldo", typeof(float));
                this.dt.Columns.Add("variacion", typeof(float));
                this.dt.Columns.Add("transaccion", typeof(string));
                this.dt.PrimaryKey = new DataColumn[] { this.dt.Columns[0] };

                try
                {
                    this.da.Fill(this.dt);
                    this.dtaGridView.DataSource = this.dt;
                    this.dtaGridView.MultiSelect = false;
                    this.dtaGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//para darle doble click
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                this.empresa = SerializacionJugadores.Leer();
                this.empresa.Jugadas.Clear();
            }
            catch(ArchivosException ex)
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
                    this.LlenarFilaComprar(fila);

                }
                else//si no esta
                {
                    this.empresa += this.comprar.participante;
                    this.empresa += this.comprar.primera;
                    //agregar jugadas
                    DataRow fila = this.dt.NewRow();
                    this.LlenarFilaComprar(fila);
                    this.dt.Rows.Add(fila);
                    
                }
            }
            ///si dialog ok : veo si ese participante esta en el casino, si no esta agrego row y a casino
            ///si esta hago un apdate en ese row de mismo dni, donde sumo la varianza con el saldo, sumo las monedas compradas
            ///si compro boleto sumo boleto y resto moneda de bronce
            
        }
        private void LlenarFilaComprar(DataRow fila)///METODO DE EXTENSION INTERFAZ???
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
            }

          

        }

        private bool ConfigurarDataAdapter()
        {
            bool rta = false;

            try
            {
                string host = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True";
                this.cn = new SqlConnection(host);
                this.da = new SqlDataAdapter();

                this.da.SelectCommand = new SqlCommand("SELECT dni, saldo, variacion, transaccion FROM [datos_Jugada].[dbo].[jugadas]", cn);
                this.da.InsertCommand = new SqlCommand("INSERT INTO [datos_Jugada].[dbo].[jugadas] (dni, saldo, variacion, transaccion) VALUES (@dni, @saldo, @variacion, @transaccion)", cn);
                this.da.UpdateCommand = new SqlCommand("UPDATE [datos_Jugada].[dbo].[jugadas] SET saldo=@saldo, variacion=@variacion, transaccion=@transaccion WHERE dni=@dni", cn);
                this.da.DeleteCommand = new SqlCommand("DELETE FROM [datos_Jugada].[dbo].[jugadas] WHERE dni=@dni", cn);

                this.da.InsertCommand.Parameters.Add("@dni", SqlDbType.Int, 10, "dni");
                this.da.InsertCommand.Parameters.Add("@saldo", SqlDbType.Float, 10, "saldo");
                this.da.InsertCommand.Parameters.Add("@variacion", SqlDbType.Float, 10, "variacion");
                this.da.InsertCommand.Parameters.Add("@transaccion", SqlDbType.VarChar, 50, "transaccion");

                this.da.UpdateCommand.Parameters.Add("@saldo", SqlDbType.Float, 10, "saldo");
                this.da.UpdateCommand.Parameters.Add("@variacion", SqlDbType.Float, 10, "variacion");
                this.da.UpdateCommand.Parameters.Add("@transaccion", SqlDbType.VarChar, 50, "transaccion");
                //this.da.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

                this.da.DeleteCommand.Parameters.Add("@dni", SqlDbType.Int, 10, "dni");

                rta = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return rta;
        }


        private void DobleClick(object sender, DataGridViewCellMouseEventArgs e)
        {      
            int i = this.dtaGridView.SelectedRows[0].Index;
            DataRow fila = this.dt.Rows[i];
            string dni=fila[0].ToString();
            Jugador buscado=Extension.BuscarJugador(this.empresa, dni);
            
            MessageBox.Show(buscado.ToString());//traer un id de esa fila y recorrer casino lista de jugadores y sacar la cantidad de monedas de ahi.
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

            
            
        }
    }
}
