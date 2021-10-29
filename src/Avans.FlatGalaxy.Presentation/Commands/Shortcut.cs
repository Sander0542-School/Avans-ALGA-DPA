using System.Windows.Input;
using ICommand = Avans.FlatGalaxy.Simulation.Commands.Common.ICommand;

namespace Avans.FlatGalaxy.Presentation.Commands
{
    public class Shortcut
    {
        public ICommand Command;
        public Key Key;
        public string Description;
    }
}