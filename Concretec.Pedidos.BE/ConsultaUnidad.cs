using System;

namespace Concretec.Pedidos.BE
{
    public class ConsultaUnidad
    {
        public int IDUnidad
        { set; get; }

        public int IDEstatus
        { set; get; }

        public int IDEstatusUnidad
        { set; get; }

        public string Estatus
        { set; get; }

        public int IDPedido
        { set; get; }

        public int CveCliente
        { set; get; }

        public string CveAlterna
        { set; get; }

        public string IDClaveUnidad
        { set; get; }

        public bool Borrado
        { set; get; }

        public string Marca
        { set; get; }

        public int IDMarca
        { set; get; }

        public string Modelo
        { set; get; }

        public string Motor
        { set; get; }

        public string NumSerie
        { set; get; }

        public int IDAseguradora
        { set; get; }

        public int IDCentroCostos
        { set; get; }

        public int IDTipoPlacas
        { set; get; }

        public string Placas
        { set; get; }

        public int IdOperador
        { set; get; }

        public int CveObra
        { set; get; }

        public int IdPlanta
        { set; get; }

        public string Planta
        { set; get; }

        public string NombreObra
        { set; get; }

        public int IDTipoCombustible
        { set; get; }

        public string TipoCobustible
        { set; get; }
        

        public string Propietario
        { set; get; }

        public string Ubicado
        { set; get; }

        public DateTime VerificacionVehicular
        { set; get; }

        public string Aseguradora
        { set; get; }

        public DateTime  InicioVigencia
        { set; get; }

        public DateTime FinVigencia
        { set; get; }

        public string Inciso
        { set; get; }

        public string Poliza
        { set; get; }

        public string NombreOperador
        { set; get; }

        public string NombreCliente
        { set; get; }

        public string CveCiudad
        { set; get; }

        public string CveDosificadora
        { set; get; }

        public string horaminutos_inicio
        { set; get; }

        public string horaminutos_fin
        { set; get; }

        public string CveProducto
        { set; get; }

        public string CveAlternaProducto
        { set; get; }

        public string NombreProducto
        { set; get; }

        public DateTime fechapedido
        { set; get; }

        public int numviaje
        { set; get; }

        public int bloques
        { set; get; }

        public int carga
        { set; get; }

        public string CentroCostos
        { set; get; }
        public string TipoPlacas
        { set; get; }

        public string ProgramadoPor
        { set; get; }

        // Aqui se agregan las propiedades necesarias para poder ser compilance con la planeacion de las unidades

        public int EstatusPlaneacion
        { set; get; }

        public int MotivoInactividad
        { set; get; }

        public string StrMotivoInactividad
        { set; get; }

        public int MotivoCambioOperador
        { set; get; }

        public string StrMotivoCambioOperador
        { set; get; }

        public int IdUsuario
        { set; get; }
    }
}
