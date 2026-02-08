using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Concretec.Pedidos.Utils;
using System.ServiceModel.Activation;

namespace Concretec.Servicios
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Bitacora" in code, svc and config file together.
    public class Bitacora : IBitacora
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.0";
        readonly string Servicio = "Bitacora.svc";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return ConfigurationManager.ConnectionStrings["cnConcretec"].ConnectionString; }
        }

        public string HistorialLog(DateTime fechainicial, DateTime fechafinal)
        {
            Metodo = "HistorialLog";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerListaLog", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Desde", fechainicial);
            command.Parameters.AddWithValue("@Hasta", fechafinal);

            string salida = string.Empty;
            SqlDataReader dr = null;
            try
            {
                conexion.Open();
                dr = command.ExecuteReader();

                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
            }
            catch (Exception ex)
            {

                
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            finally
            {
                if ((dr != null) && (!dr.IsClosed)) { dr.Close(); }
                if (command != null) { command.Dispose(); }
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                if (conexion != null) {  conexion.Dispose();}
                    
            }

            return salida;
        }

        public string HistorialBitacora(int IDModulo, DateTime? fechainicial, DateTime? fechafinal)
        {
            Metodo = "HistorialBitacora";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("HISTORIABITACORA", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDModulo", IDModulo);
            command.Parameters.AddWithValue("@fechainicial", fechainicial);
            command.Parameters.AddWithValue("@fechafinal", fechafinal);

            string salida = string.Empty;

            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {

                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public string BitacoraResumen()
        {
            Metodo = "BitacoraResumen";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerBitacoraFull", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            string salida = string.Empty;

            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;

        }
    }
}
