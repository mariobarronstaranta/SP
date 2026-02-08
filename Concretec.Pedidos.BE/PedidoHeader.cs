using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    [Serializable]
    public class PedidoHeader
    {
        public int IDPedido
        { set; get; }

        public string IDRemision
        { set; get; }

        public string FechaRemision
        { set; get; }

        public string NombrePlanta
        { set; get; }

        public string FechaCompromiso
        { set; get; }

        public string HoraPrometida
        { set; get; }

        public string NombreCliente
        { set; get; }

        public string Firma
        { set; get; }

        public string NombreObra
        { set; get; }

        public string DireccionCliente
        { set; get; }

        public string ColoniaCliente
        { set; get; }

        public string DireccionObra
        { set; get; }

        public string EntreCallesObra
        { set; get; }

        public string Telefono
        { set; get; }

        public string CPObra
        { set; get; }

        public string PoblacionObra
        { set; get; }

        public string ClaveObra
        { set; get; }

        public string Solicito
        { set; get; }

        public string ClaveCliente
        { set; get; }

        public string Autorizo
        { set; get; }

        public string Vendedor
        { set; get; }

        public string Recibe
        { set; get; }

        public string Distancia
        { set; get; }

        public string Uso
        { set; get; }

        public string Roji
        { set; get; }

        public string Hrs
        { set; get; }

        public string Colado
        { set; get; }

        public string Comentarios
        { set; get; }

        public string ClaveProducto
        { set; get; }

        public float CargaTotal
        { set; get; }

        public float MSurtido
        { set; get; }

        public float MXSurtir
        { set; get; }

        public string HoraSalida
        { set; get; }

        public string Operador
        { set; get; }

        public string JefePlanta
        { set; get; }

        public string CveUnidad
        { set; get; }

        public string Contrato
        { set; get; }

        public string OrdenCompra
        { set; get; }
    }
}
