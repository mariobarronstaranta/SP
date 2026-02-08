using System;
using System.Collections.Generic;
using Concretec.Pedidos.BE;

namespace Concretec.Agentes
{
    public interface IAgenteCB2
    {
        List<LogCb2> ConsultaConexiones(DateTime Desde);
        List<LogCb2> ConsultaErrorConexiones(DateTime Desde, string Ciudad, string Planta);
        List<LogCb2> UltimaFechaDatosCb2(string Ciudad, string Planta);
    }
}