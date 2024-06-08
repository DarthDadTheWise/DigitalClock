using System.Diagnostics;
using System.Timers;

namespace Circuitry;

[DebuggerDisplay("IsRunning={IsRunning}, {Output}")]
public class ClockGate
{
    private System.Timers.Timer? timer;

    public ClockGate()
    {
        Output = new();
    }

    public Output Output;

    public bool IsRunning
    {
        get
        {
            return timer != null;
        }
    }

    private void TimerElapsed(object? sender, ElapsedEventArgs e)
    {
        Output.State = !Output.State;
    }

    public void Toggle()
    {
        if (IsRunning) return;
        Output.State = !Output.State;
    }

    public void Start()
    {
        if (timer != null) return;

        // Create a timer with a half second interval.
        timer = new System.Timers.Timer(500);
        // Hook up the Elapsed event for the timer. 
        timer.Elapsed += TimerElapsed;
        timer.AutoReset = true;
        timer.Enabled = true;
    }

    public void Stop()
    {
        if (timer == null) return;
        timer.Stop();
        timer.Elapsed -= TimerElapsed;
        timer.Dispose();
        timer = null;
    }
}
