using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Concretec.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUnidades" in both code and config file together.
    [ServiceContract]
    public interface IUnidades
    {
        [OperationContract]
        bool RegistraAjuste(int IdTanque, int IdTipoMovimiento, float valor, int IdUsuarioActualizacion, DateTime FechaMovimiento, string observaciones);

        [OperationContract]
        string BuscaAjustes(int idTanque, DateTime desde, DateTime hasta);

        [OperationContract]
        string BuscaConsumos(int idTanque, DateTime desde, DateTime hasta);
        
        [OperationContract]
        string BuscaLecturaEdicion(int IdLectura);

        [OperationContract]
        bool RegistraMovimientoOUT(int IdTanque, int IdTipoMovimiento, float valor, int IdUsuarioActualizacion, DateTime FechaMovimiento, DateTime HoraMovimiento, string proveedor, int IdUnidad, int IdOperador, float horimetro, float odometro);

        [OperationContract]
        string BuscaSalidaCombustibles(int idmovimiento,int idtanque, DateTime desde, DateTime hasta, string cveciudad,int idunidad,int idplanta);

        [OperationContract]
        string BuscaEntradaCombustibles(int idtanque, DateTime desde, DateTime hasta, string cveciudad, int idmovimiento);

        [OperationContract]
        bool RegistraMovimientoIN(int IdTanque, int IdTipoMovimiento, float valor, int IdUsuarioActualizacion, DateTime FechaMovimiento, string proveedor, string referencia);

        [OperationContract]
        bool ActualizaMovimientoIN(int idmovimiento, int IdTanque, int IdTipoMovimiento, float valor, int IdUsuarioActualizacion, DateTime FechaMovimiento, string proveedor, string referencia);

        [OperationContract]
        bool RegistraLectura(int IdTanque,DateTime fecha,DateTime hora , float valorlectura,int idusuario);

        [OperationContract]
        bool ActualizaLectura(int idlectura, int IdTanque, DateTime fecha, DateTime hora, float valorlectura, int idusuario);
        
        [OperationContract]
        string BuscaLecturas(string IdCiudad,int IdTanque,DateTime finicial,DateTime ffinal);
        
        [OperationContract]
        string BuscaTanquesCombo(string IdCiudad);

        [OperationContract]
        string BuscaTanques(int IdTanque,string IdCiudad,int IdTipoCombustible,string Nombre);

        [OperationContract]
        bool InsertaTanque(string Operacion, int IdTanque, string IdCiudad, int IdPlanta, int IdTipoCombustible, string Nombre, double capacidad, int idusuario);
        
        [OperationContract]
        string BuscaUnidadesLibres(int idPlanta, int TipoViaje, DateTime FechaViaje, string HoraInicio, string HoraFin);
        
        [OperationContract]
        string ValidaUnidadLibre(string Fecha,string Hora,int IdPlanta);
        
        [OperationContract]
        string ObtenerTipoCombustible();

        [OperationContract]
        string ObtenerTipoPlaca();

        [OperationContract]
        string ObtenerCentroCostos();

        [OperationContract]
        string ObtenerAseguradoras();

        [OperationContract]
        string ObtenerUnidadesLibres(string CveCiudad, DateTime FechaPedido, DateTime FechaHoraPedido, int IDPlantaPadre);

        [OperationContract]
        string ObtenerBombasOcupadas(string CveCiudad, DateTime FechaPedido);

        [OperationContract]
        string ObtenerUnidadesOcupadas(string CveCiudad, DateTime FechaPedido);

        [OperationContract]
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

        [OperationContract]
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
    
        [OperationContract]
        string ObtenerUnidades();

        [OperationContract]
        string ObtenerBombas();

        [OperationContract]
        string ObtenerUnidadesClave(string Filtro);

        [OperationContract]
        string ObtenerUnidadesFiltro(string Filtro, string planta, string CveCiudad);

        [OperationContract]
        string ValidaExisteUnidad(string CveUnidad);

            }
}
