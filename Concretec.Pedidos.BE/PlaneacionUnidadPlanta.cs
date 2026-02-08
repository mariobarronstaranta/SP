using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class PlaneacionUnidadPlanta
    {
        public int PlaneacionId { get; set; }
        public int PlantaId { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int UsuarioIdRegistro { get; set; }
        public int UsuarioIdActualizacion { get; set; }
    }
}
