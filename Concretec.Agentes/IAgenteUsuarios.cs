using System;
using System.Collections.Generic;
using Concretec.Pedidos.BE;

namespace Concretec.Agentes
{
    public interface IAgenteUsuarios
    {
        bool ActualizaPassword(string CveUsuario, string OldPassword, string NewPassword);
        bool ActualizaUsuario(Guid IDUsuario, string username, string password, string nombre, string APaterno, string AMaterno, string Correo, int IDCiudad, int IDPerfil, int IDPlanta);
        List<Usuario> BuscaUsuario(string Filtro, int IdPerfil, int IdCiudad);
        List<Usuario> BuscaUsuarioEdicion(int IDUsuario);
        bool InsertaUsuario(Guid IDUsuario, string username, string password, string nombre, string APaterno, string AMaterno, string Correo, int IDCiudad, int IDPerfil, int IDPlanta);
        List<Perfil> ObtenerPerfiles();
        List<Usuario> ValidaUsuario(string usuario, string password);
        List<Usuario> BuscarProgramadorPedido(string CveCiudad, DateTime Desde, DateTime Hasta, int IdCliente);
    }
}