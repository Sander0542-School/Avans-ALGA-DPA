using System;
using System.Collections.Generic;
using Avans.FlatGalaxy.Models.CelestialBodies;

namespace Avans.FlatGalaxy.Simulation.PathFinding
{
    public class DijkstraPathFinder : PathFinder
    {
        protected override List<Planet> Find(Planet start, Planet end)
        {
            return null;
        }

        private static double GetDistance(Planet origin, Planet target) => Math.Pow(origin.CenterX - target.CenterX, 2) + Math.Pow(origin.CenterY - target.CenterY, 2);
    }
}
