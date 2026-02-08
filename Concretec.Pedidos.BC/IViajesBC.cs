using Concretec.Pedidos.BE;
using System;
using System.Collections.Generic;
namespace Concretec.Pedidos.BC
{
    public interface IViajes
    {
        string LeerViajePedido(int IDPedido, string CveCiudad);
        string LeerViajesPedido(int IDPedido);
        string LeerTipoViajes();
        string LeerEstatusViaje();
        bool ActualizaViajeCR(int IdViaje, int IdUnidad_Destino, int IdPlanta_Destino, int IdOperador_Destino, int IdUsuario, string Hora_Inicio_Destino,
        string Hora_Fin_Destino);
        List<PedidoViaje> LeerCierreViajesPedido(int IDPedido);
        string EditarCierreViajesPedido(int IDPedido, int IDViaje);

        bool ActualizaViajeCierrePedido(

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
            );

        List<ViajeDetalle> RptConsumosDetalle(DateTime desde, DateTime hasta, string cveciudad, string idplanta);
        string LeerViajesComision(int idCiudad, string idTipoPersonal, int idUnidad,int idviajecomision);
        string CalculaNumRemision(int IDPedido, int IDViaje);
        bool AgregaComisionViaje(string accion, int idComisionViaje, int idCiudad, int Inicio, int Fin, string idTipoPersonal, int idUnidad, decimal Comision, int idUsuario);
        bool EliminaViaje(int IDPedido, int IDViaje, int IDUsuario);
        bool LimpiarViajesPedido(int IDPedido);
        bool BuscaViaje(int IDViaje, int IDPlanta, int IDUnidad, DateTime FechaInicio, string HoraInicio);
        bool ValidaDosificadora(DateTime FechaCompromiso, DateTime FechaHoraInicio, int IDPlanta, int Viajes);
        bool InsertaViaje(
            int IDPedido, int IDPlanta, int IDTipoViaje, int IDUnidad, int IDMotivoCambio, int IDEstatusViaje,
            float CargaViaje, DateTime? FechaInicio, string HoraInicio, string HoraFin, int IDOperador, int NumCarga,
            string Remision, float Distancia, string Observaciones);
        string BuscaViajesUnidad(int IdUnidad, string cveciudad, DateTime? Desde);
    }
}
