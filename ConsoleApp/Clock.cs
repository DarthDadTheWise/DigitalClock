using Circuitry;
using System.Diagnostics;

namespace DigitalClock
{
    [DebuggerDisplay("{hourTens.DecimalValue}{hourOnes.DecimalValue}:{minuteTens.DecimalValue}{minuteOnes.DecimalValue}:{secondTens.DecimalValue}{secondOnes.DecimalValue}")]
    public class Clock
    {
        public string Time
        {
            get
            {
                // TODO: Change to use circuitry
                var current = $"{hourTens.DisplayValue}{hourOnes.DisplayValue}:{minuteTens.DisplayValue}{minuteOnes.DisplayValue}:{secondTens.DisplayValue}{secondOnes.DisplayValue}";
                if ("24:00:00" == current)
                {
                    Set(0, 0, 0);
                }
                return $"{hourTens.DisplayValue}{hourOnes.DisplayValue}:{minuteTens.DisplayValue}{minuteOnes.DisplayValue}:{secondTens.DisplayValue}{secondOnes.DisplayValue}";
            }
        }
        private string previousTime = string.Empty;

        public event EventHandler? Tick;

        private readonly Board board;
        private readonly DecadeDigit secondOnes;
        private readonly SenaryDigit secondTens;
        private readonly DecadeDigit minuteOnes;
        private readonly SenaryDigit minuteTens;
        private readonly DecadeDigit hourOnes;
        private readonly Mod3Digit hourTens;
        private readonly ClockGate clk;

        public Clock()
        {
            board = new();
            secondOnes = new(board);
            secondTens = new(board);
            minuteOnes = new(board);
            minuteTens = new(board);
            hourOnes = new(board);
            hourTens = new(board);

            clk = new();
            clk.Output.StateChanged += ClkStateChanged;
            board.Connect(clk.Output, secondOnes.Clk);
            board.Connect(secondOnes.Bit3, secondTens.Clk);
            board.Connect(secondTens.Bit2, minuteOnes.Clk);
            board.Connect(minuteOnes.Bit3, minuteTens.Clk);
            board.Connect(minuteTens.Bit2, hourOnes.Clk);
            board.Connect(hourOnes.Bit3, hourTens.Clk);

            // TODO: Add circuitry to handle 23:59:59 maximum.
        }

        private void ClkStateChanged(object? sender, EventArgs e)
        {
            // TODO: Change to use circuitry
            if ("24:00:00" == Time)
            {
                Set(0, 0, 0);
            }
            RaiseTick();
        }

        private void RaiseTick()
        {
            if (Time == previousTime) return;
            previousTime = Time;
            Tick?.Invoke(this, EventArgs.Empty);
        }

        public void Start()
        {
            clk.Start();
        }

        public void Stop()
        {
            clk.Stop();
        }

        public void Set(int hour, int minute, int second)
        {
            int secondTensDigit = second / 10;
            int secondOnesDigit = second - secondTensDigit * 10;
            int minuteTensDigit = minute / 10;
            int minuteOnesDigit = minute - minuteTensDigit * 10;
            int hourTensDigit = hour / 10;
            int hourOnesDigit = hour - hourTensDigit * 10;

            secondOnes.Set(secondOnesDigit);
            secondTens.Set(secondTensDigit);
            minuteOnes.Set(minuteOnesDigit);
            minuteTens.Set(minuteTensDigit);
            hourOnes.Set(hourOnesDigit);
            hourTens.Set(hourTensDigit);
        }

        public void AddOneSecond()
        {
            clk.Toggle();
            clk.Toggle();
        }
    }
}
