using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class Cheques
    {
        public int IdCheque { set; get; }

        public int IdCliente { set; get; }

        public string NombreCliente { set; get; }

        public string CveCiudad { set; get; }

        public string NombreCiudad { set; get; }

        public DateTime FechaCobro { set; get; }

        public DateTime FechaRecepcion{ set; get; }

        public DateTime FechaRegistro { set; get; }

        public int IdBanco { set; get; }

        public string NombreBanco { set; get; }

        public int IdProCheque { set; get; }

        public string NombreProtectora { set; get; }

        public decimal Monto { set; get; }

        public List<ChequeSeguimiento> Seguimientos { set; get; }

        public int IdEstatus { set; get; }

        public string NombreEstatus { set; get; }

        public int IdUsuario { set; get; }

        public string ReferenciaPro { set; get; }

        public string Observaciones { set; get; }
    }
}
