using Circuitry;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace DigitalClockWpf.ViewModel;

public class DigitViewModel : ObservableObject
{
    private readonly IDisplayValue digit;

    public string Value
    {
        get
        {
            return digit.DisplayValue.ToString();
        }
    }

    [DesignOnly(true)]
    public DigitViewModel() : this(new DecadeCounter(new Board()))
    {
    }

    public DigitViewModel(IDisplayValue digit)
    {
        ArgumentNullException.ThrowIfNull(digit);
        this.digit = digit;
        this.digit.DisplayValueChanged += Digit_DisplayValueChanged;
    }

    private void Digit_DisplayValueChanged(object? sender, EventArgs e)
    {
        OnPropertyChanged(nameof(Value));
    }
}
