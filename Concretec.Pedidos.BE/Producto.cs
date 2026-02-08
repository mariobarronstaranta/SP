using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class Producto
    {
        public int IDProducto
        { set; get; }

        public string CveAlterna
        { set; get; }

        public string ClaveProducto
        { set; get; }

        public string Descripcion
        { set; get; }

        public string Unidad
        { set; get; }

        public double Precio
        { set; get; }

        public float Cantidad
        { set; get; }

        public string CveCiudad
        { set; get; }

        public string Clasificacion
        { set; get; }

        public bool Borrado
        { set; get; }

        public string Observaciones
        { set; get; }

        public bool EsComplemento
        { set; get; }
    }
}
