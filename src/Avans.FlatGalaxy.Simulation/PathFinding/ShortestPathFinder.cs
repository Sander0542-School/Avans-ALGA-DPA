﻿using System.Collections.Generic;
using Avans.FlatGalaxy.Models.CelestialBodies;

namespace Avans.FlatGalaxy.Simulation.PathFinding
{
    public class ShortestPathFinder : PathFinder
    {
        public override List<Planet> Find(Planet start, Planet end)
        {
            var previous = new Dictionary<Planet, Planet>();
            var queue = new Queue<Planet>();
            
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var planet = queue.Dequeue();
                
                foreach (var neighbour in planet.Neighbours)
                {
                    if (previous.ContainsKey(neighbour)) continue;
                    
                    previous[neighbour] = planet;
                    queue.Enqueue(neighbour);
                }
            }

            var shortest = new List<Planet>();
            var current = end;
            while (!current.Equals(start))
            {
                shortest.Add(current);
                current = previous[current];
            }
            
            shortest.Add(start);
            shortest.Reverse();

            return shortest;
        }
    }
}