using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class Logerror
    {
        public int IdLog
        { set; get; }

        public string strFecha
        { set; get; }

        public string Aplicacion
        { set; get; }

        public string Modulo
        { set; get; }

        public string Funcion
        { set; get; }

        public string Descripcion
        { set; get; }

        public DateTime Fecha
        { set; get; }
    }
}
