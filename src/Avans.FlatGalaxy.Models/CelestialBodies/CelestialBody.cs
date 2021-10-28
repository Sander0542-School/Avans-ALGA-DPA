using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Avans.FlatGalaxy.Models.CelestialBodies.States;
using Avans.FlatGalaxy.Models.Common;

namespace Avans.FlatGalaxy.Models.CelestialBodies
{
    public abstract class CelestialBody : IObservable<CelestialBody>, ICloneable<CelestialBody>
    {
        private readonly IList<IObserver<CelestialBody>> _observers;

        public double X { get; set; }

        public double Y { get; set; }

        public double VX { get; set; }

        public double VY { get; set; }

        public int Radius { get; set; }

        public Color Color { get; set; }
        
        public Color OriginalColor { get; set; }

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
            OriginalColor = color;
            CollisionState = collisionState ?? new NullCollisionState();

            _observers = new List<IObserver<CelestialBody>>();
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

        public double DistanceTo(CelestialBody target) => Math.Pow(CenterX - target.CenterX, 2) + Math.Pow(CenterY - target.CenterY, 2);

        public IDisposable Subscribe(IObserver<CelestialBody> observer)
        {
            _observers.Add(observer);

            return new Unsubscriber<CelestialBody>(_observers, observer);
        }

        public void TriggerStateEvent()
        {
            foreach (var observer in _observers.ToList())
            {
                observer.OnNext(this);
            }
        }

        public abstract CelestialBody Clone();
    }
}
