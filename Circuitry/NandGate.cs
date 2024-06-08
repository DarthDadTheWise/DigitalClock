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
/// I1 I2 Output
/// 0  0	1
/// 0  1	1
/// 1  0	1
/// 1  1	0
/// 
///            ┌───╮
///   Input1 ─-┤   │ 
///            │   ├○── Output
///   Input2 ─-┤   │
///            └───╯
///
/// </summary>
[DebuggerDisplay("not({Input1} and {Input2}) => {Output}")]
public class NandGate : CompoundGate, IHaveState
{
    private readonly AndGate andGate;
    private readonly NotGate notGate;

    public NandGate(Board board) : base(board)
    {
        andGate = new();
        notGate = new();

        board.Connect(andGate.Output, notGate.Input);
    }

    public Input Input1 { get { return andGate.Input1; } }
    public Input Input2 { get { return andGate.Input2; } }
    public Output Output { get { return notGate.Output; } }

    void IHaveState.RefreshState()
    {
        (andGate as IHaveState).RefreshState();
        (notGate as IHaveState).RefreshState();
    }
}
