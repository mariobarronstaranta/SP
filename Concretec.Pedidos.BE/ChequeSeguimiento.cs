using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class ChequeSeguimiento
    {
        public int IdChequeSeguimiento { get; set; }
        public int IdCheque { get; set; }
        public int IdChequeEstatus { get; set; }
        public string ChequeEstatus { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaSeguimiento { get; set; }
        public DateTime FechaCobro { get; set; }
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ReferenciaPro { set; get; }
        public int IdProCheque { set; get; }
    }
}
