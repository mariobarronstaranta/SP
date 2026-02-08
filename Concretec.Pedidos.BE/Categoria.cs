using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }
    }
}
