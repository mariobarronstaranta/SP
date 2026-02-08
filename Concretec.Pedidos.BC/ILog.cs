using System;

namespace Concretec.Pedidos.BC
{
    public interface ILog
    {
        string HistorialLog(DateTime fechainicial, DateTime fechafinal);
        string HistorialBitacora(int IDModulo, DateTime? fechainicial, DateTime? fechafinal);
        string BitacoraResumen();
    }
}