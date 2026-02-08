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

    public class AgenteCatalogos : IAgenteCatalogos
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.5.1";
        string Service = "AgenteCatalogos.cs";
        string Metodo = string.Empty;
        public Pedidos.BC.Catalogos BC = new Pedidos.BC.Catalogos();

        public List<Categoria> LeerCatalogos(int TipoCatalogo)
        {
            List<Categoria> salida = new List<Categoria>();
            try
            {
                salida = BC.LeerCatalogos(TipoCatalogo);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Service, Metodo, ex.Message.ToString());
            }

            return salida;
        }

    }
}
