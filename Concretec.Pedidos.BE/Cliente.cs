using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class Cliente
    {
        public int IDCliente { set; get; }
        public int IDPlanta { set; get; }
        public string ClaveCliente { set; get; }
        public bool Activo { set; get; }
        public string NombreCompleto { set; get; }
        public string RFC { set; get; }
        public string Direccion { set; get; }
        public string CP { set; get; }
        public string Poblacion { set; get; }
        public string Colonia { set; get; }
        public string Telefonos { set; get; }
        public string Fax { set; get; }
        public string Email { set; get; }
        public string TipoPago { set; get; }
        public string AttPago { set; get; }
        public string AttCobro { set; get; }
        public string RevisionPago { set; get; }
        public float LimiteCredito { set; get; }
        public float Saldo { set; get; }
        public float CreditoDisponible { set; get; }
        public float SubTotal { set; get; }
        public string IDVendedor { set; get; }
        public string Planta { set; get; }
        public int IDEstatusAutorizacion { set; get; }
        public string EstatusAutorizacion { set; get; }
        public string Descuento { set; get; }
        public string UltimaCompra { set; get; }
        public string Estatus { set; get; }

        public float LimiteCreditoAut { set; get; }
        public float SaldoAut { set; get; }
    }
}
