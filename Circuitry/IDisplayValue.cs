namespace Circuitry;

/// <summary>
/// Notifies clients that a display value has changed.
/// </summary>
public interface IDisplayValue
{
    public int DisplayValue { get; }
    public event EventHandler? DisplayValueChanged;
}
