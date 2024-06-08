using System.Diagnostics;

namespace Circuitry;

[DebuggerDisplay("Clk={Clk}: {Bit2.State ? 1 : 0}{Bit1.State ? 1 : 0}{Bit0.State ? 1 : 0}")]
public class SenaryCounter : CompoundGate, IHaveState, IHaveDigitValue
{
    private readonly JKFlipFlop jk1;
    private readonly JKFlipFlop jk2;
    private readonly JKFlipFlop jk3;
    private readonly AndGate andGate1;
    private readonly AndGate andGate2;
    private readonly Wire clk;

    public SenaryCounter(Board board) : base(board)
    {
        jk3 = new(board);
        jk2 = new(board);
        jk1 = new(board);
        andGate1 = new();
        andGate2 = new();
        clk = new();

        // bit 0
        board.Connect(clk.Output, jk1.Clk);
        board.Connect(board.Battery.Output, jk1.J);
        board.Connect(board.Battery.Output, jk1.K);

        // and 1
        board.Connect(jk1.Q, andGate1.Input1);
        board.Connect(jk3.NotQ, andGate1.Input2);

        // bit 1
        board.Connect(andGate1.Output, jk2.J);
        board.Connect(jk1.Q, jk2.K);
        board.Connect(clk.Output, jk2.Clk);

        // and 2
        board.Connect(jk1.Q, andGate2.Input1);
        board.Connect(jk2.Q, andGate2.Input2);

        // bit 2
        board.Connect(andGate2.Output, jk3.J);
        board.Connect(jk1.Q, jk3.K);
        board.Connect(clk.Output, jk3.Clk);
    }

    public Input Clk { get { return clk.Input; } }
    public Output Bit2 { get { return jk3.Q; } }
    public Output Bit1 { get { return jk2.Q; } }
    public Output Bit0 { get { return jk1.Q; } }

    void IHaveState.RefreshState()
    {
        (jk1 as IHaveState).RefreshState();
        (jk2 as IHaveState).RefreshState();
        (jk3 as IHaveState).RefreshState();
        (andGate1 as IHaveState).RefreshState();
        (andGate2 as IHaveState).RefreshState();
        (clk as IHaveState).RefreshState();
    }

    public void Set(int value)
    {
			   // TODO: Change to use circuitry
        value %= 6;
        while (value != DisplayValue)
        {
            Clk.State = !Clk.State;
            Clk.State = !Clk.State;
        }
    }

    public int DisplayValue
    {
        get
        {
            var newValue = Bit0.State ? 1 : 0;
            newValue |= Bit1.State ? 2 : 0;
            newValue |= Bit2.State ? 4 : 0;
            return newValue;
        }
    }

}
