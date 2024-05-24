namespace Circuitry
{
    public abstract class CompoundGate(Board board) : IHaveState
    {
        public Board Board { get; } = board;
    }
}
