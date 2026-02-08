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
    public class AgenteUsuarios : IAgenteUsuarios
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.5";
        readonly string Servicio = "AgenteUsuarios.cs";
        string Metodo = string.Empty;

        public List<Usuario> BuscarProgramadorPedido(string CveCiudad, DateTime Desde, DateTime Hasta, int IdCliente)
        {
            Pedidos.BC.Usuario Cliente = new Pedidos.BC.Usuario();
            List<Usuario> obj = new List<Usuario>();
            Metodo = "ValidaUsuario";

            try
            {
                obj = Cliente.BuscarProgramadorPedido( CveCiudad,  Desde,  Hasta,  IdCliente);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Usuario> ValidaUsuario(string usuario, string password)
        {

            Pedidos.BC.Usuario Cliente = new Pedidos.BC.Usuario();
            List<Usuario> obj = new List<Usuario>();
            Metodo = "ValidaUsuario";

            try
            {
                obj = Cliente.ValidaUsuario(usuario, password);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            
            return obj;
        }

        public List<Perfil> ObtenerPerfiles()
        {
            Pedidos.BC.Catalogos Cliente = new Pedidos.BC.Catalogos();
            List<Perfil> obj = new List<Perfil>();
            Metodo = "ObtenerPerfiles";

            try
            {
                string xmlRespuesta = Cliente.ListaPerfiles();
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Perfil>));
                obj = (List<Perfil>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }


        public bool ActualizaPassword(string CveUsuario, string OldPassword, string NewPassword)
        {
            Metodo = "InsertaUsuario";
            Pedidos.BC.Catalogos Cliente = new Pedidos.BC.Catalogos();

            bool obj = false;
            try
            {
                obj = Cliente.ActualizaPassword(CveUsuario, OldPassword, NewPassword);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public bool InsertaUsuario(Guid IDUsuario, string username, string password, string nombre, string APaterno, string AMaterno, string Correo, int IDCiudad, int IDPerfil,int IDPlanta)
        {
            Metodo = "InsertaUsuario";
            Pedidos.BC.Catalogos Cliente = new Pedidos.BC.Catalogos();

            bool obj = false;
            try
            {
                obj = Cliente.InsertaUsuario(IDUsuario, username, password, nombre, APaterno, AMaterno, Correo, IDCiudad, IDPerfil, IDPlanta);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }


        public bool ActualizaUsuario(Guid IDUsuario, string username, string password, string nombre, string APaterno, string AMaterno, string Correo, int IDCiudad, int IDPerfil,int IDPlanta)
        {
            Metodo = "ActualizaUsuario";
            Pedidos.BC.Catalogos Cliente = new Pedidos.BC.Catalogos();

            bool obj = false;
            try
            {
                obj = Cliente.ActualizaUsuario(IDUsuario, username, password, nombre, APaterno, AMaterno, Correo, IDCiudad, IDPerfil, IDPlanta);
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Usuario> BuscaUsuarioEdicion(int IDUsuario)
        {
            Pedidos.BC.Catalogos Cliente = new Pedidos.BC.Catalogos();
            List<Usuario> obj = new List<Usuario>();
            Metodo = "BuscaUsuarioEdicion";

            try
            {
                string xmlRespuesta = Cliente.BuscaUsuarioEdicion(IDUsuario);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Usuario>));
                obj = (List<Usuario>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        public List<Usuario> BuscaUsuario(string Filtro, int IdPerfil, int IdCiudad)
        {
            Pedidos.BC.Catalogos Cliente = new Pedidos.BC.Catalogos();
            List<Usuario> obj = new List<Usuario>();
            Metodo = "BuscaUsuario";

            try
            {
                string xmlRespuesta = Cliente.BuscaUsuario( Filtro,  IdPerfil,  IdCiudad);
                xmlRespuesta = xmlRespuesta.Replace("&lt;", "<").Replace("&gt;", ">");
                XmlSerializer xs = new XmlSerializer(typeof(List<Usuario>));
                obj = (List<Usuario>)xs.Deserialize(new StringReader(xmlRespuesta));
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return obj;
        }

        //
    }
}
