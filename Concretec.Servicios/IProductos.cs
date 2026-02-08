using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Concretec.Pedidos.BE;

namespace Concretec.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductos" in both code and config file together.
    [ServiceContract]
    public interface IProductos
    {
        [OperationContract]
        bool InsertaCB2(string IdCB2, string Folio, string Fecha_Hora_Final, string Pta, string ID_Carga_Rem, string Fecha_Hora_Final_2, string Producto, string Codigo, string M3, string ID_Dosif_Pedido, string Vol_M3, string Manual, string CR, string Operador, string Fecha_Hora_Inicial, string Fecha_Hora_Final_3, string Ingr_1, string HuFac_1, string AbsFac_1, string Sec_1, string Abs_1, string SSS_1, string U_Med_1, string Acor_1, string M3_1, string Obj_1, string Real_1, string U_Med_1A, string Err_1, string Porcentaje_1, string Ingr_2, string HuFac_2, string AbsFac_2, string Sec_2, string Abs_2, string SSS_2, string U_Med_2, string Acor_2, string M3_2, string Obj_2, string Real_2, string U_Med_2A, string Err_2, string Porcentaje_2, string Ingr_3, string HuFac_3, string AbsFac_3, string Sec_3, string Abs_3, string SSS_3, string U_Mes_3, string Acor_3, string M3_3, string Obj_3, string Real_3, string U_Med_3, string Err_3, string Porcentaje_3, string Ingr_4, string HuFac_4, string AbsFac_4, string Sec_4, string Abs_4, string SSS_4, string U_Med_4, string Acor_4, string M3_4, string Obj_4, string Real_4, string U_Med_4A, string Err_4, string Porcentaje_4, string Ingr_5, string HuFac_5, string AbsFac_5, string Sec_5, string Abs_5, string SSS_5, string U_Med_5, string Acor_5, string M3_5, string Obj_5, string Real_5, string U_Med_5A, string Err_5, string Porcentaje_5, string Ingr_6, string HuFac_6, string AbsFac_6, string Sec_6, string Abs_6, string SSS_6, string U_Med_6, string Acor_6, string M3_6, string Obj_6, string Real_6, string U_Med_6A, string Err_6, string Porcentaje_6, string Ingr_7, string HuFac_7, string AbsFac_7, string Sec_7, string Abs_7, string SSS_7, string U_Med_7, string Acor_7, string M3_7, string Obj_7, string Real_7, string U_Med_7A, string Err_7, string Porcentaje_7, string Ingr_8, string HuFac_8, string AbsFac_8, string Sec_8, string Abs_8, string SSS_8, string U_Med_8, string Acor_8, string M3_8, string Obj_8, string Real_8, string U_Med_8A, string Err_8, string Porcentaje_8, string Ingr_9, string HuFac_9, string AbsFac_9, string Sec_9, string Abs_9, string SSS_9, string U_Med_9, string Acor_9, string M3_9, string Obj_9, string Real_9, string U_Med_9A, string Err_9, string Porcentaje_9, string Ingr_10, string HuFac_10, string AbsFac_10, string Sec_10, string Abs_10, string SSS_10, string U_Med_10, string Acor_10, string M3_10, string Obj_10, string Real_10, string U_Med_10A, string Err_10, string Porcentaje_10, string Ingr_11, string HuFac_11, string AbsFac_11, string Sec_11, string Abs_11, string SSS_11, string U_Med_11, string Acor_11, string M3_11, string Obj_11, string Real_11, string U_Med_11A, string Err_11, string Porcentaje_11, string Ingr_12, string HuFac_12, string AbsFac_12, string Sec_12, string Abs_12, string SSS_12, string U_Med_12, string Acor_12, string M3_12, string Obj_12, string Real_12, string U_Med_12B, string Err_12, string Porcentaje_12, string Ingr_13, string HuFac_13, string AbsFac_13, string Sec_13, string Abs_13, string SSS_13, string U_Med_13, string Acor_13, string M3_13, string Obj_13, string Real_13, string U_Med_13A, string Err_13, string Porcentaje_13, string Ingr_14, string HuFac_14, string AbsFac_14, string Sec_14, string Abs_14, string SSS_14, string U_Med_14, string Acor_14, string M3_14, string Obj_14, string Real_14, string U_Med_14A, string Err_14, string Porcentaje_14, string Ingr_15, string HuFac_15, string AbsFac_15, string Sec_15, string Abs_15, string SSS_15, string U_Med_15, string Acor_15, string M3_15, string Obj_15, string Real_15, string U_Med_15A, string Err_15, string Porcentaje_15, string Ingr_16, string HuFac_16, string AbsFac_16, string Sec_16, string Abs_16, string SSS_16, string U_Med_16, string Acor_16, string M3_16, string Obj_16, string Real_16, string U_Med_16A, string Err_16, string Porcentaje_16, string Ingr_17, string HuFac_17, string AbsFac_17, string Sec_17, string Abs_17, string SSS_17, string U_Med_17, string Acor_17, string M3_17, string Obj_17, string Real_17, string U_Med_17A, string Err_17, string Porcentaje_17, string Ingr_18, string HuFac_18, string AbsFac_18, string Sec_18, string Abs_18, string SSS_18, string U_Med_18, string Acor_18, string M3_18, string Obj_18, string Real_18, string U_Med_18A, string Err_18, string Porcentaje_18, string Ingr_19, string HuFac_19, string AbsFac_19, string Sec_19, string Abs_19, string SSS_19, string U_Med_19, string Acor_19, string M3_19, string Obj_19, string Real_19, string U_Med_19A, string Err_19, string Porcentaje_19, string Rev, string Agua_Ajuste, string Rel_Agua_Cem);

        [OperationContract]
        bool InsertarProducto(int IDProducto, string ClaveProducto, string Descripcion, string Unidad, double Precio, bool Borrado, string Observaciones, bool EsComplemento, int Accion, string ClaveAlterna, string CveCiudad, string Clasificacion);

        [OperationContract]
        bool ActualizarProducto(int IDProducto, string ClaveProducto, string Descripcion, string Unidad, double Precio, bool Borrado, string Observaciones, bool EsComplemento);
        
        [OperationContract]
        string ObtenerProductos(int Complemento, string CveCiudad);

        [OperationContract]
        string ObtenerProductosComplemento();

        [OperationContract]
        string ObtenerProductosFiltro(string _filtro,string clasificacion,string CveCiudad);

        [OperationContract]
        string ObtenerProductosComplementoFiltro(string Filtro);

        [OperationContract]
        List<Producto> ObtieneProductos_Aspel(string CveCiudad);

        [OperationContract]
        bool ActualizaProductos(string CveCiudad);

        [OperationContract]
        bool SyncProductos(string CveCiudad);

        [OperationContract]
        bool ActualizaProductosCiudad(string CveCiudad);
    }
}
