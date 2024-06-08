using Circuitry;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DigitalClockWpf.ViewModel;

public class DigitViewModel : ObservableObject
{
    private readonly IHaveDigitValue digit;

    public string Value
    {
        get
        {
            return digit.DisplayValue.ToString();
        }
    }

    public DigitViewModel() : this(new DecadeCounter(new Board()))
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
        OnPropertyChanged(nameof(Value));
    }
}
