using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Xunit;

namespace Avans.FlatGalaxy.Simulation.Tests
{
    public class CommandTests
    {
        [Theory]
        [InlineData(5)]
        [InlineData(8)]
        [InlineData(15)]
        [InlineData(75)]
        public void Test_AddRemoveAsteroid(int cnt)
        {
            var bodies = new List<CelestialBody>();

            for (int i = 0; i < cnt; i++)
                bodies.Add(new Asteroid(7, 7, 0, 0, 3, Color.Green, null));  
            

            var sim = new Simulator(new(bodies));
            var count = sim.Galaxy.CelestialBodies.Count();
            
            sim.AddAsteroid();
            Assert.Equal(count + 1, sim.Galaxy.CelestialBodies.Count());
            sim.RemoveAsteroid();
            Assert.Equal(count, sim.Galaxy.CelestialBodies.Count());
        }
        
        [Fact]
        public void Test_ToggleCollisionVisibility()
        {
            var body = new Asteroid(7, 7, 0, 0, 3, Color.Green, null);
            var sim = new Simulator(new(new[] {body}));

            var vis = sim.CollisionVisible;
            sim.ToggleCollisionVisibility();
            Assert.NotEqual(vis, sim.CollisionVisible);
        }
    }
}