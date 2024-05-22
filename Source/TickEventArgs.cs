namespace DigitalClock
{
    public class TickEventArgs(string time) : EventArgs
    {
        public string Time { get; } = time;
    }
}
