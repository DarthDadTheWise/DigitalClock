using System.Diagnostics;

namespace Circuitry;

[DebuggerDisplay("Clk={Clk}: {Bit3.State ? 1 : 0}{Bit2.State ? 1 : 0}{Bit1.State ? 1 : 0}{Bit0.State ? 1 : 0} ==> {DisplayValue}")]
public class DecadeCounter : BaseCounter, IHaveState
{
    private readonly JKFlipFlop jk1;
    private readonly JKFlipFlop jk2;
    private readonly JKFlipFlop jk3;
    private readonly JKFlipFlop jk4;
    private readonly AndGate and1;
    private readonly AndGate and2;
    private readonly AndGate and3;
    private readonly AndGate and4;
    private readonly OrGate orGate;
    private readonly Wire clk;

    public DecadeCounter(Board board) 
    {
        jk1 = new(board);
        jk2 = new(board);
        jk3 = new(board);
        jk4 = new(board);
        and1 = new();
        and2 = new();
        and3 = new();
        and4 = new();
        orGate = new();
        clk = new();

        // bit 0
        board.Connect(clk.Output, jk1.Clk);
        board.Connect(board.Battery.Output, jk1.J);
        board.Connect(board.Battery.Output, jk1.K);

        // and 1
        board.Connect(jk1.Q, and1.Input1);
        board.Connect(jk4.NotQ, and1.Input2);

        // bit 1
        board.Connect(and1.Output, jk2.J);
        board.Connect(and1.Output, jk2.K);
        board.Connect(clk.Output, jk2.Clk);

        // and 2
        board.Connect(jk1.Q, and2.Input1);
        board.Connect(jk2.Q, and2.Input2);

        // bit 2
        board.Connect(and2.Output, jk3.J);
        board.Connect(and2.Output, jk3.K);
        board.Connect(clk.Output, jk3.Clk);

        // and 3
        board.Connect(jk4.Q, and3.Input1);
        board.Connect(jk1.Q, and3.Input2);

        // and 4
        board.Connect(and2.Output, and4.Input1);
        board.Connect(jk3.Q, and4.Input2);

        // or
        board.Connect(and3.Output, orGate.Input1);
        board.Connect(and4.Output, orGate.Input2);

        // bit 3
        board.Connect(orGate.Output, jk4.J);
        board.Connect(orGate.Output, jk4.K);
        board.Connect(clk.Output, jk4.Clk);

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

    public Input Clk { get { return clk.Input; } }
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
        (and1 as IHaveState).RefreshState();
        (and2 as IHaveState).RefreshState();
        (and3 as IHaveState).RefreshState();
        (and4 as IHaveState).RefreshState();
        (orGate as IHaveState).RefreshState();
        (clk as IHaveState).RefreshState();
    }

    public void Set(int value)
    {
        // TODO: Change to use circuitry
        value %= 10;
        while (value != DisplayValue)
        {
            Clk.State = !Clk.State;
            Clk.State = !Clk.State;
        }
    }
}
