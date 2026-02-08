using Concretec.Pedidos.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concretec.Pedidos.BC
{
    public interface ICatalogos
    {
        string TipoViaje();
        string MotivosCambio();
        bool InsertaContingencia(int idContingencia, string nombre, int estatus);
        bool ActualizaParametro(int IDParametro, string Valor, string Descripcion);
        string LlenaCombos(string TipoCombo, string CveCiudad, string Parametro1, string Parametro2, string Parametro3);
        string LeerUsos();
        string ListaComentarios(int IDTipocomentario);
        string ObtenerPlantas();
        string LeerEstatusViaje();
        string LeerPlantasObras(string CveCiudad);
        string ObtenerCiudades();
        string ListaPerfiles();
        bool ActualizaPassword(string CveUsuario, string OldPassword, string NewPassword);
        bool InsertaUsuario(Guid IDUsuario, string username, string password, string nombre, string APaterno, string AMaterno, string Correo, int IDCiudad, int IDPerfil, int IDPlanta);
        bool ActualizaUsuario(Guid IDUsuario, string username, string password, string nombre, string APaterno, string AMaterno, string Correo, int IDCiudad, int IDPerfil, int IDPlanta);
        string BuscaUsuarioEdicion(int IDUsuario);
        string BuscaUsuario(string Filtro, int IdPerfil, int IdCiudad);
        List<Categoria> LeerCatalogos(int TipoCatalogo);

    }
}
