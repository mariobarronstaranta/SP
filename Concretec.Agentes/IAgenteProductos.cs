using System.Collections.Generic;
using Concretec.Pedidos.BE;

namespace Concretec.Agentes
{
    public interface IAgenteProductos
    {
        bool ActualizaProductosCiudad(string CveCiudad);
        bool ActualizarProducto(int IDProducto, string ClaveProducto, string Descripcion, string Unidad, double Precio, bool Borrado, string Observaciones);
        bool CargaProducto(string ClaveProducto, string Descripcion, string Unidad, double Precio, bool Borrado, string Observaciones, string CveCiudad, string LinProd, string CveAlterna);
        void CargarProductos();
        bool InsertarProducto(int IDProducto, string ClaveProducto, string Descripcion, string Unidad, double Precio, bool Borrado, string Observaciones, bool EsComplemento, int Accion, string ClaveAlterna, string CveCiudad, string Clasificacion);
        List<Archivos> ListaArchivos();
        List<Producto> ObtenerProducto(int Complemento, string CveCiudad);
        List<Producto> ObtenerProductoFiltro(string _filtro, string clasificacion, string CveCiudad);
    }
}