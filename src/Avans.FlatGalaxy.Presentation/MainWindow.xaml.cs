using System;
using System.Windows;
using Avans.FlatGalaxy.Persistence.Parsers;

namespace Avans.FlatGalaxy.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SimulationWindow _simulationWindow;
        private readonly ConfigurationParser _configurationParser;

        public MainWindow(SimulationWindow simulationWindow, ConfigurationParser configurationParser)
        {
            _simulationWindow = simulationWindow;
            _configurationParser = configurationParser;

            InitializeComponent();
        }

        private void SubmitFile(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(FileInput.Text))
                {
                    var fileUri = new Uri(FileInput.Text);

                    var galaxy = _configurationParser.Load(fileUri);

                    _simulationWindow.Show(galaxy);
                    return;
                }
            }
            catch
            {
                // ignored
            }
            MessageBox.Show(this, "Could not load the file");
        }
    }
}
