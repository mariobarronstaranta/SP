using System;
using Concretec.Pedidos.BE;
using System.Collections.Generic;

namespace Concretec.Pedidos.BC
{
    public interface IUnidades
    {
        List<ConsultaUnidad> BuscaUnidadMovs(string idUnidad);
        bool InsertaPlaneacionUnidadPlantaDetalle(PlaneacionUnidadPlantaDetalle unidades);
        bool InsertaPlaneacionUnidad(PlaneacionUnidadPlanta planeacion, int Accion);
        bool InsertarMovCR(int IdUnidad, int IdPlantaOrigen, int IdPlantaDestino, DateTime Inicio, DateTime? Fin, int IdUsuario,string Comentario);
        List<MovimientoCr> BuscaMovimientoCR(int IdUnidad);
        bool InsertarUnidad(
                            string CveUnidad,
                            string CveAlterna,
                            bool Borrado,
                            int? Orden,
                            int? ACCION,
                            int? IDPersonal,
                            int? IDAseguradora,
                            int? IDPlanta,
                            string Poliza,
                            string Inciso,
                            DateTime? InicioVigencia,
                            DateTime? FinVigencia,
                            int? IDMarca,
                            int? IDTipoCombustible,
                            int? IDTipoPlacas,
                            int? IDCentroCostos,
                            bool Estatus,
                            int? Modelo,
                            string Motor,
                            string NumSerie,
                            string Placas,
                            string Ubicado,
                            string Propietario,
                            DateTime? VerificacionVehicular);

        bool ActUnidad(int IDUnidad,
                            string CveUnidad,
                            string CveAlterna,
                            bool Borrado,
                            int? Orden,
                            int? ACCION,
                            int? IDPersonal,
                            int? IDAseguradora,
                            int? IDPlanta,
                            string Poliza,
                            string Inciso,
                            DateTime? InicioVigencia,
                            DateTime? FinVigencia,
                            int? IDMarca,
                            int? IDTipoCombustible,
                            int? IDTipoPlacas,
                            int? IDCentroCostos,
                            bool Estatus,
                            int? Modelo,
                            string Motor,
                            string NumSerie,
                            string Placas,
                            string Ubicado,
                            string Propietario,
                            DateTime? VerificacionVehicular);

        List<Unidad> ValidaExisteUnidad(string CveUnidad, string CveCiudad, int IdUnidad);
        string BuscaUnidadesLibres(int idPlanta, int TipoViaje, DateTime FechaViaje, string HoraInicio, string HoraFin);
        string ValidaUnidadLibre(string Fecha, string Hora, int IdPlanta);
        string ObtenerBombasOcupadas(string CveCiudad, DateTime FechaPedido);
        string ObtenerUnidadesOcupadas(string CveCiudad, DateTime FechaPedido);
        string ObtenerUnidadesLibres(string CveCiudad, DateTime FechaPedido, DateTime FechaHoraPedido, int IDPlantaPadre);
        string ObtenerUnidadesClave(string Filtro);
        List<ConsultaUnidad> ObtenerUnidadesFiltro(string Filtro, string planta, string CveCiudad, int IdEstatus);
        string ObtenerBombas();
        string ObtenerUnidades();
        string ObtenerCentroCostos();
        string ObtenerAseguradoras();

        string ObtenerTipoPlaca();
        string ObtenerTipoCombustible();
        string ObtenerMC();
        List<ConsultaUnidad> LeerUnidadesMovs(string Filtro, string planta);
    }
}