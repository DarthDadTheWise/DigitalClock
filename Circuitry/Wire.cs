using System.Diagnostics;

namespace Circuitry;

[DebuggerDisplay("{Input} => {Output}")]
public class Wire : IHaveState
{
    public Wire()
    {
        Input = new(this);
        Output = new();
    }

    public Input Input;
    public Output Output;

    void IHaveState.RefreshState()
    {
        Output.State = Input.State;
    }
}
