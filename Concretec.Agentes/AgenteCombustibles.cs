using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using Concretec.Pedidos.BE;
using Concretec.Pedidos.Utils;
using Concretec.Pedidos.BC;

namespace Concretec.Agentes
{
    public class AgenteCombustibles
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.5";
        readonly string Servicio = "AgenteCombustibles.cs";
        string Metodo = string.Empty;

        public bool RegistraSalidaCombustible(Tanque entidad)
        {
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            bool obj = false;
            Metodo = "RegistraSalidaCombustible";

            try
            {
                obj = Cliente.RegistraSalidaCombustible(entidad);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }


        public bool RegistraEntradaCombustible(Tanque entidad)
        {
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            bool obj = false;
            Metodo = "RegistraEntradaCombustible";

            try
            {
                obj = Cliente.RegistraEntradaCombustible(entidad);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Tanque> Busca_Resumen_Tanque(string ciudad, int idTanque)
        {
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            List<Tanque> obj = new List<Tanque>();
            Metodo = "Busca_Resumen_Tanque";

            try
            {
                obj = Cliente.Busca_Resumen_Tanque(ciudad, idTanque);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Tanque> Busca_Remision_Tanque(string remision)
        {
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            List<Tanque> obj = new List<Tanque>();
            Metodo = "Busca_Remision_Tanque";

            try
            {
                obj = Cliente.Busca_Remision_Tanque(remision);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }


        public List<Tanque> Busca_Altura_Volumen_Tanque(int Temperatura, float Litros15C, int TanqueId)
        {
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            List<Tanque> obj = new List<Tanque>();
            Metodo = "Busca_Altura_Volumen_Tanque";

            try
            {
                obj = Cliente.Busca_Altura_Volumen_Tanque( Temperatura,  Litros15C,  TanqueId);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Tanque> Busca_Volumen_Altura_Taque(int TanqueId, float altura)
        {
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            List<Tanque> obj = new List<Tanque>();
            Metodo = "Busca_Volumen_Altura_Taque";

            try
            {
                obj = Cliente.Busca_Volumen_Altura_Taque(TanqueId, altura);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public Tanque ValoresCalculoSalida(int idunidad, float odometro, float horimetro)
        {
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            Tanque obj = new Tanque();
            Metodo = "ValoresCalculoSalida";

            try
            {
                obj = Cliente.ValoresCalculoSalida(idunidad, odometro, horimetro);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Tanque> Busca_Volumen_Temperatura(int TanqueId, float Temperatura, float volumen)
        {
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            List<Tanque> obj = new List<Tanque>();
            Metodo = "Busca_Volumen_Temperatura";

            try
            {
                obj = Cliente.Busca_Volumen_Temperatura(TanqueId, Temperatura, volumen);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Tanque> BuscaInfoTanque(int TanqueId)
        {
            Pedidos.BC.Combustibles Cliente = new Pedidos.BC.Combustibles();
            List<Tanque> obj = new List<Tanque>();
            Metodo = "BuscaInfoTanque";

            try
            {
                obj = Cliente.BuscaInfoTanque(TanqueId);
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
