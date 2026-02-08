using Concretec.Pedidos.BE;
using Concretec.Pedidos.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Agentes
{
    public class AgenteCB2 : IAgenteCB2
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.0";
        readonly string Servicio = "AgenteCB2.cs";
        string Metodo = string.Empty;

        public List<LogCb2> ConsultaErrorConexiones(DateTime Desde, string Ciudad, string Planta)
        {
            Pedidos.BC.Cb2BC client = new Pedidos.BC.Cb2BC();
            List<LogCb2> obj = new List<LogCb2>();
            Metodo = "ConsultaErrorConexiones";

            try
            {
                obj = client.ConsultaErrorConexiones(Desde, Ciudad, Planta);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<LogCb2> UltimaFechaDatosCb2(string Ciudad, string Planta)
        {
            Pedidos.BC.Cb2BC client = new Pedidos.BC.Cb2BC();
            List<LogCb2> obj = new List<LogCb2>();
            Metodo = "UltimaFechaDatosCb2";

            try
            {
                obj = client.UltimaFechaDatosCb2(Ciudad,Planta);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<LogCb2> ConsultaConexiones(DateTime Desde)
        {
            Pedidos.BC.Cb2BC client = new Pedidos.BC.Cb2BC();
            List<LogCb2> obj = new List<LogCb2>();
            Metodo = "ConsultaConexiones";

            try
            {
                obj = client.ConsultaConexiones(Desde);
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
