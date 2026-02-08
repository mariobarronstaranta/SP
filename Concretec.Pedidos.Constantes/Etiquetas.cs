using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.Constantes
{
    public class Etiquetas
    {
        public const string TAG_VERSION = "Programacion de Pedidos V 2.5";
        public const string TAG_MINUS_ONE = "-1";
        public const string TAG_M3 = "M3";
        public const string TAG_SI = "SI";
        public const string TAG_NO = "NO";
        public const string TAG_TODOS_PAR = "(Todos)";
        public const string TAG_PREFIJO_DOSIFICADORA = "PD";
        //Concretec.Pedidos.Constantes.Etiquetas.


        #region Acciones / Estatus

        public const string TAG_EN_AUTORIZACION_SH = "EAUT";
        public const string TAG_AUTORIZADO_SH   = "AUT";
        public const string TAG_CANCELAR_SH     = "CAN";
        public const string TAG_RECHAZADO_SH    ="REC";

        public const string REGRESAR = "Regresar";
        
        public const string TAG_EN_AUTORIZACION = "En Autorizacion";
        public const string TAG_VER = "Ver";
        public const string TAG_HABILITAR = "Habilitar";
        public const string TAG_AUTORIZADO = "Autorizado";
        public const string TAG_RECHAZADO = "Rechazado";
        public const string TAG_FILE_CONTINGENCIAS = "Contingencias";
        public const string TAG_DETALLE = "Detalle";

        public const string TAR_AGREGAR = "Agregar";
        public const string TAG_CANCELAR = "Cancelar";

        public const string TAG_ACTUALIZADO = "Actualizado";
        public const string TAG_INSERTADO = "Insertado";
        public const string TAG_EDITAR = "Editar";
        public const string TAG_EDICION = "Edicion";
        public const string TAG_CERRAR = "Cerrar";
        public const string TAG_PROGRAMACION = "Programacion";
        public const string TAG_PROG = "Prog";
        public const string TAG_SEGUIMIENTO = "Seguimiento";

        #endregion

        #region Perfiles
        public const string TAG_PERFIL_ADMON            = "Admon";
        public const string TAG_PERFIL_CONTABILIDAD     = "CONTA";
        public const string TAG_PERFIL_CONSULTA         = "CON";
        public const string TAG_PERFIL_PROGRAMADOR      = "PROG";
        public const string TAG_PERFIL_VENDEDOR         = "VEN";
        public const string TAG_PERFIL_JEFEP            = "JFP";
        #endregion

        #region Meses
        public const string TAG_MES_ENERO       = "Enero";
        public const string TAG_MES_FEBRERO     = "Febrero";
        public const string TAG_MES_MARZO       = "Marzo";
        public const string TAG_MES_ABRIL       = "Abril";
        public const string TAG_MES_MAYO        = "Mayo";
        public const string TAG_MES_JUNIO       = "Junio";
        public const string TAG_MES_JULIO       = "Julio";
        public const string TAG_MES_AGOSTO      = "Agosto";
        public const string TAG_MES_SEPTIEMBRE  = "Septiembre";
        public const string TAG_MES_OCTUBRE     = "Octubre";
        public const string TAG_MES_NOVIEMBRE   = "Noviembre";
        public const string TAG_MES_DICIEMBRE   = "Diciembre";
        #endregion

        #region Ciudades
        public const string TAG_MONTERREY       = "Monterrey";
        public const string TAG_MONTERREY_SH    = "MTY";
        public const string TAG_AGUASCALIENTES  = "Aguascalientes";
        public const string TAG_AGUASCALIENTES_SH = "AGS";
        public const string TAG_GUADALAJARA     = "Guadalajara";
        public const string TAG_GUADALAJARA_SH  = "GDL";
        public const string TAG_LEON            = "Leon";
        public const string TAG_LEON_SH         = "LEON";
        public const string TAG_PUEBLA          = "Puebla";
        public const string TAG_PUEBLA_SH       = "PUE";
        public const string TAG_QUERETARO       = "Queretaro";
        public const string TAG_QUERETARO_SH    = "QRO";
        #endregion

        #region Variables de Sesion
        public const string TAG_SESSION_DATOSUSUSARIO = "DatosUsuario";
        public const string TAG_SESSION_MP = "MP";
        #endregion


        #region Paginas Relativas
        public const string TAG_REL_PAG_DEFAULT = "../Default.aspx";
        public const string TAG_REL_PAG_LCLIENTES = "Views/ListaClientes.aspx";
        public const string TAG_REL_PAG_CALIBRACION = "Views/Cablibracion.aspx";
        public const string TAG_REL_PAG_PERSONAL = "Views/ListaPersonal.aspx";
        #endregion

        #region Master Pages
        public const string TAG_MP_ADMON            = "../Shared/MasterPage.master";
        public const string TAG_MP_CONTABILIDAD     = "../Shared/Contabilidad.master";
        public const string TAG_MP_OPERADOR         = "../Shared/Operador.master";
        public const string TAG_MP_JEFEPLANTA       = "../Shared/JefePlanta.master";
        public const string TAG_MP_CONSULTA         = "../Shared/Consulta.master";
        public const string TAG_MP_ADMON_PLANTAS    = "../Shared/AdmonPlantas.master";
        public const string TAG_MP_ADMON_PERSONAL   = "../Shared/RH.master";
        public const string TAG_MP_VENDEDOR         = "../Shared/Vendedor.master";
        public const string TAG_MP_CARTA_PORTE      = "../Shared/MP_CP.master";
        #endregion
    }
}
