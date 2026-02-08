using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Concretec.Pedidos.BE;
using System.Configuration;
using Concretec.Pedidos.Utils;
using Concretec.Pedidos.BC;

namespace Concretec.Agentes
{
    public class AgenteClientes : IAgenteClientes
    {

        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.5";
        readonly string Servicio = "AgenteClientes.svc";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return ConfigurationManager.AppSettings["conexion"].ToString(); }
        }



        public bool AjustarClientes()
        {
            Pedidos.BC.Clientes client = new Pedidos.BC.Clientes();
            bool obj = false;
            Metodo = "AjustarClientes";
            try
            {
                obj = client.AjustarClientes();

            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }


        public bool CargaClientesParadox()
        {
            Metodo = "CargaClientesParadox";
            Concretec.Pedidos.BC.Clientes BC = new Concretec.Pedidos.BC.Clientes();
            bool Insertar = new bool();

            try
            {
                Insertar = BC.CargaClientesParadox();
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return Insertar;
        }

        public bool HabilitarCliente(int IDCliente, string username, int estatus)
        {
            Metodo = "HabilitarCliente";
            Pedidos.BC.Clientes client = new Pedidos.BC.Clientes();
            bool obj = false;
            try
            {
                obj = client.HabilitarCliente(IDCliente, username, estatus);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public bool ObtenerClientesSaldo(string CveCiudad, int IDCliente, double Solicitado)
        {
            bool salida = false;
            Metodo = "ObtenerClientesSaldo";
            List<Cliente> obj = new List<Cliente>();
            Pedidos.BC.Clientes client = new Pedidos.BC.Clientes();
            try
            {
                string xmlRespuesta = client.ObtenerClientesSaldo(CveCiudad,IDCliente);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Cliente>));
                obj = (List<Cliente>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            double saldo = double.Parse(obj[0].CreditoDisponible.ToString()) - Solicitado;
            if (saldo >= 0) { salida = true; }

            return salida;
        }

        public bool SincronizaClientes_SinAutorizaciones(string CveCiudad)
        {
            Metodo = "SincronizaClientes_SinAutorizaciones";
            Pedidos.BC.Clientes client = new Pedidos.BC.Clientes();
            bool xmlRespuesta = false;
            try
            {
                xmlRespuesta = client.SincronizaClientes_SinAutorizaciones(CveCiudad);

            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return xmlRespuesta;
        }

        public bool SincronizaClientes(string CveCiudad)
        {
            Metodo = "SincronizaClientes";
            Pedidos.BC.Clientes client = new Pedidos.BC.Clientes();
            bool xmlRespuesta = false;
            try
            {
                xmlRespuesta = client.SincronizaClientes(CveCiudad);
      
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return xmlRespuesta;
        }

        public Cliente BuscarClienteCve(string CveCliente, string CveCiudad)
        {
            Metodo = "BuscarClienteCve";
            List<Cliente> obj = new List<Cliente>();
            Pedidos.BC.Clientes client = new Pedidos.BC.Clientes();
            try
            {
                string xmlRespuesta = client.BuscarClienteCve(CveCliente, CveCiudad);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Cliente>));
                obj = (List<Cliente>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj[0];
        }


        public Cliente BuscarCliente(int IDCliente,string CveCiudad)
        {
            Metodo = "BuscarCliente";
            List<Cliente> obj = new List<Cliente>();
            Pedidos.BC.Clientes client = new Pedidos.BC.Clientes();
            try
            {
                string xmlRespuesta = client.BuscarCliente(IDCliente,CveCiudad);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Cliente>));
                obj = (List<Cliente>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj[0];
        }



        public List<Cliente> ObtenerClientes(string CveCiudad)
        {
            Metodo = "ObtenerClientes";
            List<Cliente> obj = new List<Cliente>();
            Pedidos.BC.Clientes client = new Pedidos.BC.Clientes();
            try
            {
                string xmlRespuesta = client.ObtenerClientes(CveCiudad);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Cliente>));
                obj = (List<Cliente>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }          
            return obj;
        }

        public bool ActualizaAutorizacionCliente(int IDCliente, string username, int estatus, float SaldoAut, float LimiteCreditoAut)
        {
            Metodo = "ActualizaAutorizacionCliente";
            Pedidos.BC.Clientes client = new Pedidos.BC.Clientes();
            bool obj = false;
            try
            {
                obj = client.ActualizaAutorizacionCliente(IDCliente, username, estatus, SaldoAut, LimiteCreditoAut);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }


        public bool InsertarCliente(string ClaveCliente, bool Activo, string NombreCompleto, string RFC, string Direccion, string CP, string Poblacion, string Colonia, string Telefonos, string Fax, string CorreoElectronico, string TipoPago, string AttPago, string AttCobro, string RevisionPago, int IDPlanta, int IDCliente, int ACCION, string Planta, string IDVendedor)
        {
            Metodo = "InsertarCliente";
            Pedidos.BC.Clientes client = new Pedidos.BC.Clientes();
            bool obj = false;
            try
            {
                obj = client.InsertarCliente(ClaveCliente, Activo, NombreCompleto, RFC, Direccion, CP, Poblacion, Colonia, Telefonos, Fax, CorreoElectronico, TipoPago, AttPago, AttCobro, RevisionPago, IDPlanta, IDCliente, ACCION, Planta, IDVendedor);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Cliente> ObtenerClientesConPedido(string CveCiudad)
        {
            Metodo = "ObtenerClientesConPedido";
            List<Cliente> obj = new List<Cliente>();
            Pedidos.BC.Clientes client = new Pedidos.BC.Clientes();
            try
            {
                string xmlRespuesta = client.ObtenerClientesConPedido(CveCiudad);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Cliente>));
                obj = (List<Cliente>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Cliente> ObtenerClientesConObra(string CveCiudad)
        {
            Metodo = "ObtenerClientesConObra";
            List<Cliente> obj = new List<Cliente>();
            Pedidos.BC.Clientes client = new Pedidos.BC.Clientes();
            try
            {
                obj = client.ObtenerClientesConObra(CveCiudad);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

         public List<Cliente> ObtenerClientesCartera(string Filtro, string CveCiudad, string Planta)
        {
            Pedidos.BC.Clientes client = new Pedidos.BC.Clientes();
            List<Cliente> obj = new List<Cliente>();
            Metodo = "ObtenerClientesCartera";
            try
            {
                string xmlRespuesta = client.ObtenerClienteCartera(Filtro, CveCiudad, Planta);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Cliente>));
                obj = (List<Cliente>)xs.Deserialize(new StringReader(xmlRespuesta));

            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Cliente> ObtenerClientesFiltro(string Filtro, string CveCiudad, string Planta)
        {
            Pedidos.BC.Clientes client = new Pedidos.BC.Clientes();
            List<Cliente> obj = new List<Cliente>();
            Metodo = "ObtenerClientesFiltro";
            try
            {
                obj = client.ObtenerCliente(Filtro, CveCiudad, Planta);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Cliente> BuscaClientePedido(DateTime Desde, DateTime Hasta, string CveCiudad)
        { 
            Pedidos.BC.Clientes client = new Pedidos.BC.Clientes();
            List<Cliente> obj = new List<Cliente>();
            Metodo = "BuscaClientePedido";
            try
            {
                obj = client.BuscaClientePedido(Desde, Hasta, CveCiudad);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }
    }
}
