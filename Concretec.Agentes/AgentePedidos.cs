using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Concretec.Pedidos.BE;
using Concretec.Pedidos.Utils;

namespace Concretec.Agentes
{
    public class AgentePedidos : IAgentePedidos
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.0";
        readonly string Servicio = "AgentePedidos.cs";
        string Metodo = string.Empty;

        public bool CancelaPedido(int IDPedido, int IDUsuario)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            bool obj = false;
            Metodo = "InsertaPedidoHijo";

            try
            {
                obj = Cliente.CancelaPedido(IDPedido, IDUsuario);
                return true;
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public List<PARFACT0X> BuscaRemisionesSyncPedido(int IDPedido,string remision)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            bool obj = false;
            Metodo = "BuscaRemisionesSyncPedido";
            List<PARFACT0X> salida = new List<PARFACT0X>();

            try
            {
                salida = Cliente.BuscaRemisionesSyncPedido(IDPedido, remision);
                obj = true;
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public List<FACT0X> BuscaPedidoSync(int IDPedido,string cveremision)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            bool obj = false;
            Metodo = "BuscaPedidoSync";
            List<FACT0X> salida = new List<FACT0X>();

            try
            {
                salida = Cliente.BuscaPedidoSync(IDPedido, cveremision);
                obj= true;
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public bool InsertaDetalleSyncPedidoSAE(PARFACT0X elemento)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            bool obj = false;
            Metodo = "InsertaDetalleSyncPedidoSAE";

            try
            {
                obj = Cliente.InsertaDetalleSyncPedidoSAE(elemento);
                return true;
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public bool InsertaHeaderSyncPedidoSAE(List<FACT0X> valores)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            bool obj = false;
            Metodo = "InsertaHeaderSyncPedidoSAE";

            try
            {
                obj = Cliente.InsertaHeaderSyncPedidoSAE(valores);
                return true;
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public bool InsertaContingencia(int idContingencia, string nombre, int estatus, int IdCategoriaObservaciones)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            bool obj = false;
            Metodo = "InsertaContingencia";

            try
            {
                obj = Cliente.InsertaContingencia(idContingencia, nombre, estatus, IdCategoriaObservaciones);
                return true;
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            
            return obj;
        }


        public bool InsertaPedidoHijo(int IDPedidoheader, int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia, double CargaTotal,
            int Viajes, DateTime FechaCompromiso, string HoraCompromiso, int Estatus, string Solicito, string Recibe,
            int Desfase, string Observaciones, int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            bool obj = false;
            Metodo = "InsertaPedidoHijo";

            try
            {
                obj = Cliente.InsertaPedidoHijo(IDPedidoheader, IDUso, IDPlanta, IDProducto, IDVendedor, Distancia, CargaTotal,
             Viajes, FechaCompromiso, HoraCompromiso, Estatus, Solicito, Recibe,
             Desfase, Observaciones, IDCliente, IDObra, Autorizo, ProductosAdicionales);
                return true;
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Contingencia> LeerContingencias(int idContingencia, string nombre, int Activo,int IdCategoriaObservaciones)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            List<Contingencia> obj = new List<Contingencia>();
            Metodo = "LeerContingencias";
            try
            {
                string xmlRespuesta = Cliente.LeerContingencias(idContingencia, nombre, Activo, IdCategoriaObservaciones);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Contingencia>));
                obj = (List<Contingencia>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Comentario> LeerComentariosRemision(string IDRemision)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            List<Comentario> obj = new List<Comentario>();
            Metodo = "LeerComentariosRemision";
            try
            {
                string xmlRespuesta = Cliente.LeerComentariosRemision(IDRemision);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Comentario>));
                obj = (List<Comentario>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Comentario> LeerComentariosPedido(int IDPedido)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            List<Comentario> obj = new List<Comentario>();
            Metodo = "LeerComentariosPedido";
            try
            {
                string xmlRespuesta = Cliente.LeerComentariosPedido(IDPedido);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Comentario>));
                obj = (List<Comentario>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }


        public List<Comentario> LeerComentarios(int IDTipoComentario)
        {
            Pedidos.BC.Catalogos Cliente = new Pedidos.BC.Catalogos();
            List<Comentario> obj = new List<Comentario>();
            Metodo = "LeerComentarios";
            try
            {
                string xmlRespuesta = Cliente.ListaComentarios(IDTipoComentario);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Comentario>));
                obj = (List<Comentario>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<EstatusViaje> LeerEstatusViaje()
        {
            Pedidos.BC.Catalogos Cliente = new Pedidos.BC.Catalogos();
            List<EstatusViaje> obj = new List<EstatusViaje>();
            Metodo = "LeerEstatusViaje";

            try
            {
                string xmlRespuesta = Cliente.LeerEstatusViaje();
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<EstatusViaje>));
                obj = (List<EstatusViaje>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Autorizaciones> BuscaNumeroAutorizaciones(string CveCiudad)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            List<Autorizaciones> obj = new List<Autorizaciones>();
            Metodo = "BuscaNumeroAutorizaciones";
            try
            {
                string xmlRespuesta = Cliente.BuscaNumeroAutorizaciones(CveCiudad);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Autorizaciones>));
                obj = (List<Autorizaciones>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public List<Autorizacion> BuscaAutorizaciones(string CveCiudad, int? IDPedido, int? IDEstatus, DateTime? Desde, DateTime? Hasta)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos(); ;
            List<Autorizacion> obj = new List<Autorizacion>();
            Metodo = "BuscaAutorizaciones";
            try
            {
                //string BuscaAutorizaciones(string CveCiudad, int? IDPedido,int? IDEstatus,DateTime? Desde,DateTime? Hasta)
                obj = Cliente.BuscaAutorizaciones(CveCiudad, IDPedido, IDEstatus,  Desde,  Hasta);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public List<Pedido> InsertaPedidoconDetalle(int IDUso,
            int IDPlanta,
            int IDProducto, int IDVendedor, double Distancia, double CargaTotal,
            int Viajes, DateTime FechaCompromiso, string HoraCompromiso, int Estatus,
            string Solicito, string Recibe, int Desfase, string Observaciones, int IDCliente,
            int IDObra, string Autorizo, string ProductosAdicionales, int IDTipoVenta, string OrdenCompra, string Comentarios, string Contrato, int idusuarioregistro, int ColadoNocturno)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            List<Pedido> obj = new List<Pedido>();
            Metodo = "InsertaPedidoconDetalle";
            try
            {
                string xmlRespuesta = Cliente.InsertaPedidoconDetalle(IDUso, IDPlanta, IDProducto, IDVendedor, Distancia, CargaTotal,
                                                            Viajes, FechaCompromiso, HoraCompromiso, Estatus, Solicito, Recibe,
                                                            Desfase, Observaciones, IDCliente, IDObra, Autorizo,
                                                            ProductosAdicionales, IDTipoVenta, OrdenCompra, Comentarios, Contrato, idusuarioregistro,ColadoNocturno);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Pedido>));
                obj = (List<Pedido>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Pedido> InsertaPedido(int IDUso,
            int IDPlanta,
            int IDProducto, int IDVendedor, double Distancia, double CargaTotal,
            int Viajes, DateTime FechaCompromiso, string HoraCompromiso, int Estatus,
            string Solicito, string Recibe, int Desfase, string Observaciones, int IDCliente,
            int IDObra, string Autorizo, string ProductosAdicionales, int IDTipoVenta, string OrdenCompra, string Comentarios,int idusuarioregistro)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            List<Pedido> obj = new List<Pedido>();
            Metodo = "InsertaPedido";
            try
            {
                string xmlRespuesta = Cliente.InsertaPedido(IDUso, IDPlanta, IDProducto, IDVendedor, Distancia, CargaTotal,
                                                            Viajes, FechaCompromiso, HoraCompromiso, Estatus, Solicito, Recibe,
                                                            Desfase, Observaciones, IDCliente, IDObra, Autorizo,
                                                            ProductosAdicionales, IDTipoVenta, OrdenCompra, Comentarios, idusuarioregistro);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Pedido>));
                obj = (List<Pedido>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public bool ActualizaEstatusPedido(int IDPedido, int IDEstatus)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            bool obj = false;
            Metodo = "ActualizaEstatusPedido";
            try
            {
                obj = Cliente.ActualizaEstatusPedido(IDPedido, IDEstatus);

            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public bool AutorizacionPedido(int IDPedido, float limiteCredito, float Saldo, float Solicitado, string username, int estatus)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            bool obj = false;
            Metodo = "AutorizacionPedido";
            try
            {
                obj = Cliente.AutorizacionPedido(IDPedido, limiteCredito, Saldo, Solicitado, username, estatus);

            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public bool ActualizaPedidoDetalle(int IDPedidoheader, int IDPedidoHijo, int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia, double CargaTotal,
            int Viajes, DateTime FechaCompromiso, string HoraCompromiso, int Estatus, string Solicito, string Recibe,
            int Desfase, string Observaciones, int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales, int IDTipoVenta, string Comentarios, string Contrato, int ColadoNocturno,string OrdenCompra)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            bool obj = false;
            Metodo = "ActualizaPedido";
            try
            {
                obj = Cliente.ActualizaPedidoDetalle(IDPedidoheader, IDPedidoHijo, IDUso, IDPlanta, IDProducto,
                    IDVendedor, Distancia, CargaTotal, Viajes, FechaCompromiso, HoraCompromiso,
                     Estatus, Solicito, Recibe, Desfase, Observaciones, IDCliente, IDObra,
                     Autorizo, ProductosAdicionales, IDTipoVenta, Comentarios, Contrato, ColadoNocturno,OrdenCompra);

            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }


        public bool ActualizaPedido(int IDPedidoheader, int IDPedidoHijo, int IDUso, int IDPlanta, int IDProducto, int IDVendedor, double Distancia, double CargaTotal,
            int Viajes, DateTime FechaCompromiso, string HoraCompromiso, int Estatus, string Solicito, string Recibe,
            int Desfase, string Observaciones, int IDCliente, int IDObra, string Autorizo, string ProductosAdicionales, int IDTipoVenta, string Comentarios)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            bool obj = false;
            Metodo = "ActualizaPedido";
            try
            {
                obj = Cliente.ActualizaPedido(IDPedidoheader, IDPedidoHijo, IDUso, IDPlanta, IDProducto,
                    IDVendedor, Distancia, CargaTotal, Viajes, FechaCompromiso, HoraCompromiso,
                     Estatus, Solicito, Recibe, Desfase, Observaciones, IDCliente, IDObra,
                     Autorizo, ProductosAdicionales, IDTipoVenta, Comentarios);

            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        
        public List<Pedido> ConsultaPedido(int IDPedido)
        {
            Pedidos.BC.Pedidos client = new Pedidos.BC.Pedidos();
            List<Pedido> obj = new List<Pedido>();
            Metodo = "BuscaPedido";
            try
            {
                string xmlRespuesta = client.ConsultaPedido(IDPedido);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Pedido>));
                obj = (List<Pedido>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public List<TipoViaje> LeerTipoViajes()
        {
            Pedidos.BC.Viajes client = new Pedidos.BC.Viajes();
            List<TipoViaje> obj = new List<TipoViaje>();
            Metodo = "LeerTipoViajes";
            try
            {
                string xmlRespuesta = client.LeerTipoViajes();
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<TipoViaje>));
                obj = (List<TipoViaje>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }
        /*******************************************************************/
        public PedidoViaje EditarCierreViajesPedido(int IDPedido, int IDViaje)
        {
            Pedidos.BC.Viajes client = new Pedidos.BC.Viajes();
            List<PedidoViaje> obj = new List<PedidoViaje>();
            Metodo = "EditarCierreViajesPedido";
            try
            {
                string xmlRespuesta = client.EditarCierreViajesPedido(IDPedido, IDViaje);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<PedidoViaje>));
                obj = (List<PedidoViaje>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj[0];
        }

        /*******************************************************************/
        public List<PedidoViaje> LeerCierreViajesPedido(int IDPedido)
        {
            Pedidos.BC.Viajes client = new Pedidos.BC.Viajes();
            List<PedidoViaje> obj = new List<PedidoViaje>();
            Metodo = "LeerCierreViajesPedido";
            try
            {
                obj = client.LeerCierreViajesPedido(IDPedido);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }


        public PedidoHeader rpt_headerremision(string IDRemision, int IDPedido, string CveCiudad)
        {
            Pedidos.BC.Pedidos client = new Pedidos.BC.Pedidos();
            List<PedidoHeader> obj = new List<PedidoHeader>();
            Metodo = "rpt_headerremision";

            try
            {
                string xmlRespuesta = client.rpt_headerremision(IDRemision, IDPedido, CveCiudad);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<PedidoHeader>));
                obj = (List<PedidoHeader>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj[0];
        }

        public PedidoHeader rpt_headerpedido(int IDPedido, string CveCiudad)
        {
            Pedidos.BC.Pedidos client = new Pedidos.BC.Pedidos();
            List<PedidoHeader> obj = new List<PedidoHeader>();
            Metodo = "rpt_headerpedido";

            try
            {
                string xmlRespuesta = client.rpt_headerpedido(IDPedido, CveCiudad);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<PedidoHeader>));
                obj = (List<PedidoHeader>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj[0];

        }


        public List<Viaje> LeerViajesPedido(int IDPedido)
        {
            Pedidos.BC.Viajes client = new Pedidos.BC.Viajes();
            List<Viaje> obj = new List<Viaje>();
            Metodo = "LeerViajesPedido";
            try
            {
                string xmlRespuesta = client.LeerViajesPedido(IDPedido);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Viaje>));
                obj = (List<Viaje>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }



        public List<Viaje> LeerViajes(int IDPedido, string CveCiudad)
        {
            Pedidos.BC.Viajes client = new Pedidos.BC.Viajes();
            List<Viaje> obj = new List<Viaje>();
            Metodo = "LeerViajes";
            try
            {
                string xmlRespuesta = client.LeerViajePedido(IDPedido, CveCiudad);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Viaje>));
                obj = (List<Viaje>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<MotivoCambio> MotivosDeCambio()
        {
            Pedidos.BC.Catalogos client = new Pedidos.BC.Catalogos();
            List<MotivoCambio> obj = new List<MotivoCambio>();
            Metodo = "MotivosDeCambio";

            try
            {
                string xmlRespuesta = client.MotivosCambio();
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<MotivoCambio>));
                obj = (List<MotivoCambio>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<TipoViaje> TipoViaje()
        {
            Pedidos.BC.Catalogos client = new Pedidos.BC.Catalogos();
            List<TipoViaje> obj = new List<TipoViaje>();
            Metodo = "TipoViaje";

            try
            {
                string xmlRespuesta = client.TipoViaje();
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<TipoViaje>));
                obj = (List<TipoViaje>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public Pedido BuscaDatosPedido(int IDPedido, string CveCiudad)
        {

            Pedidos.BC.Pedidos client = new Pedidos.BC.Pedidos();
            List<Pedido> obj = new List<Pedido>();
            Metodo = "BuscaDatosPedido";

            try
            {
                string xmlRespuesta = client.BuscaDatosPedido(IDPedido, CveCiudad);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Pedido>));
                obj = (List<Pedido>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj[0];

        }


        public List<Pedido> BuscaPedido(string CveCiudad, DateTime Desde, DateTime Hasta, int IDCliente, int IdPlanta, int IdEstatus)
        {
            Concretec.Pedidos.BC.Pedidos client = new Concretec.Pedidos.BC.Pedidos();
            List<Pedido> obj = new List<Pedido>();
            Metodo = "BuscaPedido";

            try
            {
                obj = client.BuscaPedido(CveCiudad, Desde, Hasta, IDCliente, IdPlanta, IdEstatus);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Consumo> rptconsumos(string CveCiudad, DateTime Desde, DateTime Hasta)
        {
            Concretec.Pedidos.BC.Pedidos client = new Pedidos.BC.Pedidos();
            List<Consumo> obj = new List<Consumo>();
            Metodo = "rptconsumos";

            try
            {
                obj = client.rptconsumos(CveCiudad, Desde, Hasta);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<PedidoViaje> BuscarViajesPedido(int IDPedido)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            List<PedidoViaje> obj = new List<PedidoViaje>();
            Metodo = "BuscarViajesPedido";
            try
            {
                string xmlRespuesta = Cliente.BuscarViajesPedido(IDPedido);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<PedidoViaje>));
                obj = (List<PedidoViaje>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Producto> LeerPedidoProductosAdicionales(int IDPedidoPadre, int Insertados)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            List<Producto> obj = new List<Producto>();
            Metodo = "LeerPedidoProductosAdicionales";
            try
            {
                string xmlRespuesta = Cliente.LeerPedidoProductosAdicionales(IDPedidoPadre, Insertados);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Producto>));
                obj = (List<Producto>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }


        public List<PedidoProducto> BuscarProductosPedido(int IDPedido)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            List<PedidoProducto> obj = new List<PedidoProducto>();
            Metodo = "BuscarProductosPedido";
            try
            {
                string xmlRespuesta = Cliente.BuscarProductosPedido(IDPedido);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<PedidoProducto>));
                obj = (List<PedidoProducto>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }


        public List<PedidoProducto> BuscarProductosRemision(string IDRemision, int IDPedido)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            List<PedidoProducto> obj = new List<PedidoProducto>();
            Metodo = "BuscarProductosPedido";
            try
            {
                string xmlRespuesta = Cliente.BuscarProductosPedidoRemision(IDRemision, IDPedido);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<PedidoProducto>));
                obj = (List<PedidoProducto>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public bool EliminaPedido(int idPedido)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            bool obj = false;
            Metodo = "EliminaPedido";
            try
            { obj = Cliente.EliminaPedido(idPedido); }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public bool ActualizaCalendarioDepuracion(int idCalendario, string NuevoEstatus, int IdUsuario)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            bool obj = false;
            Metodo = "ActualizaCalendarioDepuracion";
            try
            { obj = Cliente.ActualizaCalendarioDepuracion(idCalendario, NuevoEstatus, IdUsuario); }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public bool InsertaCalendarioDepuracion(DateTime Desde, DateTime Hasta, string CveCiudad, int IdCliente, int IdUsuario)
        {
            Pedidos.BC.Pedidos Cliente = new Pedidos.BC.Pedidos();
            bool obj = false;
            Metodo = "InsertaCalendarioDepuracion";
            try
            { obj = Cliente.InsertaCalendarioDepuracion( Desde,  Hasta,  CveCiudad,  IdCliente,  IdUsuario); }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public List<CalendarioDepuracion> BuscaCalendarioDepuracion()
        {
            Concretec.Pedidos.BC.Pedidos client = new Concretec.Pedidos.BC.Pedidos();
            List<CalendarioDepuracion> obj = new List<CalendarioDepuracion>();
            Metodo = "BuscaCalendarioDepuracion";

            try
            {
                obj = client.BuscaCalendarioDepuracion();
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Consumo> rptConsumoProgramadores(string CveCiudad, DateTime Desde, DateTime Hasta, int IdProgramador, int IdCliente)
        {
            Concretec.Pedidos.BC.Pedidos client = new Concretec.Pedidos.BC.Pedidos();
            List<Consumo> obj = new List<Consumo>();
            Metodo = "rptConsumoProgramadores";

            try
            {
                obj = client.rptConsumoProgramadores( CveCiudad,  Desde,  Hasta,  IdProgramador, IdCliente);
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
