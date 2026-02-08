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
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Personal" in code, svc and config file together.
    public class Personal : IPersonal
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        string Aplicacion = "Programacion de Pedidos V 2.0";
        string Servicio = "Personal.svc";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return ConfigurationManager.ConnectionStrings["cnConcretec"].ConnectionString; }
        }

        public bool ActualizaPersonal(
            string CvePersonal,
            string Nombre,
            string APaterno,
            string AMaterno,
            string Puesto,
            string TipoPersonal,
            string CveCiudad,
            int IDPlanta,
            string interno,
            string Estatus)
        {
            Metodo = "ActualizaPersonal";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ActualizaPersonal", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CvePersonal", CvePersonal);
            command.Parameters.AddWithValue("@Nombre", Nombre);
            command.Parameters.AddWithValue("@APaterno", APaterno);
            command.Parameters.AddWithValue("@AMaterno", AMaterno);
            command.Parameters.AddWithValue("@Puesto", Puesto);
            command.Parameters.AddWithValue("@TipoPersonal", TipoPersonal);
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            command.Parameters.AddWithValue("@interno", interno);
            command.Parameters.AddWithValue("@Estatus", Estatus);

            bool salida = false;

            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;
                command.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public bool InsertarPersonal(
            string CvePersonal, 
            string Nombre, 
            string APaterno, 
            string AMaterno,  
            string Puesto,
            string TipoPersonal, 
            string CveCiudad,
            int     IDPlanta,
            string interno,
            string Estatus)
        {
            Metodo = "InsertarPersonal";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("InsertarPersonal", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CvePersonal", CvePersonal);
            command.Parameters.AddWithValue("@Nombre", Nombre);
            command.Parameters.AddWithValue("@APaterno", APaterno);
            command.Parameters.AddWithValue("@AMaterno", AMaterno);
            command.Parameters.AddWithValue("@Puesto", Puesto);
            command.Parameters.AddWithValue("@TipoPersonal", TipoPersonal);
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            command.Parameters.AddWithValue("@interno", interno);
            command.Parameters.AddWithValue("@Estatus", Estatus);

            bool salida = false;

            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;
                command.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public string BuscarEmpleado(string ClavePersonal)
        {
            Metodo = "BuscarEmpleado";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BuscaPersonal", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ClavePersonal", ClavePersonal);
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
                //conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public string ObtenerChoferUnidad(int IDUnidad, string CveCiudad)
        {
            Metodo = "ObtenerChoferUnidad";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ObtenerChoferUnidad", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDUnidad", IDUnidad);
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
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
                if (conexion.State == ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public string ObtenerPersonal(string TipoPersonal, string CveCiudad)
        {
            Metodo = "ObtenerPersonal";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerPersonal", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@TipoPersonal", TipoPersonal);
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
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
                if (conexion.State == ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public string ObtenerPersonalFiltro(string Filtro, string TipoPersonal, string CveCiudad,int Planta,string Estatus)
        {
            Metodo = "ObtenerPersonalFiltro";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerPersonalFiltro", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Filtro", Filtro);
            command.Parameters.AddWithValue("@TipoPersonal", TipoPersonal);
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@Planta", Planta);
            command.Parameters.AddWithValue("@Estatus", Estatus);
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
                if (conexion.State == ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }
    }
}
