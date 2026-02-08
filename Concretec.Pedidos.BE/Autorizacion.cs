using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class Autorizacion
    {
        public int IDAutorizacion
        { set; get; }

        public int IDPedido
        { set; get; }

        public string NombreCliente
        { set; get; }

        public int IDObra
        { set; get; }

        public string NombreObra
        { set; get; }

        public float LimiteCredito
        { set; get; }

        public float SaldoActual
        { set; get; }

        public float CreditoSolicitado
        { set; get; }

        public string Estatus
        { set; get; }

        public string NombrePlanta
        { set; get; }

        public string StrVolumen
        { set; get; }

        public string FechaCompromiso
        { set; get; }

        public string CveCliente
        { set; get; }

    }
}
