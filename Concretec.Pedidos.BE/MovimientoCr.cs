using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class MovimientoCr
    {
        public int IdMovimientoCr
        { set; get; }

        public int IdUnidad
        { set; get; }

        public int IdPlantaOrigen
        { set; get; }

        public int IdPlantaDestino
        { set; get; }

        public string Inicio
        { set; get; }

        public string Fin
        { set; get; }

        public int IdUsuario
        { set; get; }

        public string FechaMovimiento
        { set; get; }

        public string PlantaOrigen
        { set; get; }

        public string PlantaDestino
        { set; get; }

        public string NombreUnidad
        { set; get; }

        public string NombreUsuario
        { set; get; }

        public string Comentario
        { set; get; }


        public int IdViaje
        { set; get; }
        public int IdPedido
        { set; get; }
        public int IdUnidadOriginal
        { set; get; }
        public int IdUnidadDestino
        { set; get; }
        public string HoraInicioOriginal
        { set; get; }
        public string HoraFinOriginal
        { set; get; }

        public string HoraInicioCambio
        { set; get; }
        public string HoraFinCambio
        { set; get; }
        public int IdOperadorOriginal
        { set; get; }
        public int IdOperadorCambio
        { set; get; }
    }
}
