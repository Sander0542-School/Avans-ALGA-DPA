﻿using System;
using System.Drawing;
using Avans.FlatGalaxy.Persistence.CelestialBodies;
using Avans.FlatGalaxy.Persistence.CelestialBodies.States;
using Avans.FlatGalaxy.Persistence.Factories.Common;

namespace Avans.FlatGalaxy.Persistence.Factories
{
    public class CelestialBodyFactory : ICelestialBodyFactory
    {
        public CelestialBody Create(string name, string type, int x, int y, int vx, int vy, int radius, string colorName, string collisionName)
        {
            var color = Color.FromName(colorName);
            var collision = GetCollisionState(collisionName);

            return type.ToLower() switch
            {
                "planet" => new Planet(name, x, y, vx, vy, radius, color, collision),
                "asteroid" => new Asteroid(name, x, y, vx, vy, radius, color, collision),
                _ => throw new NotImplementedException($"The {type} celestial body has not been implemented yet")
            };
        }

        private static ICollisionState GetCollisionState(string collisionName)
        {
            return collisionName.ToLower() switch
            {
                "blink" => new BlinkState(),
                "bounce" => new BounceState(),
                "disappear" => new DisappearState(),
                "explode" => new ExplodeState(),
                "grow" => new GrowState(),
                _ => throw new NotImplementedException($"The {collisionName} collision has not been implemented yet")
            };
        }
    }
}