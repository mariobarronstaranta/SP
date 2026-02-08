using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class Calibracion
    {
        public int CalibracionId { set; get; }
        public string CveCiudad { set; get; }
        public int PlantaId { set; get; }
        public DateTime Fecha { set; get; }
        public DateTime Hora { set; get; }
        public string RegistradoPor { set; get; }
        public string Material { set; get; }
        public string NombrePlanta { set; get; }
        // Campos para Cemento
        public float CEM_CB2_Alto { set; get; }
        public float CEM_CB2_Bajo { set; get; }
        public float CEM_TEO_Alto { set; get; }
        public float CEM_TEO_Bajo { set; get; }
        public float CEM_ERR_Alto { set; get; }
        public float CEM_ERR_Bajo { set; get; }
        // Campos para Agregados
        public float AGR_CB2_Alto { set; get; }
        public float AGR_CB2_Bajo { set; get; }
        public float AGR_TEO_Alto { set; get; }
        public float AGR_TEO_Bajo { set; get; }
        public float AGR_ERR_Alto { set; get; }
        public float AGR_ERR_Bajo { set; get; }
        // Campos para AGUA
        public float AGU_CB2_Alto { set; get; }
        public float AGU_CB2_Bajo { set; get; }
        public float AGU_TEO_Alto { set; get; }
        public float AGU_TEO_Bajo { set; get; }
        public float AGU_ERR_Alto { set; get; }
        public float AGU_ERR_Bajo { set; get; }
        // Campos para Aditivo 01
        public float AD1_CB2_Alto { set; get; }
        public float AD1_CB2_Bajo { set; get; }
        public float AD1_TEO_Alto { set; get; }
        public float AD1_TEO_Bajo { set; get; }
        public float AD1_ERR_Alto { set; get; }
        public float AD1_ERR_Bajo { set; get; }
        // Campos para Aditivo 02
        public float AD2_CB2_Alto { set; get; }
        public float AD2_CB2_Bajo { set; get; }
        public float AD2_TEO_Alto { set; get; }
        public float AD2_TEO_Bajo { set; get; }
        public float AD2_ERR_Alto { set; get; }
        public float AD2_ERR_Bajo { set; get; }
        // Campos para Aditivo 03
        public float AD3_CB2_Alto { set; get; }
        public float AD3_CB2_Bajo { set; get; }
        public float AD3_TEO_Alto { set; get; }
        public float AD3_TEO_Bajo { set; get; }
        public float AD3_ERR_Alto { set; get; }
        public float AD3_ERR_Bajo { set; get; }
        // Campos para Aditivo 04
        public float AD4_CB2_Alto { set; get; }
        public float AD4_CB2_Bajo { set; get; }
        public float AD4_TEO_Alto { set; get; }
        public float AD4_TEO_Bajo { set; get; }
        public float AD4_ERR_Alto { set; get; }
        public float AD4_ERR_Bajo { set; get; }
        // Campos para Aditivo 04
        public float AD5_CB2_Alto { set; get; }
        public float AD5_CB2_Bajo { set; get; }
        public float AD5_TEO_Alto { set; get; }
        public float AD5_TEO_Bajo { set; get; }
        public float AD5_ERR_Alto { set; get; }
        public float AD5_ERR_Bajo { set; get; }
        // Campos Control

        public DateTime FechaRegistro { set; get; }
        public int UsuarioId { set; get; }
        public string NombreUsuario { set; get; }

        #region CamposSalida
        public float TEO_Bajo { set; get; }
        public float CB2_Bajo { set; get; }
        public float ERROR_Bajo { set; get; }
        public float TEO_Alto { set; get; }
        public float CB2_Alto { set; get; }
        public float ERROR_Alto { set; get; }

        public string fechasalida { set; get; }
        public string horasalida { set; get; }
        #endregion
    }
}
