using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Concretec.Pedidos.BE;
using Concretec.Pedidos.Utils;
using Concretec.Pedidos.BC;

namespace Concretec.Agentes
{
    public class AgenteCiudades : IAgenteCiudades
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion ="Programacion de Pedidos V 2.5";
        readonly string Servicio = "AgenteCiudades.cs";
        string Metodo = string.Empty;


        public List<Ciudad> ObtenerCiudades()
        {
            Metodo = "AgenteCiudades.cs";
            Catalogos client = new Catalogos();
            List<Ciudad> obj = new List<Ciudad>();

            try
            {
                string xmlRespuesta = client.ObtenerCiudades();
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Ciudad>));
                obj = (List<Ciudad>)xs.Deserialize(new StringReader(xmlRespuesta));
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
