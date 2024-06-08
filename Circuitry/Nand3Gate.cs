using System.Diagnostics;

namespace Circuitry;

/// <summary>
/// In digital electronics, a NAND gate (NOT-AND) is a logic gate
/// which produces an output which is false only if all its inputs
/// are true; thus its output is complement to that of an AND gate.
/// A LOW (0) output results only if all the inputs to the gate 
/// are HIGH (1); if any input is LOW (0), a HIGH (1) output results. 
/// 
/// NAND gate truth table
/// I1 I2 I3 Output
/// 0  0  0	   1
/// 0  0  1	   1
/// 0  1  0    1
/// 0  1  1	   1
/// 1  0  0	   1
/// 1  0  1	   1
/// 1  1  0    1
/// 1  1  1	   0
/// 
///            ┌───╮
///   Input1 ─-┤   │ 
///   Input2 ─-┤   ├○── Output
///   Input3 ─-┤   │
///            └───╯
///
/// </summary>
[DebuggerDisplay("not({Input1} and {Input2} and {Input3}) => {Output}")]
public class Nand3Gate : CompoundGate, IHaveState
{
    public And3Gate and3Gate;
    public NotGate notGate;

    public Nand3Gate(Board board) : base(board)
    {
        and3Gate = new(board);
        notGate = new();

        board.Connect(and3Gate.Output, notGate.Input);
    }

    public Input Input1 { get { return and3Gate.Input1; } }
    public Input Input2 { get { return and3Gate.Input2; } }
    public Input Input3 { get { return and3Gate.Input3; } }
    public Output Output { get { return notGate.Output; } }

    void IHaveState.RefreshState()
    {
        (and3Gate as IHaveState).RefreshState();
        (notGate as IHaveState).RefreshState();
    }
}
