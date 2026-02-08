using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Concretec.Pedidos.BE;
using Concretec.Pedidos.Utils;

namespace Concretec.Agentes
{
    public class AgenteViajes : IAgenteViajes
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.5";
        string Service = "AgenteUsuarios.cs";
        string Metodo = string.Empty;

        public List<ComisionViaje> LeerViajesComision(int idCiudad, string idTipoPersonal, int idUnidad,int idcomisionviajes)
        {
            Metodo = "LeerViajesComision";
            Pedidos.BC.Viajes client = new Pedidos.BC.Viajes();
            List<ComisionViaje> obj = new List<ComisionViaje>();
            try
            {
                string xmlRespuesta = client.LeerViajesComision(idCiudad, idTipoPersonal, idUnidad, idcomisionviajes);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<ComisionViaje>));
                obj = (List<ComisionViaje>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Service, Metodo, ex.Message.ToString());
            }
            
            return obj;
        }

        public List<ViajeDetalle> RptConsumosDetalle(DateTime desde, DateTime hasta, string cveciudad, string idplanta)
        {
            List<ViajeDetalle> result = new List<ViajeDetalle>();
            Pedidos.BC.Viajes _bc = new Pedidos.BC.Viajes();
            result = _bc.RptConsumosDetalle(desde, hasta, cveciudad, idplanta);

            return result;
        }

        public string CalculaNumRemision(int IDPedido, int IDViaje)
        {
            Metodo = "CalculaNumRemision";
            Pedidos.BC.Viajes Servicio = new Pedidos.BC.Viajes();
            string salida = "";

            salida = Servicio.CalculaNumRemision(IDPedido, IDViaje);

            return salida;
        }

        public bool AgregaComisionViaje(string accion, int idComisionViaje, int idCiudad, int Inicio, int Fin, string idTipoPersonal, int idUnidad, decimal Comision, int idUsuario)
        {
            Metodo = "AgregaComisionViaje";
            Pedidos.BC.Viajes Servicio = new Pedidos.BC.Viajes();

            bool obj = false;
            try
            {
                obj = Servicio.AgregaComisionViaje(accion, idComisionViaje, idCiudad, Inicio, Fin, idTipoPersonal, idUnidad, Comision,idUsuario);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Service, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public bool EliminaViaje(int IDPedido, int IDViaje, int IDUsuario)
        {
            Metodo = "EliminaViaje";
            Pedidos.BC.Viajes Servicio = new Pedidos.BC.Viajes();

            bool obj = false;
            try
            {
                obj = Servicio.EliminaViaje(IDPedido, IDViaje, IDUsuario);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Service, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public bool LimpiaViajesPedido(int IDPedido)
        {
            Metodo = "LimpiaViajesPedido";
            Pedidos.BC.Viajes Servicio = new Pedidos.BC.Viajes();

            bool obj = false;
            try
            {
                obj = Servicio.LimpiarViajesPedido( IDPedido);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Service, Metodo, ex.Message.ToString());
            }

            return obj;
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
            Pedidos.BC.Viajes Servicio = new Pedidos.BC.Viajes();

            bool obj = false;
            try
            {
                obj = Servicio.ActualizaViajeCierrePedido(
                    IDPedido,
                    IDViaje,
                    IDPlanta,
                    IDUnidad,
                    IDOperador,
                    CargaViaje,
                    FechaViaje,
                    HoraInicio,
                    HoraFin,
                    HoraLlegadaObra,
                    HoraSalidaObra,
                    Observaciones,
                    remision,
                    TicketCB2,
                    HoraCompromiso,
                    idContingencia,
                    idComentario,
                    factura, merma, reasignado);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Service, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public bool BuscaViaje(int IDViaje, int IDPlanta, int IDUnidad, DateTime FechaInicio, string HoraInicio)
        {
            Metodo = "BuscaViaje";
            Pedidos.BC.Viajes Servicio = new Pedidos.BC.Viajes();

            bool obj = false;
            try
            {
                obj = Servicio.BuscaViaje(IDViaje, IDPlanta, IDUnidad, FechaInicio, HoraInicio);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Service, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public bool ValidaDosificadora(DateTime FechaCompromiso, DateTime FechaHoraInicio, int IDPlanta, int Viajes)
        {
            Metodo = "ValidaDosificadora";
            Pedidos.BC.Viajes Servicio = new Pedidos.BC.Viajes();

            bool obj = false;
            try
            {
                obj = Servicio.ValidaDosificadora(FechaCompromiso,FechaHoraInicio,IDPlanta,Viajes);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Service, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public bool ActualizaViajeCR(int IdViaje, int IdUnidad_Destino, int IdPlanta_Destino, int IdOperador_Destino, int IdUsuario, string Hora_Inicio_Destino,
            string Hora_Fin_Destino)
        {
            Metodo = "ActualizaViajeCR";
            Pedidos.BC.Viajes Servicio = new Pedidos.BC.Viajes();

            bool obj = false;
            try
            {
                obj = Servicio.ActualizaViajeCR( IdViaje,  IdUnidad_Destino,  IdPlanta_Destino,  IdOperador_Destino,  IdUsuario,  Hora_Inicio_Destino,Hora_Fin_Destino);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Service, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public bool InsertaViajes(Viaje Entidad,int NumViaje)
        {
            Metodo = "InsertaViajes";
            Pedidos.BC.Viajes Servicio = new Pedidos.BC.Viajes();

            Entidad.NumCarga = NumViaje;

            bool obj = false;
            try
            {
                obj = Servicio.InsertaViaje(
                    Entidad.IDPedido, 
                    Entidad.IDPlanta, 
                    Entidad.IDTipoViaje, 
                    Entidad.IDUnidad, 
                    Entidad.IDMotivoCambio, 
                    Entidad.IDEstatusViaje, 
                    Entidad.CargaViaje, 
                    Entidad.FechaInicio, 
                    Entidad.HoraInicio, 
                    Entidad.HoraFin, 
                    Entidad.IDOperador, 
                    Entidad.NumCarga, 
                    Entidad.Remision, 
                    Entidad.Distancia, 
                    Entidad.Observaciones);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Service, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<ReasignaViajeCR> BuscaViajesUnidad(int IdUnidad, string cveciudad, DateTime? Desde)
        {
            Metodo = "BuscaViajesUnidad";
            Pedidos.BC.Viajes client = new Pedidos.BC.Viajes();
            List<ReasignaViajeCR> obj = new List<ReasignaViajeCR>();
            try
            {
                string xmlRespuesta = client.BuscaViajesUnidad( IdUnidad,  cveciudad, Desde);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<ReasignaViajeCR>));
                obj = (List<ReasignaViajeCR>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Service, Metodo, ex.Message.ToString());
            }

            return obj;
        }
    }
}
