using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using Concretec.Pedidos.Utils;
using Concretec.Pedidos.BE;
using System.Configuration;
using System.IO;
namespace Concretec.Pedidos.BC
{
    public class Obras : IObras
    {

        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.5";
        readonly string Servicio = "Clientes.cs";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return ConfigurationManager.AppSettings["conexion"].ToString(); }
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
        public bool ActualizarObra
            (
            int IDObra,
            string ClaveObra,
            string Direccion,
            string Nombre,
            string Telefonos,
            string Responsable,
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
            string Colonia,
            string Altitud,
            string Latitud,
            string URLMaps,
            string MunicipioSepomex
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
            command.Parameters.AddWithValue("@Altitud", Altitud);
            command.Parameters.AddWithValue("@Latitud", Latitud);
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
            command.Parameters.AddWithValue("@URLMaps", URLMaps);
            command.Parameters.AddWithValue("@MunicipioSEPOMEX", MunicipioSepomex);
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
        public bool InsertarObra(
            string ClaveObra,
            string Direccion,
            string Nombre,
            string Telefonos,
            string Responsable,
            string Altitud,
            string Latitud,
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
            string Colonia,
            string UrlMaps,
            string MunicipioSepomex)
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
            command.Parameters.AddWithValue("@Altitud", Altitud);
            command.Parameters.AddWithValue("@Latitud", Latitud);
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
            command.Parameters.AddWithValue("@URLMaps", UrlMaps);

            command.Parameters.AddWithValue("@MunicipioSEPOMEX", MunicipioSepomex);

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
        public string ObtenerObrasFiltro(string Filtro, string planta, int CveCliente, string CveCiudad, int Estatus)
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

        public List<Obra> ObtenerObrasFiltroActivas(string Filtro, string planta, int CveCliente, string CveCiudad)
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

            List<Obra> salida   = new List<Obra>();
            Obra elemento       = new Obra();

            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new Obra();

                        elemento.ClaveObra = dr["ClaveObra"].ToString().Trim();
                        elemento.Nombre = dr["Nombre"].ToString().Trim();
                        elemento.Vendedor =int.Parse( dr["Vendedor"].ToString().Trim());
                        elemento.Distancia = int.Parse(dr["Distancia"].ToString().Trim());
                        elemento.IDPlanta = int.Parse(dr["IDPlanta"].ToString().Trim());

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

        public List<Archivos> ListaArchivos()
        {
            List<Archivos> Salida = new List<Archivos>();
            Archivos item = new Archivos();

            item = new Archivos();
            item.Ciudad = "MTY";
            item.Nombre = "CLIEMTY";
            item.TipoArchivo = "Obras";
            Salida.Add(item);

            item = new Archivos();
            item.Ciudad = "GDL";
            item.Nombre = "CLIEGDL";
            item.TipoArchivo = "Obras";
            Salida.Add(item);

            item = new Archivos();
            item.Ciudad = "AGS";
            item.Nombre = "CLIEAGS";
            item.TipoArchivo = "Obras";
            Salida.Add(item);

            item = new Archivos();
            item.Ciudad = "LEON";
            item.Nombre = "CLIELEON";
            item.TipoArchivo = "Obras";

            Salida.Add(item);
            return Salida;
        }


        public bool InsertarNuevasObras()
        {
            return true;
        }

        public bool AjustarObras()
        {
            // En la primera vuelta hay que insertar los valores que son nuevos
            Metodo = "AjustarObras";
            SqlConnection conexion;
            bool salida = false;

            try
            {
                conexion = new System.Data.SqlClient.SqlConnection(ConnectionString);
                SqlCommand command = new SqlCommand("AJUSTAROBRAS", conexion);
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

        public bool InsertarObraParadox(
            string ClaveObra,
            string Direccion,
            string Nombre,
            string Telefonos,
            string Responsable,
            string Roji,
            bool Estatus,
            string RFC,
            string Poblacion,
            string CP,
            string ClaveZona,
            string Planta,
            string ClaveCliente,
            float Distancia,
            string TiempoCiclo,
            string Zona,
            string CveCiudad,
            string Colonia
        )
        {
            Metodo = "InsertarObraParadox";
            SqlConnection conexion;
            bool salida = false;

            try
            {
                conexion = new System.Data.SqlClient.SqlConnection(ConnectionString);
                SqlCommand command = new SqlCommand("InsertaObraParadox", conexion);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClaveObra", ClaveObra);
                command.Parameters.AddWithValue("@Direccion", Direccion);
                command.Parameters.AddWithValue("@Nombre", Nombre);
                command.Parameters.AddWithValue("@Telefonos", Telefonos);
                command.Parameters.AddWithValue("@Responsable", Responsable);
                command.Parameters.AddWithValue("@Roji", Roji);
                command.Parameters.AddWithValue("@Estatus", Estatus);
                command.Parameters.AddWithValue("@RFC", RFC);
                command.Parameters.AddWithValue("@Poblacion", Poblacion);
                command.Parameters.AddWithValue("@CP", CP);
                command.Parameters.AddWithValue("@ClaveZona", ClaveZona);
                command.Parameters.AddWithValue("@Planta", Planta);
                command.Parameters.AddWithValue("@ClaveCliente", ClaveCliente);
                command.Parameters.AddWithValue("@Distancia", Distancia);
                command.Parameters.AddWithValue("@TiempoCiclo", TiempoCiclo);
                command.Parameters.AddWithValue("@Zona", Zona);
                command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
                command.Parameters.AddWithValue("@Colonia", Colonia);
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        public bool CargaObrasParadox()
        {
            Metodo = "CargaObrasParadox";
            List<Archivos> Lista = new List<Archivos>();
            bool Insertar = new bool();
            bool Actualizar = new bool();
            List<CLIE01> ListaClientes = new List<CLIE01>();
            OleDbConnection _connection = new OleDbConnection();
            StringBuilder ConnectionString = new StringBuilder("");
            CLIE01 ClienteInformix = new CLIE01();
            bool Estatus = false;

            ConnectionString.Append(@"Provider=Microsoft.Jet.OLEDB.4.0;");
            ConnectionString.Append(@"Extended Properties=Paradox 5.x;");
            ConnectionString.Append(@"Data Source=C:\Concretec\;");

            Lista = ListaArchivos();
            foreach (Archivos ii in Lista)
            {
                if (File.Exists(@"C:\Concretec\" + ii.Nombre + ".db"))
                {
                    if (_connection.State.ToString() == "Open")
                    {
                        _connection.Close();
                    }

                    _connection.ConnectionString = ConnectionString.ToString();
                    _connection.Open();
                    ListaClientes = new List<CLIE01>();

                    try
                    {
                        OleDbCommand _Comando = new OleDbCommand("SELECT * FROM " + ii.Nombre.ToString() + " WHERE CLASIFIC = 'OBRAS';", _connection);
                        OleDbDataReader DR = _Comando.ExecuteReader();

                        if (DR.HasRows)
                        {
                            while (DR.Read())
                            {
                                ClienteInformix = new CLIE01();
                                ClienteInformix.CCLIE = DR["CCLIE"].ToString().Trim();
                                ClienteInformix.DIR = DR["DIR"].ToString().Trim();
                                ClienteInformix.NOMBRE = DR["NOMBRE"].ToString().Trim();
                                ClienteInformix.TELEFONO = DR["TELEFONO"].ToString().Trim(); ;
                                ClienteInformix.ATENCION = DR["ATENCION"].ToString().Trim();
                                ClienteInformix.CAMLIBRE1 = DR["CAMLIBRE1"].ToString().Trim();
                                ClienteInformix.STATUS = DR["STATUS"].ToString().Trim();
                                ClienteInformix.RFC = DR["RFC"].ToString().Trim();
                                ClienteInformix.POB = DR["POB"].ToString().Trim();
                                ClienteInformix.CVE_ZONA = DR["CVE_ZONA"].ToString().Trim();
                                ClienteInformix.CAMLIBRE2 = DR["CAMLIBRE2"].ToString().Trim();
                                ClienteInformix.CAMLIBRE3 = DR["CAMLIBRE3"].ToString().Trim();
                                ClienteInformix.CAMLIBRE5 = DR["CAMLIBRE5"].ToString().Trim();
                                ClienteInformix.CAMLIBRE6 = DR["CAMLIBRE5"].ToString().Trim();
                                ClienteInformix.ZONA = DR["ZONA"].ToString().Trim();
                                ClienteInformix.COLONIA = DR["COLONIA"].ToString().Trim();

                                ListaClientes.Add(ClienteInformix);
                            }
                        }

                        _connection.Close();

                        foreach (CLIE01 i in ListaClientes)
                        {
                            if (i.STATUS == "A") { Estatus = true; } else { Estatus = false; }

                            Insertar = new bool();
                            Insertar = InsertarObraParadox(i.CCLIE, i.DIR, i.NOMBRE, i.TELEFONO, i.ATENCION, i.CAMLIBRE1, Estatus,
                                i.RFC, i.POB, "", i.CVE_ZONA, i.CAMLIBRE2, i.CAMLIBRE3, float.Parse(i.CAMLIBRE5), i.CAMLIBRE6, i.ZONA, ii.Ciudad.ToString(), i.COLONIA);
                        }

                    }
                    catch (Exception ex)
                    {
                        BitError = new BitacoraErrores();
                        BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
                    }

                    Utils.UtilsArchivos TS = new Utils.UtilsArchivos();
                    TS.TransferirArchivos(ii.Nombre + ".db", @"C:\Concretec\", @"C:\Concretec\Procesados\");
                }


            }
            Actualizar = AjustarObras();
            return true;
        }

        public List<BE.Sepomex> BUSCAINFO_CP(string CP)
        {
            Metodo = "BUSCAINFO_CP";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BUSCAINFO_CP", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CP", CP);

            SqlDataReader dr = null;

            List<BE.Sepomex> salida = new List<BE.Sepomex>();
            BE.Sepomex elemento = new BE.Sepomex();
            try
            {
                conexion.Open();
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new BE.Sepomex();

                        elemento.CP_ID          = dr["CP_ID"].ToString();
                        elemento.CP             = dr["CP"].ToString();
                        elemento.Municipio      = dr["Municipio"].ToString();
                        elemento.Estado         = dr["Estado"].ToString();
                        elemento.CveEstado      = dr["CveEstado"].ToString();
                        elemento.CveMunicipio   = dr["CveMunicipio"].ToString();
                        elemento.CveLocalidad   = dr["CveLocalidad"].ToString();

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

            return salida;
        }

        public List<BE.Obra> BuscaObrasAlitudLatitud(string CveCiduad,DateTime Desde,DateTime Hasta)
        {
            Metodo = "BuscaRemisionesSyncPedido";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BuscaObrasAlitudLatitud", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            
            command.Parameters.AddWithValue("@Desde", Desde);
            command.Parameters.AddWithValue("@Hasta", Hasta);
            command.Parameters.AddWithValue("@CveCiudad", CveCiduad);

            SqlDataReader dr = null;

            List<BE.Obra> salida = new List<BE.Obra>();
            BE.Obra elemento = new BE.Obra();
            try
            {
                conexion.Open();
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new BE.Obra();

                        elemento.ClaveObra      = dr["ClaveObra"].ToString();
                        elemento.Direccion      = dr["Direccion"].ToString();
                        elemento.Nombre         = dr["Nombre"].ToString();
                        elemento.CveCiudad      = dr["CveCiudad"].ToString();
                        elemento.Altitud        = dr["Altitud"].ToString();
                        elemento.Latitud        = dr["Latitud"].ToString();

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

            return salida;
        }

        public List<Planta> LeerPlantasObras(string CveCiudad)
        {
            Metodo = "LeerPlantasObras";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerPlantasObras", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);


            List<Planta> salida = new List<Planta>();
            Planta elemento = new Planta();
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new Planta();

                        elemento.IDPlanta   = int.Parse(dr["IDPlanta"].ToString());
                        elemento.Nombre     = dr["Nombre"].ToString().Trim();
                        elemento.CvePlanta  = dr["CvePlanta"].ToString().Trim();

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
    }
}
