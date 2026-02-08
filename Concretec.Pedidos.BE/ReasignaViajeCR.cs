using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class ReasignaViajeCR
    {
        public int IdCROrigen
        { set; get; }

        public int IdCRDestino
        { set; get; }

        public int IdPlantaOrigen
        { set; get; }

        public int IdPlantaDestino
        { set; get; }

        public string NombreCROrigen
        { set; get; }

        public string NombreCRDestino
        { set; get; }

        public string FechaViaje
        { set; get; }

        public string HoraViaje
        { set; get; }

        public string HoraViajeFin
        { set; get; }

        public string NumPedidoViaje
        { set; get; }

        public int IdPedido
        { set; get; }

        public int IdViaje
        { set; get; }

        public float Carga
        { set; get; }

        public string ClienteObra
        { set; get; }
		
		public string ClienteNombre
        { set; get; }
		
		public string ObraNombre
        { set; get; }

        public DateTime DT_FechaViaje
        { set; get; }

    }
}
