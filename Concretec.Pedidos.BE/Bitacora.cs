using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class Bitacora
    {
        public int RegistrosNuevos
        { set; get; }

        public int RegistrosActualizados
        { set; get; }

        public int RegistrosError
        { set; get; }

        public string Modulo
        { set; get; }

        public string IDModulo
        { set; get; }

        public string FechaProceso
        { set; get; }

        public int idSincronizacion
        { set; get; }

        public string CveCiudad
        { set; get; }

        public string Fecha
        { set; get; }

        public string Hora
        { set; get; }

        public string Aplicacion
        { set; get; }

        public string Funcion
        { set; get; }

        public string Descripcion
        { set; get; }
    }
}
