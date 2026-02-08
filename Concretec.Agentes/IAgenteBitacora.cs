using System;
using System.Collections.Generic;
using Concretec.Pedidos.BE;

namespace Concretec.Agentes
{
    public interface IAgenteBitacora
    {
        List<Bitacora> HistorialLog(DateTime fechainicial, DateTime fechafinal);
        BitacoraResumen ObtenerBitacoraResumen();
        List<Bitacora> ObtenerHistorialBitacora(int IDModulo, DateTime? fechainicial, DateTime? fechafinal);
    }
}