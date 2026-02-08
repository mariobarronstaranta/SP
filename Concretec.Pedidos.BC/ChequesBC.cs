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
using Concretec.Pedidos.BE;

namespace Concretec.Pedidos.BC
{
    public class ChequesBC 
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        string Aplicacion = "Programacion de Pedidos V 2.5";
        string Servicio = "ChequesBC.cs";
        string Metodo = string.Empty;
        private string ConnectionString
        {
            get
            { return ConfigurationManager.AppSettings["conexion"].ToString(); }
        }


        public List<Cheques> BuscaCheques(int Clienteid, DateTime desde, DateTime hasta, int estatus)
        {
            List<Cheques> salida = new List<Cheques>();

            Metodo = "BuscaCheques";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LEERCHEQUES", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdEstatus", estatus);
            command.Parameters.AddWithValue("@IdCliente", Clienteid);
            command.Parameters.AddWithValue("@Desde", desde);
            command.Parameters.AddWithValue("@Hasta", hasta);
            SqlDataReader dr = null;
            BE.Cheques elemento = new BE.Cheques();

            try
            {
                conexion.Open();
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new BE.Cheques();

                        elemento.IdCheque           = int.Parse(dr["IdCheque"].ToString());
                        elemento.IdCliente          = int.Parse(dr["IdCliente"].ToString());
                        elemento.NombreCliente      = dr["NombreCliente"].ToString();
                        elemento.IdBanco            = int.Parse(dr["IdBanco"].ToString());
                        elemento.NombreBanco        = dr["NombreBanco"].ToString();
                        elemento.FechaCobro         = DateTime.Parse(dr["FechaCobro"].ToString());
                        elemento.IdProCheque        = int.Parse(dr["IdProCheque"].ToString());
                        elemento.NombreProtectora   = dr["NombreProtectora"].ToString();
                        elemento.NombreEstatus      = dr["NombreEstatus"].ToString();
                        elemento.Monto              = decimal.Parse(dr["Monto"].ToString());

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

        public List<Banco> LeerBancos()
        {
            List<Banco> resultado = new List<Banco>();

            Metodo = "LeerBancos";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerBancosActivos", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = null;
            BE.Banco elemento = new BE.Banco();

            try
            {
                conexion.Open();
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new BE.Banco();

                        elemento.Bancoid = int.Parse(dr["IdBanco"].ToString());
                        elemento.CveBanco = dr["Clave"].ToString();
                        elemento.Nombre = dr["NombreCompleto"].ToString();
                        elemento.NombreCorto = dr["Nombre"].ToString();

                        resultado.Add(elemento);
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


            return resultado;
        }

        public bool ActualizaCheque(Cheques cheque)
        {
            Metodo = "ActualizaCheque";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("dbo.InsertaActualizaCheque", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdCheque", cheque.IdCheque);
            command.Parameters.AddWithValue("@IdCliente", cheque.IdCliente);
            command.Parameters.AddWithValue("@IdBanco", cheque.IdBanco);
            command.Parameters.AddWithValue("@FechaCobro", cheque.FechaCobro);
            command.Parameters.AddWithValue("@Monto", cheque.Monto);
            command.Parameters.AddWithValue("@IdProCheque", cheque.IdProCheque);
            command.Parameters.AddWithValue("@Accion", 2);
            command.Parameters.AddWithValue("@CveCiudad", cheque.CveCiudad);
            command.Parameters.AddWithValue("@IdUsuario", cheque.IdUsuario);
            command.Parameters.AddWithValue("@ReferenciaPro", cheque.ReferenciaPro);
            command.Parameters.AddWithValue("@FechaRecepcion", cheque.FechaRecepcion);
            command.Parameters.AddWithValue("@Observaciones", cheque.Observaciones);

            bool salida = false;
            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;

                command.Dispose();
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

        public List<ChequeSeguimiento> LeerChequesSeguimientos(int IdCheque)
        {
            List<ChequeSeguimiento> resultado = new List<ChequeSeguimiento>();

            Metodo = "LeerChequesSeguimientos";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerChequesSeguimientos", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdCheque", IdCheque);
            SqlDataReader dr = null;
            BE.ChequeSeguimiento elemento = new BE.ChequeSeguimiento();

            try
            {
                conexion.Open();
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new BE.ChequeSeguimiento();

                        elemento.IdCheque               = int.Parse(dr["IdCheque"].ToString());
                        elemento.ChequeEstatus          = dr["ChequeEstatus"].ToString();
                        elemento.IdChequeEstatus        = int.Parse(dr["IdChequeEstatus"].ToString());
                        elemento.IdChequeSeguimiento    = int.Parse(dr["IdChequeSeguimiento"].ToString());
                        elemento.IdUsuario              = int.Parse(dr["IdUsuario"].ToString());
                        elemento.Observaciones          = dr["Observaciones"].ToString();
                        elemento.NombreUsuario          = dr["NombreUsuario"].ToString();
                        elemento.FechaSeguimiento       = DateTime.Parse(dr["FechaHoraRegistro"].ToString());

                        resultado.Add(elemento);
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

            return resultado;
        }

        public Cheques InformacionCheque(int IdCheque)
        {
            Metodo = "InformacionCheque";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerInformacionCheque", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdCheque", IdCheque);
            SqlDataReader dr = null;
            BE.Cheques elemento = new BE.Cheques();
            List<Cheques> salida = new List<Cheques>();


            try
            {
                conexion.Open();
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new BE.Cheques();

                        elemento.IdCheque           = int.Parse(dr["IdCheque"].ToString());
                        elemento.IdCliente          = int.Parse(dr["IdCliente"].ToString());
                        elemento.NombreCliente      = dr["NombreCliente"].ToString();
                        elemento.IdBanco            = int.Parse(dr["IdBanco"].ToString());
                        elemento.NombreBanco        = dr["NombreBanco"].ToString();
                        elemento.FechaCobro         = DateTime.Parse(dr["FechaCobro"].ToString());
                        elemento.IdProCheque        = int.Parse(dr["IdProCheque"].ToString());
                        elemento.NombreProtectora   = dr["NombreProtectora"].ToString();
                        elemento.Monto              = decimal.Parse(dr["Monto"].ToString());
                        elemento.CveCiudad          = dr["CveCiudad"].ToString();
                        elemento.FechaRecepcion     = DateTime.Parse(dr["FechaRecepcion"].ToString());
                        elemento.FechaRegistro      = DateTime.Parse(dr["FechaRegistro"].ToString());
                        elemento.ReferenciaPro      = dr["ReferenciaPro"].ToString();
                        elemento.Observaciones      = dr["Observaciones"].ToString();
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

            elemento = new Cheques();
            if (salida != null && salida.Count > 0)
            {
                elemento = salida[0];
                elemento.Seguimientos = LeerChequesSeguimientos(IdCheque);
            }


            return elemento;
        }

        public bool InsertaSeguimiento(Cheques cheque)
        {
            Metodo = "InsertaSeguimiento";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("InsertaSeguimiento", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdCheque", cheque.Seguimientos[0].IdCheque);
            command.Parameters.AddWithValue("@IdChequeEstatus", cheque.Seguimientos[0].IdChequeEstatus);
            command.Parameters.AddWithValue("@IdProCheque", cheque.Seguimientos[0].IdProCheque);
            command.Parameters.AddWithValue("@FechaCobro", cheque.Seguimientos[0].FechaCobro);
            command.Parameters.AddWithValue("@Observaciones", cheque.Seguimientos[0].Observaciones);
            command.Parameters.AddWithValue("@ReferenciaPro", cheque.Seguimientos[0].ReferenciaPro);
            command.Parameters.AddWithValue("@IdUsuario", cheque.Seguimientos[0].IdUsuario);     
            command.Parameters.AddWithValue("@Accion", 1);

            bool salida = false;
            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;

                command.Dispose();
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

        public bool InsertaCheque(Cheques cheque)
        {
            Metodo = "InsertaCheque";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("dbo.InsertaActualizaCheque", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdCliente", cheque.IdCliente);
            command.Parameters.AddWithValue("@IdBanco", cheque.IdBanco);
            command.Parameters.AddWithValue("@FechaCobro", cheque.FechaCobro);
            command.Parameters.AddWithValue("@Monto", cheque.Monto);
            command.Parameters.AddWithValue("@IdProCheque", cheque.IdProCheque);
            command.Parameters.AddWithValue("@Accion", 1);
            command.Parameters.AddWithValue("@CveCiudad", cheque.CveCiudad);
            command.Parameters.AddWithValue("@IdUsuario", cheque.IdUsuario);
            command.Parameters.AddWithValue("@ReferenciaPro", cheque.ReferenciaPro);
            command.Parameters.AddWithValue("@FechaRecepcion", cheque.FechaRecepcion);
            command.Parameters.AddWithValue("@Observaciones", cheque.Observaciones);

            bool salida = false;
            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;

                command.Dispose();
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

