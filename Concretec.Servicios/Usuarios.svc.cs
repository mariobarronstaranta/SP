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
    
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Usuarios" in code, svc and config file together.
    public class Usuarios : IUsuarios
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        string Aplicacion = "Programacion de Pedidos V 2.0";
        string Servicio = "Usuarios.svc";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return ConfigurationManager.ConnectionStrings["cnConcretec"].ConnectionString; }
        }


        public bool ActualizaUsuario(Guid IDUsuario, string username, string password, string nombre, string APaterno, string AMaterno, string Correo, int IDCiudad, int IDPerfil, int IDPlanta)
        {
            Metodo = "ActualizaUsuario";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("AfectaUsuario", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDUsuario", IDUsuario);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@APaterno", APaterno);
            command.Parameters.AddWithValue("@AMaterno", AMaterno);
            command.Parameters.AddWithValue("@Correo", Correo);
            command.Parameters.AddWithValue("@IDCiudad", IDCiudad);
            command.Parameters.AddWithValue("@IDPerfil", IDPerfil);
            command.Parameters.AddWithValue("@Status", true);
            command.Parameters.AddWithValue("@Accion", 2);
            command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            bool salida = false;

            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public bool InsertaUsuario(Guid IDUsuario, string username, string password, string nombre, string APaterno, string AMaterno, string Correo, int IDCiudad, int IDPerfil,int IDPlanta)
        {
            Metodo = "InsertaUsuario";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("AfectaUsuario", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDUsuario", IDUsuario);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@APaterno", APaterno);
            command.Parameters.AddWithValue("@AMaterno", AMaterno);
            command.Parameters.AddWithValue("@Correo", Correo);
            command.Parameters.AddWithValue("@IDCiudad", IDCiudad);
            command.Parameters.AddWithValue("@IDPerfil", IDPerfil);
            command.Parameters.AddWithValue("@Status", true);
            command.Parameters.AddWithValue("@Accion", 1);
            command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            bool salida = false;

            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public bool ActualizaPassword(string CveUsuario, string OldPassword, string NewPassword)
        {
            Metodo = "ActualizaPassword";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ActualizaPassword", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@OldPassword", OldPassword);
            command.Parameters.AddWithValue("@NewPassword", NewPassword);
            command.Parameters.AddWithValue("@CveUsuario", CveUsuario);
            bool salida = false;

            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }



        public string ValidaUsuario(string usuario, string password)
        {

            Metodo = "ValidaUsuario";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ValidaUsuario", conexion);
            command.Parameters.AddWithValue("@Usuario", usuario);
            command.Parameters.AddWithValue("@Password", password);
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

        public string BuscaUsuarioEdicion(int IDUsuario)
        {
            Metodo = "BuscaUsuarioEdicion";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BuscaUsuarioEdicion", conexion);
            command.Parameters.AddWithValue("@IDUsuario", IDUsuario);
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


        public string BuscaUsuario(string Filtro,int IdPerfil,int IdCiudad)
        {
            Metodo = "BuscaUsuario";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BuscaUsuario", conexion);
            command.Parameters.AddWithValue("@Filtro", Filtro);
            command.Parameters.AddWithValue("@IdPerfil", IdPerfil);
            command.Parameters.AddWithValue("@IdCiudad", IdCiudad);
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

        public string ListaPerfiles()
        {
            Metodo = "ListaPerfiles";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerPerfiles", conexion);
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

        public string ListaModulos()
        {
            Metodo = "ListaModulos";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ListaModulos", conexion);
            //command.Parameters.AddWithValue("@Filtro", Filtro);
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
