using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Concretec.Servicios
{
    [ServiceContract]
    public interface IPedidos
    {
        [OperationContract]
        string BuscaNumeroAutorizaciones(string CveCiudad);

        [OperationContract]
        bool CancelaPedido(int IDPedido, int IDUsuario);

        [OperationContract]
        bool AutorizacionPedido(int IDPedido,float limiteCredito,float Saldo,float Solicitado,string username,int estatus);

        [OperationContract]
        string LeerComentariosPedido(int IDPedido);

        [OperationContract]
        bool ActualizaEstatusPedido(int IDPedido, int IDEstatus);

        [OperationContract]
        string ConsultaPedido(int IDPedidoPadre);

        [OperationContract]
        bool AutorizaPedido(int IDPedido, int IDUsuario, bool Autorizado);

        [OperationContract]
        string InsertaPedidoconDetalle(
            int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia,
            double CargaTotal, int Viajes, DateTime FechaCompromiso, string HoraCompromiso,
            int Estatus, string Solicito, string Recibe, int Desfase, string Observaciones,
            int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales,
            int IDTipoVenta, string OrdenCompra, string Comentarios, string Contrato);

        [OperationContract]
        string InsertaPedido(int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia, double CargaTotal,
            int Viajes, DateTime FechaCompromiso, string HoraCompromiso, int Estatus, string Solicito, string Recibe,
            int Desfase, string Observaciones, int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales,
            int IDTipoVenta, string OrdenCompra, string Comentarios);

        [OperationContract]
        bool InsertaPedidoHijo(int IDPedidoheader,int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia, double CargaTotal,
            int Viajes, DateTime FechaCompromiso, string HoraCompromiso, int Estatus, string Solicito, string Recibe,
            int Desfase, string Observaciones, int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales);

        [OperationContract]
        bool ActualizaPedidoDetalle(int IDPedidoheader, int IDPedidoHijo, int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia, double CargaTotal,
            int Viajes, DateTime FechaCompromiso, string HoraCompromiso, int Estatus, string Solicito, string Recibe,
            int Desfase, string Observaciones, int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales, int IDTipoVenta, string Comentarios,string Contrato);
   
        [OperationContract]
        bool ActualizaPedido(int IDPedidoheader, int IDPedidoHijo, int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia, double CargaTotal,
            int Viajes, DateTime FechaCompromiso, string HoraCompromiso, int Estatus, string Solicito, string Recibe,
            int Desfase, string Observaciones, int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales, int IDTipoVenta, string Comentarios);

        [OperationContract]
        string BuscaPedidoHijo(int IDPedidoPadre, string CveCiudad);

        [OperationContract]
        string BuscaAutorizaciones(string CveCiudad,int? IDPedido);

        [OperationContract]
        string LeerPedidoProductosAdicionales(int IDPedidoPadre, int Insertados);

        [OperationContract]
        string BuscaPedidoProductosAdicionales(int IDPedidoPadre, string CveCiudad);

        [OperationContract]
        string BuscaPedido(string CveCiudad, DateTime Desde, DateTime Hasta, int IDCliente, int IdPlanta, int IdEstatus);

        [OperationContract]
        string ListaComentarios(int IDTipocomentario);

        [OperationContract]
        string rpt_headerpedido(int IDPedido, string CveCiudad);

        [OperationContract]
        bool CreditoDisponible(int IDCliente, float CreditoSolicitado);

        [OperationContract]
        string TipoViaje();

        [OperationContract]
        string MotivosCambio();

        [OperationContract]
        string LeerViajes(int IDPedido, string CveCiudad);

        [OperationContract]
        string BuscaDatosPedido(int IDPedido, string CveCiudad);

        [OperationContract]
        string BuscarViajesPedido(int IDPedido);

        [OperationContract]
        string BuscarProductosPedido(int IDPedido);

        [OperationContract]
        string BuscarProductosPedidoRemision(string IDRemision, int IDPedido);

        [OperationContract]
        string rpt_headerremision(string IDRemision, int IDPedido, string CveCiudad);

        [OperationContract]
        string LeerComentariosRemision(string IDRemision);

        [OperationContract]
        string LeerContingencias(int idContingencia, string nombre,int Activo);

        [OperationContract]
       bool InsertaContingencia( int idContingencia, string nombre,int estatus);

    }
}
