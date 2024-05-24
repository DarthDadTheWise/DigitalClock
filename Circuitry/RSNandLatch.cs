using System.Diagnostics;

namespace Circuitry
{
    /// <summary>
    /// S R Q !Q
    /// --------
    /// F F undefined/not allowed
    /// F T T  F (Reset)
    /// T F F  T (Set)
    /// T T no change
    /// </summary>
    [DebuggerDisplay("R={R}  S={S} => Q={Q} !Q={NotQ}")]
    public class RSNandLatch : CompoundGate
    {
        private readonly NandGate nandGate1;
        private readonly NandGate nandGate2;

        public RSNandLatch(Board board) : base(board)
        {
            nandGate1 = new(board);
            nandGate2 = new(board);

            board.Connect(nandGate1.Output, nandGate2.Input1);
            board.Connect(nandGate2.Output, nandGate1.Input2);
        }

        public Input S { get { return nandGate1.Input1; } }
        public Input R { get { return nandGate2.Input2; } }
        public Output Q { get { return nandGate1.Output; } }
        public Output NotQ { get { return nandGate2.Output; } }

        internal override void RefreshState()
        {
            nandGate1.RefreshState();
            nandGate2.RefreshState();
        }
    }
}
