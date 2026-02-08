using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class PedidoHijo
    {
        public int IDPedidoPadre
        { set; get; }
        
        public int IDPedido
        { set; get; }

        public int IDUso
        { set; get; }

        public string Uso
        { set; get; }

        public int IDPlanta
        { set; get; }

        public string Planta
        { set; get; }
        
        public int IDProducto
        { set; get; }

        public string Producto
        { set; get; }

        public int IDVendedor
        { set; get; }

        public string Vendedor
        { set; get; }

        public double Distancia
        { set; get; }

        public double CargaTotal
        { set; get; }

        public int Viajes
        { set; get; }

        public DateTime FechaCompromiso
        { set; get; }

        public string HoraCompromiso
        { set; get; }

        public int Estatus
        { set; get; }

        public string Solicito
        { set; get; }

        public string Recibe
        { set; get; }

        public int Desfase
        { set; get; }

        public string Observaciones
        { set; get; }

        public int IDCliente
        { set; get; }

        public int IDObra
        { set; get; }

        public string Autorizo
        { set; get; }

        public List<Producto> ProAdicionales
        { set; get; }
    }
}
