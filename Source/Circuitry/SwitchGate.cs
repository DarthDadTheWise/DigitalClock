using System.Diagnostics;

namespace DigitalClock.Circuitry
{
    [DebuggerDisplay("Open={IsOpen}, {Input} => {Output}")]
    public class SwitchGate : IHaveState
    {
        private bool isOpen = true;

        public Input Input;
        public Output Output;

        public SwitchGate()
        {
            Input = new(this);
            Output = new();
        }

        public void Open()
        {
            if (isOpen) return;
            isOpen = true;
            RefreshState();
        }

        public void Close()
        {
            if (!isOpen) return;
            isOpen = false;
            RefreshState();
        }

        internal override void RefreshState()
        {
            if (IsOpen)
            {
                Output.State = false;
            }
            else
            {
                Output.State = Input.State;
            }
        }

        public bool IsOpen
        {
            get { return isOpen; }
        }
    }

}
