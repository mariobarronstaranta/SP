using Concretec.Pedidos.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BC
{
    public interface IPedidos
    {
        List<PARFACT0X> BuscaRemisionesSyncPedido(int IDPedido, string remision);
        bool InsertaDetalleSyncPedidoSAE(PARFACT0X elemento);
        bool InsertaHeaderSyncPedidoSAE(List<FACT0X> valores);
        List<FACT0X> BuscaPedidoSync(int IDPedido, string cveremision);
        string BuscarProductosPedidoRemision(string IDRemision, int IDPedido);
        string BuscarProductosPedido(int IDPedido);
        string LeerPedidoProductosAdicionales(int IDPedidoPadre, int Insertados);
        string BuscarViajesPedido(int IDPedido);
        string BuscaDatosPedido(int IDPedido, string CveCiudad);
        string rpt_headerpedido(int IDPedido, string CveCiudad);
        string rpt_headerremision(string IDRemision, int IDPedido, string CveCiudad);
        string ConsultaPedido(int IDPedidoPadre);
        bool CancelaPedido(int IDPedido, int IDUsuario);
        List<Pedido> BuscaPedido(string CveCiudad, DateTime Desde, DateTime Hasta, int IDCliente, int IdPlanta, int IdEstatus);
        System.Collections.Generic.List<Concretec.Pedidos.BE.Consumo> rptconsumos(string CveCiudad, DateTime Desde, DateTime Hasta);
        string LeerContingencias(int idContingencia, string nombre, int Activo, int IdCategoriaObservaciones);
        bool InsertaContingencia(int idContingencia, string nombre, int estatus, int IdCategoriaObservaciones);
        List<Pedido> PedidosCliente(int Idcliente, string CveCiudad,DateTime desde,DateTime hasta);
        List<PedidoViaje> BuscaRemisiones(string CveCliente, int IdPedido, string Remision,DateTime desde,DateTime hasta);
        bool ActualizaFacturaRemisiones(string factura, string remisiones);
        List<PedidoViaje> BuscaRemisiones(string factura);
        bool InsertaPedidoHijo(int IDPedidoheader, int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia, double CargaTotal,
           int Viajes, DateTime FechaCompromiso, string HoraCompromiso, int Estatus, string Solicito, string Recibe,
           int Desfase, string Observaciones, int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales);

        string LeerComentariosRemision(string IDRemision);
        string LeerComentariosPedido(int IDPedido);
        string BuscaNumeroAutorizaciones(string CveCiudad);
        List<Autorizacion> BuscaAutorizaciones(string CveCiudad, int? IDPedido, int? IDEstatus, DateTime? Desde, DateTime? Hasta);
        string InsertaPedidoconDetalle(
            int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia,
            double CargaTotal, int Viajes, DateTime FechaCompromiso, string HoraCompromiso,
            int Estatus, string Solicito, string Recibe, int Desfase, string Observaciones,
            int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales,
            int IDTipoVenta, string OrdenCompra, string Comentarios, string Contrato, int idusuarioregistro,int ColadoNocturno);

        string InsertaPedido(
            int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia,
            double CargaTotal, int Viajes, DateTime FechaCompromiso, string HoraCompromiso,
            int Estatus, string Solicito, string Recibe, int Desfase, string Observaciones,
            int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales,
            int IDTipoVenta, string OrdenCompra, string Comentarios, int idusuarioregistro);

        bool ActualizaEstatusPedido(int IDPedido, int IDEstatus);
        bool AutorizacionPedido(int IDPedido, float limiteCredito, float Saldo, float Solicitado, string username, int estatus);
        bool ActualizaPedidoDetalle(int IDPedidoheader, int IDPedidoHijo, int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia, double CargaTotal,
            int Viajes, DateTime FechaCompromiso, string HoraCompromiso, int Estatus, string Solicito, string Recibe,
            int Desfase, string Observaciones, int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales, int IDTipoVenta, string Comentarios, string Contrato, int ColadoNocturno,string OrdenCompra);

        bool ActualizaPedido(int IDPedidoheader, int IDPedidoHijo, int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia, double CargaTotal,
            int Viajes, DateTime FechaCompromiso, string HoraCompromiso, int Estatus, string Solicito, string Recibe,
            int Desfase, string Observaciones, int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales, int IDTipoVenta, string Comentarios);
        // string BuscaPedido(string CveCiudad, DateTime Desde, DateTime Hasta, int IDCliente, int IdPlanta, int IdEstatus);
        bool EliminaPedido(int idPedido);
        bool InsertaCalendarioDepuracion(DateTime Desde, DateTime Hasta, string CveCiudad, int IdCliente, int IdUsuario);
        List<CalendarioDepuracion> BuscaCalendarioDepuracion();
        bool ActualizaCalendarioDepuracion(int idCalendario, string NuevoEstatus, int IdUsuario);
        List<Consumo> rptConsumoProgramadores(string CveCiudad, DateTime Desde, DateTime Hasta, int IdProgramador, int IdCliente);
    }
}
