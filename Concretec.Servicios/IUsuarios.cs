using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Concretec.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsuarios" in both code and config file together.
    [ServiceContract]
    public interface IUsuarios
    {
        [OperationContract]
        bool InsertaUsuario(Guid IDUsuario, string username, string password, string nombre, string APaterno, string AMaterno, string Correo, int IDCiudad, int IDPerfil, int IDPlanta);

        [OperationContract]
        bool ActualizaUsuario(Guid IDUsuario, string username, string password, string nombre, string APaterno, string AMaterno, string Correo, int IDCiudad, int IDPerfil, int IDPlanta);

        [OperationContract]
        string BuscaUsuarioEdicion(int IDUsuario);

        [OperationContract]
        string BuscaUsuario(string Filtro, int IdPerfil, int IdCiudad);

        [OperationContract]
        string ValidaUsuario(string usuario,string password);

        [OperationContract]
        string ListaModulos();

        [OperationContract]
        string ListaPerfiles();

        [OperationContract]
        bool ActualizaPassword(string CveUsuario,string OldPassword, string NewPassword);
        
    }
}
