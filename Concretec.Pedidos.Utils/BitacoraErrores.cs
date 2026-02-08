using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace Concretec.Pedidos.Utils
{
    public class BitacoraErrores
    {
        public string ObtenerNombreArchivo()
        {
            string Archivo = string.Empty;
            Archivo = ConfigurationSettings.AppSettings["archivo"].ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".txt";
            return Archivo;
        }

        private string ConnectionString
        {
            get
            { return ConfigurationSettings.AppSettings["conexion"].ToString(); }
        }

        public void InsertaBitacora(string Aplicacion, string Modulo, string Funcion, string Error)
        {

            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("InsertaPedidosErrorLog", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Fecha", DateTime.Now.ToString());
            command.Parameters.AddWithValue("@Aplicacion", Aplicacion);
            command.Parameters.AddWithValue("@Modulo", Modulo);
            command.Parameters.AddWithValue("@Funcion", Funcion);
            command.Parameters.AddWithValue("@Descripcion", Error);
            

            try
            {
                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                string str_error = ex.Message;
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
               
            }
        }

        public  void EscribirBitacora(string Aplicacion,string Modulo,string Funcion ,string Error)
        {
            string strLogMessage = string.Empty;
            string strLogFile = ObtenerNombreArchivo();
            StreamWriter swLog;

            strLogMessage = DateTime.Now.ToString() + "|" + Aplicacion + "|" + Modulo + "|" + Funcion + "|" + Error;//string.Format("{0}: {1}", DateTime.Now, MensajeError);
            
            if (!File.Exists(strLogFile))
            {
                swLog = new StreamWriter(strLogFile);
            }
            else
            {
                swLog = File.AppendText(strLogFile);
            }

            swLog.WriteLine(strLogMessage);
            //swLog.WriteLine();

            swLog.Close();

            InsertaBitacora(Aplicacion, Modulo, Funcion, Error);

        }
    }
}
