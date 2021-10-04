using System.Collections.Generic;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Simulation.Extensions;

namespace Avans.FlatGalaxy.Simulation.Data
{
    public class QuadTree
    {
        public const int MaxDepth = 10;
        public const int Size = 4;

        private int _depth;

        public Bounds Bounds { get; }

        public IList<CelestialBody> Elements { get; private set; }

        public QuadTree NorthEast { get; private set; }

        public QuadTree NorthWest { get; private set; }

        public QuadTree SouthEast { get; private set; }

        public QuadTree SouthWest { get; private set; }

        public QuadTree(Bounds bounds, int depth = 1)
        {
            _depth = depth;
            Bounds = bounds;
            Elements = new List<CelestialBody>();
        }

        public void Insert(CelestialBody element)
        {
            if (Elements != null)
            {
                if (Elements.Count < Size || _depth == MaxDepth)
                {
                    Elements.Add(element);
                }
                else
                {
                    Subdivide();
                }
            }
            else
            {
                InsertSub(element);
            }
        }

        public void Subdivide()
        {
            NorthEast = new QuadTree(Bounds.NorthEast, _depth + 1);
            NorthWest = new QuadTree(Bounds.NorthWest, _depth + 1);
            SouthEast = new QuadTree(Bounds.SouthEast, _depth + 1);
            SouthWest = new QuadTree(Bounds.SouthWest, _depth + 1);

            foreach (var element in Elements)
            {
                InsertSub(element);
            }

            Elements = null;
        }

        private void InsertSub(CelestialBody element)
        {
            if (NorthEast.Bounds.Inside(element)) NorthEast.Insert(element);
            if (NorthWest.Bounds.Inside(element)) NorthWest.Insert(element);
            if (SouthEast.Bounds.Inside(element)) SouthEast.Insert(element);
            if (SouthWest.Bounds.Inside(element)) SouthWest.Insert(element);
        }
    }
}
