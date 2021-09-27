using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Presentation.Extensions;

namespace Avans.FlatGalaxy.Presentation
{
    public partial class SimulationWindow : Window
    {
        private readonly Simulation.Simulation _simulation;

        public SimulationWindow(Simulation.Simulation simulation)
        {
            _simulation = simulation;
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
            Draw(_simulation.Galaxy);
        }

        public void Show(Galaxy galaxy)
        {
            Show();

            _simulation.Galaxy = galaxy;
            _simulation.Resume();
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
                ellipse.SetValue(Canvas.LeftProperty, (double)celestialBody.X);
                ellipse.SetValue(Canvas.TopProperty, (double)celestialBody.Y);
            }

            foreach (var fold in galaxy.Folds)
            {
                GalaxyCanvas.Children.Add(new Line
                {
                    Fill = new SolidColorBrush(Colors.Blue),
                    X1 = fold.Body1.X,
                    Y1 = fold.Body1.Y,
                    X2 = fold.Body2.X,
                    Y2 = fold.Body2.Y,
                });
            }
        }
    }
}
