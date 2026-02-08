using System;
using System.Collections.Generic;

namespace Concretec.Pedidos.BC
{
   public interface IPedidos2
    {
        string BuscaPedido(string CveCiudad, DateTime Desde, DateTime Hasta, int IDCliente, int IdPlanta, int IdEstatus);
        List<Concretec.Pedidos.BE.Consumo> rptconsumos(string CveCiudad, DateTime Desde, DateTime Hasta);

        string LeerContingencias(int idContingencia, string nombre, int Activo);
    }
}
