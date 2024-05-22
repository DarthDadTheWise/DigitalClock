using System.Diagnostics;

namespace DigitalClock.Circuitry
{
    [DebuggerDisplay("Refresh {input}")]

    internal class RefreshInputCommand(Input input) : BoardCommand
    {
        private readonly Input input = input;

        internal override void Execute()
        {
            input.RefreshState();
        }
    }
}
