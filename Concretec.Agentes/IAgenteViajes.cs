using System;
using System.Collections.Generic;
using Concretec.Pedidos.BE;

namespace Concretec.Agentes
{
    public interface IAgenteViajes
    {
        bool ActualizaViajeCierrePedido(int IDPedido, int IDViaje, int IDPlanta, int IDUnidad, int IDOperador, float CargaViaje, DateTime FechaViaje, string HoraInicio, string HoraFin, string HoraLlegadaObra, string HoraSalidaObra, string Observaciones, string remision, string TicketCB2, string HoraCompromiso, int idContingencia, int idComentario, string factura, bool merma, string reasignado);
        bool ActualizaViajeCR(int IdViaje, int IdUnidad_Destino, int IdPlanta_Destino, int IdOperador_Destino, int IdUsuario, string Hora_Inicio_Destino, string Hora_Fin_Destino);
        bool AgregaComisionViaje(string accion, int idComisionViaje, int idCiudad, int Inicio, int Fin, string idTipoPersonal, int idUnidad, decimal Comision, int idUsuario);
        bool BuscaViaje(int IDViaje, int IDPlanta, int IDUnidad, DateTime FechaInicio, string HoraInicio);
        List<ReasignaViajeCR> BuscaViajesUnidad(int IdUnidad, string cveciudad, DateTime? Desde);
        string CalculaNumRemision(int IDPedido, int IDViaje);
        bool EliminaViaje(int IDPedido, int IDViaje, int IDUsuario);
        bool InsertaViajes(Viaje Entidad, int NumViaje);
        List<ComisionViaje> LeerViajesComision(int idCiudad, string idTipoPersonal, int idUnidad,int viajescomision);
        bool LimpiaViajesPedido(int IDPedido);
        List<ViajeDetalle> RptConsumosDetalle(DateTime desde, DateTime hasta, string cveciudad, string idplanta);
        bool ValidaDosificadora(DateTime FechaCompromiso, DateTime FechaHoraInicio, int IDPlanta, int Viajes);
    }
}