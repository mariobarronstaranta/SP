using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.Constantes
{
    public class Mensajes
    {
        #region Mensajes Genericos
        //Mensajes Genericos
        public const string REGISTRO_EXITOSO        = "Registro guardado con éxito.";
        public const string REGISTRO_ACT_EXITOSO    = "Registro actualizado con éxito.";
        public const string REGISTRO_FALLIDO        = "Ocurrió un error al guardar sus datos favor de intentar más tarde. Reportelo a su administrador";
        public const string USUARIO_FALLIDO         = "El usuario o el password son incorrectos.";
        public const string CAPTURAR_CAMPOS_REQ     = "Es necesario capturar todos los campos";
        public const string ERROR_IMPRIMIR          = "No es posible realizar la impresión";
        public const string PERMISOS_ERROR          = "No cuenta con permisos suficientes para ejecutar esta acción";
        public const string ERROR_CONSULTA          = "Error al procesar la consulta";
        public const string MSG_SIN_RESULTADOS      = "No se encontró información relacionada a la búsqueda.";
        public const string MSG_SYNC_EXITO          = "Los datos fueron sincronizados con éxito";
        public const string MSG_SYNC_FALLA          = "Ocurrió un error al sincronizar los datos.Reportar con su administrador";
        public const string MSG_ACT_FALLO           = "Ocurrio un error al actualizar el(los) Registro(s)";
        public const string MSG_EXISTE_CVE_EMPLEADO = "La Clave de Empleado ya existe en el catalogo";
        #endregion

        #region Mensajes Especificos
        //Mensajes Especificos
        public const string EXITO_DEL_VIAJE         = "El viaje ha sido removido con éxito";
        public const string FACTURA_BUSQUEDA_CAMPO  = "Campo Factura es requerido para la búsqueda";
        public const string VIAJE_NO_REMISIONADO    = "El viaje no se encuentra remisionado";
        public const string ERROR_HORA_COLADO       = "La hora compromiso pertenece al colado nocturno favor de verificar";
        public const string ERROR_DEL_VIAJE         = "Ocurrió un error al eliminar los viajes.";
        public const string DOSIF_OCUPADA           = "La dosificadora se encuentra ocupada en la hora seleccionada";
        public const string PEDIDO_ENVIADO_AUT      = "El Pedido ha sido enviado para su autorización.";
        public const string PEDIDO_GUARDADO_EXITO   = "El Pedido se ha guardado con éxito con el numero ";
        public const string VIAJES_EXITO            = "Los viajes se han guardado con éxito.";
        public const string ERROR_GUARDAR_VIAJES    = "Ha sucedido un error al guardar los viajes. Reportar a su administrador";
        public const string ERROR_CARGA_PEDIDO      = "Ha excedido la carga máxima del Pedido";
        public const string ERROR_CARGA_MIN         = "El volumen de la carga no puede ser menor a 0.5 m3";
        public const string ERROR_CREDITO_INSUFICIENTE = "El cliente no cuenta con crédito disponible suficiente, es necesario la autorización del área de contabilidad";
        public const string ERROR_CAPTURA_HF_COMP   = "Es requerido capturar la Fecha y Hora Compromiso del Pedido";
        public const string VAL_TIEMPO_VIAJE        = "La Hora final del viaje debera ser al menos 30 minutos mayor que el inicio";
        public const string VIAJE_GUARDAR_EXITO     = "El viaje se ha guardado con éxito.";
        public const string MSG_PEDIDO_CERRADO      = "El pedido ha sido cerrado con éxito";
        public const string MSG_RESTR_REMISION      = "Solo es posible remisionar pedidos de Ayer y Hoy";
        public const string MSG_PEDIDO_DENEGADO     = "El Pedido ha sido actualizado al estatus Denegado para su autorización";
        public const string MSG_ERROR_FECHA_PEDIDO  = "La Fecha de entrega no puede ser anterior al día de hoy";
        public const string MSG_ERROR_CARGAR_OBRAS  = "Ocurrió un error al cargar el archivo de obras";
        public const string MSG_REASIGNACION_UNIDAD_EXITO = "Los Viajes de la Unidad han sido reasignados con éxito";
        public const string MSG_REASIGNACION_UNIDAD_FALLO = "No es Posible reasignar todos los viajes de la unidad";
        public const string MSG_REASIGNA_VIAJES_NO_EXISTE = "No existen viajes a reorganizar para el CR seleccionado";
        public const string MSG_CANCELACION_DEPURACION = "Ha sido cancelado correctamente la depuracion programada";
        public const string MSG_ERROR_DEPURACION    = "Solo es posible cancelar la programacion de los registros Programados";
        public const string MSG_ERROR_CANCELA_PEDIDO = "Ocurrio un error al cancelar el pedido. Reporte a su Administrador";
        public const string MSG_CANCELA_PEDIDO      = "El Pedido ha sido cancelado con exito";
        public const string MSG_ERROR_OBRAS_ACT     = "Solo es posible programar pedidos de obras Activas";
        public const string MSG_ERROR_ELIMINAR_PEDIDO = "Ocurrió un error al eliminar el Pedido ";
        public const string MSG_ERROR_PLANTAS_IGUALES = "Las plantas seleccionadas no pueden ser iguales";
        #endregion

        #region Frases
        //Mensajes Complementos FRASES
        public const string YA_EXISTE               = " ya existe, favor de verificar";
        public const string EL_CLIENTE              = "El Cliente ";
        public const string LA_UNIDAD               = "La Unidad ";
        public const string LA_OBRA                 = "La obra ";
        public const string EL_PEDIDO               = "El Pedido ";
        public const string EXITOSAMENTE            = " exitosamente";
        public const string AUTORIZACION_PREVIA     = " Ha sido previamente autorizado";
        public const string AUTORIZACION_EXITO      = " Ha sido autorizado exitosamente";
        public const string MSG_AUTORIZACION_FALLO  = "  ha sido bloqueado para su autorización.";
        public const string MSG_ENVIADO_CONTA       = " ha sido enviado para autorizacion por parte de contabilidad previamente";
        public const string NUMERO_PEDIDO           = "Con el número de Pedido ";
        public const string MSG_VIAJES_PEDIDO       = "Los Viajes del Pedido ";
        public const string MSG_ELIMINADOS_EXITO    = "ha(n) sido eliminado(s) correctamente";
        public const string MSG_YA_AUTORIZADO       = " ya se encuentra autorizado";
        public const string MSG_RECHAZADO           = " fue rechazado";
        public const string PEDIDOS_CLIENTE         = "Los Pedidos del Cliente ";
        public const string MSG_CALENDARIZADOS      = ", han sido calendarizados para su eliminación";
        public const string MSG_NO_CALENDARIZADOS   = ", no pudieron ser calendarizados para su eliminación";
        public const string MSG_CUENTA_CON          = " cuenta con ";
        public const string MSG_PLANTA_DESTINO = " ,Seleccione una Planta Destino";
        public const string MSG_SEL_PLANTA          = ", Es necesario seleccionar una planta";
        public const string MSG_SEL_COMENTARIO_CAMBIO =", Es necesario seleccionar un Comentario motivo del cambio";
        public const string MSG_REASINGE_VIAJES     = " viajes asignados, reasignelos antes de cambiar de Planta";
        public const string MSG_MANERA_MANUAL = "ES NECESARIO PROGRAMAR DE MANERA MANUAL ";
        public const string MSG_MANERA_MANUAL_FULL = "NO FUE POSIBLE ASIGNAR TODAS LAS CARGAS , ES NECESARIO REPROGRAMAR DE MANERA MANUAL ";

        #endregion

        #region Combos
        public const string CBO_SELECCIONE = "(Seleccione)";
        #endregion
    }
}
