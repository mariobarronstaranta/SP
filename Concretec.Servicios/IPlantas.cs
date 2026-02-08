using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Concretec.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPlantas" in both code and config file together.
    [ServiceContract]
    public interface IPlantas
    {
        [OperationContract]
        string ObtenerPlantas();

        [OperationContract]
        string ObtenerPlantasBombeo();

        [OperationContract]
        string ObtenerPlantasFiltro(string Nombre, string CveDosificadora, string CveCiudad);

        [OperationContract]
        string LeerPlantasObras(string CveCiudad);

        [OperationContract]
        bool InsertarPlanta(int IDPlanta, string Nombre, string CveDosificadora, bool Estatus, string Telefono, string Telefono2, string IDCiudad, string Calle, string NumInt, string NumExt, int Accion, string Colonia, string Municipio, int IDJefePlanta, string CvePlanta, int IDPlantaAlterna1, int IDPlantaAlterna2);

        [OperationContract]
        string ConsultaPlanta(int IdPlanta);

        [OperationContract]
        string ObtenerPlantasCiudad(string CveCiudad);
    }
} 
