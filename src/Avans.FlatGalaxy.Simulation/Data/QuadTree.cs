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
        private Bounds _bounds;

        public IList<CelestialBody> Elements;

        public QuadTree NorthEast { get; private set; }

        public QuadTree NorthWest { get; private set; }

        public QuadTree SouthEast { get; private set; }

        public QuadTree SouthWest { get; private set; }

        public QuadTree(Bounds bounds, int depth = 1)
        {
            _depth = depth;
            _bounds = bounds;
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
            NorthEast = new QuadTree(_bounds.NorthEast, _depth + 1);
            NorthWest = new QuadTree(_bounds.NorthWest, _depth + 1);
            SouthEast = new QuadTree(_bounds.SouthEast, _depth + 1);
            SouthWest = new QuadTree(_bounds.SouthWest, _depth + 1);

            foreach (var element in Elements)
            {
                InsertSub(element);
            }

            Elements = null;
        }

        private void InsertSub(CelestialBody element)
        {
            if (NorthEast._bounds.Inside(element)) NorthEast.Insert(element);
            if (NorthWest._bounds.Inside(element)) NorthWest.Insert(element);
            if (SouthEast._bounds.Inside(element)) SouthEast.Insert(element);
            if (SouthWest._bounds.Inside(element)) SouthWest.Insert(element);
        }
    }
}
