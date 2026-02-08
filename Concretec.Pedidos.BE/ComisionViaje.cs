using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class ComisionViaje
    {
        public int idComisionViaje { set; get; }
        public int idCiudad { set; get; }
        public string CveCiudad { set; get; }
        public string NombreCiudad { set; get; }
        public int Inicio { set; get; }
        public int Fin { set; get; }
        public int idUnidadtipo { set; get; }
        public string TipoUnidad { set; get; }
        public string CveTipoPersonal { set; get; }
        public string TipoPersonal { set; get; }
        public decimal Comision { set; get; }
        public DateTime FechaUltimaModificacion { set; get; }
        public int idUsuario { set; get; }
    }
}
