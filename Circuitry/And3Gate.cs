using System.Diagnostics;

namespace Circuitry;

/// <summary>
/// The AND gate is a basic digital logic gate that implements logical conjunction 
/// from mathematical logic – AND gate behaves according to the truth table. 
/// A HIGH output (1) results only if all the inputs to the AND gate are HIGH (1).
/// If not all inputs to the AND gate are HIGH, LOW output results. The function
/// can be extended to any number of inputs.
/// 
/// AND gate truth table
/// I1 I2 I3 Output
/// 0  0  0	   0
/// 0  0  1	   0
/// 0  1  0    0
/// 0  1  1	   0
/// 1  0  0	   0
/// 1  0  1	   0
/// 1  1  0    0
/// 1  1  1	   1
/// 
///            ┌───╮
///   Input1 ─-┤   │ 
///   Input2 ─-┤   ├── Output
///   Input3 ─-┤   │
///            └───╯
/// </summary>
[DebuggerDisplay("{Input1} and {Input2} and {Input3} => {Output}")]
public class And3Gate : IHaveState
{
    private readonly AndGate and1;
    private readonly AndGate and2;

    public And3Gate(Board board)
    {
        and1 = new();
        and2 = new();

        board.Connect(and1.Output, and2.Input1);
    }

    public Input Input1 { get { return and1.Input1; } }
    public Input Input2 { get { return and1.Input2; } }
    public Input Input3 { get { return and2.Input2; } }
    public Output Output { get { return and2.Output; } }

    void IHaveState.RefreshState()
    {
        (and1 as IHaveState).RefreshState();
        (and2 as IHaveState).RefreshState();
    }
}
