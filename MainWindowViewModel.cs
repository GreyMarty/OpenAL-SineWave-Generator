using System.ComponentModel;
using System.Windows.Input;


namespace OpenALWaveTest
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public int Frequency 
        {
            get 
            {
                return _waveProvider.Frequency;
            }
            set 
            {
                _waveProvider.Frequency = value;

                OnPropertyChanged(nameof(Frequency));
                OnPropertyChanged(nameof(FrequencyLabel));
            }
        }

        public float Volume 
        {
            get 
            {
                return _waveProvider.Volume;
            }
            set 
            {
                _waveProvider.Volume = value;

                OnPropertyChanged(nameof(Volume));
                OnPropertyChanged(nameof(VolumeLabel));
            }
        }

        public string FrequencyLabel => $"{Frequency} Hz";
        public string VolumeLabel => $"{(int)(Volume * 100)}%";

        public ICommand PlayCommand { get; private set; }
        public ICommand PauseCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }

        private ISoundPlayer _soundPlayer;
        private SineWaveProvider _waveProvider;


        public MainWindowViewModel() 
        {
            _waveProvider = new SineWaveProvider();

            PlayCommand = new Command(Play);
            PauseCommand = new Command(Pause);
            CloseCommand = new Command(Close);
        }

        private void Play() 
        {
            if (_soundPlayer is null) 
            {
                _soundPlayer = new StreamSoundPlayer(_waveProvider);
            }

            _soundPlayer.Play();
        }

        private void Pause() 
        {
            _soundPlayer?.Pause();
        }

        private void Close() 
        {
            _soundPlayer?.Dispose();
            _soundPlayer = null;
        }

        private void OnPropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
