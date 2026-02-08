using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class Autorizaciones
    {
        public int ClientesEnAutorizacion
        { set; get; }

        public int PedidosEnAutorizacion
        { set; get; }

        public string Ciudad
        { set; get; }
    }
}
