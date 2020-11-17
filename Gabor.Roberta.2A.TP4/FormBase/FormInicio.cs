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

namespace FormBase
{
    public partial class FormPadre : Form
    {
        private SqlConnection cn;
        private SqlDataAdapter da;
        private DataTable dt;
        private Casino empresa;

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
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            
            FormComprarMonedas comprar = new FormComprarMonedas(this.empresa);
            comprar.ShowDialog();
            
        }

        private void btnAJugar_Click(object sender, EventArgs e)
        {
            FormJugar juego = new FormJugar();
            juego.ShowDialog();
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
            MessageBox.Show("hola");//traer un id de esa fila y recorrer casino lista de jugadores y sacar la cantidad de monedas de ahi.
        }
    }
}
