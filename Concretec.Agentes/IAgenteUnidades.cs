using System;
using System.Collections.Generic;
using Concretec.Pedidos.BE;

namespace Concretec.Agentes
{
    public interface IAgenteUnidades
    {
        List<ConsultaUnidad> BuscaUnidadMovs(string idUnidad);
        bool InsertaPlaneacionUnidadPlantaDetalle(PlaneacionUnidadPlantaDetalle unidades);
        //bool InsertaPlaneacionUnidad(PlaneacionUnidadPlanta planeacion, int Accion);
        bool InsertaPlaneacionUnidad(ConsultaUnidad unidad);
        bool ActualizaLectura(int idlectura, int IdTanque, DateTime fecha, DateTime hora, float valorlectura, int idusuario,int temperatura,int lecturacms);
        bool ActualizaMovimientoIN(int idmovimiento, int IdTanque, int IdTipoMovimiento, float valor, int IdUsuarioActualizacion, DateTime FechaMovimiento, string proveedor, string referencia);
        bool ActUnidad(int IDUnidad, string IDClaveUnidad, string CveAlterna, bool Borrado, int? Orden, int? ACCION, int? IDPersonal, int? IDAseguradora, int? IDPlanta, string Poliza, string Inciso, DateTime? InicioVigencia, DateTime? FinVigencia, int? IDMarca, int? IDTipoCombustible, int? IDTipoPlacas, int? IDCentroCostos, bool Estatus, int? Modelo, string Motor, string NumSerie, string Placas, string Ubicado, string Propietario, DateTime? VerificacionVehicular);
        List<Tanque> BuscaAjustes(int idTanque, DateTime desde, DateTime hasta);
        List<Tanque> BuscaConsumos(int idTanque, DateTime desde, DateTime hasta);
        List<TanqueMovimiento> BuscaEntradaCombustibles(int idtanque, DateTime desde, DateTime hasta, string cveciudad, int idmovimiento);
        Lectura BuscaLecturaEdicion(int IdLectura);
        List<Lectura> BuscaLecturas(string IdCiudad, int IdTanque, DateTime finicial, DateTime ffinal);
        List<Lectura> BuscaLecturasII(string IdCiudad, int IdTanque, DateTime finicial, DateTime ffinal);
        List<MovimientoCr> BuscaMovimientoCR(int IdUnidad);
        List<TanqueMovimiento> BuscaSalidaEntradaCombustibles(int idmovimiento, int idtanque, DateTime desde, DateTime hasta, string cveciudad, int idunidad, int idplanta);
        List<Tanque> BuscaTanques(int IdTanque, string IdCiudad, int IdTipoCombustible, string Nombre);
        List<Tanque> BuscaTanquesCombo(int plantaid);
        List<ConsultaUnidad> BuscaUnidadesLibres(int idPlanta, int TipoViaje, DateTime FechaViaje, string HoraInicio, string HoraFin);
        bool InsertarMovCR(int IdUnidad, int IdPlantaOrigen, int IdPlantaDestino, DateTime Inicio, DateTime? Fin, int IdUsuario, string Comentario);
        bool InsertarUnidad(string IDClaveUnidad, string CveAlterna, bool Borrado, int? Orden, int? ACCION, int? IDPersonal, int? IDAseguradora, int? IDPlanta, string Poliza, string Inciso, DateTime? InicioVigencia, DateTime? FinVigencia, int? IDMarca, int? IDTipoCombustible, int? IDTipoPlacas, int? IDCentroCostos, bool Estatus, int? Modelo, string Motor, string NumSerie, string Placas, string Ubicado, string Propietario, DateTime? VerificacionVehicular);
        bool InsertaTanque(string Operacion, int IdTanque, string IdCiudad, int IdPlanta, int IdTipoCombustible,
                                    string Nombre, double capacidad, int idusuario,
                                    decimal Altura, string Forma, decimal DiametroA, decimal DiametroB);
        List<ConsultaUnidad> LeerUnidadClave(string Clave);
        List<Aseguradora> ObtenerAseguradoras();
        List<ConsultaUnidad> ObtenerBombas();
        List<ConsultaUnidad> ObtenerBombasOcupadas(string CveCiudad, DateTime FechaPedido);
        List<CentroCostos> ObtenerCentroCostos();
        List<MarcaCamion> ObtenerMarcaCamion();
        List<TipoCombustible> ObtenerTipoCombustible();
        List<TipoPlacas> ObtenerTipoPlaca();
        List<ConsultaUnidad> ObtenerUnidadesFiltro(string filtro, string planta, string CveCiudad, int IdEstatus);
        List<ConsultaUnidad> ObtenerUnidadesLibres(string CveCiudad, DateTime FechaPedido, DateTime FechaHoraPedido, int IDPlantaPadre);
        List<ConsultaUnidad> ObtenerUnidadesOcupadas(string CveCiudad, DateTime FechaPedido);
        List<ConsultaUnidad> ObtieneUnidad();
        bool RegistraAjuste(int IdTanque, int IdTipoMovimiento, float valor, int IdUsuarioActualizacion, DateTime FechaMovimiento, string observaciones);
        bool RegistraLectura(int IdTanque, DateTime fecha, DateTime hora, float valorlectura, int idusuario,int lectura,int lecturacms);
        bool RegistraMovimientoIN(int IdTanque, int IdTipoMovimiento, float valor, int IdUsuarioActualizacion, DateTime FechaMovimiento, string proveedor, string referencia);
        bool RegistraMovimientoOUT(int IdTanque, int IdTipoMovimiento, float valor, int IdUsuarioActualizacion, DateTime FechaMovimiento, DateTime HoraMovimiento, string proveedor, int IdUnidad, int IdOperador, float horimetro, float odometro,float temperatura);
        //string ValidaExisteUnidad(string CveUnidad,string CveCiudad, int IdUnidad);
        List<Unidad> ValidaExisteUnidad(string CveUnidad, string CveCiudad, int IdUnidad);
        List<Unidad> ValidaUnidadLibre(string Fecha, string Hora, int IdPlanta);
        List<ConsultaUnidad> LeerUnidadesMovs(string Filtro, string planta);
    }
}