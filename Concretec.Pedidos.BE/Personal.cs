using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class Personal
    {
        public int IDPersonal
        { set; get; }

        public string ClavePersonal
        { set; get; }

        public string Nombre
        { set; get; }

        public string APaterno
        { set; get; }

        public string AMaterno
        { set; get; }

        public string Domicilio
        { set; get; }

        public string Telefono
        { set; get; }

        public string Avisar
        { set; get; }

        public string TipoPersonal
        { set; get; }

        public DateTime FechaRegistro
        { set; get; }

        public string Estatus
        { set; get; }

        public string NumLicencia
        { set; get; }

        public DateTime Vigencia
        { set; get; }

        public string Planta
        { set; get; }

        public string Area
        { set; get; }

        public string Puesto
        { set; get; }

        public string CvePuesto
        { set; get; }

        public string CveCiudad
        { set; get; }

        public string Ubicacion
        { set; get; }

        public int IDPlanta
        { set; get; }
    }
}
