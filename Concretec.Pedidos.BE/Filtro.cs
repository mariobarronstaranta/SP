using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class Filtro
    {
        public string Id
        { set; get; }

        public string cveStatus
        { set; get; }

        public string Descripcion
        { set; get; }

        public int IdParent
        { set; get; }
    }
}
