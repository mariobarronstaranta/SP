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

namespace Concretec.Pedidos.BC
{
    public class Producto:Iproducto
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new Concretec.Pedidos.Utils.BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos";
        readonly string Servicio = "Producto.cs";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return ConfigurationManager.AppSettings["conexion"].ToString(); }
        }

        private string CN_AspelMty
        {
            get
            { return ConfigurationManager.AppSettings["cnAspelSQLMTY"].ToString(); }
        }

        private string CN_AspelGdl
        {
            get
            { return ConfigurationManager.AppSettings["cnAspelSQLGDL"].ToString(); }
        }

        private string CN_AspelAgs
        {
            get
            { return ConfigurationManager.AppSettings["cnAspelSQLAGS"].ToString(); }
        }

        private string CN_AspelLeon
        {
            get
            { return ConfigurationManager.AppSettings["cnAspelSQLLEON"].ToString(); }
        }

        private string CN_AspelPuebla
        {
            get
            { return ConfigurationManager.AppSettings["cnAspelSQLPUEBLA"].ToString(); }
        }

        private string CN_AspelQRO
        {
            get
            { return ConfigurationManager.AppSettings["cnAspelSQLQRO"].ToString(); }
        }

        public List<BE.Producto> ObtenerProductos(int Complemento, string CveCiudad)
        {
            Metodo = "ObtenerProductos";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerProductos", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@EsComplemento", Complemento);

            List<BE.Producto> salida = new List<BE.Producto>();
            BE.Producto elemento = new BE.Producto();

            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new BE.Producto();

                        elemento.IDProducto     = int.Parse(dr["IDProducto"].ToString().Trim());
                        elemento.ClaveProducto  = dr["ClaveProducto"].ToString().Trim();
                        elemento.Descripcion    = dr["Descripcion"].ToString().Trim();
                        elemento.Unidad         = dr["Unidad"].ToString().Trim();
                        elemento.Precio         = double.Parse(dr["Precio"].ToString().Trim());
                        elemento.Clasificacion  = dr["Clasificacion"].ToString().Trim();
                        elemento.CveAlterna     = dr["CveAlterna"].ToString().Trim();
                        elemento.CveCiudad      = dr["CveCiudad"].ToString().Trim();

                        salida.Add(elemento);
                    }
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

        public bool AjustarProductos()
        {
            Metodo = "AjustarProductos";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("AjustarProductos", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            bool salida = false;

            try
            {
                conexion.Open();
                command.ExecuteNonQuery();
                salida = true;
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return salida;
        }

        public bool ActualizaProductos(string CveCiudad)
        {
            Metodo = "ActualizaProductos";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            List<BE.Producto> Productos_Aspel = new List<BE.Producto>();
            Productos_Aspel = ObtieneProductos_Aspel(CveCiudad);
            bool salida = true;

            try
            {
                if (Productos_Aspel.Count > 0)
                {
                    foreach (BE.Producto _producto in Productos_Aspel)
                    {
                        InsertarProductosTMP(_producto.ClaveProducto, _producto.Descripcion, _producto.Unidad, _producto.Precio, _producto.CveAlterna, _producto.Clasificacion, _producto.CveCiudad);
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

        public List<BE.Producto> ObtieneProductos_Aspel(string CveCiudad)
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
                case "QRO":
                    conexion = new System.Data.SqlClient.SqlConnection(this.CN_AspelQRO);
                    break;
                default:
                    conexion = new System.Data.SqlClient.SqlConnection(this.CN_AspelMty);
                    break;
            }
            SqlCommand command = new SqlCommand("SELECT ClaveProducto,Descripcion,Unidad,PRECIO,Clasificacion,CveAlterna FROM Productos", conexion);
            command.CommandType = System.Data.CommandType.Text;

            conexion.Open();
            SqlDataReader dr = command.ExecuteReader();
            List<BE.Producto> ListaProductos_Aspel = new List<BE.Producto>();
            BE.Producto Producto_Aspel = new BE.Producto();
            if (dr.HasRows)
            {
                try
                {
                    while (dr.Read())
                    {
                        Producto_Aspel = new BE.Producto();

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

        public string ObtenerProductosFiltro(string _filtro, string clasificacion, string CveCiudad)
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

    }
}
