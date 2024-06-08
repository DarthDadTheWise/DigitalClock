using System.Diagnostics;

namespace Circuitry;

[DebuggerDisplay("Refresh {gate}")]
internal class RefreshGateCommand(IHaveState gate) : BoardCommand
{
    private readonly IHaveState gate = gate;

    internal override void Execute()
    {
        gate.RefreshState();
    }
}
