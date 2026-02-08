using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using Concretec.Pedidos.Utils;
using Concretec.Pedidos.BE;
using System.Configuration;
using System.IO;
using System.Data;

namespace Concretec.Pedidos.BC
{
    public class Catalogos:ICatalogos
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new Concretec.Pedidos.Utils.BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.5";
        readonly string Servicio = "BC Catalogos.cs";
        string Metodo = string.Empty;


        private string ConnectionString
        {
            get
            { return ConfigurationManager.AppSettings["conexion"].ToString(); }
        }

        public string BuscaUsuario(string Filtro, int IdPerfil, int IdCiudad)
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

        public bool InsertaUsuario(Guid IDUsuario, string username, string password, string nombre, string APaterno, string AMaterno, string Correo, int IDCiudad, int IDPerfil, int IDPlanta)
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

        public string TipoViaje()
        {

            Metodo = "TipoViaje";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerTipoViaje", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@Desde", Fecha1);
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
                //conexion.Close();
                conexion.Dispose(); //works great 
            }
            catch (Exception ex)
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public string MotivosCambio()
        {
            Metodo = "MotivosCambio";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerMotivosCambio", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@Desde", Fecha1);
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

        public bool InsertaContingencia(int idContingencia, string nombre, int estatus)
        {
            Metodo = "InsertaContingencia";
            SqlConnection conexion;
            bool salida = false;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlParameter param = new SqlParameter();
            SqlCommand command = new SqlCommand("InsertaContingencia", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdContintencia", idContingencia);
            command.Parameters.AddWithValue("@Descripcion", nombre);
            command.Parameters.AddWithValue("@Estatus", estatus);


            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                conexion.Close();
                conexion.Dispose();
                command.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;

        }

        public bool ActualizaParametro(int IDParametro, string Valor, string Descripcion)
        {
            Metodo = "ActualizaParametro";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ActualizarParametro", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDParametro", IDParametro);
            command.Parameters.AddWithValue("@Valor", Valor);
            command.Parameters.AddWithValue("@Descripcion", Descripcion);
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
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
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
        public string ObtenerCiudades()
        {
            Metodo = "ObtenerCiudades";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerCiudades", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = null;
            string salida = string.Empty;

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
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            finally
            {
                if ((dr != null) && (!dr.IsClosed)) { dr.Close(); }
                if (command != null) { command.Dispose(); }
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                if (conexion != null) { conexion.Dispose(); }

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

        public string LeerEstatusViaje()
        {
            Metodo = "LeerTipoViajes";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerEstatusViaje", conexion);
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

        public string LeerUsos()
        {
            Metodo = "LeerUsos";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerUsos", conexion);
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

        public List<Categoria> LeerCatalogos(int TipoCatalogo)
        {
            Metodo = "ListaComentarios";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerCatalogos", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CATALOGOID", TipoCatalogo);
            List<Categoria> salida = new List<Categoria>();
            Categoria elemento = new Categoria();
            SqlDataReader dr = null;

            try
            {
                conexion.Open();
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new Categoria();

                        elemento.IdCategoria = int.Parse(dr["Clave"].ToString());
                        elemento.Descripcion = dr["Descripcion"].ToString();

                        salida.Add(elemento);
                    }
                }

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
                if (conexion != null) { conexion.Dispose(); }
            }

            return salida;
        }

        public string ListaComentarios(int IDTipocomentario)
        {
            Metodo = "ListaComentarios";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerListaComentarios", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDTipocomentario", IDTipocomentario);

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
