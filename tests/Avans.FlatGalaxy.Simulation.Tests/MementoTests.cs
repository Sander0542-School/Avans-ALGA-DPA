using System.Drawing;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Models.CelestialBodies.States;
using Avans.FlatGalaxy.Simulation.Bookmark;
using Xunit;

namespace Avans.FlatGalaxy.Simulation.Tests
{
    public class MementoTests
    {
        [Fact]
        public void Test_Memento_CreateRestore()
        {
            var body1 = new Asteroid(7, 7, 0, 0, 3, Color.Green, new NullCollisionState());
            var body2 = new Asteroid(7, 7, 0, 0, 3, Color.Green, new NullCollisionState());
            var galaxy = new Galaxy(new[] { body1, body2 });

            var memento = new GalaxyMemento(galaxy);
            var galaxy2 = memento.GetState();
            
            Assert.NotSame(galaxy, galaxy2);
        }

        [Fact]
        public void Test_Caretaker_CreateRestore()
        {
            var body1 = new Asteroid(7, 7, 1, 1, 3, Color.Green, new NullCollisionState());
            var body2 = new Asteroid(7, 7, 1, 1, 3, Color.Green, new NullCollisionState());
            var galaxy = new Galaxy(new[] { body1, body2 });
            var simulator = new Simulator(galaxy);
            
            var caretaker = new SimulatorCaretaker(simulator);
            caretaker.Undo();
            
            Assert.Same(galaxy, simulator.Galaxy);
            
            caretaker.Save();
            
            Assert.Same(galaxy, simulator.Galaxy);
            
            caretaker.Undo();
            
            Assert.NotSame(galaxy, simulator.Galaxy);
        }
    }
}
