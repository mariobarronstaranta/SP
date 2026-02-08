using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class PlaneacionUnidadPlantaDetalle
    {
        public int PlaneacionUnidadDetalleId { get; set; }
        public int PlaneacionId { get; set; }
        public int UnidadId { get; set; }
        public int EstatusUnidadId { get; set; }
        public int MotivoInactivoUnidad { get; set; }
        public int PlantaOrigenId { get; set; }
        public int OperadorIdAsignado { get; set; }
        public int OperadorIdOriginal { get; set; }
        public int EstatusId { get; set; }
        public int MotivoInactivoOperador { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int UsuarioIdRegistro { get; set; }
        public int UsuarioIdActualizacion { get; set; }
    }
}
