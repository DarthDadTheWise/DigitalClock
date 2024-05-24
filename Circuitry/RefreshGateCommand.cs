using System.Diagnostics;

namespace Circuitry
{
    [DebuggerDisplay("Refresh {gate}")]

    public class RefreshGateCommand(IHaveState gate) : BoardCommand
    {
        private readonly IHaveState gate = gate;

        internal override void Execute()
        {
            gate.RefreshState();
        }
    }
}
