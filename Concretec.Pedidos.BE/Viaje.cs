using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    [Serializable]
    public class Viaje
    {
        public int IDPedido { set; get; }
        public int IDViaje { set; get; }
        public int IDPlanta { set; get; }
        public string CvePlanta { set; get; }

        public int IDTipoViaje { set; get; }
        public int IDUnidad { set; get; }
        public int IDMotivoCambio { set; get; }
        public int IDEstatusViaje { set; get; }
        public float CargaViaje { set; get; }
        public DateTime? FechaInicio { set; get; }

        public string HoraInicio { set; get; } // Tambien aplica Hora Salida 
        public string HoraFin { set; get; } // // Tambien aplica Llegada Planta
        public string HoraLlegadaObra { set; get; }
        public string HoraInicioColado { set; get; }
        public string HoraFinColado { set; get; }
        public string HoraSalidaObra { set; get; }

        public int IDOperador { set; get; }
        public int NumCarga { set; get; }
        public string Remision { set; get; }
        public float Distancia { set; get; }
        public string Observaciones { set; get; }
        public string NombreOperador { set; get; }
        public string DescripcionUnidad { set; get; }
    }
}