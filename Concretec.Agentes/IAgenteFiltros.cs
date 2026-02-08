using System.Collections.Generic;
using Concretec.Pedidos.BE;

namespace Concretec.Agentes
{
    public interface IAgenteFiltros
    {
        List<Categoria> LeerCategorias(int IdCategoria);
        List<Filtro> llenaCombo(string TipoCombo, string CveCiudad, string Parametro1, string Parametro2, string Parametro3);
    }
}