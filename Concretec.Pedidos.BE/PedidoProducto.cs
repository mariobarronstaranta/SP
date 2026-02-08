using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class PedidoProducto
    {
        public int PedidoHeader
        { set; get; }

        public int PedidoHijo
        { set; get; }

        public string IDRemision
        { set; get; }

        public int IDPedido
        { set; get; }

        public int IDProducto
        { set; get; }

        public string NombreProducto
        { set; get; }

        public string ClaveProducto
        { set; get; }

        public float CargaTotal
        { set; get; }
    }
}
