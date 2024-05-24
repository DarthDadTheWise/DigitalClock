using System.Diagnostics;

namespace Circuitry
{
    [DebuggerDisplay("{Input1} or {Input2} => {Output}")]
    public class OrGate : IHaveState
    {
        public Input Input1;
        public Input Input2;
        public Output Output;

        public OrGate()
        {
            Input1 = new(this);
            Input2 = new(this);
            Output = new();
        }

        internal override void RefreshState()
        {
            Output.State = Input1.State || Input2.State;
        }
    }
}
