using Concretec.Pedidos.BE;
using System.Collections.Generic;

namespace Concretec.Pedidos.BC
{
    public interface Iproducto
    {
        //List<Archivos> ListaArchivos();
        List<BE.Producto> ObtenerProductos(int Complemento, string CveCiudad);
        bool AjustarProductos();
        bool ActualizaProductos(string CveCiudad);
        bool ActualizaProductosCiudad(string CveCiudad);
        bool SyncProductos(string CveCiudad);
        List<BE.Producto> ObtieneProductos_Aspel(string CveCiudad);
        bool InsertarProductosTMP(string ClaveProducto, string Descripcion, string Unidad, double Precio, string CveAlterna, string Clasificacion, string CveCiudad);
        bool InsertarProducto(int IDProducto, string ClaveProducto, string Descripcion, string Unidad, double Precio, bool Borrado, string Observaciones, bool EsComplemento, int Accion, string ClaveAlterna, string CveCiudad, string Clasificacion);
        bool ActualizarProducto(int IDProducto, string ClaveProducto, string Descripcion, string Unidad, double Precio, bool Borrado, string Observaciones, bool EsComplemento);
        string ObtenerProductosFiltro(string _filtro, string clasificacion, string CveCiudad);


    }
}