using System.Diagnostics;

namespace Circuitry;

[DebuggerDisplay("{Output}")]
public class Battery : IHaveState
{
    public Battery()
    {
        Output = new()
        {
            State = true
        };
    }

    public Output Output { get; }

    void IHaveState.RefreshState()
    {
        // Always High
        Output.State = true;
    }
}
