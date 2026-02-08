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
    public class AgenteParametros : IAgenteParametros
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.5";
        readonly string Servicio = "AgenteParametros.cs";
        string Metodo = string.Empty;

        

        public bool ActualizaParametro(int IDParametro, string Valor, string Descripcion)
        {
            Metodo = "ActualizaParametro";
            Pedidos.BC.Catalogos Cliente = new Pedidos.BC.Catalogos();
            bool obj = false;
            try
            {
                obj = Cliente.ActualizaParametro(IDParametro, Valor, Descripcion);
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
