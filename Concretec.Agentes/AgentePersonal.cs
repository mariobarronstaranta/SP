using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Concretec.Pedidos.BE;
using Concretec.Pedidos.Utils;

namespace Concretec.Agentes
{
    public class AgentePersonal : IAgentePersonal
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.5";
        readonly string Servicio = "AgentePersonal.cs";
        string Metodo = string.Empty;

        public bool ActualizaPersonal(int idpersonal,string CvePersonal, string Nombre, string APaterno, string AMaterno, string Puesto, string TipoPersonal, string CveCiudad, int IDPlanta, string interno, string Estatus)
        {
            Metodo = "ActualizaPersonal";
            Pedidos.BC.Personal Cliente = new Pedidos.BC.Personal();

            bool obj = false;
            try
            {
                obj = Cliente.ActualizaPersonal(idpersonal,CvePersonal, Nombre, APaterno, AMaterno, Puesto, TipoPersonal, CveCiudad, IDPlanta, interno, Estatus);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public bool InsertarPersonal(string CvePersonal,string Nombre,string APaterno, string AMaterno,string Puesto,string TipoPersonal,string CveCiudad, int IDPlanta,string interno,string Estatus)
        {
            Metodo = "InsertarPersonal";
            Pedidos.BC.Personal Cliente = new Pedidos.BC.Personal();

            bool obj = false;
            try
            {
                obj = Cliente.InsertarPersonal(CvePersonal,Nombre,APaterno,AMaterno,Puesto,TipoPersonal,CveCiudad,IDPlanta,interno,Estatus);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public Personal BuscarEmpleadoClave(string ClavePersonal)
        {
            Metodo = "BuscarEmpleadoClave";
            Pedidos.BC.Personal client = new Pedidos.BC.Personal();
            List<Personal> obj = new List<Personal>();
            Personal empleado = new Personal();

            try
            {
                string xmlRespuesta = client.BuscarEmpleadoClave(ClavePersonal);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Personal>));
                obj = (List<Personal>)xs.Deserialize(new StringReader(xmlRespuesta));
                empleado = obj[0];
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return empleado;
        }

        public Personal BuscarEmpleado(string ClavePersonal)
        {
            Metodo = "BuscarEmpleado";
            Pedidos.BC.Personal client = new Pedidos.BC.Personal();
            List<Personal> obj = new List<Personal>();
            Personal empleado = new Personal();

            try
            {
                string xmlRespuesta = client.BuscarEmpleado(ClavePersonal);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Personal>));
                obj = (List<Personal>)xs.Deserialize(new StringReader(xmlRespuesta));
                empleado = obj[0];
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return empleado;
        }

        public List<Personal> ObtenerChoferUnidad(int IDUnidad, string CveCiudad)
        {
            Metodo = "ObtenerChoferUnidad";
            Pedidos.BC.Personal client = new Pedidos.BC.Personal();
            List<Personal> obj = new List<Personal>();

            try
            {
                string xmlRespuesta = client.ObtenerChoferUnidad(IDUnidad, CveCiudad);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Personal>));
                obj = (List<Personal>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }


        public List<Personal> ObtenerPersonalFiltro(string Filtro, string TipoPersonal, string CveCiudad, int Planta, string Estatus) 
        {
            Metodo = "ObtenerPersonalFiltro";
            Pedidos.BC.Personal client = new Pedidos.BC.Personal();
            List<Personal> obj = new List<Personal>();

            try
            {
                string xmlRespuesta = client.ObtenerPersonalFiltro(Filtro, TipoPersonal, CveCiudad, Planta, Estatus);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Personal>));
                obj = (List<Personal>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Personal> ObtenerPersonal(string TipoPersonal, string CveCiudad)
        {
            Metodo = "ObtenerPersonal";
            Pedidos.BC.Personal client = new Pedidos.BC.Personal();
            List<Personal> obj = new List<Personal>();


            try
            {
                string xmlRespuesta = client.ObtenerPersonal(TipoPersonal, CveCiudad);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Personal>));
                obj = (List<Personal>)xs.Deserialize(new StringReader(xmlRespuesta));
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
