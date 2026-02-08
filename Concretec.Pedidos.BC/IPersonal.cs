using Concretec.Pedidos.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BC
{
    public interface IPersonal
    {
        string BuscarEmpleadoClave(string ClavePersonal);
        string ObtenerPersonalFiltro(string Filtro, string TipoPersonal, string CveCiudad, int Planta, string Estatus);
        string ObtenerChoferUnidad(int IDUnidad, string CveCiudad);
        string BuscarEmpleado(string ClavePersonal);
        string ObtenerPersonal(string TipoPersonal, string CveCiudad);
        List<Archivos> ListaArchivos();
        bool CargaPersonalExcel();
        bool CargaPersonalParadox();
        bool InsertarPersonal(string CvePersonal, string Nombre, string APaterno, string AMaterno, string Calle, string Colonia, string Poblacion, string Municipio, string Telefono, string Avisar, string TipoPersonal, DateTime FechaRegistro, string Estatus, string NumLicencia, string Vigencia, string CveCiudad);
        bool ActualizaPersonal(
            int idpersonal,
            string CvePersonal,
            string Nombre,
            string APaterno,
            string AMaterno,
            string Puesto,
            string TipoPersonal,
            string CveCiudad,
            int IDPlanta,
            string interno,
            string Estatus);

        bool InsertarPersonal(
            string CvePersonal,
            string Nombre,
            string APaterno,
            string AMaterno,
            string Puesto,
            string TipoPersonal,
            string CveCiudad,
            int IDPlanta,
            string interno,
            string Estatus);
    }
}
