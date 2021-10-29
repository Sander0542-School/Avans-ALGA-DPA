using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Avans.FlatGalaxy.Presentation.Commands;

namespace Avans.FlatGalaxy.Presentation
{
    public partial class ShortcutWindow : Window
    {
        private readonly ShortcutList _shortcutList;
        private Shortcut? _setKey;

        public ShortcutWindow(ShortcutList shortcutList)
        {
            _shortcutList = shortcutList;
            InitializeComponent();
        }

        private void ShortcutWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            LoadShortcuts();
        }

        private void LoadShortcuts()
        {
            StackPanel.Children.Clear();

            foreach (var shortcut in _shortcutList)
            {
                var stack = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    Margin = new(10),
                    Children =
                    {
                        new TextBlock
                        {
                            Text = shortcut.Description,
                            FontWeight = FontWeights.Bold,
                            FontSize = 20
                        },
                        new TextBlock
                        {
                            Text = $"Key: {shortcut.Key}",
                            FontSize = 15
                        }
                    }
                };

                var button = new Button
                {
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    FontWeight = FontWeights.Bold,
                    Content = "Edit",
                    Width = 40,
                    Height = 30,
                    Margin = new(10)
                };

                button.Click += (o, args) =>
                {
                    listenForKeys.Visibility = Visibility.Visible;
                    _setKey = shortcut;
                };

                var grid = new Grid
                {
                    ColumnDefinitions =
                    {
                        new ColumnDefinition
                        {
                            Width = GridLength.Auto
                        },
                        new ColumnDefinition
                        {
                            Width = GridLength.Auto
                        }
                    },
                    Children = {stack, button}
                };

                Grid.SetColumn(button, 0);
                Grid.SetColumn(stack, 1);

                var border = new Border
                {
                    Margin = new(15, 5, 15, 5),
                    BorderThickness = new(1),
                    BorderBrush = new SolidColorBrush(Colors.Black),
                    Background = Brushes.LightGray,
                    Child = grid
                };

                StackPanel.Children.Add(border);
            }
        }

        private void ShortcutWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (_setKey == null) return;

            if (CheckKey(e.Key, _setKey))
                _setKey.Key = e.Key;
            else
                MessageBox.Show("This key cannot be used, it is already used by another command!");

            _setKey = null;
            listenForKeys.Visibility = Visibility.Hidden;
            LoadShortcuts();
        }

        private bool CheckKey(Key key, Shortcut shortcut) => key != Key.Escape && _shortcutList.Where(s => s != shortcut).All(s => s.Key != key);

        private void ShortcutWindow_OnClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;

            Hide();
            _setKey = null;
            listenForKeys.Visibility = Visibility.Hidden;
        }
    }
}