using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Data.SqlClient;
using Concretec.Pedidos.BE;
using System.Configuration;
using System.Data.OleDb;
using Concretec.Pedidos.Utils;

namespace Concretec.Agentes
{
    public class AgenteProductos : IAgenteProductos
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.0";
        readonly string Servicio = "AgenteProductos.cs";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return "server=localhost;database=Pedidos;uid=sa;pwd=Pato12345"; }
        }

        public List<Archivos> ListaArchivos()
        {
            List<Archivos> Salida = new List<Archivos>();
            Archivos item = new Archivos();

            item = new Archivos();
            item.Ciudad = "MTY";
            item.Nombre = "INVEMTY";
            item.TipoArchivo = "Productos";
            Salida.Add(item);

            item = new Archivos();
            item.Ciudad = "GDL";
            item.Nombre = "INVEGDL";
            item.TipoArchivo = "Productos";
            Salida.Add(item);

            item = new Archivos();
            item.Ciudad = "AGS";
            item.Nombre = "INVEAGS";
            item.TipoArchivo = "Productos";
            Salida.Add(item);

            item = new Archivos();
            item.Ciudad = "LEON";
            item.Nombre = "INVELEON";
            item.TipoArchivo = "Productos";
            Salida.Add(item);

            item = new Archivos();
            item.Ciudad = "PUE";
            item.Nombre = "INVEPUE";
            item.TipoArchivo = "Productos";
            Salida.Add(item);


            return Salida;
        }

        public void CargarProductos()
        {
            Metodo = "CargarProductos";
            List<INVE01> ListaProductos = new List<INVE01>();
            OleDbConnection _connection = new OleDbConnection();
            StringBuilder ConnectionString = new StringBuilder("");
            INVE01 ProductosInformix = new INVE01();
            AgenteProductos AP = new AgenteProductos();
            List<Archivos> Lista = new List<Archivos>();
            bool EX = new bool();
            ConnectionString.Append(@"Provider=Microsoft.Jet.OLEDB.4.0;");
            ConnectionString.Append(@"Extended Properties=Paradox 5.x;");
            ConnectionString.Append(@"Data Source=C:\Concretec\;");

            Lista = ListaArchivos();
            foreach (Archivos ii in Lista)
            {
                if (_connection.State.ToString() == "Open")
                {
                    _connection.Close();
                }
                _connection.ConnectionString = ConnectionString.ToString();
                _connection.Open();
                ListaProductos = new List<INVE01>();

                try
                {
                    OleDbCommand _Comando = new OleDbCommand("SELECT * FROM " + ii.Nombre.ToString() + " ;", _connection);
                    OleDbDataReader DR = _Comando.ExecuteReader();
                    bool Borrado = false;
                    if (DR.HasRows)
                    {
                        while (DR.Read())
                        {
                            ProductosInformix = new INVE01();
                            ProductosInformix.CLV_ART = DR["CLV_ART"].ToString();
                            ProductosInformix.DESCR = DR["DESCR"].ToString();
                            ProductosInformix.UNI_MED = DR["UNI_MED"].ToString();
                            ProductosInformix.PRECIO1 = DR["PRECIO1"].ToString();
                            ProductosInformix.OBS_INV = DR["OBS_INV"].ToString();
                            ProductosInformix.LIN_PROD = DR["LIN_PROD"].ToString();
                            ProductosInformix.CLV_ALTER = DR["CLV_ALTER"].ToString();
                            ListaProductos.Add(ProductosInformix);
                        }
                        // aqui hay que mandar llamar al insert en la tabla de Productos2
                        _connection.Close();

                        foreach (INVE01 P in ListaProductos)
                        {

                            if (P.STATUS == "A")
                            { Borrado = false; }
                            else
                            { Borrado = true; }

                            AP = new AgenteProductos();
                            EX = new bool();
                            EX = AP.CargaProducto(P.CLV_ART, P.DESCR, P.UNI_MED, double.Parse(P.PRECIO1.ToString()), Borrado, P.OBS_INV, ii.Ciudad.ToString(), P.LIN_PROD.ToString(), P.CLV_ALTER);
                        }
                    }
                    Concretec.Pedidos.BC.Producto BC = new Concretec.Pedidos.BC.Producto();
                    BC = new Concretec.Pedidos.BC.Producto();
                    EX = new bool();
                    EX = BC.AjustarProductos();
                }
                catch (Exception ex)
                {
                    BitError = new BitacoraErrores();
                    BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
                }
            }



        }

        public bool ActualizaProductosCiudad(string CveCiudad)
        {
            Metodo = "ActualizaProductosCiudad";
            bool obj = false;
            Pedidos.BC.Producto Cliente = new Pedidos.BC.Producto();

            try
            {
                obj = Cliente.ActualizaProductosCiudad(CveCiudad);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public bool CargaProducto(string ClaveProducto, string Descripcion, string Unidad, double Precio, bool Borrado, string Observaciones, string CveCiudad, string LinProd, string CveAlterna)
        {
            Metodo = "CargaProducto";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("InsertarProductosParadox", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDProducto", 0);
            command.Parameters.AddWithValue("@ClaveProducto", ClaveProducto);
            command.Parameters.AddWithValue("@Descripcion", Descripcion);
            command.Parameters.AddWithValue("@Unidad", Unidad);
            command.Parameters.AddWithValue("@Precio", Precio);
            command.Parameters.AddWithValue("@Borrado", Borrado);
            command.Parameters.AddWithValue("@Observaciones", Observaciones);
            command.Parameters.AddWithValue("@ACCION", 0);
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@LinProd", LinProd);
            command.Parameters.AddWithValue("@CveAlterna", CveAlterna);

            bool salida = false;

            try
            {
                conexion.Open();
                command.ExecuteNonQuery();
                //conexion.Close();
                conexion.Dispose();
                salida = true;
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }


        public bool InsertarProducto(int IDProducto, string ClaveProducto, string Descripcion, string Unidad, double Precio, bool Borrado, string Observaciones, bool EsComplemento, int Accion, string ClaveAlterna, string CveCiudad, string Clasificacion)
        {
            Metodo = "InsertarProducto";
            bool obj = false;
            Pedidos.BC.Producto Cliente = new Pedidos.BC.Producto();

            try
            {
                obj = Cliente.InsertarProducto( IDProducto,  ClaveProducto,  Descripcion,  Unidad,  Precio,  Borrado,  Observaciones,  EsComplemento,  Accion,  ClaveAlterna,  CveCiudad,  Clasificacion);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public bool ActualizarProducto(int IDProducto, string ClaveProducto, string Descripcion, string Unidad, double Precio, bool Borrado, string Observaciones)
        {
            Metodo = "ActualizarProducto";
            Pedidos.BC.Producto Cliente = new Pedidos.BC.Producto();
            bool obj = false;

            try
            {
                obj = Cliente.ActualizarProducto(IDProducto, ClaveProducto, Descripcion, Unidad, Precio, Borrado, Observaciones, true);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
                obj = false;
            }

            return obj;
        }

        public List<Producto> ObtenerProducto(int Complemento, string CveCiudad)
        {
            Metodo = "ObtenerProducto";
            Pedidos.BC.Producto Cliente = new Pedidos.BC.Producto();
            List<Producto> obj = new List<Producto>();

            try
            {
                obj = Cliente.ObtenerProductos(Complemento, CveCiudad);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }


        public List<Producto> ObtenerProductoFiltro(string _filtro,string clasificacion,string CveCiudad)
        {
            Metodo = "ObtenerProductoFiltro";
            Pedidos.BC.Producto Cliente = new Pedidos.BC.Producto();
            List<Producto> obj = new List<Producto>();

            try
            {
                string xmlRespuesta = Cliente.ObtenerProductosFiltro(_filtro,clasificacion,CveCiudad);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Producto>));
                obj = (List<Producto>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }
    }
}
