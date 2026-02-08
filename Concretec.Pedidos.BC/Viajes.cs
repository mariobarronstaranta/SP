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
    public class Viajes : IViajes
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        string Aplicacion = "Programacion de Pedidos V 2.5";
        string Servicio = "Viajes BC.cs";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return ConfigurationManager.AppSettings["conexion"].ToString(); }
        }

        public bool ActualizaViajeCR(int IdViaje, int IdUnidad_Destino, int IdPlanta_Destino, int IdOperador_Destino, int IdUsuario, string Hora_Inicio_Destino,
            string Hora_Fin_Destino)
        {
            Metodo = "ActualizaViajeCR";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("dbo.ActualizaViajeCR", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdViaje", IdViaje);
            command.Parameters.AddWithValue("@IdUnidad_Destino", IdUnidad_Destino);
            command.Parameters.AddWithValue("@IdPlanta_Destino", IdPlanta_Destino);
            command.Parameters.AddWithValue("@IdOperador_Destino", IdOperador_Destino);
            command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            command.Parameters.AddWithValue("@Hora_Inicio_Destino", Hora_Inicio_Destino);
            command.Parameters.AddWithValue("@Hora_Fin_Destino", Hora_Fin_Destino);

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

        public bool BuscaViaje(int IDViaje, int IDPlanta, int IDUnidad, DateTime FechaInicio, string HoraInicio)
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

        public string LeerViajesComision(int idCiudad, string idTipoPersonal, int idUnidad,int idviajecomision)
        {
            Metodo = "LeerViajesComision";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("SelViajeComision", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idCiudad", idCiudad);
            command.Parameters.AddWithValue("@idTipoPerssonal", idTipoPersonal);
            command.Parameters.AddWithValue("@idUnidad", idUnidad);
            command.Parameters.AddWithValue("@idComisionVije", idviajecomision);
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

        public string LeerEstatusViaje()
        {
            Metodo = "LeerEstatusViaje";
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


        public List<ViajeDetalle> RptConsumosDetalle(DateTime desde,DateTime hasta,string cveciudad,string idplanta)
        {
            List<ViajeDetalle> result = new List<ViajeDetalle>();

            ViajeDetalle elemento = new ViajeDetalle();
            /////////////////////////////////////////////////////////////////////////

            Metodo = "RptConsumosDetalle";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("RptConsumosDetalle", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@DESDE", desde);
            command.Parameters.AddWithValue("@HASTA", hasta);
            command.Parameters.AddWithValue("@CIUDAD", cveciudad);
            command.Parameters.AddWithValue("@PLANTA", idplanta);
            string salida = string.Empty;

            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new ViajeDetalle();
                        elemento.IDViaje            = int.Parse(dr["IDViaje"].ToString());
                        elemento.IDPedido           = int.Parse(dr["IDPedido"].ToString());
                        elemento.CargaViaje         = float.Parse(dr["CargaViaje"].ToString());
                        elemento.IDPlanta           = int.Parse(dr["IDPlanta"].ToString());
                        elemento.NombrePlantaViaje  = dr["NombrePlantaViaje"].ToString();
                        elemento.IDUnidad           = int.Parse(dr["IDUnidad"].ToString());
                        elemento.NombreUnidad       = dr["NombreUnidad"].ToString();
                        elemento.IDOperador         = int.Parse(dr["IDOperador"].ToString());
                        elemento.NombreOperador     = dr["NombreOperador"].ToString();
                        elemento.IDEstatusViaje     = int.Parse(dr["IDEstatusViaje"].ToString());
                        elemento.NombreEstatus      = dr["NombreEstatus"].ToString();
                        elemento.FechaInicio        = DateTime.Parse(dr["FechaInicio"].ToString());
                        elemento.HoraInicio         = dr["HoraInicio"].ToString();
                        elemento.HoraFin            = dr["HoraFin"].ToString();
                        elemento.IDObra             = int.Parse(dr["IDObra"].ToString());
                        elemento.NombreObra         = dr["NombreObra"].ToString();
                        elemento.IDClienteSAE       = dr["IDClienteSAE"].ToString();
                        elemento.NombreCliente      = dr["NombreCliente"].ToString();
                        elemento.IDUso              = int.Parse(dr["IDUso"].ToString());
                        elemento.NombreUso          = dr["NombreUso"].ToString();
                        elemento.IDProducto         = int.Parse(dr["IDProducto"].ToString());
                        elemento.NombreProducto     = dr["NombreProducto"].ToString();
                        elemento.Remision           = dr["Remision"].ToString();
                        elemento.CveCiudad          = dr["CveCiudad"].ToString();
                        elemento.NombreVendedor     = dr["NombreVendedor"].ToString();

                        elemento.UnidadRemision     = dr["UnidadRemision"].ToString();
                        elemento.Llegada            = dr["Llegada"].ToString();
                        elemento.Salida             = dr["Salida"].ToString();
                        elemento.VolRemision        = dr["VolRemision"].ToString();


                        result.Add(elemento);
                    }
                }
                dr.Dispose();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                //if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }



            ////////////////////////////////////////////////////////////////////////

            return result;
        }

        public List<PedidoViaje> LeerCierreViajesPedido(int IDPedido)
        {
            Metodo = "LeerCierreViajesPedido";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerCierreViajesPedido", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPedido", IDPedido);
            List<PedidoViaje> salida = new List<PedidoViaje>();
            SqlDataReader dr = null;
            BE.PedidoViaje elemento = new BE.PedidoViaje();

            try
            {
                conexion.Open();
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new BE.PedidoViaje();

                        elemento.IDViaje        = int.Parse(dr["IDViaje"].ToString());
                        elemento.IDPedido       = int.Parse(dr["IDPedido"].ToString());
                        elemento.FechaViaje     = DateTime.Parse(dr["FechaViaje"].ToString());
                        elemento.HoraInicio     = dr["HoraInicio"].ToString();
                        elemento.HoraFin        = dr["HoraFin"].ToString();
                        elemento.HoraLlegadaObra    = dr["HoraLlegadaObra"].ToString();
                        elemento.HoraInicioColado   = dr["HoraInicioColado"].ToString();
                        elemento.HoraFinColado  = dr["HoraFinColado"].ToString();
                        elemento.HoraSalidaObra = dr["HoraSalidaObra"].ToString();
                        elemento.CargaViaje     = float.Parse(dr["CargaViaje"].ToString());
                        elemento.IDClaveUnidad  = dr["IDClaveUnidad"].ToString();
                        elemento.CvePlanta      = dr["CvePlanta"].ToString();
                        elemento.Remision       = dr["Remision"].ToString();
                        elemento.idComentario   = int.Parse(dr["idComentario"].ToString());
                        elemento.factura        = dr["factura"].ToString();
                        elemento.HoraCompromiso = dr["Horacompromiso"].ToString();

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
                //if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public bool ActualizaViajeCierrePedido(

            int IDPedido,
            int IDViaje,
            int IDPlanta,
            int IDUnidad,
            int IDOperador,
            float CargaViaje,
            DateTime FechaViaje,
            string HoraInicio,
            string HoraFin,
            string HoraLlegadaObra,
            string HoraSalidaObra,
            string Observaciones,
            string remision,
            string TicketCB2,
            string HoraCompromiso,
            int idContingencia,
            int idComentario,
            string factura,
            bool merma,
            string reasignado
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
            command.Parameters.AddWithValue("@IdComentario", idComentario);
            command.Parameters.AddWithValue("@factura", factura);
            //Cambios para agregar los campos de merma y reasignacion
            command.Parameters.AddWithValue("@Merma", merma);
            command.Parameters.AddWithValue("@Reasignacion", reasignado);

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
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public string BuscaViajesUnidad(int IdUnidad, string cveciudad,DateTime? Desde)
        {
            Metodo = "BuscaViajesUnidad";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BuscaViajesUnidad", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdUnidad", IdUnidad);
            command.Parameters.AddWithValue("@cveciudad", cveciudad);
            command.Parameters.AddWithValue("@Desde", Desde);

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
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }
    }
}