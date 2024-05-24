using System.Diagnostics;

namespace Circuitry
{
    [DebuggerDisplay("{Input1} and {Input2} and {Input3} => {Output}")]

    public class And3Gate : AndGate
    {
        public Input Input3;

        public And3Gate()
        {
            Input3 = new Input(this);
        }

        internal override void RefreshState()
        {
            Output.State = Input1.State && Input2.State && Input3.State;
        }
    }
}
