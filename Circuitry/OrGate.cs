using System.Diagnostics;

namespace Circuitry;

/// <summary>
/// The OR gate is a digital logic gate that implements logical disjunction.
/// The OR gate outputs "true" if any of its inputs are "true"; otherwise 
/// it outputs "false". The input and output states are normally represented 
/// by different voltage levels.
/// 
/// OR gate truth table
/// I1 I2 Output
/// 0  0	0
/// 0  1	1
/// 1  0	1
/// 1  1	1
/// 
///            ╮───╮
///   Input1 ─-┤   │ 
///            │   ├── Output
///   Input2 ─-┤   │
///            ╯───╯
///           
/// </summary>
[DebuggerDisplay("{Input1} or {Input2} => {Output}")]
public class OrGate : IHaveState
{
    public OrGate()
    {
        Input1 = new(this);
        Input2 = new(this);
        Output = new();
    }

    public Input Input1;
    public Input Input2;
    public Output Output;

    void IHaveState.RefreshState()
    {
        Output.State = Input1.State || Input2.State;
    }
}
