using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using Concretec.Pedidos.BE;
using Concretec.Pedidos.Utils;
using Concretec.Pedidos.BC;

namespace Concretec.Agentes
{
    public class AgenteBitacora : IAgenteBitacora
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.5";
        readonly string Servicio = "AgenteBitacora.cs";
        string Metodo = string.Empty;

        public List<Bitacora> HistorialLog(DateTime fechainicial, DateTime fechafinal)
        {
            Metodo = "HistorialLog";
            Logs client = new Logs();
            List<Bitacora> obj = new List<Bitacora>();
            try
            {
                string xmlRespuesta = client.HistorialLog(fechainicial, fechafinal);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Bitacora>));
                obj = (List<Bitacora>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }


            return obj;
        }

        public List<Bitacora> ObtenerHistorialBitacora(int IDModulo, DateTime? fechainicial, DateTime? fechafinal)
        {
            Metodo = "ObtenerHistorialBitacora";
            Logs client = new Pedidos.BC.Logs();
            List<Bitacora> obj = new List<Bitacora>();
            try
            {
                string xmlRespuesta = client.HistorialBitacora(IDModulo, fechainicial, fechafinal);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Bitacora>));
                obj = (List<Bitacora>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;

        }

        public BitacoraResumen ObtenerBitacoraResumen()
        {
            Metodo = "ObtenerBitacoraResumen";
            BitacoraResumen obj = new BitacoraResumen();
            List<BitacoraResumen> Lista = new List<BitacoraResumen>();
            Pedidos.BC.Logs client = new Pedidos.BC.Logs();

            try
            {
                string xmlRespuesta = client.BitacoraResumen();
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                Lista = new List<BitacoraResumen>();
                XmlSerializer xs = new XmlSerializer(typeof(List<BitacoraResumen>));
                Lista = (List<BitacoraResumen>)xs.Deserialize(new StringReader(xmlRespuesta));
                obj = new BitacoraResumen();
                obj = Lista[0];
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
