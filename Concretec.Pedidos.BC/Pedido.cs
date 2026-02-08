using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Concretec.Pedidos.Utils;
using System.Data;
using Concretec.Pedidos.BE;

namespace Concretec.Pedidos.BC
{
    public class Pedidos:IPedidos
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion      = "Programacion de Pedidos V 2.5";
        readonly string Servicio        = "BC Pedido.cs";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return ConfigurationManager.AppSettings["conexion"].ToString(); }
        }

        private string ConnectionStringSyncRemisiones
        {
            get
            { return ConfigurationManager.AppSettings["cnAzureSync"].ToString(); }
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


        public bool InsertaDetalleSyncPedidoSAE(PARFACT0X elemento)
        {
            Metodo = "InsertaDetalleSyncPedidoSAE";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionStringSyncRemisiones);


            SqlCommand command = new SqlCommand("INSERT_PARFACTC0X", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CVE_PEDI", elemento.CVE_PEDI);
            command.Parameters.AddWithValue("@NUM_PAR", elemento.NUM_PAR);
            command.Parameters.AddWithValue("@CVE_ART", elemento.CVE_ART);
            command.Parameters.AddWithValue("@CANT", elemento.CANT);
            command.Parameters.AddWithValue("@PREC", elemento.PREC);
            command.Parameters.AddWithValue("@REMISIONSP", elemento.REMISIONSP);
            
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

        public bool InsertaHeaderSyncPedidoSAE(List<FACT0X> valores)
        {
            Metodo = "InsertaHeaderSyncPedidoSAE";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionStringSyncRemisiones);

            FACT0X elemento = new FACT0X();
            elemento = valores[0];

            SqlCommand command = new SqlCommand("INSERT_FACTC0X", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CVE_CLPV", elemento.CVE_CLPV);
            command.Parameters.AddWithValue("@CVE_PEDI", elemento.CVE_PEDI);
            command.Parameters.AddWithValue("@IMP_TOT4", elemento.IMP_TOT4);
            command.Parameters.AddWithValue("@RFC", elemento.RFC);
            command.Parameters.AddWithValue("@CAN_TOT", elemento.CAN_TOT);
            command.Parameters.AddWithValue("@CVE_VEND", elemento.CVE_VEND);
            command.Parameters.AddWithValue("@DES_TOT", elemento.DES_TOT);
            command.Parameters.AddWithValue("@CONDICION", elemento.CONDICION);
            command.Parameters.AddWithValue("@DAT_ENVIO", elemento.DAT_ENVIO);
            command.Parameters.AddWithValue("@CONTADO", elemento.CONTADO);
            command.Parameters.AddWithValue("@DES_TOT_PORC", elemento.DES_TOT_PORC);
            command.Parameters.AddWithValue("@IMPORTE", elemento.IMPORTE);
            command.Parameters.AddWithValue("@CIUDAD", elemento.CVECIDUAD);
            command.Parameters.AddWithValue("@REMISION", elemento.REMISION);
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

        public bool ActualizaPedidoDetalle(int IDPedidoheader, int IDPedidoHijo, int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia, double CargaTotal,
            int Viajes, DateTime FechaCompromiso, string HoraCompromiso, int Estatus, string Solicito, string Recibe,
            int Desfase, string Observaciones, int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales, int IDTipoVenta, string Comentarios, string Contrato,int ColadoNocturno,string OrdenCompra)
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
            command.Parameters.AddWithValue("@ColadoNocturno", ColadoNocturno);
            command.Parameters.AddWithValue("@OrdenCompra", OrdenCompra);

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

        public string InsertaPedido(
            int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia,
            double CargaTotal, int Viajes, DateTime FechaCompromiso, string HoraCompromiso,
            int Estatus, string Solicito, string Recibe, int Desfase, string Observaciones,
            int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales,
            int IDTipoVenta, string OrdenCompra, string Comentarios,int idusuarioregistro)
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
            command.Parameters.AddWithValue("@IdUsuarioRegistro", idusuarioregistro);

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
            int IDTipoVenta, string OrdenCompra, string Comentarios, string Contrato, int idusuarioregistro,int ColadoNocturno)
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
            command.Parameters.AddWithValue("@IdUsuarioRegistro", idusuarioregistro);
            command.Parameters.AddWithValue("@ColadoNocturno", ColadoNocturno);
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

        public List<PARFACT0X> BuscaRemisionesSyncPedido(int IDPedido,string remision)
        {
            Metodo = "BuscaRemisionesSyncPedido";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BuscaRemisionesSyncPedido", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPedido", IDPedido);
            command.Parameters.AddWithValue("@Remision", remision);
            SqlDataReader dr = null;

            List<PARFACT0X> salida = new List<PARFACT0X>();
            PARFACT0X elemento = new PARFACT0X();
            try
            {
                conexion.Open();
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new PARFACT0X();

                        elemento.CVE_PEDI       = dr["CVE_PEDI"].ToString();
                        elemento.NUM_PAR        = dr["NUM_PAR"].ToString();
                        elemento.CVE_ART        = dr["CVE_ART"].ToString();
                        elemento.CANT           = dr["CANT"].ToString();
                        elemento.PREC           = dr["PREC"].ToString();
                        elemento.REMISIONSP     = dr["REMISIONSP"].ToString();
                        elemento.CVECIUDAD      = dr["CVECIUDAD"].ToString();

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

        public List<FACT0X> BuscaPedidoSync(int IDPedido,string cveremision)
        {
            Metodo = "BuscaPedidoSync";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BuscaPedidoSycSAE", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PedidoID", IDPedido);
            SqlDataReader dr = null;

            List<FACT0X> salida = new List<FACT0X>();
            FACT0X elemento = new FACT0X();
            try
            {
                conexion.Open();
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new FACT0X();
                        elemento.CVE_CLPV       = dr["CVE_CLPV"].ToString();
                        elemento.CVE_PEDI       = dr["CVE_PEDI"].ToString();
                        elemento.IMP_TOT4       = dr["IMP_TOT4"].ToString();
                        elemento.RFC            = dr["RFC"].ToString();
                        elemento.CAN_TOT        = dr["CAN_TOT"].ToString();
                        elemento.CVE_VEND       = dr["CVE_VEND"].ToString();
                        elemento.DES_TOT        = dr["DES_TOT"].ToString();
                        elemento.CONDICION      = dr["CONDICION"].ToString();
                        elemento.DAT_ENVIO      = dr["DAT_ENVIO"].ToString();
                        elemento.CONTADO        = dr["CONTADO"].ToString();
                        elemento.DES_TOT_PORC   = dr["DES_TOT_PORC"].ToString();
                        elemento.IMPORTE        = dr["IMPORTE"].ToString();
                        elemento.CVECIDUAD      = dr["CVECIDUAD"].ToString();
                        elemento.REMISION       = dr["REMISION"].ToString();

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

        public List<Autorizacion> BuscaAutorizaciones(string CveCiudad, int? IDPedido,int? IDEstatus,DateTime? Desde,DateTime? Hasta)
        {
            Metodo = "BuscaAutorizaciones";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BuscaAutorizaciones", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@IDPedido", IDPedido);
            command.Parameters.AddWithValue("@IDEstatus", IDEstatus);
            command.Parameters.AddWithValue("@Desde", Desde);
            command.Parameters.AddWithValue("@Hasta", Hasta);
            SqlDataReader dr = null;

            List<Autorizacion> salida = new List<Autorizacion>();
            Autorizacion elemento = new Autorizacion();
            try
            {
                conexion.Open();
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento                    = new Autorizacion();
                        elemento.IDPedido           = int.Parse(dr["IDPedido"].ToString());
                        elemento.CveCliente         = dr["CveCliente"].ToString();
                        elemento.NombreCliente      = dr["NombreCliente"].ToString();
                        elemento.IDObra             = int.Parse(dr["IDObra"].ToString());
                        elemento.NombreObra         = dr["NombreObra"].ToString();
                        elemento.LimiteCredito      = float.Parse(dr["LimiteCredito"].ToString());
                        elemento.SaldoActual        = float.Parse(dr["SaldoActual"].ToString());
                        elemento.CreditoSolicitado  = float.Parse(dr["CreditoSolicitado"].ToString());
                        elemento.Estatus            = dr["Estatus"].ToString();
                        elemento.NombrePlanta       = dr["NombrePlanta"].ToString();
                        elemento.StrVolumen         = dr["StrVolumen"].ToString();
                        elemento.FechaCompromiso    = dr["FechaCompromiso"].ToString();

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

        

        public List<BE.Pedido> BuscaPedido(string CveCiudad, DateTime Desde, DateTime Hasta, int IDCliente, int IdPlanta, int IdEstatus)
        {

            Metodo = "BuscaPedido";
            BE.Pedido elemento = new BE.Pedido();
            SqlConnection conexion;
            SqlDataReader dr = null;
            List<BE.Pedido> result = new List<BE.Pedido>();
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
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new BE.Pedido();

                        elemento.IDPedido           = int.Parse(dr["IDPedido"].ToString());
                        elemento.IDCliente          = int.Parse(dr["IDCliente"].ToString());
                        elemento.NombreObra         = dr["NombreObra"].ToString();
                        elemento.NombreCliente      = dr["NombreCliente"].ToString();
                        elemento.FechaCompromiso    = DateTime.Parse(dr["FechaCompromiso"].ToString());
                        elemento.FechaHoraCompromiso = dr["FechaHoraCompromiso"].ToString();
                        elemento.Estatus            = dr["Estatus"].ToString();
                        elemento.CargaProgramada    = dr["CargaProgramada"].ToString();
                        elemento.CargaViajes        = dr["CargaViajes"].ToString();
                        elemento.CargaRemisiones    = dr["CargaRemision"].ToString();

                        result.Add(elemento);
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

            return result;
        }


        public bool ActualizaFacturaRemisiones(string factura,string remisiones)
        {
            Metodo = "ActualizaFacturaRemisiones";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ActualizaFacturaRemisiones", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@FACTURA", factura);
            command.Parameters.AddWithValue("@REMISIONES", remisiones);

            bool salida = false;

            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;
                command.Dispose();
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

        

        public List<PedidoViaje> BuscaRemisiones(string factura)
        {
            Metodo = "BuscaRemisiones";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BuscaRemisionPorFactura", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Factura", factura);

            List<PedidoViaje> salida = new List<PedidoViaje>();
            PedidoViaje elemento = new PedidoViaje();
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
                        elemento                = new PedidoViaje();
                        elemento.IDViaje        = int.Parse(dr["IdViaje"].ToString());
                        elemento.IDPedido       = int.Parse(dr["IdPedido"].ToString());
                        elemento.Remision       = dr["Remision"].ToString();
                        elemento.factura        = dr["Factura"].ToString();
                        elemento.FechaInicio = DateTime.Parse(dr["FechaPedido"].ToString());
                        elemento.NombreCliente  = dr["Cliente"].ToString();
                        elemento.NombreObra     = dr["Obra"].ToString();
                        elemento.Producto       = dr["Producto"].ToString();
                        elemento.Volumen        = dr["Volumen"].ToString();

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

        public List<PedidoViaje> BuscaRemisiones(string CveCliente,int IdPedido,string Remision,DateTime desde,DateTime hasta)
        {
            Metodo = "BuscaRemisiones";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BuscaRemisiones", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdPedido", IdPedido);
            command.Parameters.AddWithValue("@CveCliente", CveCliente);
            command.Parameters.AddWithValue("@Remision", Remision);
            command.Parameters.AddWithValue("@Desde", desde);
            command.Parameters.AddWithValue("@Hasta", hasta);

            List<PedidoViaje> salida = new List<PedidoViaje>();
            PedidoViaje elemento = new PedidoViaje();
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
                        elemento                = new PedidoViaje();
                        elemento.IDViaje        = int.Parse(dr["IdViaje"].ToString());
                        elemento.IDPedido       = int.Parse(dr["IdPedido"].ToString());
                        elemento.Remision       = dr["Remision"].ToString();
                        elemento.factura        = dr["Factura"].ToString();
                        elemento.FechaInicio    = DateTime.Parse(dr["FechaPedido"].ToString());
                        elemento.NombreCliente  = dr["Cliente"].ToString();
                        elemento.NombreObra     = dr["Obra"].ToString();
                        elemento.Producto       = dr["Producto"].ToString();
                        elemento.Volumen        = dr["Volumen"].ToString();

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

        public List<Pedido> PedidosCliente(int Idcliente, string CveCiudad,DateTime desde,DateTime hasta)
        {
            Metodo = "PedidosCliente";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BuscarPedidoCliente", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CVECIUDAD", CveCiudad);
            command.Parameters.AddWithValue("@IDCLIENTE", Idcliente);
            command.Parameters.AddWithValue("@Desde", desde);
            command.Parameters.AddWithValue("@Hasta", hasta);

            List<Pedido> salida = new List<Pedido>();
            Pedido elemento = new Pedido();
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
                        elemento                = new Pedido();
                        elemento.IDPedido       = dr.GetInt32(0) ;
                        elemento.CiudadCliente  = dr.GetString(1);
                        elemento.CiudadObra     = dr.GetString(1);
                        elemento.NombreObra     = dr.GetString(2);

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

        public List<Consumo> rptconsumos(string CveCiudad, DateTime Desde, DateTime Hasta)
        {

            Metodo = "rptconsumos";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("RptConsumos", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@Desde", Desde);
            command.Parameters.AddWithValue("@Hasta", Hasta);

            List<Consumo> salida = new List<Consumo>();
            Consumo elemento = new Consumo();
            SqlDataReader dr = null;
            command.CommandTimeout = 120;

            try
            {
                conexion.Open();
                dr = command.ExecuteReader();

                if (dr.HasRows)
                {
                    //salida = dr.GetString(0);
                    while (dr.Read())
                    {
                        elemento = new Consumo();
                        elemento.Ciudad = dr.GetString(0);
                        elemento.IdPlanta = dr.GetInt32(1);
                        elemento.Planta = dr.GetString(2);
                        elemento.Pedidos = dr.GetDecimal(3);
                        elemento.Viajes = dr.GetDecimal(4);
                        elemento.Remision = dr.GetDecimal(5);
                        elemento.NumPedidos = dr.GetInt32(6);
                        elemento.NumViajes = dr.GetInt32(7);
                        elemento.NumRemision = dr.GetInt32(8);
                        elemento.ViajeProm = dr.GetDecimal(9);
                        elemento.PedidoProm = dr.GetDecimal(10);
                        elemento.Cb2 = dr.GetDecimal(11);

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

        public string LeerContingencias(int idContingencia, string nombre, int Activo, int IdCategoriaObservaciones)
        {
            Metodo = "LeerContingencias";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerContingencias", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idContingencia", idContingencia);
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@Activo", Activo);
            command.Parameters.AddWithValue("@IdCategoriaObservaciones", IdCategoriaObservaciones);

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

        public bool InsertaContingencia(int idContingencia, string nombre, int estatus, int IdCategoriaObservaciones)
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
            command.Parameters.AddWithValue("@IdCategoriaObservaciones", IdCategoriaObservaciones);

            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                //conexion.Close();
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

        public bool EliminaPedido(int idPedido)
        {
            Metodo = "EliminaPedido";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BorraInfoPedido", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdPedido", idPedido);
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

        public bool ActualizaCalendarioDepuracion(int idCalendario, string NuevoEstatus,int IdUsuario)
        {
            Metodo = "ActualizaCalendarioDepuracion";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ActualizaCalendarioDepuracion", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdCalendarioDepuracion", idCalendario);
            command.Parameters.AddWithValue("@NewEstatus", NuevoEstatus);
            command.Parameters.AddWithValue("@IdUsuario", IdUsuario);

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

        public bool InsertaCalendarioDepuracion(DateTime Desde,DateTime Hasta,string CveCiudad,int IdCliente,int IdUsuario)
        {
            Metodo = "InsertaCalendarioDepuracion";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("InsertaCalendarioDepuracion", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Desde", Desde);
            command.Parameters.AddWithValue("@Hasta", Hasta);
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@IdCliente", IdCliente);
            command.Parameters.AddWithValue("@IdUsuario", IdUsuario);

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

        public List<CalendarioDepuracion> BuscaCalendarioDepuracion()
        {

            Metodo = "BuscaCalendarioDepuracion";
            BE.CalendarioDepuracion elemento = new BE.CalendarioDepuracion();
            SqlConnection conexion;
            SqlDataReader dr = null;
            List<BE.CalendarioDepuracion> result = new List<BE.CalendarioDepuracion>();
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BuscaCalendarioDepuracion", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            string salida = string.Empty;
            try
            {
                conexion.Open();
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new BE.CalendarioDepuracion();

                        elemento.IdCalendarioDepuracion     = int.Parse(dr["IdCalendarioDepuracion"].ToString());
                        elemento.Desde                      = DateTime.Parse(dr["Desde"].ToString());
                        elemento.Hasta                      = DateTime.Parse(dr["Hasta"].ToString());
                        elemento.CveCiudad                  = dr["CveCiudad"].ToString();
                        elemento.IdCliente                  = int.Parse(dr["IdCliente"].ToString());
                        elemento.IdUsuario                  = int.Parse(dr["IdUsuario"].ToString());
                        elemento.FechaRegistro              = DateTime.Parse(dr["FechaRegistro"].ToString());
                        elemento.Estatus                    = dr["Estatus"].ToString();
                        elemento.NombreCliente              = dr["NombreCliente"].ToString();
                        elemento.NombreUsuario              = dr["NombreUsuario"].ToString();
                        elemento.Str_Desde                  = dr["Str_Desde"].ToString();
                        elemento.Str_Hasta                  = dr["Str_Hasta"].ToString();

                        result.Add(elemento);
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

            return result;
        }


        public List<Consumo> rptConsumoProgramadores(string CveCiudad, DateTime Desde, DateTime Hasta, int IdProgramador,int IdCliente)
        {
            Metodo = "rptConsumoProgramadores";
            BE.Consumo elemento = new BE.Consumo();
            SqlConnection conexion;
            SqlDataReader dr = null;
            List<BE.Consumo> result = new List<BE.Consumo>();
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("rptProgramadores", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@Desde", Desde);
            command.Parameters.AddWithValue("@Hasta", Hasta);
            command.Parameters.AddWithValue("@IdProgramador", IdProgramador);
            command.Parameters.AddWithValue("@IdCliente", IdCliente);
            string salida = string.Empty;

            try
            {
                conexion.Open();
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new BE.Consumo();

                        elemento.Ciudad                 = dr["Ciudad"].ToString();
                        elemento.IdUsuario              = int.Parse(dr["IdUsuario"].ToString());
                        elemento.NombreProgramador      = dr["NombreProgramador"].ToString();
                        elemento.NumPedidos             = int.Parse(dr["NumPedidos"].ToString());
                        elemento.M3Pedidos              = int.Parse(dr["M3Pedidos"].ToString());
                        elemento.M3Viajes               = int.Parse(dr["M3Viajes"].ToString());
                        elemento.M3Remision             = int.Parse(dr["M3Remision"].ToString());
                        elemento.PedidoProm             = decimal.Parse(dr["PedidoProm"].ToString());
                        elemento.M3Cancelados           = int.Parse(dr["M3Cancelados"].ToString());
                        elemento.M3Autorizados          = int.Parse(dr["M3Autorizados"].ToString());
                        elemento.NumPedidoFueraHorario  = int.Parse(dr["NumPedidoFueraHorario"].ToString());

                        result.Add(elemento);
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

            return result;
        }

    }
}
