using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Concretec.Pedidos.BE;
using Concretec.Pedidos.Utils;
using System.Configuration;
using System.Data.SqlClient;

namespace Concretec.Pedidos.BC
{
    public class Calibracion
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.5";
        readonly string Servicio = "BC Calibracion.cs";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return ConfigurationManager.AppSettings["conexion"].ToString(); }
        }

        public bool InsertaCalibracion(BE.Calibracion registro)
        {
            bool salida = false;

            Metodo = "RegistraAjuste";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("Inserta_Calibracion", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            //Campos de Lectura Generales
            command.Parameters.AddWithValue("@CveCiudad",registro.CveCiudad);
            command.Parameters.AddWithValue("@PlantaId", registro.PlantaId);
            command.Parameters.AddWithValue("@Fecha", registro.Fecha);
            command.Parameters.AddWithValue("@Hora",registro.Hora );
            //Campos para insertar los campos para cemento
            command.Parameters.AddWithValue("@CEM_CB2_Alto", registro.CEM_CB2_Alto);
            command.Parameters.AddWithValue("@CEM_CB2_Bajo", registro.CEM_CB2_Bajo);
            command.Parameters.AddWithValue("@CEM_TEO_Alto", registro.CEM_TEO_Alto);
            command.Parameters.AddWithValue("@CEM_TEO_Bajo", registro.CEM_TEO_Bajo);
            //Campos para insertar los campos para AGREGADOS
            command.Parameters.AddWithValue("@AGR_CB2_Alto", registro.AGR_CB2_Alto);
            command.Parameters.AddWithValue("@AGR_CB2_Bajo", registro.AGR_CB2_Bajo);
            command.Parameters.AddWithValue("@AGR_TEO_Alto", registro.AGR_TEO_Alto);
            command.Parameters.AddWithValue("@AGR_TEO_Bajo", registro.AGR_TEO_Bajo);
            //Campos para insertar los campos para AGUA
            command.Parameters.AddWithValue("@AGU_CB2_Alto", registro.AGU_CB2_Alto);
            command.Parameters.AddWithValue("@AGU_CB2_Bajo", registro.AGU_CB2_Bajo);
            command.Parameters.AddWithValue("@AGU_TEO_Alto", registro.AGU_TEO_Alto);
            command.Parameters.AddWithValue("@AGU_TEO_Bajo", registro.AGU_TEO_Bajo);
            //Campos para insertar los campos para AD1
            command.Parameters.AddWithValue("@AD1_CB2_Alto", registro.AD1_CB2_Alto);
            command.Parameters.AddWithValue("@AD1_CB2_Bajo", registro.AD1_CB2_Bajo);
            command.Parameters.AddWithValue("@AD1_TEO_Alto", registro.AD1_TEO_Alto);
            command.Parameters.AddWithValue("@AD1_TEO_Bajo", registro.AD1_TEO_Bajo);
            //Campos para insertar los campos para AD2
            command.Parameters.AddWithValue("@AD2_CB2_Alto", registro.AD2_CB2_Alto);
            command.Parameters.AddWithValue("@AD2_CB2_Bajo", registro.AD2_CB2_Bajo);
            command.Parameters.AddWithValue("@AD2_TEO_Alto", registro.AD2_TEO_Alto);
            command.Parameters.AddWithValue("@AD2_TEO_Bajo", registro.AD2_TEO_Bajo);
            //Campos para insertar los campos para AD3
            command.Parameters.AddWithValue("@AD3_CB2_Alto", registro.AD3_CB2_Alto);
            command.Parameters.AddWithValue("@AD3_CB2_Bajo", registro.AD3_CB2_Bajo);
            command.Parameters.AddWithValue("@AD3_TEO_Alto", registro.AD3_TEO_Alto);
            command.Parameters.AddWithValue("@AD3_TEO_Bajo", registro.AD3_TEO_Bajo);
            //Campos para insertar los campos para AD4
            command.Parameters.AddWithValue("@AD4_CB2_Alto", registro.AD4_CB2_Alto);
            command.Parameters.AddWithValue("@AD4_CB2_Bajo", registro.AD4_CB2_Bajo);
            command.Parameters.AddWithValue("@AD4_TEO_Alto", registro.AD4_TEO_Alto);
            command.Parameters.AddWithValue("@AD4_TEO_Bajo", registro.AD4_TEO_Bajo);
            //Campos para insertar los campos para AD5
            command.Parameters.AddWithValue("@AD5_CB2_Alto", registro.AD5_CB2_Alto);
            command.Parameters.AddWithValue("@AD5_CB2_Bajo", registro.AD5_CB2_Bajo);
            command.Parameters.AddWithValue("@AD5_TEO_Alto", registro.AD5_TEO_Alto);
            command.Parameters.AddWithValue("@AD5_TEO_Bajo", registro.AD5_TEO_Bajo);
            //Campos de Control
            command.Parameters.AddWithValue("@UsuarioRegistro", registro.UsuarioId);


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

        public bool ActualizaCalibracion(BE.Calibracion registro)
        {
            bool salida = false;

            return salida;
        }

        public List<BE.Calibracion> ListaCalibraciones(DateTime Desde, DateTime Hasta, string CveCiudad, int PlantaId,int IdCalibracion)
        {
            List<BE.Calibracion> salida = new List<BE.Calibracion>();
            //=====================================================================
            Metodo = "BuscaAutorizaciones";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerCalibraciones", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@PlantaId", PlantaId);
            command.Parameters.AddWithValue("@IdCalibracion", IdCalibracion);
            command.Parameters.AddWithValue("@Desde", Desde);
            command.Parameters.AddWithValue("@Hasta", Hasta);
            SqlDataReader dr = null;

            BE.Calibracion elemento = new BE.Calibracion();
            try
            {
                conexion.Open();
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new BE.Calibracion();
                        elemento.CalibracionId      = int.Parse(dr["CalibracionId"].ToString());
                        elemento.CveCiudad          = dr["CveCiudad"].ToString();
                        elemento.PlantaId           = int.Parse(dr["PlantaId"].ToString());
                        elemento.NombrePlanta       = dr["NombrePlanta"].ToString();
                        elemento.fechasalida        = dr["Fecha"].ToString();
                        elemento.FechaRegistro      = DateTime.Parse(dr["FechaRegistro"].ToString());
                        elemento.horasalida         = dr["Hora"].ToString();
                        elemento.UsuarioId          = int.Parse(dr["UsuarioId"].ToString());
                        elemento.NombreUsuario      = dr["NombreUsuario"].ToString();
                        elemento.Material           = dr["Material"].ToString();


                        elemento.TEO_Bajo           = float.Parse(dr["TEO_Bajo"].ToString());
                        elemento.CB2_Bajo           = float.Parse(dr["CB2_Bajo"].ToString());
                        elemento.ERROR_Bajo         = float.Parse(dr["ERROR_Bajo"].ToString());
                        elemento.TEO_Alto           = float.Parse(dr["TEO_Alto"].ToString());
                        elemento.CB2_Alto           = float.Parse(dr["CB2_Alto"].ToString());
                        elemento.ERROR_Alto         = float.Parse(dr["ERROR_Alto"].ToString());
                        salida.Add(elemento);
                    }
                }
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            finally
            {
                if ((dr != null) && (!dr.IsClosed)) { dr.Close(); }
                if (command != null) { command.Dispose(); }
                if (conexion != null) { conexion.Dispose(); }
            }
            //=====================================================================
            return salida;
        }
    }
}
