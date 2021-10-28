﻿using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Simulation.Data;

namespace Avans.FlatGalaxy.Simulation
{
    public interface ISimulator
    {
        public const int Width = 800;

        public const int Height = 600;

        public const double SpeedDiff = 0.1;

        public const double BookmarkTime = 5000;

        Galaxy Galaxy { get; set; }

        QuadTree QuadTree { get; set; }

        bool CollisionVisible { get; set; }

        void Resume();

        void Pause();

        void Restore();

        void SpeedUp(double speed);

        void SpeedDown(double speed);

        void SwitchCollisionAlgo();

        void AddAsteroid();

        void RemoveAsteroid();

        void ToggleCollisionVisibility();
    }
}
