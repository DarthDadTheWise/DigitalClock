using DigitalClockWpf.ViewModel;
using System.Windows;

namespace DigitalClockWpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new();
    }

    public new MainViewModel DataContext
    {
        get
        {
            MainViewModel? vm = base.DataContext as MainViewModel;
            ArgumentNullException.ThrowIfNull(vm);
            return vm;
        }
        set { base.DataContext = value; }
    }

    private void Start_Click(object sender, RoutedEventArgs e)
    {
        DataContext.Start();
    }

    private void Stop_Click(object sender, RoutedEventArgs e)
    {
        DataContext.Stop();
    }

    private void Window_Closed(object sender, EventArgs e)
    {
        DataContext.Stop();
    }
}