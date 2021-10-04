using System.Collections.Generic;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Simulation.Data;

namespace Avans.FlatGalaxy.Simulation
{
    public interface ISimulator
    {
        public const int Width = 800;

        public const int Height = 600;

        Galaxy Galaxy { get; set; }

        QuadTree QuadTree { get; set; }

        List<Planet> PathSteps { get; set; }

        void Resume();

        void Pause();
    }
}
