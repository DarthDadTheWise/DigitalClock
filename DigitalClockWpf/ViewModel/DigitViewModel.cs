using Circuitry;

namespace DigitalClockWpf.ViewModel
{
    public class DigitViewModel : ViewModelBase
    {
        private readonly IHaveDigitValue digit;

        public string Value
        {
            get
            {
                return digit.DisplayValue.ToString();
            }
        }

        public DigitViewModel() : this(new DecadeDigit(new Board()))
        {
        }

        public DigitViewModel(IHaveDigitValue digit)
        {
            ArgumentNullException.ThrowIfNull(digit);
            this.digit = digit;
            this.digit.Bit0.StateChanged += Bit_StateChanged;
        }

        private void Bit_StateChanged(object? sender, EventArgs e)
        {
            RaisePropertyChanged(() => Value);
        }
    }
}
