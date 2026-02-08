using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class LogCb2
    {
        public string Ciudad { set; get; }
        public string Planta { set; get; }
        public string NombrePC { set; get; }
        public string PlantaPC { set; get; }
        public int Exitosos { set; get; }
        public int Fallidos { set; get; }
        public string Descripcion { set; get; }
        public int Incidencias { set; get; }
        public DateTime Fecha { set; get; }
    }
}
