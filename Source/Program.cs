namespace DigitalClock;

class Program
{
    public static void OnTick(Object source, TickEventArgs e)
    {
        if (source == null) return;
        Console.WriteLine(e.Time);
//        Console.WriteLine(e.Time.ToLongTimeString());
    }

    static void Main(string[] _)
    {
        Clock clock = new();

        var currentTime = DateTime.Now;
        clock.Set(currentTime.Hour, currentTime.Minute, currentTime.Second);

        clock.Tick += OnTick;
        clock.Start();

        Console.WriteLine("Press the Enter key to exit the program at any time... ");
        Console.ReadLine();

        clock.Stop();
    }
}