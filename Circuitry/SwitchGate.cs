using System.Diagnostics;

namespace Circuitry;

[DebuggerDisplay("Open={IsOpen}, {Input} => {Output}")]
public class SwitchGate : IHaveState
{
    private bool isOpen = true;

    public SwitchGate()
    {
        Input = new(this);
        Output = new();
    }

    public Input Input;
    public Output Output;

    public void Open()
    {
        if (isOpen) return;
        isOpen = true;
        (this as IHaveState).RefreshState();
    }

    public void Close()
    {
        if (!isOpen) return;
        isOpen = false;
        (this as IHaveState).RefreshState();
    }

    void IHaveState.RefreshState()
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
