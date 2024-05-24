using System.Diagnostics;

namespace Circuitry
{
    [DebuggerDisplay("{Input} => {Output}")]
    public class Wire : IHaveState
    {
        public Input Input;
        public Output Output;

        public Wire()
        {
            Input = new(this);
            Output = new();
        }

        internal override void RefreshState()
        {
            Output.State = Input.State;
        }
    }
}
