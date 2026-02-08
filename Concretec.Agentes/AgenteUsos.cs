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
    public class AgenteUsos : IAgenteUsos
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.0";
        readonly string Servicio = "AgenteUsos.cs";
        string Metodo = string.Empty;

        public List<Uso> LeerUsos()
        {
            Pedidos.BC.Catalogos Cliente = new Pedidos.BC.Catalogos();
            List<Uso> obj = new List<Uso>();

            try
            {
                string xmlRespuesta = Cliente.LeerUsos();
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Uso>));
                obj = (List<Uso>)xs.Deserialize(new StringReader(xmlRespuesta));
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
