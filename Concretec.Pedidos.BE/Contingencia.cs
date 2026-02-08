using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class Contingencia
    {

        public int idContingencia { set; get; }

        public string Descripcion { set; get; }

        public int Activo { set; get; }

        public DateTime fechaultimamodificacion { set; get; }

        public int IdCategoriaObservaciones { set; get; }

        public string DescripcionCategoriaObservaciones { set; get; }
    }
}
