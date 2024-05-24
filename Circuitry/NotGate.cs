using System.Diagnostics;

namespace Circuitry
{
    [DebuggerDisplay("not({Input}) => {Output}")]
    public class NotGate : IHaveState
    {
        public Input Input;
        public Output Output;

        public NotGate()
        {
            Input = new(this);
            Output = new()
            {
                State = true
            };
        }

        internal override void RefreshState()
        {
            Output.State = !Input.State;
        }
    }
}
