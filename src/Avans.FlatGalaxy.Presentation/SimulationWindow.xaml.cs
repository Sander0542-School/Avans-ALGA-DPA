using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Presentation.Commands;
using Avans.FlatGalaxy.Presentation.Extensions;
using Avans.FlatGalaxy.Simulation;
using Avans.FlatGalaxy.Simulation.Data;

namespace Avans.FlatGalaxy.Presentation
{
    public partial class SimulationWindow : Window, IObserver<ISimulator>
    {
        private MainWindow _mainWindow;
        private ISimulator? _simulator;
        private readonly ShortcutList _shortcutList;

        public SimulationWindow(ShortcutList shortcutList)
        {
            _shortcutList = shortcutList;
            
            InitializeComponent();

            GalaxyCanvas.Width = ISimulator.Width;
            GalaxyCanvas.Height = ISimulator.Height;

            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
            KeyUp += OnKeyUp;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (_simulator != null) _shortcutList.HandleKey(e.Key, _simulator);
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

            if (_simulator == null) return;

            if (_simulator.Galaxy != null) { Draw(_simulator.Galaxy, _simulator.PathSteps); }
            if (_simulator.CollisionVisible && _simulator.QuadTree != null) { Draw(_simulator.QuadTree); }
        }

        public void Show(Galaxy galaxy, MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            
            Show();

            _simulator = new Simulator(galaxy);
            _simulator.Subscribe(this);
            _simulator.Resume();
        }

        private void Draw(Galaxy galaxy, ICollection<Planet> pathSteps)
        {
            var pathColor = Colors.Chartreuse;

            GalaxyCanvas.Children.Clear();

            foreach (var celestialBody in galaxy.CelestialBodies)
            {
                var ellipse = new Ellipse
                {
                    Height = celestialBody.Diameter,
                    Width = celestialBody.Diameter,
                    Fill = new SolidColorBrush(pathSteps?.Contains(celestialBody) ?? false ? pathColor : celestialBody.Color.ToColor()),
                };

                GalaxyCanvas.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, celestialBody.X);
                Canvas.SetTop(ellipse, celestialBody.Y);
                Panel.SetZIndex(ellipse, 10);

                if (celestialBody is Planet planet)
                {
                    foreach (var neighbour in planet.Neighbours)
                    {
                        var isStepLine = pathSteps != null && pathSteps.Contains(planet) && pathSteps.Contains(neighbour);

                        GalaxyCanvas.Children.Add(new Line
                        {
                            Stroke = new SolidColorBrush(isStepLine ? pathColor : Colors.Blue),
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

            if (tree.TopRight != null) Draw(tree.TopRight);
            if (tree.TopLeft != null) Draw(tree.TopLeft);
            if (tree.BottomRight != null) Draw(tree.BottomRight);
            if (tree.BottomLeft != null) Draw(tree.BottomLeft);
        }

        private void Draw(Bounds bounds)
        {
            var rect = new Rectangle
            {
                Stroke = Brushes.Red,
                Fill = Brushes.Transparent,
                Width = bounds.Width,
                Height = bounds.Height,
            };
            Canvas.SetTop(rect, bounds.Top);
            Canvas.SetLeft(rect, bounds.Left);
            GalaxyCanvas.Children.Add(rect);
        }

        public void OnCompleted()
        {
            _simulator = null;
            
            Hide();
            _mainWindow.Show();
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(ISimulator value)
        {
        }
    }
}
