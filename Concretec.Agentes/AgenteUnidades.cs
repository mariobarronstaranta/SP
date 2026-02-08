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
    public class AgenteUnidades : IAgenteUnidades
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.5";
        readonly string Servicio = "AgenteUnidades.cs";
        string Metodo = string.Empty;

        public bool InsertaPlaneacionUnidadPlantaDetalle(PlaneacionUnidadPlantaDetalle unidades)
        {
            Metodo = "InsertaPlaneacionUnidadPlantaDetalle";
            Pedidos.BC.Unidades Cliente = new Pedidos.BC.Unidades();
            bool obj = false;

            try
            {
                obj = Cliente.InsertaPlaneacionUnidadPlantaDetalle(unidades);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public bool InsertaPlaneacionUnidad(ConsultaUnidad unidad)
        {
            Metodo = "InsertaPlaneacionUnidad";
            Pedidos.BC.Unidades Cliente = new Pedidos.BC.Unidades();
            bool obj = false;

            try
            {
                obj = Cliente.InsertaPlaneacionUnidad(unidad);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public bool InsertarMovCR(int IdUnidad, int IdPlantaOrigen, int IdPlantaDestino, DateTime Inicio, DateTime? Fin, int IdUsuario,string Comentario)
        {
            Metodo = "InsertarMovCR";
            Pedidos.BC.Unidades Cliente = new Pedidos.BC.Unidades();
            bool obj = false;

            try
            {
                obj = Cliente.InsertarMovCR(IdUnidad, IdPlantaOrigen, IdPlantaDestino, Inicio, Fin, IdUsuario, Comentario);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public bool RegistraAjuste(int IdTanque, int IdTipoMovimiento, float valor, int IdUsuarioActualizacion, DateTime FechaMovimiento,string observaciones)
        {
            Metodo = "RegistraAjuste";
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            bool obj = false;

            try
            {
                obj = Cliente.RegistraAjuste(IdTanque, IdTipoMovimiento, valor, IdUsuarioActualizacion, FechaMovimiento, observaciones);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public bool ActualizaMovimientoIN(int idmovimiento, int IdTanque, int IdTipoMovimiento, float valor, int IdUsuarioActualizacion, DateTime FechaMovimiento, string proveedor, string referencia)
        {
            Metodo = "ActualizaMovimientoIN";
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            bool obj = false;

            try
            {
                obj = Cliente.ActualizaMovimientoIN(idmovimiento, IdTanque, IdTipoMovimiento, valor, IdUsuarioActualizacion, FechaMovimiento, proveedor, referencia);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public bool RegistraMovimientoIN(int IdTanque, int IdTipoMovimiento, float valor, int IdUsuarioActualizacion, DateTime FechaMovimiento, string proveedor, string referencia)
        {
            Metodo = "RegistraMovimientoIN";
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            bool obj = false;

            try
            {
                obj = Cliente.RegistraMovimientoIN(IdTanque, IdTipoMovimiento, valor, IdUsuarioActualizacion, FechaMovimiento, proveedor, referencia);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public bool ActualizaLectura(int idlectura, int IdTanque, DateTime fecha, DateTime hora, float valorlectura, int idusuario,int temperatura,int lecturacms)
        {
            Metodo = "ActualizaLectura";
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            bool obj = false;

            try
            {
                obj = Cliente.ActualizaLectura(idlectura,IdTanque, fecha, hora, valorlectura, idusuario, temperatura, lecturacms);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public bool RegistraLectura(int IdTanque, DateTime fecha, DateTime hora, float valorlectura, int idusuario,int temperatura, int lecturacms)
        {
            Metodo = "RegistraLectura";
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            bool obj = false;

            try
            {
                obj = Cliente.RegistraLectura( IdTanque,  fecha,  hora,  valorlectura, idusuario, temperatura, lecturacms);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public bool InsertaTanque(string Operacion, int IdTanque, string IdCiudad, int IdPlanta, int IdTipoCombustible,
                                    string Nombre, double capacidad, int idusuario,
                                    decimal Altura, string Forma, decimal DiametroA, decimal DiametroB)
        {
            Metodo = "InsertaTanque";
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            bool obj = false;

            try
            {
                obj = Cliente.InsertaTanque( Operacion,  IdTanque,  IdCiudad,  IdPlanta,  IdTipoCombustible,
                                     Nombre,  capacidad,  idusuario,
                                     Altura,  Forma,  DiametroA,  DiametroB);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public bool ActUnidad(int IDUnidad, string IDClaveUnidad, string CveAlterna, bool Borrado, int? Orden, int? ACCION, int? IDPersonal, int? IDAseguradora, int? IDPlanta, string Poliza, string Inciso, DateTime? InicioVigencia, DateTime? FinVigencia, int? IDMarca, int? IDTipoCombustible, int? IDTipoPlacas, int? IDCentroCostos, bool Estatus, int? Modelo, string Motor, string NumSerie, string Placas, string Ubicado, string Propietario, DateTime? VerificacionVehicular)
        {
            Metodo = "ActUnidad";
            Pedidos.BC.Unidades Cliente = new Pedidos.BC.Unidades();
            bool obj = false;

            try
            {
                obj = Cliente.ActUnidad(IDUnidad, 
                            IDClaveUnidad,
                             CveAlterna,
                             Borrado,
                             Orden,
                             ACCION,
                             IDPersonal,
                             IDAseguradora,
                             IDPlanta,
                             Poliza,
                             Inciso,
                             InicioVigencia,
                             FinVigencia,
                             IDMarca,
                             IDTipoCombustible,
                             IDTipoPlacas,
                             IDCentroCostos,
                             Estatus,
                             Modelo,
                             Motor,
                             NumSerie,
                             Placas,
                             Ubicado,
                             Propietario,
                             VerificacionVehicular);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public bool InsertarUnidad(string IDClaveUnidad, string CveAlterna, bool Borrado, int? Orden, int? ACCION, int? IDPersonal, int? IDAseguradora, int? IDPlanta, string Poliza, string Inciso, DateTime? InicioVigencia, DateTime? FinVigencia, int? IDMarca, int? IDTipoCombustible, int? IDTipoPlacas, int? IDCentroCostos, bool Estatus, int? Modelo, string Motor, string NumSerie, string Placas, string Ubicado, string Propietario, DateTime? VerificacionVehicular)
        {
            Metodo = "InsertarUnidad";
            Pedidos.BC.Unidades Cliente = new Pedidos.BC.Unidades();
            bool obj = false;
            try
            {
                obj = Cliente.InsertarUnidad(
                             IDClaveUnidad,
                             CveAlterna,
                             Borrado,
                             Orden,
                             ACCION,
                             IDPersonal,
                             IDAseguradora,
                             IDPlanta,
                             Poliza,
                             Inciso,
                             InicioVigencia,
                             FinVigencia,
                             IDMarca,
                             IDTipoCombustible,
                             IDTipoPlacas,
                             IDCentroCostos,
                             Estatus,
                             Modelo,
                             Motor,
                             NumSerie,
                             Placas,
                             Ubicado,
                             Propietario,
                             VerificacionVehicular);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public bool RegistraMovimientoOUT(int IdTanque, int IdTipoMovimiento, float valor, int IdUsuarioActualizacion, DateTime FechaMovimiento, DateTime HoraMovimiento, string proveedor, int IdUnidad, int IdOperador, float horimetro, float odometro,float temperatura)
        {
            Metodo = "RegistraMovimientoOUT";
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            bool obj = false;
            try
            {
                obj = Cliente.RegistraMovimientoOUT( IdTanque,  IdTipoMovimiento,  valor,  IdUsuarioActualizacion,  FechaMovimiento,  HoraMovimiento,  proveedor,  IdUnidad,  IdOperador,  horimetro,  odometro, temperatura);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<TanqueMovimiento> BuscaSalidaEntradaCombustibles(int idmovimiento, int idtanque, DateTime desde, DateTime hasta, string cveciudad, int idunidad, int idplanta)
        {
            Metodo = "BuscaSalidaEntradaCombustibles";
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            List<TanqueMovimiento> obj = new List<TanqueMovimiento>();

            try
            {
                string xmlRespuesta = Cliente.BuscaSalidaCombustibles(idmovimiento, idtanque,  desde,  hasta,  cveciudad,  idunidad,  idplanta);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<TanqueMovimiento>));
                obj = (List<TanqueMovimiento>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<TanqueMovimiento> BuscaEntradaCombustibles(int idtanque, DateTime desde, DateTime hasta, string cveciudad,int idmovimiento)
        {
            Metodo = "BuscaEntradaCombustibles";
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            List<TanqueMovimiento> obj = new List<TanqueMovimiento>();

            try
            {
                string xmlRespuesta = Cliente.BuscaEntradaCombustibles(idtanque, desde, hasta, cveciudad, idmovimiento);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<TanqueMovimiento>));
                obj = (List<TanqueMovimiento>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Tanque>  BuscaTanquesCombo(int IdPlanta)
        {
            Metodo = "BuscaTanquesCombo";
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            List<Tanque> obj = new List<Tanque>();

            try
            {
                string xmlRespuesta = Cliente.BuscaTanquesCombo(IdPlanta);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Tanque>));
                obj = (List<Tanque>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public Lectura BuscaLecturaEdicion(int IdLectura)
        {
            Metodo = "BuscaLecturaEdicion";
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            List<Lectura> obj = new List<Lectura>();
            Lectura salida = new Lectura();

            try
            {
                string xmlRespuesta = Cliente.BuscaLecturaEdicion(IdLectura);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Lectura>));
                obj = (List<Lectura>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            if (obj.Count > 0)
            {
                salida = obj[0];
            }

            return salida;
        }

        public List<Tanque> BuscaAjustes(int idTanque, DateTime desde, DateTime hasta)
        {
            Metodo = "BuscaAjustes";
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            List<Tanque> obj = new List<Tanque>();

            try
            {
                string xmlRespuesta = Cliente.BuscaAjustes(idTanque, desde, hasta);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Tanque>));
                obj = (List<Tanque>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Tanque> BuscaConsumos(int idTanque, DateTime desde, DateTime hasta)
        {
            Metodo = "BuscaConsumos";
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            List<Tanque> obj = new List<Tanque>();

            try
            {
                string xmlRespuesta = Cliente.BuscaConsumos(idTanque, desde, hasta);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Tanque>));
                obj = (List<Tanque>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public List<Lectura> BuscaLecturas(string IdCiudad, int IdTanque, DateTime finicial, DateTime ffinal)
        {
            Metodo = "BuscaLecturas";
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            List<Lectura> obj = new List<Lectura>();

            try
            {
                string xmlRespuesta = Cliente.BuscaLecturas( IdCiudad,  IdTanque,  finicial,  ffinal);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Lectura>));
                obj = (List<Lectura>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Tanque> BuscaTanques(int IdTanque, string IdCiudad, int IdTipoCombustible, string Nombre)
        {
            Metodo = "BuscaTanques";
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            List<Tanque> obj = new List<Tanque>();

            try
            {
                string xmlRespuesta = Cliente.BuscaTanques( IdTanque,  IdCiudad,  IdTipoCombustible, Nombre);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Tanque>));
                obj = (List<Tanque>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Unidad> ValidaUnidadLibre(string Fecha, string Hora, int IdPlanta)
        {
            Metodo = "ValidaUnidadLibre";
            Pedidos.BC.Unidades Cliente = new Pedidos.BC.Unidades();
            List<Unidad> obj = new List<Unidad>();

            try
            {
                string xmlRespuesta = Cliente.ValidaUnidadLibre(Fecha, Hora, IdPlanta);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Unidad>));
                obj = (List<Unidad>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<ConsultaUnidad> BuscaUnidadesLibres(int idPlanta, int TipoViaje, DateTime FechaViaje, string HoraInicio, string HoraFin)
        {
            Metodo = "BuscaUnidadesLibres";
            Pedidos.BC.Unidades Cliente = new Pedidos.BC.Unidades();
            List<ConsultaUnidad> obj = new List<ConsultaUnidad>();

            try
            {
                string xmlRespuesta = Cliente.BuscaUnidadesLibres(idPlanta, TipoViaje, FechaViaje, HoraInicio, HoraFin);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<ConsultaUnidad>));
                obj = (List<ConsultaUnidad>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<ConsultaUnidad> BuscaUnidadMovs(string idUnidad)
        {
            Metodo = "BuscaUnidadMovs";
            Pedidos.BC.Unidades Agente = new Pedidos.BC.Unidades();
            List<ConsultaUnidad> obj = new List<ConsultaUnidad>();

            try
            {
                obj = Agente.BuscaUnidadMovs(idUnidad);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<ConsultaUnidad> LeerUnidadesMovs(string Filtro, string planta)
        {
            Metodo = "LeerUnidadesMovs";
            Pedidos.BC.Unidades Agente = new Pedidos.BC.Unidades();
            List<ConsultaUnidad> obj = new List<ConsultaUnidad>();

            try
            {
                obj = Agente.LeerUnidadesMovs(Filtro, planta);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }


        public List<ConsultaUnidad> LeerUnidadClave(string Clave)
        {
            Metodo = "LeerUnidadClave";
            Pedidos.BC.Unidades Cliente = new Pedidos.BC.Unidades();
            List<ConsultaUnidad> obj = new List<ConsultaUnidad>();

            try
            {
                string xmlRespuesta = Cliente.ObtenerUnidadesClave(Clave);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<ConsultaUnidad>));
                obj = (List<ConsultaUnidad>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        //ObtenerUnidadesFiltro
        public List<ConsultaUnidad> ObtenerUnidadesFiltro(string filtro, string planta,string CveCiudad,int IdEstatus)
        {
            Metodo = "ObtenerUnidadesFiltro";
            Pedidos.BC.Unidades Agente = new Pedidos.BC.Unidades();
            List<ConsultaUnidad> obj = new List<ConsultaUnidad>();

            try
            {
                obj = Agente.ObtenerUnidadesFiltro(filtro, planta, CveCiudad, IdEstatus);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<ConsultaUnidad> ObtenerBombasOcupadas(string CveCiudad, DateTime FechaPedido)
        {
            Metodo = "ObtenerBombasOcupadas";
            Pedidos.BC.Unidades Cliente = new Pedidos.BC.Unidades();
            List<ConsultaUnidad> obj = new List<ConsultaUnidad>();

            try
            {
                string xmlRespuesta = Cliente.ObtenerBombasOcupadas(CveCiudad, FechaPedido);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<ConsultaUnidad>));
                obj = (List<ConsultaUnidad>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }


        public List<ConsultaUnidad> ObtenerUnidadesOcupadas(string CveCiudad, DateTime FechaPedido)
        {
            Metodo = "ObtenerUnidadesOcupadas";
            Pedidos.BC.Unidades Cliente = new Pedidos.BC.Unidades();
            List<ConsultaUnidad> obj = new List<ConsultaUnidad>();

            try
            {
                string xmlRespuesta = Cliente.ObtenerUnidadesOcupadas(CveCiudad, FechaPedido);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<ConsultaUnidad>));
                obj = (List<ConsultaUnidad>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }
        
        
        
        public List<ConsultaUnidad> ObtenerUnidadesLibres(string CveCiudad, DateTime FechaPedido, DateTime FechaHoraPedido, int IDPlantaPadre)
        {
            Metodo = "ObtenerUnidadesLibres";
            Pedidos.BC.Unidades Cliente = new Pedidos.BC.Unidades();
            List<ConsultaUnidad> obj = new List<ConsultaUnidad>();

            try
            {
                string xmlRespuesta = Cliente.ObtenerUnidadesLibres(CveCiudad, FechaPedido, FechaHoraPedido,IDPlantaPadre);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<ConsultaUnidad>));
                obj = (List<ConsultaUnidad>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            
            return obj;
        }


        public List<ConsultaUnidad> ObtenerBombas()
        {
            Metodo = "ObtenerBombas";
            Pedidos.BC.Unidades Cliente = new Pedidos.BC.Unidades();
            List<ConsultaUnidad> obj = new List<ConsultaUnidad>();

            try
            {
                string xmlRespuesta = Cliente.ObtenerBombas();
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<ConsultaUnidad>));
                obj = (List<ConsultaUnidad>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<ConsultaUnidad> ObtieneUnidad()
        {
            Pedidos.BC.Unidades Cliente = new Pedidos.BC.Unidades();
            List<ConsultaUnidad> obj = new List<ConsultaUnidad>();

            try
            {
                string xmlRespuesta = Cliente.ObtenerUnidades();
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<ConsultaUnidad>));
                obj = (List<ConsultaUnidad>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<CentroCostos> ObtenerCentroCostos()
        {
            Metodo = "ObtenerCentroCostos";
            Pedidos.BC.Unidades Cliente = new Pedidos.BC.Unidades();
            List<CentroCostos> obj = new List<CentroCostos>();
            try
            {
                string xmlRespuesta = Cliente.ObtenerCentroCostos();
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<CentroCostos>));
                obj = (List<CentroCostos>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Unidad> ValidaExisteUnidad(string CveUnidad, string CveCiudad, int IdUnidad)
        {
            Metodo = "ValidaExisteUnidad";
            Pedidos.BC.Unidades Cliente = new Pedidos.BC.Unidades();
            List<Unidad> obj = new List<Unidad>();

            try
            {
                obj = new List<Unidad>();
                obj = Cliente.ValidaExisteUnidad(CveUnidad, CveCiudad,  IdUnidad);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public List<Lectura> BuscaLecturasII(string IdCiudad, int IdTanque, DateTime finicial, DateTime ffinal)
        {

            Metodo = "ObtenerAseguradoras";
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            List<Lectura> obj = new List<Lectura>();

            try
            {
                string xmlRespuesta = Cliente.ObtenerAseguradoras();
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Lectura>));
                obj = (List<Lectura>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Aseguradora> ObtenerAseguradoras()
        {

            Metodo = "ObtenerAseguradoras";
            Pedidos.BC.Unidades Cliente = new Pedidos.BC.Unidades();
            List<Aseguradora> obj = new List<Aseguradora>();

            try
            {
                string xmlRespuesta = Cliente.ObtenerAseguradoras();
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Aseguradora>));
                obj = (List<Aseguradora>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<TipoPlacas> ObtenerTipoPlaca()
        {
            Metodo = "ObtenerTipoPlaca";
            Pedidos.BC.Unidades Cliente = new Pedidos.BC.Unidades();
            List<TipoPlacas> obj = new List<TipoPlacas>();

            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<TipoPlacas>));
                string xmlRespuesta = Cliente.ObtenerTipoPlaca();
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                obj = (List<TipoPlacas>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<TipoCombustible> ObtenerTipoCombustible()
        {
            Metodo = "ObtenerTipoCombustible";
            Pedidos.BC.Unidades Cliente = new Pedidos.BC.Unidades();


            List<TipoCombustible> obj = new List<TipoCombustible>();
            try
            {
                string xmlRespuesta = Cliente.ObtenerTipoCombustible();
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<TipoCombustible>));
                obj = (List<TipoCombustible>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<MovimientoCr> BuscaMovimientoCR(int IdUnidad)
        {
            List<MovimientoCr> obj = new List<MovimientoCr>();
            Pedidos.BC.Unidades Cliente = new Pedidos.BC.Unidades();
            Metodo = "BuscaMovimientoCR";
            try
            {
                obj = new List<MovimientoCr>();
                obj = Cliente.BuscaMovimientoCR(IdUnidad);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public List<MarcaCamion> ObtenerMarcaCamion()
        {
            List<MarcaCamion> obj = new List<MarcaCamion>();
            Pedidos.BC.Unidades Cliente = new Pedidos.BC.Unidades();
            Metodo = "ObtenerMarcaCamion";
            try
            {
                string xmlRespuesta = Cliente.ObtenerMC();
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<MarcaCamion>));
                obj = (List<MarcaCamion>)xs.Deserialize(new StringReader(xmlRespuesta));
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
