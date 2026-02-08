using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using Concretec.Pedidos.BE;
using Concretec.Pedidos.Utils;

namespace Concretec.Agentes
{
    public class AgenteFiltros : IAgenteFiltros
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.5";
        readonly string Servicio = "AgenteFiltros.cs";
        string Metodo = string.Empty;

        public List<Filtro> llenaCombo(string TipoCombo, string CveCiudad, string Parametro1, string Parametro2, string Parametro3)
        {
            Metodo = "llenaCombo";
            Pedidos.BC.Catalogos client = new Pedidos.BC.Catalogos();

            List<Filtro> obj = new List<Filtro>();
            try
            {
                string xmlRespuesta = client.LlenaCombos(TipoCombo, CveCiudad, Parametro1, Parametro2, Parametro3);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Filtro>));
                obj = (List<Filtro>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Categoria> LeerCategorias(int IdCategoria)
        {
            Pedidos.BC.Configuracion Cliente = new Pedidos.BC.Configuracion();
            List<Categoria> obj = new List<Categoria>();
            Metodo = "LeerCategorias";
            try
            {
                string xmlRespuesta = Cliente.LeerCategorias(IdCategoria);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Categoria>));
                obj = (List<Categoria>)xs.Deserialize(new StringReader(xmlRespuesta));
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
