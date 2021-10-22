using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Presentation.Extensions;
using Avans.FlatGalaxy.Simulation;
using Avans.FlatGalaxy.Simulation.Data;

namespace Avans.FlatGalaxy.Presentation
{
    public partial class SimulationWindow : Window
    {
        private ISimulator? _simulator;

        public SimulationWindow()
        {
            InitializeComponent();

            GalaxyCanvas.Width = ISimulator.Width;
            GalaxyCanvas.Height = ISimulator.Height;

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
            GalaxyCanvas.Children.Clear();

            if (_simulator?.Galaxy != null) { Draw(_simulator.Galaxy); }
            if (_simulator?.QuadTree != null) { Draw(_simulator.QuadTree); }
        }

        public void Show(Galaxy galaxy)
        {
            Show();

            _simulator = new Simulator(galaxy);
            _simulator.Resume();
        }

        private void Draw(Galaxy galaxy)
        {
            foreach (var celestialBody in galaxy.CelestialBodies)
            {
                var ellipse = new Ellipse
                {
                    Height = celestialBody.Diameter,
                    Width = celestialBody.Diameter,
                    Fill = new SolidColorBrush(celestialBody.Color.ToColor()),
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
                            Stroke = new SolidColorBrush(Colors.Blue),
                            X1 = celestialBody.CenterX,
                            Y1 = celestialBody.CenterY,
                            X2 = neighbour.CenterX,
                            Y2 = neighbour.CenterY,
                            SnapsToDevicePixels = true
                        });
                    }
                }
            }
        }

        private void Draw(QuadTree tree)
        {
            Draw(tree.Bounds);

            if (tree.NorthEast != null) Draw(tree.NorthEast);
            if (tree.NorthWest != null) Draw(tree.NorthWest);
            if (tree.SouthEast != null) Draw(tree.SouthEast);
            if (tree.SouthWest != null) Draw(tree.SouthWest);
        }

        private void Draw(Bounds bounds)
        {
            var rect = new Rectangle
            {
                Stroke = new SolidColorBrush(Colors.Red),
                Fill = new SolidColorBrush(Colors.Transparent),
                Width = bounds.Width,
                Height = bounds.Height,
            };
            Canvas.SetTop(rect, bounds.North);
            Canvas.SetLeft(rect, bounds.East);
            GalaxyCanvas.Children.Add(rect);
        }
    }
}
