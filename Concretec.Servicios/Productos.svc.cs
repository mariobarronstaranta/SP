using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Concretec.Pedidos.Utils;
using Concretec.Pedidos.BE;
using System.ServiceModel.Activation;
namespace Concretec.Servicios
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Productos" in code, svc and config file together.
    public class Productos : IProductos
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        string Aplicacion = "Programacion de Pedidos V 2.0";
        string Servicio = "Productos.svc";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return ConfigurationManager.ConnectionStrings["cnConcretec"].ConnectionString; }
        }


        private string CN_AspelMty
        {
            get
            { return ConfigurationManager.ConnectionStrings["cnAspelSQLMTY"].ConnectionString; }
        }

        private string CN_AspelGdl
        {
            get
            { return ConfigurationManager.ConnectionStrings["cnAspelSQLGDL"].ConnectionString; }
        }

        private string CN_AspelAgs
        {
            get
            { return ConfigurationManager.ConnectionStrings["cnAspelSQLAGS"].ConnectionString; }
        }

        private string CN_AspelLeon
        {
            get
            { return ConfigurationManager.ConnectionStrings["cnAspelSQLLEON"].ConnectionString; }
        }

        private string CN_AspelPuebla
        {
            get
            { return ConfigurationManager.ConnectionStrings["cnAspelSQLPUEBLA"].ConnectionString; }
        }

        public bool InsertaCB2(string IdCB2, string Folio, string Fecha_Hora_Final, string Pta, string ID_Carga_Rem, string Fecha_Hora_Final_2, string Producto, string Codigo, string M3, string ID_Dosif_Pedido, string Vol_M3, string Manual, string CR, string Operador, string Fecha_Hora_Inicial, string Fecha_Hora_Final_3, string Ingr_1, string HuFac_1, string AbsFac_1, string Sec_1, string Abs_1, string SSS_1, string U_Med_1, string Acor_1, string M3_1, string Obj_1, string Real_1, string U_Med_1A, string Err_1, string Porcentaje_1, string Ingr_2, string HuFac_2, string AbsFac_2, string Sec_2, string Abs_2, string SSS_2, string U_Med_2, string Acor_2, string M3_2, string Obj_2, string Real_2, string U_Med_2A, string Err_2, string Porcentaje_2, string Ingr_3, string HuFac_3, string AbsFac_3, string Sec_3, string Abs_3, string SSS_3, string U_Mes_3, string Acor_3, string M3_3, string Obj_3, string Real_3, string U_Med_3, string Err_3, string Porcentaje_3, string Ingr_4, string HuFac_4, string AbsFac_4, string Sec_4, string Abs_4, string SSS_4, string U_Med_4, string Acor_4, string M3_4, string Obj_4, string Real_4, string U_Med_4A, string Err_4, string Porcentaje_4, string Ingr_5, string HuFac_5, string AbsFac_5, string Sec_5, string Abs_5, string SSS_5, string U_Med_5, string Acor_5, string M3_5, string Obj_5, string Real_5, string U_Med_5A, string Err_5, string Porcentaje_5, string Ingr_6, string HuFac_6, string AbsFac_6, string Sec_6, string Abs_6, string SSS_6, string U_Med_6, string Acor_6, string M3_6, string Obj_6, string Real_6, string U_Med_6A, string Err_6, string Porcentaje_6, string Ingr_7, string HuFac_7, string AbsFac_7, string Sec_7, string Abs_7, string SSS_7, string U_Med_7, string Acor_7, string M3_7, string Obj_7, string Real_7, string U_Med_7A, string Err_7, string Porcentaje_7, string Ingr_8, string HuFac_8, string AbsFac_8, string Sec_8, string Abs_8, string SSS_8, string U_Med_8, string Acor_8, string M3_8, string Obj_8, string Real_8, string U_Med_8A, string Err_8, string Porcentaje_8, string Ingr_9, string HuFac_9, string AbsFac_9, string Sec_9, string Abs_9, string SSS_9, string U_Med_9, string Acor_9, string M3_9, string Obj_9, string Real_9, string U_Med_9A, string Err_9, string Porcentaje_9, string Ingr_10, string HuFac_10, string AbsFac_10, string Sec_10, string Abs_10, string SSS_10, string U_Med_10, string Acor_10, string M3_10, string Obj_10, string Real_10, string U_Med_10A, string Err_10, string Porcentaje_10, string Ingr_11, string HuFac_11, string AbsFac_11, string Sec_11, string Abs_11, string SSS_11, string U_Med_11, string Acor_11, string M3_11, string Obj_11, string Real_11, string U_Med_11A, string Err_11, string Porcentaje_11, string Ingr_12, string HuFac_12, string AbsFac_12, string Sec_12, string Abs_12, string SSS_12, string U_Med_12, string Acor_12, string M3_12, string Obj_12, string Real_12, string U_Med_12B, string Err_12, string Porcentaje_12, string Ingr_13, string HuFac_13, string AbsFac_13, string Sec_13, string Abs_13, string SSS_13, string U_Med_13, string Acor_13, string M3_13, string Obj_13, string Real_13, string U_Med_13A, string Err_13, string Porcentaje_13, string Ingr_14, string HuFac_14, string AbsFac_14, string Sec_14, string Abs_14, string SSS_14, string U_Med_14, string Acor_14, string M3_14, string Obj_14, string Real_14, string U_Med_14A, string Err_14, string Porcentaje_14, string Ingr_15, string HuFac_15, string AbsFac_15, string Sec_15, string Abs_15, string SSS_15, string U_Med_15, string Acor_15, string M3_15, string Obj_15, string Real_15, string U_Med_15A, string Err_15, string Porcentaje_15, string Ingr_16, string HuFac_16, string AbsFac_16, string Sec_16, string Abs_16, string SSS_16, string U_Med_16, string Acor_16, string M3_16, string Obj_16, string Real_16, string U_Med_16A, string Err_16, string Porcentaje_16, string Ingr_17, string HuFac_17, string AbsFac_17, string Sec_17, string Abs_17, string SSS_17, string U_Med_17, string Acor_17, string M3_17, string Obj_17, string Real_17, string U_Med_17A, string Err_17, string Porcentaje_17, string Ingr_18, string HuFac_18, string AbsFac_18, string Sec_18, string Abs_18, string SSS_18, string U_Med_18, string Acor_18, string M3_18, string Obj_18, string Real_18, string U_Med_18A, string Err_18, string Porcentaje_18, string Ingr_19, string HuFac_19, string AbsFac_19, string Sec_19, string Abs_19, string SSS_19, string U_Med_19, string Acor_19, string M3_19, string Obj_19, string Real_19, string U_Med_19A, string Err_19, string Porcentaje_19, string Rev, string Agua_Ajuste, string Rel_Agua_Cem)
        {
            Metodo = "InsertaCB2";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("InsertaCB2", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdCB2", IdCB2);
            command.Parameters.AddWithValue("@Folio", Folio);
            command.Parameters.AddWithValue("@Fecha_Hora_Final", Fecha_Hora_Final);
            command.Parameters.AddWithValue("@Pta", Pta);
            command.Parameters.AddWithValue("@ID_Carga_Rem", ID_Carga_Rem);
            command.Parameters.AddWithValue("@Fecha_Hora_Final_2", Fecha_Hora_Final_2);
            command.Parameters.AddWithValue("@Producto", Producto);
            command.Parameters.AddWithValue("@Codigo", Codigo);
            command.Parameters.AddWithValue("@M3", M3);
            command.Parameters.AddWithValue("@ID_Dosif_Pedido", ID_Dosif_Pedido);
            command.Parameters.AddWithValue("@Vol_M3", Vol_M3);
            command.Parameters.AddWithValue("@Manual", Manual);
            command.Parameters.AddWithValue("@CR", CR);
            command.Parameters.AddWithValue("@Operador", Operador);
            command.Parameters.AddWithValue("@Fecha_Hora_Inicial", Fecha_Hora_Inicial);
            command.Parameters.AddWithValue("@Fecha_Hora_Final_3", Fecha_Hora_Final_3);
            command.Parameters.AddWithValue("@Ingr_1", Ingr_1);
            command.Parameters.AddWithValue("@HuFac_1", HuFac_1);
            command.Parameters.AddWithValue("@AbsFac_1", AbsFac_1);
            command.Parameters.AddWithValue("@Sec_1", Sec_1);
            command.Parameters.AddWithValue("@Abs_1", Abs_1);
            command.Parameters.AddWithValue("@SSS_1", SSS_1);
            command.Parameters.AddWithValue("@U_Med_1", U_Med_1);
            command.Parameters.AddWithValue("@Acor_1", Acor_1);
            command.Parameters.AddWithValue("@M3_1", M3_1);
            command.Parameters.AddWithValue("@Obj_1", Obj_1);
            command.Parameters.AddWithValue("@Real_1", Real_1);
            command.Parameters.AddWithValue("@U_Med_1A", U_Med_1A);
            command.Parameters.AddWithValue("@Err_1", Err_1);
            command.Parameters.AddWithValue("@Porcentaje_1", Porcentaje_1);
            command.Parameters.AddWithValue("@Ingr_2", Ingr_2);
            command.Parameters.AddWithValue("@HuFac_2", HuFac_2);
            command.Parameters.AddWithValue("@AbsFac_2", AbsFac_2);
            command.Parameters.AddWithValue("@Sec_2", Sec_2);
            command.Parameters.AddWithValue("@Abs_2", Abs_2);
            command.Parameters.AddWithValue("@SSS_2", SSS_2);
            command.Parameters.AddWithValue("@U_Med_2", U_Med_2);
            command.Parameters.AddWithValue("@Acor_2", Acor_2);
            command.Parameters.AddWithValue("@M3_2", M3_2);
            command.Parameters.AddWithValue("@Obj_2", Obj_2);
            command.Parameters.AddWithValue("@Real_2", Real_2);
            command.Parameters.AddWithValue("@U_Med_2A", U_Med_2A);
            command.Parameters.AddWithValue("@Err_2", Err_2);
            command.Parameters.AddWithValue("@Porcentaje_2", Porcentaje_2);
            command.Parameters.AddWithValue("@Ingr_3", Ingr_3);
            command.Parameters.AddWithValue("@HuFac_3", HuFac_3);
            command.Parameters.AddWithValue("@AbsFac_3", AbsFac_3);
            command.Parameters.AddWithValue("@Sec_3", Sec_3);
            command.Parameters.AddWithValue("@Abs_3", Abs_3);
            command.Parameters.AddWithValue("@SSS_3", SSS_3);
            command.Parameters.AddWithValue("@U_Mes_3", U_Mes_3);
            command.Parameters.AddWithValue("@Acor_3", Acor_3);
            command.Parameters.AddWithValue("@M3_3", M3_3);
            command.Parameters.AddWithValue("@Obj_3", Obj_3);
            command.Parameters.AddWithValue("@Real_3", Real_3);
            command.Parameters.AddWithValue("@U_Med_3", U_Med_3);
            command.Parameters.AddWithValue("@Err_3", Err_3);
            command.Parameters.AddWithValue("@Porcentaje_3", Porcentaje_3);
            command.Parameters.AddWithValue("@Ingr_4", Ingr_4);
            command.Parameters.AddWithValue("@HuFac_4", HuFac_4);
            command.Parameters.AddWithValue("@AbsFac_4", AbsFac_4);
            command.Parameters.AddWithValue("@Sec_4", Sec_4);
            command.Parameters.AddWithValue("@Abs_4", Abs_4);
            command.Parameters.AddWithValue("@SSS_4", SSS_4);
            command.Parameters.AddWithValue("@U_Med_4", U_Med_4);
            command.Parameters.AddWithValue("@Acor_4", Acor_4);
            command.Parameters.AddWithValue("@M3_4", M3_4);
            command.Parameters.AddWithValue("@Obj_4", Obj_4);
            command.Parameters.AddWithValue("@Real_4", Real_4);
            command.Parameters.AddWithValue("@U_Med_4A", U_Med_4A);
            command.Parameters.AddWithValue("@Err_4", Err_4);
            command.Parameters.AddWithValue("@Porcentaje_4", Porcentaje_4);
            command.Parameters.AddWithValue("@Ingr_5", Ingr_5);
            command.Parameters.AddWithValue("@HuFac_5", HuFac_5);
            command.Parameters.AddWithValue("@AbsFac_5", AbsFac_5);
            command.Parameters.AddWithValue("@Sec_5", Sec_5);
            command.Parameters.AddWithValue("@Abs_5", Abs_5);
            command.Parameters.AddWithValue("@SSS_5", SSS_5);
            command.Parameters.AddWithValue("@U_Med_5", U_Med_5);
            command.Parameters.AddWithValue("@Acor_5", Acor_5);
            command.Parameters.AddWithValue("@M3_5", M3_5);
            command.Parameters.AddWithValue("@Obj_5", Obj_5);
            command.Parameters.AddWithValue("@Real_5", Real_5);
            command.Parameters.AddWithValue("@U_Med_5A", U_Med_5A);
            command.Parameters.AddWithValue("@Err_5", Err_5);
            command.Parameters.AddWithValue("@Porcentaje_5", Porcentaje_5);
            command.Parameters.AddWithValue("@Ingr_6", Ingr_6);
            command.Parameters.AddWithValue("@HuFac_6", HuFac_6);
            command.Parameters.AddWithValue("@AbsFac_6", AbsFac_6);
            command.Parameters.AddWithValue("@Sec_6", Sec_6);
            command.Parameters.AddWithValue("@Abs_6", Abs_6);
            command.Parameters.AddWithValue("@SSS_6", SSS_6);
            command.Parameters.AddWithValue("@U_Med_6", U_Med_6);
            command.Parameters.AddWithValue("@Acor_6", Acor_6);
            command.Parameters.AddWithValue("@M3_6", M3_6);
            command.Parameters.AddWithValue("@Obj_6", Obj_6);
            command.Parameters.AddWithValue("@Real_6", Real_6);
            command.Parameters.AddWithValue("@U_Med_6A", U_Med_6A);
            command.Parameters.AddWithValue("@Err_6", Err_6);
            command.Parameters.AddWithValue("@Porcentaje_6", Porcentaje_6);
            command.Parameters.AddWithValue("@Ingr_7", Ingr_7);
            command.Parameters.AddWithValue("@HuFac_7", HuFac_7);
            command.Parameters.AddWithValue("@AbsFac_7", AbsFac_7);
            command.Parameters.AddWithValue("@Sec_7", Sec_7);
            command.Parameters.AddWithValue("@Abs_7", Abs_7);
            command.Parameters.AddWithValue("@SSS_7", SSS_7);
            command.Parameters.AddWithValue("@U_Med_7", U_Med_7);
            command.Parameters.AddWithValue("@Acor_7", Acor_7);
            command.Parameters.AddWithValue("@M3_7", M3_7);
            command.Parameters.AddWithValue("@Obj_7", Obj_7);
            command.Parameters.AddWithValue("@Real_7", Real_7);
            command.Parameters.AddWithValue("@U_Med_7A", U_Med_7A);
            command.Parameters.AddWithValue("@Err_7", Err_7);
            command.Parameters.AddWithValue("@Porcentaje_7", Porcentaje_7);
            command.Parameters.AddWithValue("@Ingr_8", Ingr_8);
            command.Parameters.AddWithValue("@HuFac_8", HuFac_8);
            command.Parameters.AddWithValue("@AbsFac_8", AbsFac_8);
            command.Parameters.AddWithValue("@Sec_8", Sec_8);
            command.Parameters.AddWithValue("@Abs_8", Abs_8);
            command.Parameters.AddWithValue("@SSS_8", SSS_8);
            command.Parameters.AddWithValue("@U_Med_8", U_Med_8);
            command.Parameters.AddWithValue("@Acor_8", Acor_8);
            command.Parameters.AddWithValue("@M3_8", M3_8);
            command.Parameters.AddWithValue("@Obj_8", Obj_8);
            command.Parameters.AddWithValue("@Real_8", Real_8);
            command.Parameters.AddWithValue("@U_Med_8A", U_Med_8A);
            command.Parameters.AddWithValue("@Err_8", Err_8);
            command.Parameters.AddWithValue("@Porcentaje_8", Porcentaje_8);
            command.Parameters.AddWithValue("@Ingr_9", Ingr_9);
            command.Parameters.AddWithValue("@HuFac_9", HuFac_9);
            command.Parameters.AddWithValue("@AbsFac_9", AbsFac_9);
            command.Parameters.AddWithValue("@Sec_9", Sec_9);
            command.Parameters.AddWithValue("@Abs_9", Abs_9);
            command.Parameters.AddWithValue("@SSS_9", SSS_9);
            command.Parameters.AddWithValue("@U_Med_9", U_Med_9);
            command.Parameters.AddWithValue("@Acor_9", Acor_9);
            command.Parameters.AddWithValue("@M3_9", M3_9);
            command.Parameters.AddWithValue("@Obj_9", Obj_9);
            command.Parameters.AddWithValue("@Real_9", Real_9);
            command.Parameters.AddWithValue("@U_Med_9A", U_Med_9A);
            command.Parameters.AddWithValue("@Err_9", Err_9);
            command.Parameters.AddWithValue("@Porcentaje_9", Porcentaje_9);
            command.Parameters.AddWithValue("@Ingr_10", Ingr_10);
            command.Parameters.AddWithValue("@HuFac_10", HuFac_10);
            command.Parameters.AddWithValue("@AbsFac_10", AbsFac_10);
            command.Parameters.AddWithValue("@Sec_10", Sec_10);
            command.Parameters.AddWithValue("@Abs_10", Abs_10);
            command.Parameters.AddWithValue("@SSS_10", SSS_10);
            command.Parameters.AddWithValue("@U_Med_10", U_Med_10);
            command.Parameters.AddWithValue("@Acor_10", Acor_10);
            command.Parameters.AddWithValue("@M3_10", M3_10);
            command.Parameters.AddWithValue("@Obj_10", Obj_10);
            command.Parameters.AddWithValue("@Real_10", Real_10);
            command.Parameters.AddWithValue("@U_Med_10A", U_Med_10A);
            command.Parameters.AddWithValue("@Err_10", Err_10);
            command.Parameters.AddWithValue("@Porcentaje_10", Porcentaje_10);
            command.Parameters.AddWithValue("@Ingr_11", Ingr_11);
            command.Parameters.AddWithValue("@HuFac_11", HuFac_11);
            command.Parameters.AddWithValue("@AbsFac_11", AbsFac_11);
            command.Parameters.AddWithValue("@Sec_11", Sec_11);
            command.Parameters.AddWithValue("@Abs_11", Abs_11);
            command.Parameters.AddWithValue("@SSS_11", SSS_11);
            command.Parameters.AddWithValue("@U_Med_11", U_Med_11);
            command.Parameters.AddWithValue("@Acor_11", Acor_11);
            command.Parameters.AddWithValue("@M3_11", M3_11);
            command.Parameters.AddWithValue("@Obj_11", Obj_11);
            command.Parameters.AddWithValue("@Real_11", Real_11);
            command.Parameters.AddWithValue("@U_Med_11A", U_Med_11A);
            command.Parameters.AddWithValue("@Err_11", Err_11);
            command.Parameters.AddWithValue("@Porcentaje_11", Porcentaje_11);
            command.Parameters.AddWithValue("@Ingr_12", Ingr_12);
            command.Parameters.AddWithValue("@HuFac_12", HuFac_12);
            command.Parameters.AddWithValue("@AbsFac_12", AbsFac_12);
            command.Parameters.AddWithValue("@Sec_12", Sec_12);
            command.Parameters.AddWithValue("@Abs_12", Abs_12);
            command.Parameters.AddWithValue("@SSS_12", SSS_12);
            command.Parameters.AddWithValue("@U_Med_12", U_Med_12);
            command.Parameters.AddWithValue("@Acor_12", Acor_12);
            command.Parameters.AddWithValue("@M3_12", M3_12);
            command.Parameters.AddWithValue("@Obj_12", Obj_12);
            command.Parameters.AddWithValue("@Real_12", Real_12);
            command.Parameters.AddWithValue("@U_Med_12B", U_Med_12B);
            command.Parameters.AddWithValue("@Err_12", Err_12);
            command.Parameters.AddWithValue("@Porcentaje_12", Porcentaje_12);
            command.Parameters.AddWithValue("@Ingr_13", Ingr_13);
            command.Parameters.AddWithValue("@HuFac_13", HuFac_13);
            command.Parameters.AddWithValue("@AbsFac_13", AbsFac_13);
            command.Parameters.AddWithValue("@Sec_13", Sec_13);
            command.Parameters.AddWithValue("@Abs_13", Abs_13);
            command.Parameters.AddWithValue("@SSS_13", SSS_13);
            command.Parameters.AddWithValue("@U_Med_13", U_Med_13);
            command.Parameters.AddWithValue("@Acor_13", Acor_13);
            command.Parameters.AddWithValue("@M3_13", M3_13);
            command.Parameters.AddWithValue("@Obj_13", Obj_13);
            command.Parameters.AddWithValue("@Real_13", Real_13);
            command.Parameters.AddWithValue("@U_Med_13A", U_Med_13A);
            command.Parameters.AddWithValue("@Err_13", Err_13);
            command.Parameters.AddWithValue("@Porcentaje_13", Porcentaje_13);
            command.Parameters.AddWithValue("@Ingr_14", Ingr_14);
            command.Parameters.AddWithValue("@HuFac_14", HuFac_14);
            command.Parameters.AddWithValue("@AbsFac_14", AbsFac_14);
            command.Parameters.AddWithValue("@Sec_14", Sec_14);
            command.Parameters.AddWithValue("@Abs_14", Abs_14);
            command.Parameters.AddWithValue("@SSS_14", SSS_14);
            command.Parameters.AddWithValue("@U_Med_14", U_Med_14);
            command.Parameters.AddWithValue("@Acor_14", Acor_14);
            command.Parameters.AddWithValue("@M3_14", M3_14);
            command.Parameters.AddWithValue("@Obj_14", Obj_14);
            command.Parameters.AddWithValue("@Real_14", Real_14);
            command.Parameters.AddWithValue("@U_Med_14A", U_Med_14A);
            command.Parameters.AddWithValue("@Err_14", Err_14);
            command.Parameters.AddWithValue("@Porcentaje_14", Porcentaje_14);
            command.Parameters.AddWithValue("@Ingr_15", Ingr_15);
            command.Parameters.AddWithValue("@HuFac_15", HuFac_15);
            command.Parameters.AddWithValue("@AbsFac_15", AbsFac_15);
            command.Parameters.AddWithValue("@Sec_15", Sec_15);
            command.Parameters.AddWithValue("@Abs_15", Abs_15);
            command.Parameters.AddWithValue("@SSS_15", SSS_15);
            command.Parameters.AddWithValue("@U_Med_15", U_Med_15);
            command.Parameters.AddWithValue("@Acor_15", Acor_15);
            command.Parameters.AddWithValue("@M3_15", M3_15);
            command.Parameters.AddWithValue("@Obj_15", Obj_15);
            command.Parameters.AddWithValue("@Real_15", Real_15);
            command.Parameters.AddWithValue("@U_Med_15A", U_Med_15A);
            command.Parameters.AddWithValue("@Err_15", Err_15);
            command.Parameters.AddWithValue("@Porcentaje_15", Porcentaje_15);
            command.Parameters.AddWithValue("@Ingr_16", Ingr_16);
            command.Parameters.AddWithValue("@HuFac_16", HuFac_16);
            command.Parameters.AddWithValue("@AbsFac_16", AbsFac_16);
            command.Parameters.AddWithValue("@Sec_16", Sec_16);
            command.Parameters.AddWithValue("@Abs_16", Abs_16);
            command.Parameters.AddWithValue("@SSS_16", SSS_16);
            command.Parameters.AddWithValue("@U_Med_16", U_Med_16);
            command.Parameters.AddWithValue("@Acor_16", Acor_16);
            command.Parameters.AddWithValue("@M3_16", M3_16);
            command.Parameters.AddWithValue("@Obj_16", Obj_16);
            command.Parameters.AddWithValue("@Real_16", Real_16);
            command.Parameters.AddWithValue("@U_Med_16A", U_Med_16A);
            command.Parameters.AddWithValue("@Err_16", Err_16);
            command.Parameters.AddWithValue("@Porcentaje_16", Porcentaje_16);
            command.Parameters.AddWithValue("@Ingr_17", Ingr_17);
            command.Parameters.AddWithValue("@HuFac_17", HuFac_17);
            command.Parameters.AddWithValue("@AbsFac_17", AbsFac_17);
            command.Parameters.AddWithValue("@Sec_17", Sec_17);
            command.Parameters.AddWithValue("@Abs_17", Abs_17);
            command.Parameters.AddWithValue("@SSS_17", SSS_17);
            command.Parameters.AddWithValue("@U_Med_17", U_Med_17);
            command.Parameters.AddWithValue("@Acor_17", Acor_17);
            command.Parameters.AddWithValue("@M3_17", M3_17);
            command.Parameters.AddWithValue("@Obj_17", Obj_17);
            command.Parameters.AddWithValue("@Real_17", Real_17);
            command.Parameters.AddWithValue("@U_Med_17A", U_Med_17A);
            command.Parameters.AddWithValue("@Err_17", Err_17);
            command.Parameters.AddWithValue("@Porcentaje_17", Porcentaje_17);
            command.Parameters.AddWithValue("@Ingr_18", Ingr_18);
            command.Parameters.AddWithValue("@HuFac_18", HuFac_18);
            command.Parameters.AddWithValue("@AbsFac_18", AbsFac_18);
            command.Parameters.AddWithValue("@Sec_18", Sec_18);
            command.Parameters.AddWithValue("@Abs_18", Abs_18);
            command.Parameters.AddWithValue("@SSS_18", SSS_18);
            command.Parameters.AddWithValue("@U_Med_18", U_Med_18);
            command.Parameters.AddWithValue("@Acor_18", Acor_18);
            command.Parameters.AddWithValue("@M3_18", M3_18);
            command.Parameters.AddWithValue("@Obj_18", Obj_18);
            command.Parameters.AddWithValue("@Real_18", Real_18);
            command.Parameters.AddWithValue("@U_Med_18A", U_Med_18A);
            command.Parameters.AddWithValue("@Err_18", Err_18);
            command.Parameters.AddWithValue("@Porcentaje_18", Porcentaje_18);
            command.Parameters.AddWithValue("@Ingr_19", Ingr_19);
            command.Parameters.AddWithValue("@HuFac_19", HuFac_19);
            command.Parameters.AddWithValue("@AbsFac_19", AbsFac_19);
            command.Parameters.AddWithValue("@Sec_19", Sec_19);
            command.Parameters.AddWithValue("@Abs_19", Abs_19);
            command.Parameters.AddWithValue("@SSS_19", SSS_19);
            command.Parameters.AddWithValue("@U_Med_19", U_Med_19);
            command.Parameters.AddWithValue("@Acor_19", Acor_19);
            command.Parameters.AddWithValue("@M3_19", M3_19);
            command.Parameters.AddWithValue("@Obj_19", Obj_19);
            command.Parameters.AddWithValue("@Real_19", Real_19);
            command.Parameters.AddWithValue("@U_Med_19A", U_Med_19A);
            command.Parameters.AddWithValue("@Err_19", Err_19);
            command.Parameters.AddWithValue("@Porcentaje_19", Porcentaje_19);
            command.Parameters.AddWithValue("@Rev", Rev);
            command.Parameters.AddWithValue("@Agua_Ajuste", Agua_Ajuste);
            command.Parameters.AddWithValue("@Rel_Agua_Cem", Rel_Agua_Cem);

            bool salida = false;

            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;
                command.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public bool InsertarProductosTMP(string ClaveProducto, string Descripcion, string Unidad, double Precio, string CveAlterna, string Clasificacion, string CveCiudad)
        {
            Metodo = "InsertarProductosTMP";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("InsertarProductosTMP", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ClaveProducto", ClaveProducto);
            command.Parameters.AddWithValue("@Descripcion", Descripcion);
            command.Parameters.AddWithValue("@Unidad", Unidad);
            command.Parameters.AddWithValue("@Precio", Precio);
            command.Parameters.AddWithValue("@CveAlterna", CveAlterna);
            command.Parameters.AddWithValue("@Clasificacion", Clasificacion);
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);

            bool salida = false;

            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;
                command.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public bool InsertarProducto(int IDProducto, string ClaveProducto, string Descripcion, string Unidad, double Precio, bool Borrado, string Observaciones, bool EsComplemento, int Accion, string ClaveAlterna, string CveCiudad, string Clasificacion)
        {
            Metodo = "InsertarProducto";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("InsertarProductos", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDProducto", IDProducto);
            command.Parameters.AddWithValue("@ClaveProducto", ClaveProducto);
            command.Parameters.AddWithValue("@Descripcion", Descripcion);
            command.Parameters.AddWithValue("@Unidad", Unidad);
            command.Parameters.AddWithValue("@Precio", Precio);
            command.Parameters.AddWithValue("@Borrado", Borrado);
            command.Parameters.AddWithValue("@Observaciones", Observaciones);
            command.Parameters.AddWithValue("@EsComplemento", EsComplemento);
            command.Parameters.AddWithValue("@ACCION", 0);

            command.Parameters.AddWithValue("@CveAlterna", ClaveAlterna);
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@Clasificacion", Clasificacion);

            bool salida = false;

            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;
                command.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }


        public bool ActualizarProducto(int IDProducto, string ClaveProducto, string Descripcion, string Unidad, double Precio, bool Borrado, string Observaciones, bool EsComplemento)
        {
            Metodo = "ActualizarProducto";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("InsertarProductos", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDProducto", IDProducto);
            command.Parameters.AddWithValue("@ClaveProducto", ClaveProducto);
            command.Parameters.AddWithValue("@Descripcion", Descripcion);
            command.Parameters.AddWithValue("@Unidad", Unidad);
            command.Parameters.AddWithValue("@Precio", Precio);
            command.Parameters.AddWithValue("@Borrado", Borrado);
            command.Parameters.AddWithValue("@Observaciones", Observaciones);
            command.Parameters.AddWithValue("@EsComplemento", EsComplemento);
            command.Parameters.AddWithValue("@ACCION", 1);

            bool salida = false;
            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;
                command.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public string ObtenerProductosComplemento()
        {
            Metodo = "ObtenerProductosComplemento";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerProductos", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EsComplemento", true);

            string salida = string.Empty;

            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public string ObtenerProductos(int Complemento, string CveCiudad)
        {
            Metodo = "ObtenerProductos";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerProductos", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@EsComplemento", Complemento);

            string salida = string.Empty;

            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }


        public string ObtenerProductosComplementoFiltro(string Filtro)
        {
            Metodo = "ObtenerProductosComplementoFiltro";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerProductosFiltro", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Filtro", Filtro);
            command.Parameters.AddWithValue("@EsComplemento", true);

            string salida = string.Empty;

            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public string ObtenerProductosFiltro(string _filtro,string clasificacion,string CveCiudad)
        {
            Metodo = "ObtenerProductosFiltro";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerProductosFiltro", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Filtro", _filtro);
            command.Parameters.AddWithValue("@clasificacion", clasificacion);
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            string salida = string.Empty;

            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public bool ActualizaProductos(string CveCiudad)
        {
            Metodo = "ObtenerProductosFiltro";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            List<Producto> Productos_Aspel = new List<Producto>();
            Productos_Aspel = ObtieneProductos_Aspel(CveCiudad);
            bool salida = true;

            try
            {
                if (Productos_Aspel.Count > 0)
                {
                    foreach (Producto _producto in Productos_Aspel)
                    {
                        InsertarProductosTMP(_producto.ClaveProducto, _producto.Descripcion, _producto.Unidad, _producto.Precio, _producto.CveAlterna, _producto.Clasificacion,_producto.CveCiudad);
                    }
                }
            }
            catch (Exception ex)
            {
                salida = false;
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public bool ActualizaProductosCiudad(string CveCiudad)
        {
            Metodo = "SyncProductos";
            bool Salida = false;

            Salida = ActualizaProductos(CveCiudad);
            Salida = SyncProductos(CveCiudad);

            return Salida;
        }

        public bool SyncProductos(string CveCiudad)
        {
            Metodo = "SyncProductos";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("SincronizaProducto_ASPEL", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);


            bool salida = false;
            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;
                command.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public List<Producto> ObtieneProductos_Aspel(string CveCiudad)
        {
            Metodo = "ObtieneProductos_Aspel";
            SqlConnection conexion;
            switch (CveCiudad)
            {
                case "MTY":
                    conexion = new System.Data.SqlClient.SqlConnection(this.CN_AspelMty);
                    break;
                case "GDL":
                    conexion = new System.Data.SqlClient.SqlConnection(this.CN_AspelGdl);
                    break;
                case "AGS":
                    conexion = new System.Data.SqlClient.SqlConnection(this.CN_AspelAgs);
                    break;
                case "LEON":
                    conexion = new System.Data.SqlClient.SqlConnection(this.CN_AspelLeon);
                    break;
                case "PUE":
                    conexion = new System.Data.SqlClient.SqlConnection(this.CN_AspelPuebla);
                    break;
                default:
                    conexion = new System.Data.SqlClient.SqlConnection(this.CN_AspelMty);
                    break;
            }
            SqlCommand command = new SqlCommand("SELECT ClaveProducto,Descripcion,Unidad,PRECIO,Clasificacion,CveAlterna FROM Productos", conexion);
            command.CommandType = System.Data.CommandType.Text;

            conexion.Open();
            SqlDataReader dr = command.ExecuteReader();
            List<Producto> ListaProductos_Aspel = new List<Producto>();
            Producto Producto_Aspel = new Producto();
            if (dr.HasRows)
            {
                try
                {
                    while (dr.Read())
                    {
                        Producto_Aspel = new Producto();

                        Producto_Aspel.ClaveProducto = dr["ClaveProducto"].ToString().Trim();
                        Producto_Aspel.Descripcion = dr["Descripcion"].ToString().Trim();
                        Producto_Aspel.Descripcion = dr["Descripcion"].ToString().Trim();
                        Producto_Aspel.Unidad = dr["Unidad"].ToString().Trim();
                        Producto_Aspel.Precio = double.Parse(dr["PRECIO"].ToString());
                        Producto_Aspel.Clasificacion = dr["Clasificacion"].ToString().Trim();
                        Producto_Aspel.CveAlterna = dr["CveAlterna"].ToString().Trim();
                        Producto_Aspel.CveCiudad = CveCiudad;

                        ListaProductos_Aspel.Add(Producto_Aspel);
                    }
                    command.Dispose();
                    dr.Dispose();
                    conexion.Close();
                    conexion.Dispose();
                }

                catch (Exception ex)
                {
                    if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                    BitError = new BitacoraErrores();
                    BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
                }
            }
            return ListaProductos_Aspel;
        }

    }
}
