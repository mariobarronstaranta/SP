using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Data.SqlClient;
using Concretec.Pedidos.BE;
using Concretec.Pedidos.Utils;

namespace Concretec.Agentes
{
    public class AgenteObras : IAgenteObras
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.5";
        readonly string Servicio = "AgenteObras.cs";
        string Metodo = string.Empty;

        public bool AjustarObras()
        {
            return true;
        }

        public bool CargarObra()
        {
            return true;
        }

        public bool InsertarObraParadox(int IDObra, string ClaveObra, string Direccion, string Nombre, string Telefonos,
           string Responsable, string Roji, string EntreCalles, bool Estatus)
        {
            Metodo = "InsertarObraParadox";
            SqlConnection conexion;
            bool salida = false;

            try
            {
                conexion = new System.Data.SqlClient.SqlConnection("server=localhost;database=Pedidos;uid=sa;pwd=Pato12345");
                SqlCommand command = new SqlCommand("InsertaObraParadox", conexion);
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
                conexion.Open();
                command.ExecuteNonQuery();
                salida = true;
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }


        public bool CargaObrasParadox()
        {
            Metodo = "CargaObrasParadox";
            Concretec.Pedidos.BC.Obras BC = new Concretec.Pedidos.BC.Obras();
            bool Insertar = new bool();

            try
            {
                Insertar = BC.CargaObrasParadox();
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            
            return Insertar;
        }

        public List<Sepomex> BUSCAINFO_CP(string CP)
        {
            Metodo = "BUSCAINFO_CP";
            Pedidos.BC.Obras client = new Pedidos.BC.Obras();
            List<Sepomex> obj = new List<Sepomex>();

            try
            {
                obj = client.BUSCAINFO_CP(CP);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Obra> BuscaObrasAlitudLatitud(string CveCiduad, DateTime Desde, DateTime Hasta)
        {
            Metodo = "BuscaObrasAlitudLatitud";
            Pedidos.BC.Obras client = new Pedidos.BC.Obras();
            List<Obra> obj = new List<Obra>();

            try
            {
                obj = client.BuscaObrasAlitudLatitud(CveCiduad, Desde, Hasta);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;

        }
        public string ObtenerNumeroObra(int CveCliente, string CveCiudad)
        {
            Metodo = "BuscarObra";
            Pedidos.BC.Obras client = new Pedidos.BC.Obras();
            string obj = "";

            try
            {
                obj = client.ObtenerNumeroObra(CveCliente, CveCiudad);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;

        }

        public Obra BuscarObra(int ClaveObra, string CveCiudad)
        {
            Metodo = "BuscarObra";
            Pedidos.BC.Obras client = new Pedidos.BC.Obras();
            List<Obra> obj = new List<Obra>();
            try
            {
                string xmlRespuesta = client.BuscarObra(ClaveObra, CveCiudad);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Obra>));
                obj = (List<Obra>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj[0];
        }

        public List<Obra> ObtenerObrasFiltroActivas(string Filtro, string planta, int CveCliente, string CveCiudad)
        {
            Metodo = "ObtenerObrasFiltroActivas";
            Pedidos.BC.Obras client = new Pedidos.BC.Obras();
            List<Obra> obj = new List<Obra>();
            try
            {
                obj = client.ObtenerObrasFiltroActivas(Filtro, planta, CveCliente, CveCiudad);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }


        public List<Obra> ObtenerObrasFiltro(string Filtro, string planta, int CveCliente, string CveCiudad, int Estatus)
        {
            Metodo = "ObtenerObrasFiltro";
            Pedidos.BC.Obras client = new Pedidos.BC.Obras();
            List<Obra> obj = new List<Obra>();
            try
            {
                string xmlRespuesta = client.ObtenerObrasFiltro(Filtro, planta, CveCliente, CveCiudad, Estatus);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Obra>));
                obj = (List<Obra>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public bool ActualizarObra(
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
            string MunicipioSepomex)
        {
            Metodo = "ActualizarObra";
            Pedidos.BC.Obras Servicio = new Pedidos.BC.Obras();
            bool obj = false;
            try
            {
                obj = Servicio.ActualizarObra(
                                     IDObra,
                                     ClaveObra,
                                     Direccion,
                                     Nombre,
                                     Telefonos,
                                     Responsable,
                                     EntreCalles,
                                     Estatus,
                                     IDVendedor,
                                     RFC,
                                     POBLACION,
                                     CP,
                                     ATENCION,
                                     CLAVEZONA,
                                     PLANTA,
                                     CLAVECLIENTE,
                                     DISTANCIA,
                                     TIEMPOCICLO,
                                     VOLUMENESTIMADO,
                                     VOLUMENACUMULADO,
                                     CVECIUDAD,
                                     Colonia,
                                     Altitud,
                                     Latitud,
                                     URLMaps,
                                     MunicipioSepomex);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, "AgenteObras.cs", Metodo, ex.Message.ToString());
            }

            return obj;
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
            Pedidos.BC.Obras Servicio = new Pedidos.BC.Obras();
            bool obj = false;
            try
            {
                obj = Servicio.InsertarObra(
                                     ClaveObra,
                                     Direccion,
                                     Nombre,
                                     Telefonos,
                                     Responsable,
                                     Altitud,
                                     Latitud,
                                     EntreCalles,
                                     Estatus,
                                     IDVendedor,
                                    RFC,
                                     POBLACION,
                                     CP,
                                     ATENCION,
                                     CLAVEZONA,
                                    PLANTA,
                                    CLAVECLIENTE,
                                     DISTANCIA,
                                     TIEMPOCICLO,
                                     VOLUMENESTIMADO,
                                     VOLUMENACUMULADO,
                                     CVECIUDAD,Colonia,UrlMaps, MunicipioSepomex);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, "AgenteObras.cs", Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Obra> ObtenerObras()
        {
            Metodo = "ObtenerObras";
            Pedidos.BC.Obras client = new Pedidos.BC.Obras();
            List<Obra> obj = new List<Obra>();

            try
            {
                string xmlRespuesta = client.ObtenerObras();
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Obra>));
                obj = (List<Obra>)xs.Deserialize(new StringReader(xmlRespuesta));
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
