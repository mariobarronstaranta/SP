using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class PedidoViaje
    {
        public int IDPedido { set; get; }
        public int IDPlanta { set; get; }
        public int IDUnidad { set; get; }
        public int IDOperador { set; get; }
        public string Observaciones { set; get; }
        public DateTime FechaInicio { set; get; }
        public DateTime FechaViaje { set; get; }

        public string Operador { set; get; }
        public string Remision { set; get; }
        public string TicketCB2 { set; get; }
        public string Estatus { set; get; }
        public float CargaViaje { set; get; }
        public string IDClaveUnidad { set; get; }
        public string CvePlanta { set; get; }
        public int IDViaje { set; get; }
        public int idContingencia { set; get; }
        public int idComentario { set; get; }
        public string factura { set; get; }
        public string HoraInicio { set; get; }
        public string HoraFin { set; get; }
        public string HoraLlegadaObra { set; get; }
        public string HoraInicioColado { set; get; }
        public string HoraFinColado { set; get; }
        public string HoraSalidaObra { set; get; }
        public string HoraCompromiso { set; get; }

        public DateTime dt_HoraCompromiso { set; get; }
        public DateTime dt_HoraInicio { set; get; }
        public DateTime dt_HoraFin { set; get; }
        public DateTime dt_HoraLlegadaObra { set; get; }
        public DateTime dt_HoraInicioColado { set; get; }
        public DateTime dt_HoraFinColado { set; get; }
        public DateTime dt_HoraSalidaObra { set; get; }

        public string NombreCliente { set; get; }
        public string NombreObra { set; get; }

        public string Producto { set; get; }
        public string Volumen { set; get; }

        public bool Merma { set; get; }
        public string Reasignacion { set; get; }
        public int ColadoNocturno { set; get; }

        public string RemisionStr { set; get; }

        public bool resultado { set; get; }
    }
}
