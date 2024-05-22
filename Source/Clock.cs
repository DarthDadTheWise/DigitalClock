using DigitalClock.Circuitry;
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
                return $"{hourTens.DecimalValue}{hourOnes.DecimalValue}:{minuteTens.DecimalValue}{minuteOnes.DecimalValue}:{secondTens.DecimalValue}{secondOnes.DecimalValue}";
            }
        }
        private string previousTime = string.Empty;

        public event TickEventHandler? Tick;

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

            // 
            //board.Connect(hourTens.Bit1, );
            // When 24:00:00 ==> 00:00:00
            // hourTens.Bit1.State == true
            // hourTens.Bit0.State == false
            // hourOnes.Bit2.State == false
            // hourOnes.Bit1.State == true
            // hourOnes.Bit0.State == true



        }

        private void ClkStateChanged(object? sender, EventArgs e)
        {          
            RaiseTick();
        }

        public void RaiseTick()
        {
            if (Time == previousTime) return;
            
            previousTime = Time;
            var e = new TickEventArgs(Time);
            Tick?.Invoke(this, e);
        }

        internal void Start()
        {
            // clk.Start();
            for (int i = 0; i < 120 * 60 * 25; i++)
            {
                clk.Toggle();
            }
        }

        internal void Stop()
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
