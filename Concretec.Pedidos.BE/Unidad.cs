using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class Unidad
    {
        public int IDUnidad
        { set; get; }

        public string IDClave
        { set; get; }

        public string CvePlanta
        { set; get; }

        public bool Borrado
        { set; get; }

        public int Orden
        { set; get; }

        public int IDPlanta
        { set; get; }
    }
}
