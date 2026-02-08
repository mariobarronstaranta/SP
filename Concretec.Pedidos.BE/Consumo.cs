using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class Consumo
    {
        public string Ciudad { get; set; }
        public int IdPlanta { get; set; }
        public string Planta { get; set; }
        public decimal Pedidos { get; set; }
        public decimal Viajes { get; set; }
        public decimal Remision { get; set; }
        public int NumPedidos { get; set; }
        public int NumViajes { get; set; }
        public int NumRemision { get; set; }
        public decimal ViajeProm { get; set; }
        public decimal PedidoProm { get; set; }
        public decimal Cb2 { get; set; }

        //Campos necesarios para Consumos por Operador
        public int IdUsuario { get; set; }
        public string NombreProgramador { get; set; }
        public int M3Pedidos { get; set; }
        public int M3Viajes { get; set; }
        public int M3Remision { get; set; }
        public int M3Cancelados { get; set; }
        public int M3Autorizados { get; set; }
        public int NumPedidoFueraHorario { get; set; }



    }
}
