using Concretec.Pedidos.BE;
using System;
using System.Collections.Generic;

namespace Concretec.Pedidos.BC
{
    public interface ICb2BC
    {
        List<LogCb2> UltimaFechaDatosCb2(string Ciudad, string Planta);
        List<LogCb2> ConsultaErrorConexiones(DateTime Desde, string Ciudad, string Planta);
        List<LogCb2> ConsultaConexiones(DateTime Desde);
    }
}