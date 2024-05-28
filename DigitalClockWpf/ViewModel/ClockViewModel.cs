using Circuitry;

namespace DigitalClockWpf.ViewModel
{
    public class ClockViewModel : ViewModelBase
    {
        private readonly Board board;
        private readonly DecadeDigit secondOnesDigit;
        private readonly SenaryDigit secondTensDigit;
        private readonly DecadeDigit minuteOnesDigit;
        private readonly SenaryDigit minuteTensDigit;
        private readonly DecadeDigit hourOnesDigit;
        private readonly Mod3Digit hourTensDigit;
        private readonly ClockGate clk;

        private readonly DigitViewModel hourTens;
        private readonly DigitViewModel hourOnes;
        private readonly DigitViewModel minuteTens;
        private readonly DigitViewModel minuteOnes;
        private readonly DigitViewModel secondTens;
        private readonly DigitViewModel secondOnes;

        public ClockViewModel()
        {
            board = new();
            secondOnesDigit = new(board);
            secondTensDigit = new(board);
            minuteOnesDigit = new(board);
            minuteTensDigit = new(board);
            hourOnesDigit = new(board);
            hourTensDigit = new(board);

            clk = new();
            clk.Output.StateChanged += ClkStateChanged;
            board.Connect(clk.Output, secondOnesDigit.Clk);
            board.Connect(secondOnesDigit.Bit3, secondTensDigit.Clk);
            board.Connect(secondTensDigit.Bit2, minuteOnesDigit.Clk);
            board.Connect(minuteOnesDigit.Bit3, minuteTensDigit.Clk);
            board.Connect(minuteTensDigit.Bit2, hourOnesDigit.Clk);
            board.Connect(hourOnesDigit.Bit3, hourTensDigit.Clk);

            hourTens = new DigitViewModel(hourTensDigit);
            hourOnes = new DigitViewModel(hourOnesDigit);
            minuteTens = new DigitViewModel(minuteTensDigit);
            minuteOnes = new DigitViewModel(minuteOnesDigit);
            secondTens = new DigitViewModel(secondTensDigit);
            secondOnes = new DigitViewModel(secondOnesDigit);
        }

        public string Time
        {
            get
            {
                // TODO: Change to use circuitry
                var current = $"{hourTensDigit.DisplayValue}{hourOnesDigit.DisplayValue}:{minuteTensDigit.DisplayValue}{minuteOnesDigit.DisplayValue}:{secondTensDigit.DisplayValue}{secondOnesDigit.DisplayValue}";
                if ("24:00:00" == current)
                {
                    Set(0, 0, 0);
                }
                return $"{hourTensDigit.DisplayValue}{hourOnesDigit.DisplayValue}:{minuteTensDigit.DisplayValue}{minuteOnesDigit.DisplayValue}:{secondTensDigit.DisplayValue}{secondOnesDigit.DisplayValue}";
            }
        }

        private void ClkStateChanged(object? sender, EventArgs e)
        {
            // TODO: Change to use circuitry
            if ("24:00:00" == Time)
            {
                Set(0, 0, 0);
            }
        }

        public DigitViewModel HourTens { get { return hourTens; } }
        public DigitViewModel HourOnes { get { return hourOnes; } }
        public DigitViewModel MinuteTens { get { return minuteTens; } }
        public DigitViewModel MinuteOnes { get { return minuteOnes; } }
        public DigitViewModel SecondTens { get { return secondTens; } }
        public DigitViewModel SecondOnes { get { return secondOnes; } }

        public void Set(int hour, int minute, int second)
        {
            int secondTensPlace = second / 10;
            int secondOnesPlace = second - secondTensPlace * 10;
            int minuteTensPlace = minute / 10;
            int minuteOnesPlace = minute - minuteTensPlace * 10;
            int hourTensPlace = hour / 10;
            int hourOnesPlace = hour - hourTensPlace * 10;

            secondOnesDigit.Set(secondOnesPlace);
            secondTensDigit.Set(secondTensPlace);
            minuteOnesDigit.Set(minuteOnesPlace);
            minuteTensDigit.Set(minuteTensPlace);
            hourOnesDigit.Set(hourOnesPlace);
            hourTensDigit.Set(hourTensPlace);
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
}
