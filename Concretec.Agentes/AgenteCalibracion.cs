using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Concretec.Pedidos.BE;
using Concretec.Pedidos.BC;
using Concretec.Pedidos.Utils;

namespace Concretec.Agentes
{
    public class AgenteCalibracion
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.5.1";
        string Service = "AgenteCatalogos.cs";
        string Metodo = string.Empty;
        Pedidos.BC.Calibracion bc = new Pedidos.BC.Calibracion();
        public bool InsertaCalibracion(Pedidos.BE.Calibracion registro)
        {
            bool salida = false;
            try
            {
                salida = bc.InsertaCalibracion(registro);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Service, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public bool ActualizaCalibracion(Pedidos.BE.Calibracion registro)
        {
            bool salida = false;
            try
            {
                salida = bc.ActualizaCalibracion(registro);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Service, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public List<Pedidos.BE.Calibracion> ListaCalibraciones(DateTime Desde, DateTime Hasta, string CveCiudad, int PlantaId, int IdCalibracion)
        {
            List<Pedidos.BE.Calibracion> salida = new List<Pedidos.BE.Calibracion>();

            try
            {
                salida = bc.ListaCalibraciones( Desde,  Hasta,  CveCiudad,  PlantaId,  IdCalibracion);
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
