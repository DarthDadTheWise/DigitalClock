using DigitalClockWpf.ViewModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DigitalClockWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
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
    }
}