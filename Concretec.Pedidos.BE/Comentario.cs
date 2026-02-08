using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class Comentario
    {
        public int IDComentario
        { set; get; }

        public string Descripcion
        { set; get; }

        public int IDPedido
        { set; get; }

        public int IDRemision
        { set; get; }
    }
}
