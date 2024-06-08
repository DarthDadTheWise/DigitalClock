using System.Diagnostics;

namespace Circuitry;

[DebuggerDisplay("Clk={Clk}: {Bit3 ? 1 : 0}{Bit2 ? 1 : 0}{Bit1 ? 1 : 0}{Bit0 ? 1 : 0} ==> {DisplayValue}")]
public class HexCounter : BaseCounter, IHaveState
{
    private readonly JKFlipFlop jk1;
    private readonly JKFlipFlop jk2;
    private readonly JKFlipFlop jk3;
    private readonly JKFlipFlop jk4;

    public HexCounter(Board board) 
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

        Bit3.StateChanged += Bit_StateChanged;
        Bit2.StateChanged += Bit_StateChanged;
        Bit1.StateChanged += Bit_StateChanged;
        Bit0.StateChanged += Bit_StateChanged;
    }

    private void Bit_StateChanged(object? sender, EventArgs e)
    {
        var newValue = Bit0.State ? 1 : 0;
        newValue |= Bit1.State ? 2 : 0;
        newValue |= Bit2.State ? 4 : 0;
        newValue |= Bit3.State ? 8 : 0;
        DisplayValue = newValue;
    }

    public Input Clk { get { return jk1.Clk; } }
    public Output Bit3 { get { return jk4.Q; } }
    public Output Bit2 { get { return jk3.Q; } }
    public Output Bit1 { get { return jk2.Q; } }
    public Output Bit0 { get { return jk1.Q; } }

    void IHaveState.RefreshState()
    {
        (jk1 as IHaveState).RefreshState();
        (jk2 as IHaveState).RefreshState();
        (jk3 as IHaveState).RefreshState();
        (jk4 as IHaveState).RefreshState();
    }

    public void Set(int value)
    {
        // TODO: Change to use circuitry
        value %= 16;
        while (value != DisplayValue)
        {
            Clk.State = !Clk.State;
            Clk.State = !Clk.State;
        }
    }
}
