using System.Windows;


namespace OpenALWaveTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainWindowViewModel viewModel = new MainWindowViewModel();
            DataContext = viewModel;

            Closing += (o, e) => viewModel.CloseCommand.Execute(null);
        }
    }
}
