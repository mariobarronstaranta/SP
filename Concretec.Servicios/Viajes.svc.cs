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
    
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Viajes" in code, svc and config file together.
    public class Viajes : IViajes
    {

        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        string Aplicacion = "Programacion de Pedidos V 2.0";
        string Servicio = "Viajes.svc";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return ConfigurationManager.ConnectionStrings["cnConcretec"].ConnectionString; }
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

        public string LeerTipoViajes()
        {
            Metodo = "LeerTipoViajes";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerTipoViajes", conexion);
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
        /*--------------------------------------------------------------*/

        public string EditarCierreViajesPedido(int IDPedido, int IDViaje)
        {
            Metodo = "EditarCierreViajesPedido";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("EditarCierreViajesPedido_V2", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPedido", IDPedido);
            command.Parameters.AddWithValue("@IDViaje", IDViaje);
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

        /*--------------------------------------------------------------*/

        public string LeerCierreViajesPedido(int IDPedido)
        {
            Metodo = "LeerCierreViajesPedido";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerCierreViajesPedido", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
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

        public string LeerViajesPedido(int IDPedido)
        {
            Metodo = "LeerViajesPedido II";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerViajePedido", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
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

        public string LeerViajesComision(int idCiudad,string idTipoPersonal,int idUnidad)
        {
            Metodo = "LeerViajesComision";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("SelViajeComision", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idCiudad", idCiudad);
            command.Parameters.AddWithValue("@idTipoPerssonal", idTipoPersonal);
            command.Parameters.AddWithValue("@idUnidad", idUnidad);
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

        public string LeerViajePedido(int IDPedido, string CveCiudad)
        {
            Metodo = "LeerViajePedido";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerViajePedido", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPedido", IDPedido);
            command.Parameters.AddWithValue("@IDCiudad", CveCiudad);
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

        public bool AgregaComisionViaje(string accion, int idComisionViaje, int idCiudad, int Inicio, int Fin, string idTipoPersonal, int idUnidad, decimal Comision, int idUsuario)
        {
            bool salida = false;

            Metodo = "AgregaComisionViaje";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ProcComisionViaje", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@accion", accion);
            command.Parameters.AddWithValue("@idComisionViaje", idComisionViaje);
            command.Parameters.AddWithValue("@idCiudad", idCiudad);
            command.Parameters.AddWithValue("@Inicio", Inicio);
            command.Parameters.AddWithValue("@Fin", Fin);
            command.Parameters.AddWithValue("@idTipoPerssonal", idTipoPersonal);
            command.Parameters.AddWithValue("@idUnidad", idUnidad);
            command.Parameters.AddWithValue("@Comision", Comision);
            command.Parameters.AddWithValue("@idUsuario", idUsuario);

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

        public bool EliminaViaje(int IDPedido, int IDViaje, int IDUsuario)
        {
            bool salida = false;

            Metodo = "EliminaViaje";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("CancelaViaje", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPedido", IDPedido);
            command.Parameters.AddWithValue("@IDViaje", IDViaje);
            command.Parameters.AddWithValue("@IDUsuario", IDUsuario);

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

        public string CalculaNumRemision(int IDPedido, int IDViaje)
        {
            string salida = "";
            Metodo = "CalculaNumRemision";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("CalculaNumRemision", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDViaje", IDViaje);
            command.Parameters.AddWithValue("@IDPedido", IDPedido);
            try
            {
                conexion.Open();
                string result = command.ExecuteScalar().ToString();
                salida = result;
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

        public bool BuscaViaje(int IDViaje, int IDPlanta, int IDUnidad,DateTime FechaInicio,string HoraInicio)
        {
            bool salida = true;

            Metodo = "BuscaViaje";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BuscaViaje", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDViaje", IDViaje);
            command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            command.Parameters.AddWithValue("@IDUnidad", IDUnidad);
            command.Parameters.AddWithValue("@FechaInicio", FechaInicio);
            command.Parameters.AddWithValue("@HoraInicio", HoraInicio);

            try
            {
                conexion.Open();
                string result = command.ExecuteScalar().ToString();
                if (result == "0")
                { salida = false; }
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

        public bool ValidaDosificadora(DateTime FechaCompromiso, DateTime FechaHoraInicio, int IDPlanta, int Viajes)
        {
            bool salida = false;

            Metodo = "ValidaDosificadora";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ValidaDosificadora", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@FechaCompromiso", FechaCompromiso);
            command.Parameters.AddWithValue("@FechaHoraInicio", FechaHoraInicio);
            command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            command.Parameters.AddWithValue("@Viajes", Viajes);

            try
            {
                conexion.Open();
                string result = command.ExecuteScalar().ToString();
                if (result == "0")
                { salida = true; }
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


        public bool ActualizaViajeCierrePedido(
            
            int IDPedido			, 
	        int IDViaje			    , 
	        int IDPlanta			, 
	        int IDUnidad			, 
	        int IDOperador			, 
	        float CargaViaje		, 
	        DateTime FechaViaje		, 
	        string HoraInicio		, 
	        string HoraFin			, 
	        string HoraLlegadaObra	, 
	        string HoraSalidaObra	, 
	        string Observaciones	,
            string remision         ,
            string TicketCB2        ,
            string HoraCompromiso   ,
            int idContingencia
            )
        {
            Metodo = "ActualizaViajeCierrePedido";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ActualizaViajeCierrePedido_V2", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPedido", IDPedido);
            command.Parameters.AddWithValue("@IDViaje", IDViaje);
            command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            command.Parameters.AddWithValue("@IDUnidad", IDUnidad);
            command.Parameters.AddWithValue("@IDOperador", IDOperador);
            command.Parameters.AddWithValue("@CargaViaje", CargaViaje);
            command.Parameters.AddWithValue("@FechaViaje", FechaViaje);
            command.Parameters.AddWithValue("@HoraInicio", HoraInicio);
            command.Parameters.AddWithValue("@HoraFin", HoraFin);
            command.Parameters.AddWithValue("@HoraLlegadaObra", HoraLlegadaObra);
            command.Parameters.AddWithValue("@HoraSalidaObra", HoraSalidaObra);
            command.Parameters.AddWithValue("@Observaciones", Observaciones);
            command.Parameters.AddWithValue("@remision", remision);
            command.Parameters.AddWithValue("@TicketCB2", TicketCB2);

            command.Parameters.AddWithValue("@HoraCompromiso", HoraCompromiso);
            command.Parameters.AddWithValue("@idContingencia", idContingencia);

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

        public bool LimpiarViajesPedido(int IDPedido)
        {
            Metodo = "LimpiarViajesPedido";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LimpiaViajesPedido", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPedido", IDPedido);

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


        public bool ActualizarViaje(
                int IDViaje, int IDPedido, int IDPlanta, int IDTipoViaje, int IDUnidad, int IDMotivoCambio, int IDEstatusViaje,
                float CargaViaje, string FechaInicio, string HoraInicio, string HoraFin, int IDOperador, int NumCarga,
                string Remision, float Distancia, string Observaciones)
        {
            Metodo = "ActualizarViaje";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ActualizaPedidoViajeDetalle", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDViaje", IDViaje);
            command.Parameters.AddWithValue("@IDPedido", IDPedido);
            command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            command.Parameters.AddWithValue("@IDTipoViaje", IDTipoViaje);
            command.Parameters.AddWithValue("@IDUnidad", IDUnidad);
            command.Parameters.AddWithValue("@IDMotivoCambio", IDMotivoCambio);
            command.Parameters.AddWithValue("@IDEstatusViaje", IDEstatusViaje);
            command.Parameters.AddWithValue("@CargaViaje", CargaViaje);
            command.Parameters.AddWithValue("@FechaInicio", FechaInicio);
            command.Parameters.AddWithValue("@HoraInicio", HoraInicio);
            command.Parameters.AddWithValue("@HoraFin", HoraFin);
            command.Parameters.AddWithValue("@IDOperador", IDOperador);
            command.Parameters.AddWithValue("@NumCarga", NumCarga);
            command.Parameters.AddWithValue("@Remision", Remision);
            command.Parameters.AddWithValue("@Distancia", Distancia);
            command.Parameters.AddWithValue("@Observaciones", Observaciones);

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
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }
        /*=========================================================================================================*/

        public bool LimpiarCierrePedidoViajes(int IDPedido)
        {
            Metodo = "LimpiarCierrePedidoViajes";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LimpiarCierrePedidoViajes", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPedido", IDPedido);

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
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }


        public bool ActualizarCierrePedidosViaje
        (
            int IDPedido,
            int IDPlanta,
            int IDTipoViaje,
            int IDUnidad,
            int IDMotivoCambio,
            int IDEstatusViaje,
            float CargaViaje,
            DateTime? FechaInicio,
            string HoraInicio,
            string HoraFin,
            int IDOperador,
            int NumCarga,
            string Remision,
            float Distancia,
            string Observaciones,
            string HoraLlegadaObra,
            string HoraInicioColado,
            string HoraFinColado,
            string HoraSalidaObra,
            int IDViaje
        )
        {
            Metodo = "ActualizarCierrePedidosViaje";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ActualizarCierrePedidosViaje", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDViaje", IDViaje);
            command.Parameters.AddWithValue("@IDPedido", IDPedido);
            command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            command.Parameters.AddWithValue("@IDTipoViaje", IDTipoViaje);
            command.Parameters.AddWithValue("@IDUnidad", IDUnidad);
            command.Parameters.AddWithValue("@IDMotivoCambio", IDMotivoCambio);
            command.Parameters.AddWithValue("@IDEstatusViaje", IDEstatusViaje);
            command.Parameters.AddWithValue("@CargaViaje", CargaViaje);
            command.Parameters.AddWithValue("@FechaInicio", FechaInicio);
            command.Parameters.AddWithValue("@HoraInicio", HoraInicio);
            command.Parameters.AddWithValue("@HoraFin", HoraFin);
            command.Parameters.AddWithValue("@IDOperador", IDOperador);
            command.Parameters.AddWithValue("@NumCarga", NumCarga);
            command.Parameters.AddWithValue("@Remision", Remision);
            command.Parameters.AddWithValue("@Distancia", Distancia);
            command.Parameters.AddWithValue("@Observaciones", Observaciones);
            command.Parameters.AddWithValue("@HoraLlegadaObra", HoraLlegadaObra);
            command.Parameters.AddWithValue("@HoraInicioColado", HoraInicioColado);
            command.Parameters.AddWithValue("@HoraFinColado", HoraFinColado);
            command.Parameters.AddWithValue("@HoraSalidaObra", HoraSalidaObra);

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
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }


        public bool InsertaCierrePedidoViajes
        (
            int IDPedido,
            int IDPlanta,
            int IDTipoViaje,
            int IDUnidad,
            int IDMotivoCambio,
            int IDEstatusViaje,
            float CargaViaje,
            DateTime? FechaInicio,
            string HoraInicio,
            string HoraFin,
            int IDOperador,
            int NumCarga,
            string Remision,
            float Distancia,
            string Observaciones,
            string HoraLlegadaObra,
            string HoraInicioColado,
            string HoraFinColado,
            string HoraSalidaObra
        )
        {
            Metodo = "InsertaCierrePedidoViajes";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("dbo.InsertaCierrePedidoViajes", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPedido", IDPedido);
            command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            command.Parameters.AddWithValue("@IDTipoViaje", IDTipoViaje);
            command.Parameters.AddWithValue("@IDUnidad", IDUnidad);
            command.Parameters.AddWithValue("@IDMotivoCambio", IDMotivoCambio);
            command.Parameters.AddWithValue("@IDEstatusViaje", IDEstatusViaje);
            command.Parameters.AddWithValue("@CargaViaje", CargaViaje);
            command.Parameters.AddWithValue("@FechaInicio", FechaInicio);
            command.Parameters.AddWithValue("@HoraInicio", HoraInicio);
            command.Parameters.AddWithValue("@HoraFin", HoraFin);
            command.Parameters.AddWithValue("@IDOperador", IDOperador);
            command.Parameters.AddWithValue("@NumCarga", NumCarga);
            command.Parameters.AddWithValue("@Remision", Remision);
            command.Parameters.AddWithValue("@Distancia", Distancia);
            command.Parameters.AddWithValue("@Observaciones", Observaciones);
            command.Parameters.AddWithValue("@HoraLlegadaObra", HoraLlegadaObra);
            command.Parameters.AddWithValue("@HoraInicioColado", HoraInicioColado);
            command.Parameters.AddWithValue("@HoraFinColado", HoraFinColado);
            command.Parameters.AddWithValue("@HoraSalidaObra", HoraSalidaObra);

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
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }



        /*=========================================================================================================*/
        public bool InsertaViaje(
            int IDPedido, int IDPlanta, int IDTipoViaje, int IDUnidad, int IDMotivoCambio, int IDEstatusViaje,
            float CargaViaje, DateTime? FechaInicio, string HoraInicio, string HoraFin, int IDOperador, int NumCarga,
            string Remision, float Distancia, string Observaciones)
        {
            Metodo = "InsertaViaje";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("dbo.InsertaViajes", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPedido", IDPedido);
            command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            command.Parameters.AddWithValue("@IDTipoViaje", IDTipoViaje);
            command.Parameters.AddWithValue("@IDUnidad", IDUnidad);
            command.Parameters.AddWithValue("@IDMotivoCambio", IDMotivoCambio);
            command.Parameters.AddWithValue("@IDEstatusViaje", IDEstatusViaje);
            command.Parameters.AddWithValue("@CargaViaje", CargaViaje);
            command.Parameters.AddWithValue("@FechaInicio", FechaInicio);
            command.Parameters.AddWithValue("@HoraInicio", HoraInicio);
            command.Parameters.AddWithValue("@HoraFin", HoraFin);
            command.Parameters.AddWithValue("@IDOperador", IDOperador);
            command.Parameters.AddWithValue("@NumCarga", NumCarga);
            command.Parameters.AddWithValue("@Remision", Remision);
            command.Parameters.AddWithValue("@Distancia", Distancia);
            command.Parameters.AddWithValue("@Observaciones", Observaciones);


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
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

    }
}