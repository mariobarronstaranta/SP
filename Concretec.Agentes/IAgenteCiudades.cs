using System.Collections.Generic;
using Concretec.Pedidos.BE;

namespace Concretec.Agentes
{
    public interface IAgenteCiudades
    {
        List<Ciudad> ObtenerCiudades();
    }
}