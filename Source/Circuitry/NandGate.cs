using System.Diagnostics;

namespace DigitalClock.Circuitry
{
    [DebuggerDisplay("not({Input1} and {Input2}) => {Output}")]
    public class NandGate : CompoundGate
    {
        private readonly AndGate andGate;
        private readonly NotGate notGate;

        public NandGate(Board board) : base(board)
        {
            andGate = new AndGate();
            notGate = new NotGate();

            board.Connect(andGate.Output, notGate.Input);
        }

        public Input Input1 { get { return andGate.Input1; } }
        public Input Input2 { get { return andGate.Input2; } }
        public Output Output { get { return notGate.Output; } }

        internal override void RefreshState()
        {
            andGate.RefreshState();
            notGate.RefreshState();
        }
    }
}
