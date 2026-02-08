using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Concretec.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPersonal" in both code and config file together.
    [ServiceContract]
    public interface IPersonal
    {
        [OperationContract]
        bool InsertarPersonal( string CvePersonal,string Nombre,string APaterno,string AMaterno,string Puesto, string TipoPersonal,string CveCiudad,int IDPlanta,string interno,string Estatus);

        [OperationContract]
        bool ActualizaPersonal(string CvePersonal, string Nombre, string APaterno, string AMaterno, string Puesto, string TipoPersonal, string CveCiudad, int IDPlanta, string interno, string Estatus);

        [OperationContract]
        string ObtenerPersonal(string TipoPersonal,string CveCiudad);

        [OperationContract]
        string ObtenerPersonalFiltro(string Filtro, string TipoPersonal, string CveCiudad, int Planta, string Estatus);

        [OperationContract]
        string ObtenerChoferUnidad(int IDUnidad, string CveCiudad);

        [OperationContract]
        string BuscarEmpleado(string ClavePersonal);
    }
}
