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
    public class AgenteCheques
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.5";
        string Service = "AgenteCheques.cs";
        string Metodo = string.Empty;

        public List<Cheques> BuscaCheques(int Clienteid, DateTime desde, DateTime hasta, int estatus)
        {
            List<Cheques> salida = new List<Cheques>();
            Pedidos.BC.ChequesBC bc = new Pedidos.BC.ChequesBC();
            

            try
            {
                salida = bc.BuscaCheques(Clienteid, desde, hasta, estatus);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Service, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public Cheques InformacionCheque(int IdCheque)
        {

            Cheques salida = new Cheques();
            Pedidos.BC.ChequesBC bc = new Pedidos.BC.ChequesBC();

            try
            {
                salida = bc.InformacionCheque(IdCheque);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Service, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public List<ChequeSeguimiento> LeerChequesSeguimientos(int IdCheque)
        {

            List<ChequeSeguimiento> salida = new List<ChequeSeguimiento>();
            Pedidos.BC.ChequesBC bc = new Pedidos.BC.ChequesBC();

            try
            {
                salida = bc.LeerChequesSeguimientos(IdCheque);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Service, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public bool InsertaSeguimiento(Cheques cheque)
        {
            Metodo = "InsertaSeguimiento";
            Pedidos.BC.ChequesBC Servicio = new Pedidos.BC.ChequesBC();

            bool obj = false;
            try
            {
                obj = Servicio.InsertaSeguimiento(cheque);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Service, Metodo, ex.Message.ToString());
            }
            return true;
        }

        public bool ActualizaCheque(Cheques cheque)
        {
            Metodo = "ActualizaCheque";
            Pedidos.BC.ChequesBC Servicio = new Pedidos.BC.ChequesBC();

            bool obj = false;
            try
            {
                obj = Servicio.ActualizaCheque(cheque);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Service, Metodo, ex.Message.ToString());
            }
            return true;
        }

        public List<Banco> LeerBancos()
        {
            List<Banco> salida = new List<Banco>();
            Pedidos.BC.ChequesBC Servicio = new Pedidos.BC.ChequesBC();
            salida = Servicio.LeerBancos();
            return salida;
        }

        public bool InsertaCheque(Cheques cheque)
        {
            Metodo = "InsertaCheque";
            Pedidos.BC.ChequesBC Servicio = new Pedidos.BC.ChequesBC();

            bool obj = false;
            try
            {
                obj = Servicio.InsertaCheque(cheque);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Service, Metodo, ex.Message.ToString());
            }

            // para fines de prueba se regresa verdadero
            //return obj;

            return true;
        }


    }
}
