using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Concretec.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IViajes" in both code and config file together.
    [ServiceContract]
    public interface IViajes
    {
        [OperationContract]
        string LeerViajesComision(int idCiudad, string idTipoPersonal, int idUnidad);

        [OperationContract]
        bool AgregaComisionViaje(string accion, int idComisionViaje, int idCiudad, int Inicio, int Fin, string idTipoPersonal, int idUnidad, decimal Comision, int idUsuario);

        [OperationContract]
        string CalculaNumRemision(int IDPedido, int IDViaje);

        [OperationContract]
        bool EliminaViaje(int IDPedido, int IDViaje, int IDUsuario);

        [OperationContract]
        bool ValidaDosificadora(DateTime FechaCompromiso, DateTime FechaHoraInicio, int IDPlanta, int Viajes);

        [OperationContract]
        bool BuscaViaje(int IDViaje, int IDPlanta, int IDUnidad, DateTime FechaInicio, string HoraInicio);

        [OperationContract]
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
           int idContingencia
           );

        [OperationContract]
        string EditarCierreViajesPedido(int IDPedido, int IDViaje);

        [OperationContract]
        string LeerEstatusViaje();

        [OperationContract]
        string LeerViajesPedido(int IDPedido);

        [OperationContract]
        bool LimpiarViajesPedido(int IDPedido);

        [OperationContract]
        string LeerViajePedido(int IDPedido, string CveCiudad);

        [OperationContract]
        string LeerCierreViajesPedido(int IDPedido);

        [OperationContract]
        bool InsertaViaje(
            int IDPedido, int IDPlanta, int IDTipoViaje, int IDUnidad, int IDMotivoCambio, int IDEstatusViaje,
            float CargaViaje, DateTime? FechaInicio, string HoraInicio, string HoraFin, int IDOperador, int NumCarga,
            string Remision, float Distancia, string Observaciones);

        [OperationContract]
        bool LimpiarCierrePedidoViajes(int IDPedido);

        [OperationContract]
        bool ActualizarCierrePedidosViaje
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
        );


        [OperationContract]
        bool InsertaCierrePedidoViajes
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
        );

        [OperationContract]
        bool ActualizarViaje(
                int IDViaje,
                int IDPedido,
                int IDPlanta,
                int IDTipoViaje,
                int IDUnidad,
                int IDMotivoCambio,
                int IDEstatusViaje,
                float CargaViaje,
                string FechaInicio,
                string HoraInicio,
                string HoraFin,
                int IDOperador,
                int NumCarga,
                string Remision,
                float Distancia,
                string Observaciones

            );

        [OperationContract]
        string LeerTipoViajes();
    }
}