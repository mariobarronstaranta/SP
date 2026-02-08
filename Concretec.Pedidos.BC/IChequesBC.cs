using Concretec.Pedidos.BE;

namespace Concretec.Pedidos.BC
{
    public interface IChequesBC
    {
        bool InsertaCheque(Cheques cheque);
        bool ActualizaCheque(Cheques cheque);
    }
}