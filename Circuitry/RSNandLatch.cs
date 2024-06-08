using System.Diagnostics;

namespace Circuitry;

/// <summary>
/// S R Q !Q
/// --------
/// F F undefined/not allowed
/// F T T  F (Reset)
/// T F F  T (Set)
/// T T no change
/// </summary>
[DebuggerDisplay("R={R}  S={S} => Q={Q} !Q={NotQ}")]
public class RSNandLatch : IHaveState
{
    private readonly NandGate nand1;
    private readonly NandGate nand2;

    public RSNandLatch(Board board) 
    {
        nand1 = new(board);
        nand2 = new(board);

        board.Connect(nand1.Output, nand2.Input1);
        board.Connect(nand2.Output, nand1.Input2);
    }

    public Input S { get { return nand1.Input1; } }
    public Input R { get { return nand2.Input2; } }
    public Output Q { get { return nand1.Output; } }
    public Output NotQ { get { return nand2.Output; } }

    void IHaveState.RefreshState()
    {
        (nand1 as IHaveState).RefreshState();
        (nand2 as IHaveState).RefreshState();
    }
}
