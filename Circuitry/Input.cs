using System.Diagnostics;

namespace Circuitry
{
    [DebuggerDisplay("{State}")]
    public class Input(IHaveState gate) : Port
    {
        private readonly List<Output> outputs = [];

        public IHaveState Gate { get; } = gate;

        private bool GetOutputsState()
        {
            if (outputs.Count == 0) return false;

            foreach (var output in outputs)
            {
                if (output.State)
                {
                    return true;
                }
            }

            return false;
        }

        internal void Connect(Output output)
        {
            // Multiple outputs can be connected to an input.  Track them
            // to correctly update this input's state.
            if (outputs.Contains(output)) return;
            outputs.Add(output);
        }

        public void RefreshState()
        {
            State = GetOutputsState();
        }
    }
}
