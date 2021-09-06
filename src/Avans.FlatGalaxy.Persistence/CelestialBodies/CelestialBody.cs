﻿using System.Drawing;
using Avans.FlatGalaxy.Persistence.CelestialBodies.States;

namespace Avans.FlatGalaxy.Persistence.CelestialBodies
{
    public abstract class CelestialBody
    {
        public int X { get; set; }
        
        public int Y { get; set; }
        
        public int VX { get; set; }
        
        public int VY { get; set; }
        
        public int Radius { get; set; }
        
        public Color Color { get; set; }
        
        public ICollisionState CollisionState { get; set; }
    }
}