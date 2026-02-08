using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Concretec.Pedidos.Utils;
using System.Data;
using Concretec.Pedidos.BE;

namespace Concretec.Pedidos.BC
{
    public class Usuario
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.1";
        readonly string Servicio = "BC Usuario.cs";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return ConfigurationManager.AppSettings["conexion"].ToString(); }
        }

        public List<BE.Usuario> ValidaUsuario(string usuario, string password)
        {

            Metodo = "ValidaUsuario";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ValidaUsuario", conexion);
            command.Parameters.AddWithValue("@Usuario", usuario);
            command.Parameters.AddWithValue("@Password", password);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            List<BE.Usuario> salida = new List<BE.Usuario>();
            BE.Usuario elemento = new BE.Usuario();
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new BE.Usuario();

                        elemento.IDUsuario = Guid.Parse( dr["IDUsuario"].ToString().Trim());
                        elemento.IDPerfil = int.Parse(dr["IDPerfil"].ToString().Trim());
                        elemento.UserName = dr["UserName"].ToString().Trim();
                        elemento.IDCiudad = int.Parse(dr["IDCiudad"].ToString().Trim());
                        elemento.Password = dr["Password"].ToString().Trim();
                        elemento.Nombre = dr["Nombre"].ToString().Trim();
                        elemento.Correo = dr["Correo"].ToString().Trim();
                        elemento.Ciudad = dr["Ciudad"].ToString().Trim();
                        elemento.Perfil = dr["Perfil"].ToString().Trim();
                        elemento.Estatus = bool.Parse(dr["Estatus"].ToString().Trim());
                        elemento.Id_Usuario = int.Parse(dr["Id_Usuario"].ToString().Trim());
                        elemento.IDPlanta = int.Parse(dr["IDPlanta"].ToString().Trim());

                        salida.Add(elemento);
                    }
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


        public List<BE.Usuario> BuscarProgramadorPedido(string CveCiudad, DateTime Desde, DateTime Hasta, int IdCliente)
        {

            Metodo = "ValidaUsuario";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BuscarProgramadorPedido", conexion);
            command.Parameters.AddWithValue("@Desde", Desde);
            command.Parameters.AddWithValue("@Hasta", Hasta);
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@IdCliente", IdCliente);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            List<BE.Usuario> salida = new List<BE.Usuario>();
            BE.Usuario elemento = new BE.Usuario();
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new BE.Usuario();

                        elemento.IDUsuario      = Guid.Parse(dr["IDUsuario"].ToString().Trim());
                        elemento.UserName       = dr["UserName"].ToString().Trim();
                        elemento.Ciudad         = dr["CveCiudad"].ToString().Trim();
                        elemento.Password       = dr["Password"].ToString().Trim();
                        elemento.Nombre         = dr["Nombre"].ToString().Trim();
                        elemento.Correo         = dr["Correo"].ToString().Trim();
                        elemento.Estatus        = bool.Parse(dr["Estatus"].ToString().Trim());
                        elemento.Id_Usuario     = int.Parse(dr["Id_Usuario"].ToString().Trim());
                        salida.Add(elemento);
                    }
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
