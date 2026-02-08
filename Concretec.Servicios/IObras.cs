using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Concretec.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IObras" in both code and config file together.
    [ServiceContract]
    public interface IObras
    {
        [OperationContract]
        string ObtenerNumeroObra(int CveCliente,string CveCiudad);

        [OperationContract]
        string ObtenerObras();

        [OperationContract]
        string ObtenerObrasFiltroActivas(string Filtro, string planta, int CveCliente, string CveCiudad);

        [OperationContract]
        string ObtenerObrasFiltro(string Filtro, string planta, int CveCliente,string CveCiudad,int Estatus);

        [OperationContract]
        string BuscarObra(int CvePedido, string CveCiudad);

        [OperationContract]
        string ObtenerParametros();

        [OperationContract]
        bool ActualizarObra(

            int IDObra,
            string ClaveObra,
            string Direccion,
            string Nombre,
            string Telefonos,
            string Responsable,
            string Roji,
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
            string Colonia
            );

        [OperationContract]
        bool InsertarObra(  
            
            string ClaveObra,
		    string Direccion,
		    string Nombre,
		    string Telefonos, 
		    string Responsable, 
		    string Roji, 
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
            string Colonia
            );
    }
}
