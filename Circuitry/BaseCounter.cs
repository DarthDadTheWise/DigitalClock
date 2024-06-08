namespace Circuitry;

public abstract class BaseCounter : IDisplayValue
{
    public event EventHandler? DisplayValueChanged;

    public void OnDisplayValueChanged()
    {
        DisplayValueChanged?.Invoke(this, EventArgs.Empty);
    }

    protected int displayValue = 0;

    public int DisplayValue
    {
        get
        {
            return displayValue;
        }
        internal set
        {
            if (displayValue == value) return;
            displayValue = value;
            OnDisplayValueChanged();
        }
    }
}
