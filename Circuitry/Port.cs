﻿namespace Circuitry;

public abstract class Port
{
    private bool state;

    public event EventHandler? StateChanged;

    public void RaiseStateChanged()
    {
        StateChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool State
    {
        get { return state; }
        internal set
        {
            if (state == value) return;
            state = value;
            RaiseStateChanged();
        }
    }
}
