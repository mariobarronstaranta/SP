using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class CalendarioDepuracion
    {
        public int IdCalendarioDepuracion
        { set; get; }

        public DateTime Desde
        { set; get; }

        public DateTime Hasta
        { set; get; }

        public string CveCiudad
        { set; get; }

        public int IdCliente
        { set; get; }

        public int IdUsuario
        { set; get; }

        public DateTime FechaRegistro
        { set; get; }

        public string Estatus
        { set; get; }

        public string NombreCliente
        { set; get; }

        public string NombreUsuario
        { set; get; }

        public string Str_Desde
        { set; get; }

        public string Str_Hasta
        { set; get; }

    }
}
