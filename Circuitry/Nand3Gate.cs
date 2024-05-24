using System.Diagnostics;

namespace Circuitry
{
    [DebuggerDisplay("not({Input1} and {Input2} and {Input3}) => {Output}")]
    public class Nand3Gate : CompoundGate
    {
        public And3Gate and3Gate;
        public NotGate notGate;

        public Nand3Gate(Board board) : base(board)
        {
            and3Gate = new();
            notGate = new();

            board.Connect(and3Gate.Output, notGate.Input);
        }

        public Input Input1 { get { return and3Gate.Input1; } }
        public Input Input2 { get { return and3Gate.Input2; } }
        public Input Input3 { get { return and3Gate.Input3; } }
        public Output Output { get { return notGate.Output; } }

        internal override void RefreshState()
        {
            and3Gate.RefreshState();
            notGate.RefreshState();
        }
    }
}
