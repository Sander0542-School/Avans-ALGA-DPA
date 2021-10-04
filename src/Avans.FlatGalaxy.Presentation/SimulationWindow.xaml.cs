using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Presentation.Extensions;
using Avans.FlatGalaxy.Simulation;
using Avans.FlatGalaxy.Simulation.PathFinding;

namespace Avans.FlatGalaxy.Presentation
{
    public partial class SimulationWindow : Window
    {
        private readonly ISimulator _simulator;

        public SimulationWindow(ISimulator simulator)
        {
            _simulator = simulator;
            InitializeComponent();

            GalaxyCanvas.Width = _simulator.Width;
            GalaxyCanvas.Height = _simulator.Height;

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
            
            var stepPlanets = galaxy.CelestialBodies.OfType<Planet>().OrderByDescending(planet => planet.Radius).ToList();
            var steps = new ShortestPathFinder().Calculate(stepPlanets[0], stepPlanets[1]);

            foreach (var celestialBody in galaxy.CelestialBodies)
            {
                var ellipse = new Ellipse
                {
                    Height = celestialBody.Diameter,
                    Width = celestialBody.Diameter,
                    Fill = new SolidColorBrush(steps.Contains(celestialBody) ? Colors.Chartreuse : celestialBody.Color.ToColor()),
                };

                GalaxyCanvas.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, celestialBody.X);
                Canvas.SetTop(ellipse, celestialBody.Y);
                Panel.SetZIndex(ellipse, 10);

                if (celestialBody is Planet planet)
                {
                    foreach (var neighbour in planet.Neighbours)
                    {
                        GalaxyCanvas.Children.Add(new Line
                        {
                            Stroke = new SolidColorBrush((steps.Contains(planet) && steps.Contains(neighbour)) ? Colors.Chartreuse : Colors.Blue) ,
                            X1 = celestialBody.CenterX,
                            Y1 = celestialBody.CenterY,
                            X2 = neighbour.CenterX,
                            Y2 = neighbour.CenterY,
                            SnapsToDevicePixels = true
                        });
                    }
                }
            }

            Console.WriteLine("Galaxy drawn");
        }
    }
}
