using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class ViajeDetalle:Viaje
    {
        public string NombrePlantaViaje { get; set; }
        public string NombreUnidad { get; set; }
        public string NombreEstatus { get; set; }
        public int IDObra { get; set; }
        public string NombreObra { get; set; }
        public string IDClienteSAE { get; set; }
        public string NombreCliente { get; set; }
        public int IDUso { get; set; }
        public string NombreUso { get; set; }
        public int IDProducto { get; set; }
        public string NombreProducto { get; set; }
        public string CveCiudad { get; set; }
        public string NombreVendedor { get; set; }

        public string UnidadRemision { get; set; }
        public string Remision { get; set; }
        public string Llegada { get; set; }
        public string Salida { get; set; }

        public string VolRemision { get; set; }

    }
}
