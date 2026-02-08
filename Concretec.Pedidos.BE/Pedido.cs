using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class Pedido
    {
        
        public int IDPedido { set; get; }

        public int IDPedidoHijo { set; get; }

        public int IDObra { set; get; }

        public int IDCliente { set; get; }

        public string NombreObra { set; get; }

        public string NombreCliente { set; get; }

        public float Distancia { set; get; }

        public string NombrePlanta { set; get; }

        public DateTime FechaCompromiso { set; get; }

        public DateTime HoraPrometida { set; get; }

        public string HoraCompromiso { set; get; }

        public float CargaTotal { set; get; }

        public int Viajes { set; get; }

        public int Desfase { set; get; }

        public int IDUso { set; get; }

        public string NombreUso { set; get; }

        public int IDVendedor { set; get; }

        public string NombreVendedor { set; get; }

        public string Observaciones { set; get; }

        public string Solicito { set; get; }

        public string Recibe { set; get; }

        public int IDPlanta  { set; get; }

        public string DireccionCliente  { set; get; }

        public string ColoniaCliente { set; get; }

        public string CiudadCliente { set; get; }

        public string DireccionObra { set; get; }

        public string Estatus  { set; get; }

        public string CiudadObra { set; get; }

        public int IDProducto  { set; get; }

        public List<PedidoHijo> PedidosHijo { set; get; }

        public int IDTipoVenta { set; get; }

        public int IDComentario { set; get; }

        public string FechaHoraCompromiso { set; get; }

        public string NombreProducto { set; get; }

        public string Comentarios { set; get; }

        public string Contrato { set; get; }
        
        public string Factura { set; get; }

        public string CargaProgramada { set; get; }
        public string CargaViajes { set; get; }
        public string CargaRemisiones { set; get; }
        public string NombreUsuario { set; get; }
        public string FechaCreacion { set; get; }
        public int ColadoNocturno { set; get; }
        public string OrdenCompra { set; get; }
    }
}
