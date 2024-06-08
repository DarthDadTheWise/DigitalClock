using Circuitry;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DigitalClockWpf.ViewModel;

public class ClockViewModel : ObservableObject
{
    private readonly Board board;
    private readonly DecadeCounter secondOnesCounter;
    private readonly SenaryCounter secondTensCounter;
    private readonly DecadeCounter minuteOnesCounter;
    private readonly SenaryCounter minuteTensCounter;
    private readonly DecadeCounter hourOnesCounter;
    private readonly Mod3Counter hourTensCounter;
    private readonly ClockGate clk;

    private readonly DigitViewModel hourTensDigit;
    private readonly DigitViewModel hourOnesDigit;
    private readonly DigitViewModel minuteTensDigit;
    private readonly DigitViewModel minuteOnesDigit;
    private readonly DigitViewModel secondTensDigit;
    private readonly DigitViewModel secondOnesDigit;

    public ClockViewModel()
    {
        board = new();
        secondOnesCounter = new(board);
        secondTensCounter = new(board);
        minuteOnesCounter = new(board);
        minuteTensCounter = new(board);
        hourOnesCounter = new(board);
        hourTensCounter = new(board);

        clk = new();
        clk.Output.StateChanged += Clk_StateChanged;
        board.Connect(clk.Output, secondOnesCounter.Clk);
        board.Connect(secondOnesCounter.Bit3, secondTensCounter.Clk);
        board.Connect(secondTensCounter.Bit2, minuteOnesCounter.Clk);
        board.Connect(minuteOnesCounter.Bit3, minuteTensCounter.Clk);
        board.Connect(minuteTensCounter.Bit2, hourOnesCounter.Clk);
        board.Connect(hourOnesCounter.Bit3, hourTensCounter.Clk);

        hourTensDigit = new(hourTensCounter);
        hourOnesDigit = new(hourOnesCounter);
        minuteTensDigit = new(minuteTensCounter);
        minuteOnesDigit = new(minuteOnesCounter);
        secondTensDigit = new(secondTensCounter);
        secondOnesDigit = new(secondOnesCounter);
    }

    public string Time
    {
        get
        {
            // TODO: Change to use circuitry
            var current = $"{hourTensCounter.DisplayValue}{hourOnesCounter.DisplayValue}:{minuteTensCounter.DisplayValue}{minuteOnesCounter.DisplayValue}:{secondTensCounter.DisplayValue}{secondOnesCounter.DisplayValue}";
            if ("24:00:00" == current)
            {
                Set(0, 0, 0);
            }
            return $"{hourTensCounter.DisplayValue}{hourOnesCounter.DisplayValue}:{minuteTensCounter.DisplayValue}{minuteOnesCounter.DisplayValue}:{secondTensCounter.DisplayValue}{secondOnesCounter.DisplayValue}";
        }
    }

    private void Clk_StateChanged(object? sender, EventArgs e)
    {
        // TODO: Change to use circuitry
        if ("24:00:00" == Time)
        {
            Set(0, 0, 0);
        }
    }

    public DigitViewModel HourTens { get { return hourTensDigit; } }
    public DigitViewModel HourOnes { get { return hourOnesDigit; } }
    public DigitViewModel MinuteTens { get { return minuteTensDigit; } }
    public DigitViewModel MinuteOnes { get { return minuteOnesDigit; } }
    public DigitViewModel SecondTens { get { return secondTensDigit; } }
    public DigitViewModel SecondOnes { get { return secondOnesDigit; } }

    public void Set(int hour, int minute, int second)
    {
        int secondTensPlace = second / 10;
        int secondOnesPlace = second - secondTensPlace * 10;
        int minuteTensPlace = minute / 10;
        int minuteOnesPlace = minute - minuteTensPlace * 10;
        int hourTensPlace = hour / 10;
        int hourOnesPlace = hour - hourTensPlace * 10;

        secondOnesCounter.Set(secondOnesPlace);
        secondTensCounter.Set(secondTensPlace);
        minuteOnesCounter.Set(minuteOnesPlace);
        minuteTensCounter.Set(minuteTensPlace);
        hourOnesCounter.Set(hourOnesPlace);
        hourTensCounter.Set(hourTensPlace);
    }

    internal void Start()
    {
        clk.Start();
    }

    internal void Stop()
    {
        clk.Stop();
    }
}
