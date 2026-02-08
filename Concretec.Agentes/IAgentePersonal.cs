using System.Collections.Generic;
using Concretec.Pedidos.BE;

namespace Concretec.Agentes
{
    public interface IAgentePersonal
    {
        bool ActualizaPersonal(int idpersonal, string CvePersonal, string Nombre, string APaterno, string AMaterno, string Puesto, string TipoPersonal, string CveCiudad, int IDPlanta, string interno, string Estatus);
        Personal BuscarEmpleado(string ClavePersonal);
        bool InsertarPersonal(string CvePersonal, string Nombre, string APaterno, string AMaterno, string Puesto, string TipoPersonal, string CveCiudad, int IDPlanta, string interno, string Estatus);
        List<Personal> ObtenerChoferUnidad(int IDUnidad, string CveCiudad);
        List<Personal> ObtenerPersonal(string TipoPersonal, string CveCiudad);
        List<Personal> ObtenerPersonalFiltro(string Filtro, string TipoPersonal, string CveCiudad, int Planta, string Estatus);
    }
}