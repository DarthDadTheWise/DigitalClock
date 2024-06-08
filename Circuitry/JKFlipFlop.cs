using System.Diagnostics;

namespace Circuitry;

/// <summary>
/// clk	J K Q NotQ Description
/// x   0 0 0 0    error
/// x   1 0 1 0    Set
/// x   0 1 0 1    Reset
/// x   1 1 x x    Toggle
/// </summary>
[DebuggerDisplay("Clk={Clk} J={J} K={K} => Q={Q} !Q={NotQ}")]
public class JKFlipFlop : CompoundGate, IHaveState
{
    private readonly Wire clk;
    private readonly RSNandLatch rs1;
    private readonly RSNandLatch rs2;
    private readonly Nand3Gate nand1;
    private readonly Nand3Gate nand2;
    private readonly NandGate nand3;
    private readonly NandGate nand4;
    private readonly NotGate notGate;

    public JKFlipFlop(Board board) : base(board)
    {
        clk = new();
        rs1 = new(board);
        rs2 = new(board);
        nand1 = new(board);
        nand2 = new(board);
        nand3 = new(board);
        nand4 = new(board);
        notGate = new();

        board.Connect(rs2.NotQ, nand1.Input2);
        board.Connect(clk.Output, nand1.Input3);
        board.Connect(clk.Output, nand2.Input1);
        board.Connect(rs2.Q, nand2.Input2);

        board.Connect(nand1.Output, rs1.S);
        board.Connect(nand2.Output, rs1.R);

        board.Connect(rs1.Q, nand3.Input1);
        board.Connect(notGate.Output, nand3.Input2);
        board.Connect(notGate.Output, nand4.Input1);
        board.Connect(rs1.NotQ, nand4.Input2);

        board.Connect(nand3.Output, rs2.S);
        board.Connect(nand4.Output, rs2.R);

        board.Connect(clk.Output, notGate.Input);
    }

    public Input Clk { get { return clk.Input; } }
    public Input J { get { return nand1.Input1; } }
    public Input K { get { return nand2.Input3; } }
    public Output Q { get { return rs2.Q; } }
    public Output NotQ { get { return rs2.NotQ; } }

    void IHaveState.RefreshState()
    {
        (clk as IHaveState).RefreshState();
        (rs1 as IHaveState).RefreshState();
        (rs2 as IHaveState).RefreshState();
        (nand1 as IHaveState).RefreshState();
        (nand2 as IHaveState).RefreshState();
        (nand3 as IHaveState).RefreshState();
        (nand4 as IHaveState).RefreshState();
        (notGate as IHaveState).RefreshState();
    }
}
