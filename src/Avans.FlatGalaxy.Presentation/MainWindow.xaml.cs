using System;
using System.Windows;
using Avans.FlatGalaxy.Persistence.Loaders;
using Avans.FlatGalaxy.Persistence.Parsers;

namespace Avans.FlatGalaxy.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SimulationWindow _simulationWindow;
        private readonly IFileLoader _fileLoader;
        private readonly ConfigurationParserBase _configurationParser;

        public MainWindow(SimulationWindow simulationWindow, IFileLoader fileLoader, ConfigurationParserBase configurationParser)
        {
            _simulationWindow = simulationWindow;
            _fileLoader = fileLoader;
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
                    var fileContents = _fileLoader.GetContent(fileUri);
                    var galaxy = _configurationParser.Parse(fileContents);

                    _simulationWindow.Show(galaxy);
                    Close();
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
