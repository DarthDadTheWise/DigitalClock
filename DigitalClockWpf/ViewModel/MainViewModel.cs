using CommunityToolkit.Mvvm.ComponentModel;

namespace DigitalClockWpf.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private readonly ClockViewModel clockViewModel;

        public MainViewModel()
        {
            clockViewModel = new ClockViewModel();

            // The the current time, otherwise it is "00:00:00"
            var currentTime = DateTime.Now;
            clockViewModel.Set(currentTime.Hour, currentTime.Minute, currentTime.Second);

            clockViewModel.Start();
        }

        public ClockViewModel ClockVM { get { return clockViewModel; } }

        public void Start()
        {
            clockViewModel.Start();
        }

        public void Stop()
        {
            clockViewModel.Stop();
        }
    }
}
