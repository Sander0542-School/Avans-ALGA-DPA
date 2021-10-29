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

        public QuadTree TopRight { get; private set; }

        public QuadTree TopLeft { get; private set; }

        public QuadTree BottomRight { get; private set; }

        public QuadTree BottomLeft { get; private set; }

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
                    InsertSub(element);
                }
            }
            else
            {
                InsertSub(element);
            }
        }

        public void Subdivide()
        {
            TopRight = new(Bounds.TopRight, _depth + 1);
            TopLeft = new(Bounds.TopLeft, _depth + 1);
            BottomRight = new(Bounds.BottomRight, _depth + 1);
            BottomLeft = new(Bounds.BottomLeft, _depth + 1);

            foreach (var element in Elements)
            {
                InsertSub(element);
            }

            Elements = null;
        }

        private void InsertSub(CelestialBody element)
        {
            if (TopRight.Bounds.Inside(element)) TopRight.Insert(element);
            if (TopLeft.Bounds.Inside(element)) TopLeft.Insert(element);
            if (BottomRight.Bounds.Inside(element)) BottomRight.Insert(element);
            if (BottomLeft.Bounds.Inside(element)) BottomLeft.Insert(element);
        }
    }
}
