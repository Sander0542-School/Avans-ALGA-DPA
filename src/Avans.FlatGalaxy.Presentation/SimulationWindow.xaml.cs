using System.Windows;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Persistence;

namespace Avans.FlatGalaxy.Presentation
{
    public partial class SimulationWindow : Window
    {
        private Galaxy _galaxy;
        
        public SimulationWindow()
        {
            InitializeComponent();
        }

        public void Show(Galaxy galaxy)
        {
            _galaxy = galaxy;

            Show();
        }

        private void Tick()
        {
            
        }
    }
}

