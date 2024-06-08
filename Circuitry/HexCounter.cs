using System.Diagnostics;

namespace Circuitry;

[DebuggerDisplay("Clk={Clk}: {Bit3 ? 1 : 0}{Bit2 ? 1 : 0}{Bit1 ? 1 : 0}{Bit0 ? 1 : 0}")]
public class HexCounter : CompoundGate, IHaveState
{
    private readonly JKFlipFlop jk1;
    private readonly JKFlipFlop jk2;
    private readonly JKFlipFlop jk3;
    private readonly JKFlipFlop jk4;

    public HexCounter(Board board) : base(board)
    {
        jk4 = new(board);
        jk3 = new(board);
        jk2 = new(board);
        jk1 = new(board);

        board.Connect(jk1.Q, jk2.Clk);
        board.Connect(jk2.Q, jk3.Clk);
        board.Connect(jk3.Q, jk4.Clk);
        board.Connect(board.Battery.Output, jk1.J);
        board.Connect(board.Battery.Output, jk1.K);
        board.Connect(board.Battery.Output, jk2.J);
        board.Connect(board.Battery.Output, jk2.K);
        board.Connect(board.Battery.Output, jk3.J);
        board.Connect(board.Battery.Output, jk3.K);
        board.Connect(board.Battery.Output, jk4.J);
        board.Connect(board.Battery.Output, jk4.K);
    }

    public Input Clk { get { return jk1.Clk; } }
    public bool Bit3 { get { return jk4.Q.State; } }
    public bool Bit2 { get { return jk3.Q.State; } }
    public bool Bit1 { get { return jk2.Q.State; } }
    public bool Bit0 { get { return jk1.Q.State; } }

    void IHaveState.RefreshState()
    {
        (jk1 as IHaveState).RefreshState();
        (jk2 as IHaveState).RefreshState();
        (jk3 as IHaveState).RefreshState();
        (jk4 as IHaveState).RefreshState();
    }
}
