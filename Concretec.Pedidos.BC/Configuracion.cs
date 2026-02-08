using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data.SqlClient;
using System.Configuration;
using Concretec.Pedidos.Utils;
using System.Data;
using Concretec.Pedidos.BE;
using System.Xml;

namespace Concretec.Pedidos.BC
{
    public class Configuracion :IConfiguracion
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.1";
        readonly string Servicio = "BC Configuracion.cs";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get

#pragma warning disable CS0618 // Type or member is obsolete
            { return ConfigurationSettings.AppSettings["conexion"].ToString(); }
#pragma warning restore CS0618 // Type or member is obsolete
        }

        public string CadenaConexionI()
        {
            Metodo = "CadenaConexionI";
            XmlDocument xDoc = new XmlDocument();
            string CS = string.Empty;
            try 
            { 
                xDoc.Load("C:\\ProgPedidos\\Configuracion.xml");
                XmlNodeList AppConfig = xDoc.GetElementsByTagName("appSettings");
                XmlNodeList lista = ((XmlElement)AppConfig[0]).GetElementsByTagName("CS");
                foreach (XmlElement nodo in lista)
                {CS = nodo.GetAttribute("value");}
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());

            }

            return CS;
        }

        public string LeerCategorias(int IdCategoria)
        {

            Metodo = "LeerCategorias";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerCategorias", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdCategoria", IdCategoria);

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

            }
            catch (Exception ex)
            {
                //if (conexion.State == ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            finally
            {
                if ((dr != null) && (!dr.IsClosed)) { dr.Close(); }
                if (command != null) { command.Dispose(); }
                //if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                if (conexion != null) { conexion.Dispose(); }

            }

            return salida;
        }

    }
}
