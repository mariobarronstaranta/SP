using System;
using System.Collections.Generic;
using Concretec.Pedidos.BE;

namespace Concretec.Agentes
{
    public interface IAgentePedidos
    {
        bool InsertaDetalleSyncPedidoSAE(PARFACT0X elemento);
        List<PARFACT0X> BuscaRemisionesSyncPedido(int IDPedido, string remision);
         bool InsertaHeaderSyncPedidoSAE(List<FACT0X> valores);
        List<FACT0X> BuscaPedidoSync(int IDPedido, string cveremision);
        bool ActualizaCalendarioDepuracion(int idCalendario, string NuevoEstatus, int IdUsuario);
        bool ActualizaEstatusPedido(int IDPedido, int IDEstatus);
        bool ActualizaPedido(int IDPedidoheader, int IDPedidoHijo, int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia, double CargaTotal, int Viajes, DateTime FechaCompromiso, string HoraCompromiso, int Estatus, string Solicito, string Recibe, int Desfase, string Observaciones, int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales, int IDTipoVenta, string Comentarios);
        bool ActualizaPedidoDetalle(int IDPedidoheader, int IDPedidoHijo, int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia, double CargaTotal, int Viajes, DateTime FechaCompromiso, string HoraCompromiso, int Estatus, string Solicito, string Recibe, int Desfase, string Observaciones, int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales, int IDTipoVenta, string Comentarios, string Contrato, int ColadoNocturno,string OrdenCompra);
        bool AutorizacionPedido(int IDPedido, float limiteCredito, float Saldo, float Solicitado, string username, int estatus);
        List<Autorizacion> BuscaAutorizaciones(string CveCiudad, int? IDPedido, int? IDEstatus, DateTime? Desde, DateTime? Hasta);
        List<CalendarioDepuracion> BuscaCalendarioDepuracion();
        Pedido BuscaDatosPedido(int IDPedido, string CveCiudad);
        List<Autorizaciones> BuscaNumeroAutorizaciones(string CveCiudad);
        List<Pedido> BuscaPedido(string CveCiudad, DateTime Desde, DateTime Hasta, int IDCliente, int IdPlanta, int IdEstatus);
        List<PedidoProducto> BuscarProductosPedido(int IDPedido);
        List<PedidoProducto> BuscarProductosRemision(string IDRemision, int IDPedido);
        List<PedidoViaje> BuscarViajesPedido(int IDPedido);
        bool CancelaPedido(int IDPedido, int IDUsuario);
        List<Pedido> ConsultaPedido(int IDPedido);
        PedidoViaje EditarCierreViajesPedido(int IDPedido, int IDViaje);
        bool EliminaPedido(int idPedido);
        bool InsertaCalendarioDepuracion(DateTime Desde, DateTime Hasta, string CveCiudad, int IdCliente, int IdUsuario);
        bool InsertaContingencia(int idContingencia, string nombre, int estatus, int IdCategoriaObservaciones);
        List<Pedido> InsertaPedido(int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia, double CargaTotal, int Viajes, DateTime FechaCompromiso, string HoraCompromiso, int Estatus, string Solicito, string Recibe, int Desfase, string Observaciones, int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales, int IDTipoVenta, string OrdenCompra, string Comentarios, int idusuarioregistro);
        List<Pedido> InsertaPedidoconDetalle(int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia, double CargaTotal, int Viajes, DateTime FechaCompromiso, string HoraCompromiso, int Estatus, string Solicito, string Recibe, int Desfase, string Observaciones, int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales, int IDTipoVenta, string OrdenCompra, string Comentarios, string Contrato, int idusuarioregistro, int ColadoNocturno);
        bool InsertaPedidoHijo(int IDPedidoheader, int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia, double CargaTotal, int Viajes, DateTime FechaCompromiso, string HoraCompromiso, int Estatus, string Solicito, string Recibe, int Desfase, string Observaciones, int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales);
        List<PedidoViaje> LeerCierreViajesPedido(int IDPedido);
        List<Comentario> LeerComentarios(int IDTipoComentario);
        List<Comentario> LeerComentariosPedido(int IDPedido);
        List<Comentario> LeerComentariosRemision(string IDRemision);
        List<Contingencia> LeerContingencias(int idContingencia, string nombre, int Activo, int IdCategoriaObservaciones);
        List<EstatusViaje> LeerEstatusViaje();
        List<Producto> LeerPedidoProductosAdicionales(int IDPedidoPadre, int Insertados);
        List<TipoViaje> LeerTipoViajes();
        List<Viaje> LeerViajes(int IDPedido, string CveCiudad);
        List<Viaje> LeerViajesPedido(int IDPedido);
        List<MotivoCambio> MotivosDeCambio();
        List<Consumo> rptConsumoProgramadores(string CveCiudad, DateTime Desde, DateTime Hasta, int IdProgramador, int IdCliente);
        List<Consumo> rptconsumos(string CveCiudad, DateTime Desde, DateTime Hasta);
        PedidoHeader rpt_headerpedido(int IDPedido, string CveCiudad);
        PedidoHeader rpt_headerremision(string IDRemision, int IDPedido, string CveCiudad);
        List<TipoViaje> TipoViaje();
    }
}