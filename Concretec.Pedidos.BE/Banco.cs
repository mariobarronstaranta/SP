using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class Banco
    {
        public int Bancoid { set; get; }
        public string CveBanco { set; get; }
        public string Nombre { set; get; }
        public string NombreCorto { set; get; }
        public bool Activo { set; get; }
    }
}
