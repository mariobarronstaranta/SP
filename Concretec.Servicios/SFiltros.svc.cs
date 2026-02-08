using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Concretec.Pedidos.Utils;
using System.Data;
using System.ServiceModel.Activation;

namespace Concretec.Servicios
{
        [AspNetCompatibilityRequirements(
        RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SFiltros" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SFiltros.svc or SFiltros.svc.cs at the Solution Explorer and start debugging.
    public class SFiltros : ISFiltros
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        string Aplicacion = "Programacion de Pedidos V 2.0";
        string Servicio = "Parametros.svc";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return ConfigurationManager.ConnectionStrings["cnConcretec"].ConnectionString; }
        }

        public string LlenaCombos(string TipoCombo, string CveCiudad, string Parametro1, string Parametro2, string Parametro3)
        {
            Metodo = "llenaCombo: " + TipoCombo;
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerCombos", conexion);
            command.Parameters.AddWithValue("@TipoCombo", TipoCombo);
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@Parametro1", Parametro1);
            command.Parameters.AddWithValue("@Parametro2", Parametro2);
            command.Parameters.AddWithValue("@Parametro3", Parametro3);
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
                dr.Dispose();
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
