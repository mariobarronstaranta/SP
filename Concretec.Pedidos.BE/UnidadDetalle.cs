using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class UnidadDetalle
    {
        public int IDUnidad
        { set; get; }

        public int IDClaveUnidad
        { set; get; }

        public int ClaveAlterna
        { set; get; }

        public int IDPlanta
        { set; get; }

        public int IDMarca
        { set; get; }

        public int IDTipoCombustible
        { set; get; }

        public int IDTipoPlacas
        { set; get; }

        public int IDCentroCostos
        { set; get; }

        public bool Estatus
        { set; get; }

        public string Modelo
        { set; get; }

        public string Motor
        { set; get; }

        public string NumSerie
        { set; get; }

        public string Placas
        { set; get; }

        public string Ubicado
        { set; get; }

        public string Propietario
        { set; get; }

        public string VerificacionVehicular
        { set; get; }

        public string NombrePlanta
        { set; get; }
    }
}
