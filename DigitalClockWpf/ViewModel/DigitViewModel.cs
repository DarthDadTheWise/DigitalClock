using Circuitry;

namespace DigitalClockWpf.ViewModel
{
    public class DigitViewModel : ViewModelBase
    {
        private readonly FourBitDigit digit;

        public string Value
        {
            get
            {
                return digit.DecimalValue.ToString();
            }
        }

        public DigitViewModel() : this(new DecadeDigit(new Board()))
        {
        }

        public DigitViewModel(FourBitDigit digit)
        {
            ArgumentNullException.ThrowIfNull(digit);
            this.digit = digit;
            this.digit.Bit0.StateChanged += Bit_StateChanged;
            //this.digit.Bit1.StateChanged += Bit_StateChanged;
            //this.digit.Bit2.StateChanged += Bit_StateChanged;
            //this.digit.Bit3.StateChanged += Bit_StateChanged;
        }

        private void Bit_StateChanged(object? sender, EventArgs e)
        {
            RaisePropertyChanged(() => Value);
        }

        protected override void OnDispose()
        {
            //base.OnDispose();
        }

    }
}
