﻿using System.Drawing;
using Avans.FlatGalaxy.Models.CelestialBodies.States;

namespace Avans.FlatGalaxy.Models.CelestialBodies
{
    public abstract class CelestialBody
    {
        public int X { get; set; }

        public int Y { get; set; }

        public double VX { get; set; }

        public double VY { get; set; }

        public int Radius { get; set; }

        public Color Color { get; set; }

        public ICollisionState CollisionState { get; set; }

        public CelestialBody(int x, int y, double vx, double vy, int radius, Color color, ICollisionState collisionState)
        {
            X = x;
            Y = y;
            VX = vx;
            VY = vy;
            Radius = radius;
            Color = color;
            CollisionState = collisionState;
        }
    }
}