using System.Diagnostics;

namespace DigitalClock.Circuitry
{
    [DebuggerDisplay("Clk={Clk}: {Bit3.State ? 1 : 0}{Bit2.State ? 1 : 0}{Bit1.State ? 1 : 0}{Bit0.State ? 1 : 0}")]

    public class DecadeDigit : CompoundGate
    {
        private readonly JKFlipFlop jk1;
        private readonly JKFlipFlop jk2;
        private readonly JKFlipFlop jk3;
        private readonly JKFlipFlop jk4;
        private readonly AndGate andGate1;
        private readonly AndGate andGate2;
        private readonly AndGate andGate3;
        private readonly AndGate andGate4;
        private readonly OrGate orGate;
        private readonly Wire clk;

        public DecadeDigit(Board board) : base(board)
        {
            jk1 = new(board);
            jk2 = new(board);
            jk3 = new(board);
            jk4 = new(board);
            andGate1 = new();
            andGate2 = new();
            andGate3 = new();
            andGate4 = new();
            orGate = new();
            clk = new();

            // bit 0
            board.Connect(clk.Output, jk1.Clk);
            board.Connect(board.Battery.Output, jk1.J);
            board.Connect(board.Battery.Output, jk1.K);

            // and 1
            board.Connect(jk1.Q, andGate1.Input1);
            board.Connect(jk4.NotQ, andGate1.Input2);

            // bit 1
            board.Connect(andGate1.Output, jk2.J);
            board.Connect(andGate1.Output, jk2.K);
            board.Connect(clk.Output, jk2.Clk);

            // and 2
            board.Connect(jk1.Q, andGate2.Input1);
            board.Connect(jk2.Q, andGate2.Input2);

            // bit 2
            board.Connect(andGate2.Output, jk3.J);
            board.Connect(andGate2.Output, jk3.K);
            board.Connect(clk.Output, jk3.Clk);

            // and 3
            board.Connect(jk4.Q, andGate3.Input1);
            board.Connect(jk1.Q, andGate3.Input2);

            // and 4
            board.Connect(andGate2.Output, andGate4.Input1);
            board.Connect(jk3.Q, andGate4.Input2);

            // or
            board.Connect(andGate3.Output, orGate.Input1);
            board.Connect(andGate4.Output, orGate.Input2);

            // bit 3
            board.Connect(orGate.Output, jk4.J);
            board.Connect(orGate.Output, jk4.K);
            board.Connect(clk.Output, jk4.Clk);
        }

        public Input Clk { get { return clk.Input; } }
        public Output Bit3 { get { return jk4.Q; } }
        public Output Bit2 { get { return jk3.Q; } }
        public Output Bit1 { get { return jk2.Q; } }
        public Output Bit0 { get { return jk1.Q; } }

        public string BinaryString
        {
            get
            {
                return
                    (Bit3.State ? "1" : "0") +
                    (Bit2.State ? "1" : "0") +
                    (Bit1.State ? "1" : "0") +
                    (Bit0.State ? "1" : "0");
            }
        }

        public int DecimalValue
        {
            get
            {
                var newValue = Bit0.State ? 1 : 0;
                newValue |= Bit1.State ? 2 : 0;
                newValue |= Bit2.State ? 4 : 0;
                newValue |= Bit3.State ? 8 : 0;
                return newValue;
            }
        }

        internal override void RefreshState()
        {
            jk1.RefreshState();
            jk2.RefreshState();
            jk3.RefreshState();
            jk4.RefreshState();
            andGate1.RefreshState();
            andGate2.RefreshState();
            andGate3.RefreshState();
            andGate4.RefreshState();
            orGate.RefreshState();
            clk.RefreshState();
        }

        public void Set(int value)
        {
            value %= 10;
            while (value != DecimalValue)
            {
                Clk.State = !Clk.State;
                Clk.State = !Clk.State;
            }
        }
    }
}
