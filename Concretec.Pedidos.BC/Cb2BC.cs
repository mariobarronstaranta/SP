using Concretec.Pedidos.BE;
using Concretec.Pedidos.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BC
{
    public class Cb2BC: ICb2BC
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.5";
        readonly string Servicio = "Cb2BC.cs";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return ConfigurationManager.AppSettings["conexion"].ToString(); }
        }

        private string ConnectionStringAzure
        {
            get
            { return ConfigurationManager.AppSettings["conexionCB2Azure"].ToString(); }
        }

        private string ConnectionStringLogCB2Local
        {
            get
            { return ConfigurationManager.AppSettings["conexionCB2Local"].ToString(); }
        }

        public List<LogCb2> ConsultaConexiones(DateTime Desde)
        {
            Metodo = "ConsultaConexiones";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionStringAzure);
            SqlCommand command = new SqlCommand("LogTransmision", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@DESDE", Desde);

            List<LogCb2> salida = new List<LogCb2>();
            LogCb2 elemento = new LogCb2();
            SqlDataReader dr = null;
            command.CommandTimeout = 120;

            try
            {
                conexion.Open();
                dr = command.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new LogCb2();
                        elemento.Ciudad     = dr["Ciudad"].ToString();
                        elemento.Planta     = dr["Planta"].ToString();
                        elemento.NombrePC   = dr["NombrePC"].ToString();
                        elemento.PlantaPC   = dr["PlantaPC"].ToString();
                        elemento.Exitosos   = int.Parse(dr["Exitosos"].ToString());
                        elemento.Fallidos   = int.Parse(dr["Fallidos"].ToString());

                        salida.Add(elemento);
                    }
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

        public List<LogCb2> ConsultaErrorConexiones(DateTime Desde, string Ciudad, string Planta)
        {
            Metodo = "ConsultaErrorConexiones";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionStringAzure);
            SqlCommand command = new SqlCommand("LogErroresTransmision", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@DESDE", Desde);
            command.Parameters.AddWithValue("@CIUDAD", Ciudad);
            command.Parameters.AddWithValue("@PLANTA", Planta);

            List<LogCb2> salida = new List<LogCb2>();
            LogCb2 elemento = new LogCb2();
            SqlDataReader dr = null;
            command.CommandTimeout = 120;

            try
            {
                conexion.Open();
                dr = command.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new LogCb2();
                        elemento.Ciudad = dr["Ciudad"].ToString();
                        elemento.Planta = dr["Planta"].ToString();
                        elemento.Descripcion = dr["Descripcion"].ToString();
                        elemento.Incidencias = int.Parse(dr["Incidencias"].ToString());

                        salida.Add(elemento);
                    }
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

        public List<LogCb2> UltimaFechaDatosCb2(string Ciudad,string Planta)
        {
            Metodo = "UltimaFechaDatosCb2";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("UltimaFechaDatosCb2", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Ciudad", Ciudad);
            command.Parameters.AddWithValue("@Planta", Planta);

            List<LogCb2> salida = new List<LogCb2>();
            LogCb2 elemento = new LogCb2();
            SqlDataReader dr = null;
            command.CommandTimeout = 120;

            try
            {
                conexion.Open();
                dr = command.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new LogCb2();
                        elemento.Ciudad = dr["Ciudad"].ToString();
                        elemento.Planta = dr["Planta"].ToString();
                        elemento.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                        salida.Add(elemento);
                    }
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
                if (conexion != null) { conexion.Dispose(); }
            }

            return salida;
        }
    }

}
