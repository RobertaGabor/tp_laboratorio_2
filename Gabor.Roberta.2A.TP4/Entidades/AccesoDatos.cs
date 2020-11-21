using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public class AccesoDatos
    {
     

        private SqlConnection cn;
        private SqlCommand comando;

     

        public AccesoDatos()
        {
            string host = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True";
            this.cn = new SqlConnection(host);
        }


 
        public bool InsertarJugada(Jugada p)
        {
            bool todoOk = false;

            string sql = "INSERT INTO [datos_Jugada].[dbo].[jugadas] (dni, saldo, variacion, transaccion) ";
            sql += "VALUES (@dni, @saldo,@variacion , @transaccion)";

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;

                this.comando.Connection = this.cn;

                this.comando.Parameters.AddWithValue("@dni", p.Victima.DNI);
                this.comando.Parameters.AddWithValue("@saldo", p.Victima.Saldo);
                this.comando.Parameters.AddWithValue("@variacion", p.Varianza);
                this.comando.Parameters.AddWithValue("@transaccion", p.Movimiento.ToString());
                this.comando.CommandText = sql;

                this.cn.Open();

                this.comando.ExecuteNonQuery();

                todoOk = true;
            }
            catch (Exception)
            {
                todoOk = false;
            }
            finally
            {
                if (this.cn.State == ConnectionState.Open)
                {
                    this.cn.Close();
                }
            }

            return todoOk;
        }

        public bool ModificarJuego(Jugada p)
        {
            bool todoOk = false;

            string sql = "UPDATE [datos_Jugada].[dbo].[jugadas] SET saldo = @saldo, variacion = @variacion, ";
            sql += "transaccion = @transaccion WHERE dni = @dni";

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;

                this.comando.Connection = this.cn;

                this.comando.Parameters.AddWithValue("@dni", p.Victima.DNI);
                this.comando.Parameters.AddWithValue("@saldo", p.Victima.Saldo);
                this.comando.Parameters.AddWithValue("@variacion", p.Varianza);
                this.comando.Parameters.AddWithValue("@transaccion", p.Movimiento.ToString());

                this.comando.CommandText = sql;

                this.cn.Open();

                this.comando.ExecuteNonQuery();

                todoOk = true;
            }
            catch (Exception)
            {
                todoOk = false;
            }
            finally
            {
                if (this.cn.State == ConnectionState.Open)
                {
                    this.cn.Close();
                }
            }

            return todoOk;
        } 

    }
}
