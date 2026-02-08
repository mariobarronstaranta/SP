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
    public class AgentePlantas : IAgentePlantas
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.5";
        readonly string Servicio = "AgentePlantas.cs";
        string Metodo = string.Empty;



        public List<Planta> ObtenerPlantasCiudad(string CveCiudad)
        {
            Pedidos.BC.Plantas client = new Pedidos.BC.Plantas();
            List<Planta> obj = new List<Planta>();
            Metodo = "ObtenerPlantasCiudad";

            try
            {
                string xmlRespuesta = client.ObtenerPlantasCiudad(CveCiudad);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Planta>));
                obj = (List<Planta>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

      
            return obj;
        }

        public List<Planta> ObtenerPlantasFiltro(string nombre, string cveDosificadora,string CveCiudad)
        {
            Pedidos.BC.Plantas client = new Pedidos.BC.Plantas();
            List<Planta> obj = new List<Planta>();
            Metodo = "ObtenerPlantasFiltro";

            try
            {
                string xmlRespuesta = client.ObtenerPlantasFiltro(nombre, cveDosificadora, CveCiudad);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Planta>));
                obj = (List<Planta>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public bool ActPlanta(int IDPlanta, string Nombre, string CveDosificadora, bool Estatus, string Telefono, string Telefono2, string IDCiudad, string Calle, string NumInt, string NumExt, int Accion, string Colonia, string Municipio, int IDJefePlanta, string CvePlanta, int IDPlantaAlterna1, int IDPlantaAlterna2)
        {
            Pedidos.BC.Plantas Cliente = new Pedidos.BC.Plantas();
            bool obj = false;
            Metodo = "ActPlanta";

            try
            {
                obj = Cliente.InsertarPlanta(IDPlanta, Nombre, CveDosificadora, Estatus, Telefono, Telefono2, IDCiudad, Calle, NumInt, NumExt, 1, Colonia, Municipio, IDJefePlanta, CvePlanta, IDPlantaAlterna1, IDPlantaAlterna2);
                return true;
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public bool InsertarPlanta(int IDPlanta, string Nombre, string CveDosificadora, bool Estatus, string Telefono, string Telefono2, string IDCiudad, string Calle, string NumInt, string NumExt, int Accion, string Colonia, string Municipio, int IDJefePlanta, string CvePlanta, int IDPlantaAlterna1, int IDPlantaAlterna2)
        {
            Pedidos.BC.Plantas Cliente = new Pedidos.BC.Plantas();
            bool obj = false;
            Metodo = "InsertarPlanta";
            try
            {
                obj = Cliente.InsertarPlanta(0, Nombre, CveDosificadora, Estatus, Telefono, Telefono2, IDCiudad, Calle, NumInt, NumExt, 0, Colonia, Municipio, IDJefePlanta, CvePlanta, IDPlantaAlterna1, IDPlantaAlterna2);
                return true;
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return obj;
        }

        public List<Planta> ObtenerPlantasObra(string CveCiudad)
        {
            Pedidos.BC.Obras Agente = new Pedidos.BC.Obras();
            List<Planta> obj = new List<Planta>();
            Metodo = "ObtenerPlantasObra";

            try
            {
                obj = Agente.LeerPlantasObras(CveCiudad);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Planta> ConsultaPlanta(int IdPlanta)
        {
            Pedidos.BC.Plantas Cliente = new Pedidos.BC.Plantas();
            List<Planta> obj = new List<Planta>();
            Metodo = "ObtenerPlantas";

            try
            {
                string xmlRespuesta = Cliente.ConsultaPlanta(IdPlanta);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Planta>));
                obj = (List<Planta>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }


            return obj;
        }

        public List<Planta> ObtenerPlantasBombeo()
        {
            Pedidos.BC.Plantas Cliente = new Pedidos.BC.Plantas();
            List<Planta> obj = new List<Planta>();
            Metodo = "ObtenerPlantasBombeo";

            try
            {
                string xmlRespuesta = Cliente.ObtenerPlantasBombeo();
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Planta>));
                obj = (List<Planta>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Planta> ObtenerPlantas()
        {
            Pedidos.BC.Catalogos Cliente = new Pedidos.BC.Catalogos();
            List<Planta> obj = new List<Planta>();
            Metodo = "ObtenerPlantas";

            try
            {
                string xmlRespuesta = Cliente.ObtenerPlantas();
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Planta>));
                obj = (List<Planta>)xs.Deserialize(new StringReader(xmlRespuesta));
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
