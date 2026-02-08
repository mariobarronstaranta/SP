using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Concretec.Pedidos.BE;

namespace Concretec.Pedidos.BC
{
   public interface IClientes
    {
        bool SincronizaClientes(string CveCiudad);
        bool InsertarCliente(string ClaveCliente, bool Activo, string NombreCompleto, string RFC, string Direccion, string CP, string Poblacion, string Colonia, string Telefonos, string Fax, string CorreoElectronico, string TipoPago, string AttPago, string AttCobro, string RevisionPago, int IDPlanta, int IDCliente, int ACCION, string Planta, string IDVendedor);
        bool ActualizaAutorizacionCliente(int IDCliente, string username, int estatus, float SaldoAut, float LimiteCreditoAut);
        string BuscarCliente(int IDCliente, string CveCiudad);
        string BuscarClienteCve(string CveCliente, string CveCiudad);
        bool AjustarClientes_Parcial();
        bool SincronizaClientes_SinAutorizaciones(string CveCiudad);
        string ObtenerClientesSaldo(string CveCiudad, int IDCliente);
        bool HabilitarCliente(int IDCliente, string username, int estatus);
        string ObtenerClienteCartera(string Filtro, string CveCiudad, string Planta);
        bool CargaClientesParadox();
        bool AjustarClientes();
        bool CargaCliente(BE.ClientesDetalle clientedetalle);
        List<Cliente> ObtenerCliente(string Filtro, string CveCiudad, string Planta);
        List<Cliente> ObtenerClientesConObra(string CveCiudad);
        string ObtenerClientesConPedido(string CveCiudad);
        string ObtenerClientes(string CveCiudad);

        List<Cliente> BuscaClientePedido(DateTime Desde, DateTime Hasta, string CveCiudad);
    }
}
