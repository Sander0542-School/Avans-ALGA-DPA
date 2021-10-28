using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Avans.FlatGalaxy.Simulation;
using Avans.FlatGalaxy.Simulation.Commands;

namespace Avans.FlatGalaxy.Presentation.Commands
{
    public class ShortcutList : List<Shortcut>
    {
        public ShortcutList()
        {
            Add(new()
            {
                Command = new PauseCommand(),
                Description = "Pause simulation",
                Key = Key.P
            });

            Add(new()
            {
                Command = new ResumeCommand(),
                Description = "Resume simulation",
                Key = Key.R
            });

            Add(new()
            {
                Command = new SpeedUpCommand(),
                Description = "Speed up simulation",
                Key = Key.OemPlus
            });

            Add(new()
            {
                Command = new SpeedUpCommand(),
                Description = "Speed down simulation",
                Key = Key.OemMinus,
            });

            Add(new()
            {
                Command = new RestoreCommand(),
                Description = "Go back 5 seconds in simulation",
                Key = Key.Back,
            });

            Add(new()
            {
                Command = new CollisionSwitchCommand(),
                Description = "Switch collision (Quad tree / Naive)",
                Key = Key.K,
            });

            Add(new()
            {
                Command = new CollisionVisibilityCommand(),
                Description = "Switch collision visibility",
                Key = Key.L,
            });

            Add(new()
            {
                Command = new PathSwitchCommand(),
                Description = "Switch path finding (Breadth first / Dijkstra)",
                Key = Key.J,
            });

            Add(new()
            {
                Command = new AddAsteroidCommand(),
                Description = "Add asteroid to simulation",
                Key = Key.U,
            });

            Add(new()
            {
                Command = new RemoveAsteroidCommand(),
                Description = "Remove asteroid from simulation",
                Key = Key.I,
            });
            
            Add(new Shortcut
            {
                Command = new RemoveAsteroidCommand(),
                Description = "Remove asteroid from simulation",
                Key = Key.I,
            });
        }

        public void HandleKey(Key key, ISimulator simulator)
        {
            foreach (var shortcut in this.Where(shortcut => shortcut.Key == key))
            {
                shortcut.Command.Execute(simulator);
            }
        }
    }
}
