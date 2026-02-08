using System;
using System.Collections.Generic;
using Concretec.Pedidos.BE;

namespace Concretec.Agentes
{
    public interface IAgenteClientes
    {
        bool ActualizaAutorizacionCliente(int IDCliente, string username, int estatus, float SaldoAut, float LimiteCreditoAut);
        bool AjustarClientes();
        List<Cliente> BuscaClientePedido(DateTime Desde, DateTime Hasta, string CveCiudad);
        Cliente BuscarCliente(int IDCliente, string CveCiudad);
        Cliente BuscarClienteCve(string CveCliente, string CveCiudad);
        bool CargaClientesParadox();
        bool HabilitarCliente(int IDCliente, string username, int estatus);
        bool InsertarCliente(string ClaveCliente, bool Activo, string NombreCompleto, string RFC, string Direccion, string CP, string Poblacion, string Colonia, string Telefonos, string Fax, string CorreoElectronico, string TipoPago, string AttPago, string AttCobro, string RevisionPago, int IDPlanta, int IDCliente, int ACCION, string Planta, string IDVendedor);
        List<Cliente> ObtenerClientes(string CveCiudad);
        List<Cliente> ObtenerClientesCartera(string Filtro, string CveCiudad, string Planta);
        List<Cliente> ObtenerClientesConObra(string CveCiudad);
        List<Cliente> ObtenerClientesConPedido(string CveCiudad);
        List<Cliente> ObtenerClientesFiltro(string Filtro, string CveCiudad, string Planta);
        bool ObtenerClientesSaldo(string CveCiudad, int IDCliente, double Solicitado);
        bool SincronizaClientes(string CveCiudad);
        bool SincronizaClientes_SinAutorizaciones(string CveCiudad);
    }
}