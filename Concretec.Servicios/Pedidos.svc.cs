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

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Pedidos" in code, svc and config file together.
    public class Pedidos : IPedidos
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        string Aplicacion = "Programacion de Pedidos V 2.0";
        string Servicio = "Pedidos.svc";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return ConfigurationManager.ConnectionStrings["cnConcretec"].ConnectionString; }
        }

        public bool CancelaPedido(int IDPedido, int IDUsuario)
        {
            Metodo = "CancelaPedido";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("CancelaPedido", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPedido", IDPedido);
            command.Parameters.AddWithValue("@IDUsuario", IDUsuario);

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

        public bool AutorizacionPedido(int IDPedido, float limiteCredito, float Saldo, float Solicitado, string username, int estatus)
        {
            Metodo = "AutorizacionPedido";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("InsertaAutorizacionPedido", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPedido", IDPedido);
            command.Parameters.AddWithValue("@limiteCredito", limiteCredito);
            command.Parameters.AddWithValue("@Saldo", Saldo);
            command.Parameters.AddWithValue("@Solicitado", Solicitado);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@estatus", estatus);

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


        public bool InsertaPedidoHijo(int IDPedidoheader, int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia, double CargaTotal,
            int Viajes, DateTime FechaCompromiso, string HoraCompromiso, int Estatus, string Solicito, string Recibe,
            int Desfase, string Observaciones, int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales)
        {
            Metodo = "InsertaPedidoHijo";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("InsertaPedidoHijo", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPedidoheader", IDPedidoheader);
            command.Parameters.AddWithValue("@IDUso", IDUso);
            command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            command.Parameters.AddWithValue("@IDProducto", IDProducto);
            command.Parameters.AddWithValue("@IDVendedor", IDVendedor);
            command.Parameters.AddWithValue("@Distancia", Distancia);
            command.Parameters.AddWithValue("@CargaTotal", CargaTotal);
            command.Parameters.AddWithValue("@Viajes", Viajes);
            command.Parameters.AddWithValue("@FechaCompromiso", FechaCompromiso);
            command.Parameters.AddWithValue("@HoraCompromiso", HoraCompromiso);
            command.Parameters.AddWithValue("@Estatus", Estatus);
            command.Parameters.AddWithValue("@Solicito", Solicito);
            command.Parameters.AddWithValue("@Recibe", Recibe);
            command.Parameters.AddWithValue("@Desfase", Desfase);
            command.Parameters.AddWithValue("@Observaciones", Observaciones);
            command.Parameters.AddWithValue("@IDCliente", IDCliente);
            command.Parameters.AddWithValue("@IDObra", IDObra);
            command.Parameters.AddWithValue("@Autorizo", Autorizo);
            command.Parameters.AddWithValue("@ProAdicionales", ProductosAdicionales);

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

        public bool AutorizaPedido(int IDPedido, int IDUsuario, bool Status)
        {
            Metodo = "AutorizaPedido";
            SqlConnection conexion;
            bool salida = false;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlParameter param = new SqlParameter();
            SqlCommand command = new SqlCommand("AutorizaPedido", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPedido", IDPedido);
            command.Parameters.AddWithValue("@IDUsuario", IDUsuario);
            command.Parameters.AddWithValue("@Status", Status);
            param = command.Parameters.Add(new SqlParameter("@Salida", SqlDbType.Bit));
            param.Direction = ParameterDirection.Output;

            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    param.Value = salida;

                }
                dr.Dispose();
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

        public bool InsertaContingencia( int idContingencia, string nombre,int estatus)
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

        public bool CreditoDisponible(int IDCliente, float CreditoSolicitado)
        {
            Metodo = "CreditoDisponible";
            SqlConnection conexion;
            bool salida = false;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlParameter param = new SqlParameter();
            SqlCommand command = new SqlCommand("ValidaCredito", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDCliente", IDCliente);
            command.Parameters.AddWithValue("@CreditoSolicitado", CreditoSolicitado);
            param = command.Parameters.Add(new SqlParameter("@Salida", SqlDbType.Bit));
            param.Direction = ParameterDirection.Output;

            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    param.Value = salida;

                }
                dr.Dispose();
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

        public string LeerContingencias(int idContingencia, string nombre,int Activo)
        {
            Metodo = "LeerContingencias";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerContingencias", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idContingencia", idContingencia);
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@Activo", Activo);

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
                if (conexion.State == ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public string BuscarViajesPedido(int IDPedido)
        {
            Metodo = "BuscarViajesPedido";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerViajesPedido", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPEDIDOHEADER", IDPedido);

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

        public string BuscarProductosPedidoRemision(string IDRemision, int IDPedido)
        {
            Metodo = "BuscarProductosPedidoRemision";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerProductosRemision", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDRemision", IDRemision);
            command.Parameters.AddWithValue("@IDPedido", IDPedido);

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

        public string BuscarProductosPedido(int IDPedido)
        {
            Metodo = "BuscarProductosPedido";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerProductosPedido", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPEDIDOHEADER", IDPedido);

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

        public string BuscaDatosPedido(int IDPedido, string CveCiudad)
        {
            Metodo = "BuscaDatosPedido";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerPedidoDetalle_LIGHT", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@IDPEDIDO", IDPedido);

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

        public string BuscaNumeroAutorizaciones(string CveCiudad)
        {
            Metodo = "BuscaNumeroAutorizaciones";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("RevisaAutorizaciones", conexion);
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
                if (conexion.State == ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public string BuscaAutorizaciones(string CveCiudad, int? IDPedido)
        {
            Metodo = "BuscaAutorizaciones";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BuscaAutorizaciones", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@IDPedido", IDPedido);

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


        public string InsertaPedidoconDetalle(
            int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia,
            double CargaTotal, int Viajes, DateTime FechaCompromiso, string HoraCompromiso,
            int Estatus, string Solicito, string Recibe, int Desfase, string Observaciones,
            int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales,
            int IDTipoVenta, string OrdenCompra, string Comentarios, string Contrato)
        {
            Metodo = "InsertaPedidoconDetalle";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("InsertaPedido", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDUso", IDUso);
            command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            command.Parameters.AddWithValue("@IDProducto", IDProducto);
            command.Parameters.AddWithValue("@IDVendedor", IDVendedor);
            command.Parameters.AddWithValue("@Distancia", Distancia);
            command.Parameters.AddWithValue("@CargaTotal", CargaTotal);
            command.Parameters.AddWithValue("@Viajes", Viajes);
            command.Parameters.AddWithValue("@FechaCompromiso", FechaCompromiso);
            command.Parameters.AddWithValue("@HoraCompromiso", HoraCompromiso);
            command.Parameters.AddWithValue("@Estatus", Estatus);
            command.Parameters.AddWithValue("@Solicito", Solicito);
            command.Parameters.AddWithValue("@Recibe", Recibe);
            command.Parameters.AddWithValue("@Desfase", Desfase);
            command.Parameters.AddWithValue("@Observaciones", Observaciones);
            command.Parameters.AddWithValue("@IDCliente", IDCliente);
            command.Parameters.AddWithValue("@IDObra", IDObra);
            command.Parameters.AddWithValue("@Autorizo", Autorizo);
            command.Parameters.AddWithValue("@ProAdicionales", ProductosAdicionales);
            command.Parameters.AddWithValue("@IDTipoVenta", IDTipoVenta);
            command.Parameters.AddWithValue("@OrdenCompra", OrdenCompra);
            command.Parameters.AddWithValue("@Comentarios", Comentarios);
            command.Parameters.AddWithValue("@Contrato", Contrato);

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

        public string InsertaPedido(
            int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia,
            double CargaTotal, int Viajes, DateTime FechaCompromiso, string HoraCompromiso,
            int Estatus, string Solicito, string Recibe, int Desfase, string Observaciones,
            int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales,
            int IDTipoVenta, string OrdenCompra, string Comentarios)
        {
            Metodo = "InsertaPedido";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("InsertaPedido", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDUso", IDUso);
            command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            command.Parameters.AddWithValue("@IDProducto", IDProducto);
            command.Parameters.AddWithValue("@IDVendedor", IDVendedor);
            command.Parameters.AddWithValue("@Distancia", Distancia);
            command.Parameters.AddWithValue("@CargaTotal", CargaTotal);
            command.Parameters.AddWithValue("@Viajes", Viajes);
            command.Parameters.AddWithValue("@FechaCompromiso", FechaCompromiso);
            command.Parameters.AddWithValue("@HoraCompromiso", HoraCompromiso);
            command.Parameters.AddWithValue("@Estatus", Estatus);
            command.Parameters.AddWithValue("@Solicito", Solicito);
            command.Parameters.AddWithValue("@Recibe", Recibe);
            command.Parameters.AddWithValue("@Desfase", Desfase);
            command.Parameters.AddWithValue("@Observaciones", Observaciones);
            command.Parameters.AddWithValue("@IDCliente", IDCliente);
            command.Parameters.AddWithValue("@IDObra", IDObra);
            command.Parameters.AddWithValue("@Autorizo", Autorizo);
            command.Parameters.AddWithValue("@ProAdicionales", ProductosAdicionales);
            command.Parameters.AddWithValue("@IDTipoVenta", IDTipoVenta);
            command.Parameters.AddWithValue("@OrdenCompra", OrdenCompra);
            command.Parameters.AddWithValue("@Comentarios", Comentarios);

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


        public bool ActualizaEstatusPedido(int IDPedido, int IDEstatus)
        {
            Metodo = "ActualizaEstatusPedido";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ActualizaEstatusPedido", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPedido", IDPedido);
            command.Parameters.AddWithValue("@Estatus", IDEstatus);


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

        public bool ActualizaPedidoDetalle(int IDPedidoheader, int IDPedidoHijo, int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia, double CargaTotal,
            int Viajes, DateTime FechaCompromiso, string HoraCompromiso, int Estatus, string Solicito, string Recibe,
            int Desfase, string Observaciones, int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales, int IDTipoVenta, string Comentarios, string Contrato)
        {
            Metodo = "ActualizaPedidoDetalle";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ActualizaPedido", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPedido", IDPedidoheader);
            command.Parameters.AddWithValue("@IDUso", IDUso);
            command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            command.Parameters.AddWithValue("@IDProducto", IDProducto);
            command.Parameters.AddWithValue("@IDVendedor", IDVendedor);
            command.Parameters.AddWithValue("@Distancia", Distancia);
            command.Parameters.AddWithValue("@CargaTotal", CargaTotal);
            command.Parameters.AddWithValue("@Viajes", Viajes);
            command.Parameters.AddWithValue("@FechaCompromiso", FechaCompromiso);
            command.Parameters.AddWithValue("@HoraCompromiso", HoraCompromiso);
            command.Parameters.AddWithValue("@Estatus", Estatus);
            command.Parameters.AddWithValue("@Solicito", Solicito);
            command.Parameters.AddWithValue("@Recibe", Recibe);
            command.Parameters.AddWithValue("@Desfase", Desfase);
            command.Parameters.AddWithValue("@Observaciones", Observaciones);
            command.Parameters.AddWithValue("@IDCliente", IDCliente);
            command.Parameters.AddWithValue("@IDObra", IDObra);
            command.Parameters.AddWithValue("@Autorizo", Autorizo);
            command.Parameters.AddWithValue("@ProAdicionales", ProductosAdicionales);
            command.Parameters.AddWithValue("@IDTipoVenta", IDTipoVenta);
            command.Parameters.AddWithValue("@Comentarios", Comentarios);
            command.Parameters.AddWithValue("@Contrato", Contrato);
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

        public bool ActualizaPedido(int IDPedidoheader, int IDPedidoHijo, int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia, double CargaTotal,
            int Viajes, DateTime FechaCompromiso, string HoraCompromiso, int Estatus, string Solicito, string Recibe,
            int Desfase, string Observaciones, int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales, int IDTipoVenta, string Comentarios)
        {
            Metodo = "ActualizaPedido";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ActualizaPedido", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPedido", IDPedidoheader);
            command.Parameters.AddWithValue("@IDUso", IDUso);
            command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            command.Parameters.AddWithValue("@IDProducto", IDProducto);
            command.Parameters.AddWithValue("@IDVendedor", IDVendedor);
            command.Parameters.AddWithValue("@Distancia", Distancia);
            command.Parameters.AddWithValue("@CargaTotal", CargaTotal);
            command.Parameters.AddWithValue("@Viajes", Viajes);
            command.Parameters.AddWithValue("@FechaCompromiso", FechaCompromiso);
            command.Parameters.AddWithValue("@HoraCompromiso", HoraCompromiso);
            command.Parameters.AddWithValue("@Estatus", Estatus);
            command.Parameters.AddWithValue("@Solicito", Solicito);
            command.Parameters.AddWithValue("@Recibe", Recibe);
            command.Parameters.AddWithValue("@Desfase", Desfase);
            command.Parameters.AddWithValue("@Observaciones", Observaciones);
            command.Parameters.AddWithValue("@IDCliente", IDCliente);
            command.Parameters.AddWithValue("@IDObra", IDObra);
            command.Parameters.AddWithValue("@Autorizo", Autorizo);
            command.Parameters.AddWithValue("@ProAdicionales", ProductosAdicionales);
            command.Parameters.AddWithValue("@IDTipoVenta", IDTipoVenta);
            command.Parameters.AddWithValue("@Comentarios", Comentarios);
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

        public string rpt_headerremision(string IDRemision, int IDPedido, string CveCiudad)
        {
            Metodo = "rpt_headerremision";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("rpt_header_remision", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDRemision", IDRemision);
            command.Parameters.AddWithValue("@IDPedido", IDPedido);
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
                //conexion.Close();
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


        public string rpt_headerpedido(int IDPedido, string CveCiudad)
        {
            Metodo = "rpt_headerpedido";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("rpt_headerpedido", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPedido", IDPedido);
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
                //conexion.Close();
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

        public string LeerViajes(int IDPedido, string CveCiudad)
        {
            Metodo = "LeerViajes";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerViajes", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPedido", IDPedido);
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

        public string ConsultaPedido(int IDPedidoPadre)
        {

            Metodo = "ConsultaPedido";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerPedidoDetalle", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPEDIDOHEADER", IDPedidoPadre);

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

        public string BuscaPedidoHijo(int IDPedidoPadre, string CveCiudad)
        {

            Metodo = "BuscaPedidoHijo";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerBuscaPedidoHijoFiltro", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@IDPedidoPadre", IDPedidoPadre);

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


        public string LeerComentariosRemision(string IDRemision)
        {

            Metodo = "LeerComentariosRemision";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerComentariosRemision", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdPedido", IDRemision);

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

        public string LeerComentariosPedido(int IDPedido)
        {

            Metodo = "LeerComentariosPedido";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerComentariosPedido", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdPedido", IDPedido);

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

        public string LeerPedidoProductosAdicionales(int IDPedidoPadre, int Insertados)
        {

            Metodo = "LeerPedidoProductosAdicionales";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerProductosAdicionalesPedido", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdPedido", IDPedidoPadre);
            command.Parameters.AddWithValue("@Insertados", Insertados);

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


        public string BuscaPedidoProductosAdicionales(int IDPedidoPadre, string CveCiudad)
        {

            Metodo = "BuscaPedidoProductosAdicionales";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerPedidoProductosAdicionalesFiltro", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@IDPedidoPadre", IDPedidoPadre);

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

        public string BuscaPedido(string CveCiudad, DateTime Desde, DateTime Hasta, int IDCliente, int IdPlanta, int IdEstatus)
        {

            Metodo = "BuscaPedido";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerPedidosFiltro", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@Desde", Desde);
            command.Parameters.AddWithValue("@Hasta", Hasta);
            command.Parameters.AddWithValue("@IdPlanta", IdPlanta);
            command.Parameters.AddWithValue("@IdEstatus", IdEstatus);

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
