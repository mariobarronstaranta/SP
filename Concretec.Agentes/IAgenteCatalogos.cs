using System.Collections.Generic;
using Concretec.Pedidos.BE;

namespace Concretec.Agentes
{
    public interface IAgenteCatalogos
    {
        List<Categoria> LeerCatalogos(int TipoCatalogo);
    }
}