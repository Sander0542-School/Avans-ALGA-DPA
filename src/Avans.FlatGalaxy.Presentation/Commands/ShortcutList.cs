using System.Collections.Generic;
using System.Windows.Input;
using Avans.FlatGalaxy.Simulation.Commands;

namespace Avans.FlatGalaxy.Presentation.Commands
{
    public class ShortcutList : List<Shortcut>
    {
        public ShortcutList()
        {
            Add(new Shortcut
            {
                Command = new PauseCommand(),
                Description = "Pause simulation",
                Key = Key.P
            });
            
            Add(new Shortcut
            {
                Command = new ResumeCommand(),
                Description = "Resume simulation",
                Key = Key.R
            });
            
            Add(new Shortcut
            {
                Command = new SpeedUpCommand(),
                Description = "Speed up simulation",
                Key = Key.OemPlus
            });

            Add(new Shortcut
            {
                Command = new SpeedUpCommand(),
                Description = "Speed down simulation",
                Key = Key.OemMinus,
            });

            Add(new Shortcut
            {
                Command = new RestoreCommand(),
                Description = "Go back 5 seconds in simulation",
                Key = Key.Back,
            });

            Add(new Shortcut
            {
                Command = new CollisionSwitchCommand(),
                Description = "Switch collision (Quad tree / Naive)",
                Key = Key.K,
            });

            Add(new Shortcut
            {
                Command = new CollisionVisibilityCommand(),
                Description = "Switch collision visibility",
                Key = Key.L,
            });

            Add(new Shortcut
            {
                Command = new AddAsteroidCommand(),
                Description = "Add asteroid to simulation",
                Key = Key.U,
            });

            Add(new Shortcut
            {
                Command = new RemoveAsteroidCommand(),
                Description = "Remove asteroid from simulation",
                Key = Key.I,
            });
        }
    }
}