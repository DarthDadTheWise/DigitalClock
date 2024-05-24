using System.Diagnostics;

namespace Circuitry
{
    [DebuggerDisplay("{Output}")]

    public class Battery : IHaveState
    {
        public Output Output;

        public Battery()
        {
            Output = new()
            {
                State = true
            };
        }

        internal override void RefreshState()
        {
            // Always High
            Output.State = true;
        }
    }
}
