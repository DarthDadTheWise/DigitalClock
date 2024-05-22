namespace DigitalClock;

class Program
{
    private static void Clock_Tick(object? sender, EventArgs e)
    {
        if (sender is not Clock clock) return;
        Console.Write("\r{0}", clock.Time);
    }

    static void Main(string[] _)
    {
        Clock clock = new();

        var currentTime = DateTime.Now;
        clock.Set(currentTime.Hour, currentTime.Minute, currentTime.Second);

        clock.Tick += Clock_Tick;
        clock.Start();

        Console.WriteLine("Press the Enter key to exit the program at any time... ");
        Console.ReadLine();

        clock.Stop();
    }
}