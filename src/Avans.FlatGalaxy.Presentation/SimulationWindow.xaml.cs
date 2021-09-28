using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Presentation.Extensions;
using Avans.FlatGalaxy.Simulation;

namespace Avans.FlatGalaxy.Presentation
{
    public partial class SimulationWindow : Window
    {
        private readonly ISimulator _simulator;

        public SimulationWindow(ISimulator simulator)
        {
            _simulator = simulator;
            InitializeComponent();

            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            CompositionTarget.Rendering += OnRender;
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            CompositionTarget.Rendering -= OnRender;
        }

        private void OnRender(object? sender, EventArgs e)
        {
            if (_simulator.Galaxy != null) Draw(_simulator.Galaxy);
        }

        public void Show(Galaxy galaxy)
        {
            Show();

            _simulator.Galaxy = galaxy;
            _simulator.Resume();
        }

        private void Draw(Galaxy galaxy)
        {
            GalaxyCanvas.Children.Clear();

            foreach (var celestialBody in galaxy.CelestialBodies)
            {
                var ellipse = new Ellipse
                {
                    Height = celestialBody.Diameter,
                    Width = celestialBody.Diameter,
                    Fill = new SolidColorBrush(celestialBody.Color.ToColor()),
                };

                GalaxyCanvas.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, celestialBody.CenterX);
                Canvas.SetTop(ellipse, celestialBody.CenterY);
            }

            Console.WriteLine("Galaxy drawn");
        }
    }
}
