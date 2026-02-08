using System;
namespace Concretec.Pedidos.BC
{
    public interface IConfiguracion
    {
        string CadenaConexionI();
        string LeerCategorias(int IdCategoria);
    }
}
