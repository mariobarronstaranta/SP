using System.Collections.Generic;
using Concretec.Pedidos.BE;

namespace Concretec.Agentes
{
    public interface IAgenteObras
    {
        List<Sepomex> BUSCAINFO_CP(string CP);
        bool ActualizarObra(int IDObra, string ClaveObra, string Direccion, string Nombre, string Telefonos, string Responsable, string EntreCalles, bool? Estatus, int? IDVendedor, string RFC, string POBLACION, string CP, string ATENCION, string CLAVEZONA, string PLANTA, string CLAVECLIENTE, float? DISTANCIA, int? TIEMPOCICLO, float? VOLUMENESTIMADO, float? VOLUMENACUMULADO, string CVECIUDAD, string Colonia,string Altitud,string Latitud, string URLMaps, string MunicipioSepomex);
        bool AjustarObras();
        Obra BuscarObra(int ClaveObra, string CveCiudad);
        bool CargaObrasParadox();
        bool CargarObra();
        bool InsertarObra(string ClaveObra, string Direccion, string Nombre, string Telefonos, string Responsable, string Altitud,string Latitud, string EntreCalles, bool? Estatus, int? IDVendedor, string RFC, string POBLACION, string CP, string ATENCION, string CLAVEZONA, string PLANTA, string CLAVECLIENTE, float? DISTANCIA, int? TIEMPOCICLO, float? VOLUMENESTIMADO, float? VOLUMENACUMULADO, string CVECIUDAD, string Colonia, string UrlMaps,string MunicipioSepomex);
        bool InsertarObraParadox(int IDObra, string ClaveObra, string Direccion, string Nombre, string Telefonos, string Responsable, string Roji, string EntreCalles, bool Estatus);
        string ObtenerNumeroObra(int CveCliente, string CveCiudad);
        List<Obra> ObtenerObras();
        List<Obra> ObtenerObrasFiltro(string Filtro, string planta, int CveCliente, string CveCiudad, int Estatus);
        List<Obra> ObtenerObrasFiltroActivas(string Filtro, string planta, int CveCliente, string CveCiudad);
    }
}