﻿namespace Avans.FlatGalaxy.Models.CelestialBodies.States
{
    public interface ICollisionState
    {
        public void Collide(CelestialBody celestialBody);
    }
}