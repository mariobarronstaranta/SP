using Concretec.Pedidos.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BC
{
    public interface IObras
    {
        List<BE.Sepomex> BUSCAINFO_CP(string CP);
        List<BE.Obra> BuscaObrasAlitudLatitud(string CveCiduad, DateTime Desde, DateTime Hasta);
        string ObtenerObras();
        string ObtenerNumeroObra(int CveCliente, string CveCiudad);
        string BuscarObra(int CvePedido, string CveCiudad);
        List<Obra> ObtenerObrasFiltroActivas(string Filtro, string planta, int CveCliente, string CveCiudad);
        List<Planta> LeerPlantasObras(string CveCiudad);
        bool CargaObrasParadox();
        bool AjustarObras();
        bool InsertarNuevasObras();
        string ObtenerObrasFiltro(string Filtro, string planta, int CveCliente, string CveCiudad, int Estatus);
        bool InsertarObraParadox(
            string  ClaveObra,
            string  Direccion,
            string  Nombre,
            string  Telefonos,
            string  Responsable,
            string  Roji,
            bool    Estatus,
            string  RFC,
            string  Poblacion,
            string  CP,
            string  ClaveZona,
            string  Planta,
            string  ClaveCliente,
            float   Distancia,
            string  TiempoCiclo,
            string  Zona,
            string  CveCiudad,
            string  Colonia
        );

        bool InsertarObra(
            string ClaveObra,
            string Direccion,
            string Nombre,
            string Telefonos,
            string Responsable,
            string Altitud,
            string Latitud,
            string EntreCalles,
            bool? Estatus,
            int? IDVendedor,
            string RFC,
            string POBLACION,
            string CP,
            string ATENCION,
            string CLAVEZONA,
            string PLANTA,
            string CLAVECLIENTE,
            float? DISTANCIA,
            int? TIEMPOCICLO,
            float? VOLUMENESTIMADO,
            float? VOLUMENACUMULADO,
            string CVECIUDAD,
            string Colonia,
            string UrlMaps,
            string MunicipioSepomex);

        bool ActualizarObra
            (
            int IDObra,
            string ClaveObra,
            string Direccion,
            string Nombre,
            string Telefonos,
            string Responsable,
            string EntreCalles,
            bool? Estatus,
            int? IDVendedor,
            string RFC,
            string POBLACION,
            string CP,
            string ATENCION,
            string CLAVEZONA,
            string PLANTA,
            string CLAVECLIENTE,
            float? DISTANCIA,
            int? TIEMPOCICLO,
            float? VOLUMENESTIMADO,
            float? VOLUMENACUMULADO,
            string CVECIUDAD,
            string Colonia,
            string Altitud,
            string Latitud,
            string URLMaps,
            string MunicipioSepomex
            );
    }
}
