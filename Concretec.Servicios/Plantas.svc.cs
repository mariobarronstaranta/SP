using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel.Activation;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Concretec.Pedidos.Utils;

namespace Concretec.Servicios
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Plantas" in code, svc and config file together.
    public class Plantas : IPlantas
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        string Aplicacion = "Programacion de Pedidos V 2.0";
        string Servicio = "Plantas.svc";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return ConfigurationManager.ConnectionStrings["cnConcretec"].ConnectionString; }
        }

        public string ConsultaPlanta(int IdPlanta)
        {
            Metodo = "ConsultaPlanta";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ConsultaPlanta", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPlanta", IdPlanta);

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

        public string LeerPlantasObras(string CveCiudad)
        {
            Metodo = "LeerPlantasObras";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerPlantasObras", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
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
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;

        }

        public string ObtenerPlantasCiudad(string CveCiudad)
        {
            Metodo = "ObtenerPlantasCiudad";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerPlantasCiudad", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
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
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;

        }

        public string ObtenerPlantasBombeo()
        {
            Metodo = "ObtenerPlantasBombeo";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerPlantasBombas", conexion);
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

        public string ObtenerPlantas()
        {
            Metodo = "ObtenerPlantas";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerPlantas", conexion);
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

        public string ObtenerPlantasFiltro(string Nombre, string CveDosificadora,string CveCiudad)
        {
            Metodo = "ObtenerPlantasFiltro";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerPlantasfiltro", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Nombre", Nombre);
            command.Parameters.AddWithValue("@CveDosificadora", CveDosificadora);
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
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public bool InsertarPlanta(int IDPlanta, string Nombre, string CveDosificadora, bool Estatus, string Telefono, string Telefono2, string IDCiudad, string Calle, string NumInt, string NumExt, int Accion, string Colonia, string Municipio, int IDJefePlanta, string CvePlanta, int IDPlantaAlterna1, int IDPlantaAlterna2)
        {
            Metodo = "InsertarPlanta";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("INSERTARPLANTAS", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            command.Parameters.AddWithValue("@Nombre", Nombre);
            command.Parameters.AddWithValue("@CveDosificadora", CveDosificadora);
            command.Parameters.AddWithValue("@Estatus", Estatus);
            command.Parameters.AddWithValue("@Telefono", Telefono);
            command.Parameters.AddWithValue("@Telefono2", Telefono2);
            command.Parameters.AddWithValue("@IDCiudad", IDCiudad);
            command.Parameters.AddWithValue("@Calle", Calle);
            command.Parameters.AddWithValue("@NumInt", NumInt);
            command.Parameters.AddWithValue("@NumExt", NumExt);
            command.Parameters.AddWithValue("@ACCION", Accion);
            command.Parameters.AddWithValue("@Colonia", Colonia);
            command.Parameters.AddWithValue("@Municipio", Municipio);
            command.Parameters.AddWithValue("@JefePlanta", IDJefePlanta);
            command.Parameters.AddWithValue("@CvePlanta", CvePlanta);
            command.Parameters.AddWithValue("@IDPlantaAlterna1", IDPlantaAlterna1);
            command.Parameters.AddWithValue("@IDPlantaAlterna2", IDPlantaAlterna2);

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
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

    }
}
