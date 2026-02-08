using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class UnidadAseguradoraDetalle
    {
        public int IDUnidad
        { set; get; }

        public int IDAseguradora
        { set; get; }

        public string Poliza
        { set; get; }

        public string Inciso
        { set; get; }

        public DateTime IncisoVigencia
        { set; get; }

        public DateTime FinVigencia
        { set; get; }
    }
}
