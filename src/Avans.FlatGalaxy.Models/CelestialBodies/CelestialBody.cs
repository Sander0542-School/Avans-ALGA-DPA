﻿using System;
using System.Drawing;
using Avans.FlatGalaxy.Models.CelestialBodies.States;

namespace Avans.FlatGalaxy.Models.CelestialBodies
{
    public abstract class CelestialBody
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double VX { get; set; }

        public double VY { get; set; }

        public int Radius { get; set; }

        public Color Color { get; set; }

        public ICollisionState CollisionState { get; set; }

        public int Diameter => Radius * 2;

        public double CenterX => X + Radius;
        public double CenterY => Y + Radius;

        public CelestialBody(double x, double y, double vx, double vy, int radius, Color color, ICollisionState collisionState = null)
        {
            X = x;
            Y = y;
            VX = vx;
            VY = vy;
            Radius = radius;
            Color = color;
            CollisionState = collisionState ?? new NullCollisionState();
        }

        public bool IsColliding(CelestialBody other)
        {
            var dist = Math.Pow(CenterX - other.CenterX, 2) + Math.Pow(CenterY - other.CenterY, 2);
            var radSum = Math.Pow(Radius + other.Radius, 2);

            return dist <= radSum;
        }

        public void Collide(CelestialBody other)
        {
            CollisionState.Collide(this, other);
        }
    }
}
