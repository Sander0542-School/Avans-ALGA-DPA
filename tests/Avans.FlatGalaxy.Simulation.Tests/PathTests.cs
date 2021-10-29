using System.Collections.Generic;
using System.Drawing;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Simulation.Path;
using Xunit;

namespace Avans.FlatGalaxy.Simulation.Tests
{
    public class PathTests
    {
        [Fact]
        public void Test_Dijkstra()
        {
            var handler = new DijkstraPathAlgorithm();
            var planets = new List<Planet>();

            var start = new Planet("PlanetStart", 35, 30, 0, 0, 3, Color.Green, null);
            planets.Add(start);
            
            var middle = new Planet("PlanetMiddle", 35, 35, 0, 0, 3, Color.Green, null);
            planets.Add(middle);

            var end = new Planet("PlanetEnd", 40, 30, 0, 0, 3, Color.Green, null);
            planets.Add(end);

            var random1 = new Planet("Random1", 15, 5, 0, 0, 3, Color.Green, null);
            planets.Add(random1);

            var random2 = new Planet("Random2", 100, 5, 0, 0, 3, Color.Green, null);
            planets.Add(random2);

            var random3 = new Planet("Random3", 12, 200, 0, 0, 3, Color.Green, null);
            planets.Add(random3);

            
            start.Neighbours.Add(middle);
            middle.Neighbours.Add(start);
            middle.Neighbours.Add(end);
            end.Neighbours.Add(middle);
            
            start.Neighbours.Add(random1);
            random1.Neighbours.Add(start);
            
            random1.Neighbours.Add(random2);
            random2.Neighbours.Add(random1);
            
            random2.Neighbours.Add(random3);
            random3.Neighbours.Add(random2);
            
            random3.Neighbours.Add(end);
            end.Neighbours.Add(random3);

            var result = handler.Find(start, end, planets);
            
            Assert.Equal(3, result.Count);
            Assert.Contains(result, planet => planet == start);
            Assert.Contains(result, planet => planet == middle);
            Assert.Contains(result, planet => planet == end);

        }
        
        [Fact]
        public void Test_BreadthFirst()
        {
            var handler = new BreadthFirstPathAlgorithm();
            var planets = new List<Planet>();

            var start = new Planet("PlanetStart", 35, 30, 0, 0, 3, Color.Green, null);
            planets.Add(start);
            
            var middle = new Planet("PlanetMiddle", 35, 35, 0, 0, 3, Color.Green, null);
            planets.Add(middle);

            var end = new Planet("PlanetEnd", 40, 30, 0, 0, 3, Color.Green, null);
            planets.Add(end);

            var random1 = new Planet("Random1", 15, 5, 0, 0, 3, Color.Green, null);
            planets.Add(random1);

            var random2 = new Planet("Random2", 100, 5, 0, 0, 3, Color.Green, null);
            planets.Add(random2);

            var random3 = new Planet("Random3", 12, 200, 0, 0, 3, Color.Green, null);
            planets.Add(random3);

            
            start.Neighbours.Add(middle);
            middle.Neighbours.Add(start);
            middle.Neighbours.Add(end);
            end.Neighbours.Add(middle);
            
            start.Neighbours.Add(random1);
            random1.Neighbours.Add(start);
            
            random1.Neighbours.Add(random2);
            random2.Neighbours.Add(random1);
            
            random2.Neighbours.Add(random3);
            random3.Neighbours.Add(random2);
            
            random3.Neighbours.Add(end);
            end.Neighbours.Add(random3);

            var result = handler.Find(start, end, planets);
            
            Assert.Equal(3, result.Count);
            Assert.Contains(result, planet => planet == start);
            Assert.Contains(result, planet => planet == middle);
            Assert.Contains(result, planet => planet == end);

        }

        [Fact]
        public void Test_PathHandler()
        {
            var handler = new PathHandler();
            var planets = new List<Planet>();

            var start = new Planet("PlanetStart", 35, 30, 0, 0, 3, Color.Green, null);
            planets.Add(start);
            
            var middle = new Planet("PlanetMiddle", 35, 35, 0, 0, 3, Color.Green, null);
            planets.Add(middle);

            var end = new Planet("PlanetEnd", 40, 30, 0, 0, 3, Color.Green, null);
            planets.Add(end);

            var random1 = new Planet("Random1", 15, 5, 0, 0, 3, Color.Green, null);
            planets.Add(random1);

            var random2 = new Planet("Random2", 100, 5, 0, 0, 3, Color.Green, null);
            planets.Add(random2);

            var random3 = new Planet("Random3", 12, 200, 0, 0, 3, Color.Green, null);
            planets.Add(random3);

            
            start.Neighbours.Add(middle);
            middle.Neighbours.Add(start);
            middle.Neighbours.Add(end);
            end.Neighbours.Add(middle);
            
            start.Neighbours.Add(random1);
            random1.Neighbours.Add(start);
            
            random1.Neighbours.Add(random2);
            random2.Neighbours.Add(random1);
            
            random2.Neighbours.Add(random3);
            random3.Neighbours.Add(random2);
            
            random3.Neighbours.Add(end);
            end.Neighbours.Add(random3);

            var result = handler.Find(start, end, planets);
            Assert.Equal(3, result.Count);
            Assert.Contains(result, planet => planet == start);
            Assert.Contains(result, planet => planet == middle);
            Assert.Contains(result, planet => planet == end);
            
            handler.Next();
            result = handler.Find(start, end, planets);
            Assert.Equal(3, result.Count);
            Assert.Contains(result, planet => planet == start);
            Assert.Contains(result, planet => planet == middle);
            Assert.Contains(result, planet => planet == end);
        }
    }
}