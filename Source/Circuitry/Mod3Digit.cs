using System.Diagnostics;

namespace DigitalClock.Circuitry
{
    [DebuggerDisplay("Clk={Clk}: {Bit1.State ? 1 : 0}{Bit0.State ? 1 : 0}")]

    public class Mod3Digit : CompoundGate
    {
        private readonly JKFlipFlop jk1;
        private readonly JKFlipFlop jk2;
        private readonly Wire clk;

        public Mod3Digit(Board board) : base(board)
        {
            jk1 = new(board);
            jk2 = new(board);
            clk = new();

            // bit 0
            board.Connect(clk.Output, jk1.Clk);
            Board.Connect(jk2.NotQ, jk1.J);
            Board.Connect(board.Battery.Output, jk1.K);

            // bit 1
            board.Connect(clk.Output, jk2.Clk);
            board.Connect(jk1.Q, jk2.J);
            Board.Connect(board.Battery.Output, jk2.K);
        }

        public Input Clk { get { return clk.Input; } }
        public Output Bit1 { get { return jk2.Q; } }
        public Output Bit0 { get { return jk1.Q; } }

        internal override void RefreshState()
        {
            jk1.RefreshState();
            jk2.RefreshState();
            clk.RefreshState();
        }

        public void Set(int value)
        {
			   // TODO: Change to use circuitry
            value %= 3;
            while (value != DecimalValue)
            {
                Clk.State = !Clk.State;
                Clk.State = !Clk.State;
            }
        }

        public int DecimalValue
        {
            get
            {
                var newValue = Bit0.State ? 1 : 0;
                newValue |= Bit1.State ? 2 : 0;
                return newValue;
            }
        }
    }
}
