using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Concretec.Pedidos.Utils;
using System.ServiceModel.Activation;

namespace Concretec.Servicios
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Obras" in code, svc and config file together.
    public class Obras : IObras
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        string Aplicacion = "Programacion de Pedidos V 2.0";
        string Servicio = "Obras.svc";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return ConfigurationManager.ConnectionStrings["cnConcretec"].ConnectionString; }
        }

        public bool ActualizarObra
            (
            int IDObra,
            string ClaveObra,
            string Direccion,
            string Nombre,
            string Telefonos,
            string Responsable,
            string Roji,
            string EntreCalles,
            bool? Estatus,
            int? IDVendedor,
            string RFC,
            string POBLACION,
            string CP,
            string ATENCION,
            string CLAVEZONA,
            string PLANTA,
            string CLAVECLIENTE,
            float? DISTANCIA,
            int? TIEMPOCICLO,
            float? VOLUMENESTIMADO,
            float? VOLUMENACUMULADO,
            string CVECIUDAD,
            string Colonia
            )
        {
            Metodo = "ActualizarObra";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ActualizarObras", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDObra", IDObra);
            command.Parameters.AddWithValue("@ClaveObra", ClaveObra);
            command.Parameters.AddWithValue("@Direccion", Direccion);
            command.Parameters.AddWithValue("@Nombre", Nombre);
            command.Parameters.AddWithValue("@Telefonos", Telefonos);
            command.Parameters.AddWithValue("@Responsable", Responsable);
            command.Parameters.AddWithValue("@Roji", Roji);
            command.Parameters.AddWithValue("@EntreCalles", EntreCalles);
            command.Parameters.AddWithValue("@Estatus", Estatus);
            command.Parameters.AddWithValue("@IDVendedor", IDVendedor);
            command.Parameters.AddWithValue("@RFC", RFC);
            command.Parameters.AddWithValue("@POBLACION", POBLACION);
            command.Parameters.AddWithValue("@CP", CP);
            command.Parameters.AddWithValue("@ATENCION", ATENCION);
            command.Parameters.AddWithValue("@CLAVEZONA", CLAVEZONA);
            command.Parameters.AddWithValue("@PLANTA", PLANTA);
            command.Parameters.AddWithValue("@CLAVECLIENTE", CLAVECLIENTE);
            command.Parameters.AddWithValue("@DISTANCIA", DISTANCIA);
            command.Parameters.AddWithValue("@TIEMPOCICLO", TIEMPOCICLO);
            command.Parameters.AddWithValue("@VOLUMENESTIMADO", VOLUMENESTIMADO);
            command.Parameters.AddWithValue("@VOLUMENACUMULADO", VOLUMENACUMULADO);
            command.Parameters.AddWithValue("@CVECIUDAD", CVECIUDAD);
            command.Parameters.AddWithValue("@Colonia", Colonia);
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

        public bool InsertarObra(
            string ClaveObra,
            string Direccion,
            string Nombre,
            string Telefonos,
            string Responsable,
            string Roji,
            string EntreCalles,
            bool? Estatus,
            int? IDVendedor,
            string RFC,
            string POBLACION,
            string CP,
            string ATENCION,
            string CLAVEZONA,
            string PLANTA,
            string CLAVECLIENTE,
            float? DISTANCIA,
            int? TIEMPOCICLO,
            float? VOLUMENESTIMADO,
            float? VOLUMENACUMULADO,
            string CVECIUDAD,
            string Colonia)
        {
            Metodo = "InsertarObra";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("InsertarObras", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ClaveObra", ClaveObra);
            command.Parameters.AddWithValue("@Direccion", Direccion);
            command.Parameters.AddWithValue("@Nombre", Nombre);
            command.Parameters.AddWithValue("@Telefonos", Telefonos);
            command.Parameters.AddWithValue("@Responsable", Responsable);
            command.Parameters.AddWithValue("@Roji", Roji);
            command.Parameters.AddWithValue("@EntreCalles", EntreCalles);
            command.Parameters.AddWithValue("@Estatus", Estatus);
            command.Parameters.AddWithValue("@IDVendedor", IDVendedor);
            command.Parameters.AddWithValue("@RFC", RFC);
            command.Parameters.AddWithValue("@POBLACION", POBLACION);
            command.Parameters.AddWithValue("@CP", CP);
            command.Parameters.AddWithValue("@ATENCION", ATENCION);
            command.Parameters.AddWithValue("@CLAVEZONA", CLAVEZONA);
            command.Parameters.AddWithValue("@PLANTA", PLANTA);
            command.Parameters.AddWithValue("@CLAVECLIENTE", CLAVECLIENTE);
            command.Parameters.AddWithValue("@DISTANCIA", DISTANCIA);
            command.Parameters.AddWithValue("@TIEMPOCICLO", TIEMPOCICLO);
            command.Parameters.AddWithValue("@VOLUMENESTIMADO", VOLUMENESTIMADO);
            command.Parameters.AddWithValue("@VOLUMENACUMULADO", VOLUMENACUMULADO);
            command.Parameters.AddWithValue("@CVECIUDAD", CVECIUDAD);
            command.Parameters.AddWithValue("@Colonia", Colonia);
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

        public string ObtenerNumeroObra(int CveCliente, string CveCiudad)
        {
            Metodo = "ObtenerNumeroObra";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("Numero_Obra", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CVECLIENTE", CveCliente);
            command.Parameters.AddWithValue("@CVECIUDAD", CveCiudad);

            string salida = string.Empty;

            try
            {
                conexion.Open();
                salida = command.ExecuteScalar().ToString();
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

        public string BuscarObra(int CvePedido, string CveCiudad)
        {
            Metodo = "BuscarObra";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BuscarObra", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CveObra", CvePedido);
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

        public string ObtenerObras()
        {
            Metodo = "ObtenerObras";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerObras", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;

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

        public string ObtenerParametros()
        {
            Metodo = "ObtenerParametros";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerParametros", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
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

        public string ObtenerObrasFiltroActivas(string Filtro, string planta, int CveCliente, string CveCiudad)
        {
            Metodo = "ObtenerObrasFiltroActivas";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerObrasFiltroActivas", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Filtro", Filtro);
            command.Parameters.AddWithValue("@Planta", planta);
            command.Parameters.AddWithValue("@CveCliente", CveCliente);
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

        public string ObtenerObrasFiltro(string Filtro, string planta, int CveCliente,string CveCiudad,int Estatus)
        {
            Metodo = "ObtenerObrasFiltro";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerObrasFiltroFull", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Filtro", Filtro);
            command.Parameters.AddWithValue("@Planta", planta);
            command.Parameters.AddWithValue("@CveCliente", CveCliente);
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@Estatus", Estatus);
            
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
    }
}
