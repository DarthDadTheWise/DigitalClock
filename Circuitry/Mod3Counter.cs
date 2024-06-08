using System.Diagnostics;

namespace Circuitry;

[DebuggerDisplay("Clk={Clk}: {Bit1.State ? 1 : 0}{Bit0.State ? 1 : 0} ==> {DisplayValue}")]
public class Mod3Counter : BaseCounter, IHaveState
{
    private readonly JKFlipFlop jk1;
    private readonly JKFlipFlop jk2;
    private readonly Wire clk;

    public Mod3Counter(Board board)
    {
        jk1 = new(board);
        jk2 = new(board);
        clk = new();

        // bit 0
        board.Connect(clk.Output, jk1.Clk);
        board.Connect(jk2.NotQ, jk1.J);
        board.Connect(board.Battery.Output, jk1.K);

        // bit 1
        board.Connect(clk.Output, jk2.Clk);
        board.Connect(jk1.Q, jk2.J);
        board.Connect(board.Battery.Output, jk2.K);

        Bit0.StateChanged += Bit_StateChanged;
        Bit1.StateChanged += Bit_StateChanged;
    }

    private void Bit_StateChanged(object? sender, EventArgs e)
    {
        var newValue = Bit0.State ? 1 : 0;
        newValue |= Bit1.State ? 2 : 0;
        DisplayValue = newValue;
    }

    public Input Clk { get { return clk.Input; } }
    public Output Bit1 { get { return jk2.Q; } }
    public Output Bit0 { get { return jk1.Q; } }

    void IHaveState.RefreshState()
    {
        (jk1 as IHaveState).RefreshState();
        (jk2 as IHaveState).RefreshState();
        (clk as IHaveState).RefreshState();
    }

    public void Set(int value)
    {
        // TODO: Change to use circuitry
        value %= 3;
        while (value != DisplayValue)
        {
            Clk.State = !Clk.State;
            Clk.State = !Clk.State;
        }
    }
}
