using System;
using System.Collections.Generic;
using System.Linq;
using Avans.FlatGalaxy.Models.CelestialBodies;

namespace Avans.FlatGalaxy.Simulation.PathFinding
{
    public class DijkstraPathFinder : PathFinder
    {
        public override List<Planet> Find(Planet start, Planet end)
        {
            var steps = new Dictionary<Planet, Conn>();
            var queue = new Queue<Planet>();
            Planet previous = null;
            var previousDistance = 0.0;
            
            // start with the first planet
            queue.Enqueue(start);
            
            // check distance to all neighbours
            while (queue.Count > 0)
            {
                var planet = queue.Dequeue();

                foreach (var neighbour in planet.Neighbours)
                {
                    if (previous != neighbour)
                    {
                        var distance = GetDistance(planet, neighbour);
                        steps.Add(neighbour, new Conn(distance, planet));
                        
                        queue.Enqueue(neighbour);
                    }
                }

                previous = planet;
            }
            
            // add those neighbours to queue
            
            // 

            return null;
        }

        private static double GetDistance(Planet origin, Planet target) => Math.Pow(origin.CenterX - target.CenterX, 2) + Math.Pow(origin.CenterY - target.CenterY, 2);

        class Conn
        {
            public double distance;
            public Planet previous;

            public Conn(double distance, Planet previous)
            {
                this.distance = distance;
                this.previous = previous;
            }
        }
    }
}