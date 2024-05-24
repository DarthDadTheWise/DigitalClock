using System.Diagnostics;

namespace Circuitry
{
    [DebuggerDisplay("{Input1} and {Input2} => {Output}")]

    public class AndGate : IHaveState
    {
        public Input Input1;
        public Input Input2;
        public Output Output;

        public AndGate()
        {
            Input1 = new(this);
            Input2 = new(this);
            Output = new();
        }

        internal override void RefreshState()
        {
            Output.State = Input1.State && Input2.State;
        }
    }
}
