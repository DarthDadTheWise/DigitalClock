namespace Circuitry
{
    public abstract class FourBitDigit : CompoundGate
    {
        protected FourBitDigit(Board board) : base(board)
        {
        }

        public abstract int DecimalValue { get; }

        public abstract Output Bit0 { get; }

    }
}
