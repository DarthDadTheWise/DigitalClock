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
/// I1 I2 Output
/// 0  0	0
/// 0  1	0
/// 1  0	0
/// 1  1	1
/// 
///            ┌───╮
///   Input1 ─-┤   │ 
///            │   ├── Output
///   Input2 ─-┤   │
///            └───╯
///           
/// </summary>
[DebuggerDisplay("{Input1} and {Input2} => {Output}")]
public class AndGate : IHaveState
{
    public AndGate()
    {
        Input1 = new(this);
        Input2 = new(this);
        Output = new();
    }

    public Input Input1 { get; }
    public Input Input2 { get; }
    public Output Output { get; }

    void IHaveState.RefreshState()
    {
        Output.State = Input1.State && Input2.State;
    }
}
