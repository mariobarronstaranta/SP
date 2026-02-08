    using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace Concretec.Servicios
{
    [ServiceContract]
    public interface IClientes
    {
        [OperationContract]
        string CString();

        [OperationContract]
        bool ActualizaAutorizacionCliente(int IDCliente, string username, int estatus, float SaldoAut, float LimiteCreditoAut);

        [OperationContract]
        bool AjustarClientes();

        [OperationContract]
        string ObtenerClientesSaldo(string CveCiudad,int IDCliente);

        [OperationContract]
         string ObtenerClientes(string CveCiudad);

        [OperationContract]
        string ObtenerClientesConObra(string CveCiudad);

        [OperationContract]
        string ObtenerClientesConPedido(string CveCiudad);

        [OperationContract]
        string BuscarCliente(int IDCliente,string CveCiudad);

        [OperationContract]
        string BuscarClienteCve(string CveCliente, string CveCiudad);

        [OperationContract]
        string ObtenerCliente(string Filtro, string CveCiudad, string Planta);

        [OperationContract]
        string ObtenerClienteCartera(string Filtro, string CveCiudad, string Planta);

        [OperationContract]
        bool HabilitarCliente(int IDCliente, string username, int estatus);

        [OperationContract]
        bool InsertarCliente(string ClaveCliente, bool Activo, string NombreCompleto, string RFC, string Direccion, string CP, string Poblacion, string Colonia, string Telefonos, string Fax, string CorreoElectronico, string TipoPago, string AttPago, string AttCobro, string RevisionPago, int IDPlanta, int IDCliente, int ACCION, string Planta, string IDVendedor);

        [OperationContract]
        bool SincronizaClientes(string CveCiudad);

        [OperationContract]
        bool SincronizaClientes_SinAutorizaciones(string CveCiudad);
    }
}
