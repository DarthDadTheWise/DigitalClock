using System.Diagnostics;

namespace Circuitry;

/// <summary>
/// The NOT gate outputs a zero when given a one, and a one when given a zero.
/// 
/// NOT gate truth table
/// I Output
/// 0   1
/// 1 	0
/// 
///   Input1 ─>○─ Output
///   
/// </summary>
[DebuggerDisplay("not({Input}) => {Output}")]
public class NotGate : IHaveState
{
    public NotGate()
    {
        Input = new(this);
        Output = new()
        {
            State = true
        };
    }

    public Input Input { get; }
    public Output Output { get; }

    void IHaveState.RefreshState()
    {
        Output.State = !Input.State;
    }
}
