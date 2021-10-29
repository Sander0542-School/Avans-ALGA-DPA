using System;
using System.Collections.Generic;
using System.Drawing;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Models.CelestialBodies.States;
using Avans.FlatGalaxy.Simulation.Data;
using Xunit;

namespace Avans.FlatGalaxy.Simulation.Tests
{
    public class QuadTreeTests
    {
        private const int Size = 500;
        private const int Speed = 4;

        [Theory]
        [InlineData(1)]
        [InlineData(15)]
        [InlineData(28)]
        [InlineData(56)]
        [InlineData(74)]
        public void Test_QuadTree_Insert(int count)
        {
            var quadTree = new QuadTree(new(0, Size, Size, 0));

            foreach (var body in CreateCelestialBodies(count))
            {
                quadTree.Insert(body);
            }
        }

        [Fact]
        public void Test_QuadTree_Insert_SameLocation_BelowSize()
        {
            var quadTree = new QuadTree(new(0, Size, Size, 0));

            foreach (var body in CreateCelestialBodies(QuadTree.Size - 1))
            {
                body.X = body.Y = 1;
                quadTree.Insert(body);
            }

            Assert.Null(quadTree.TopRight);
            Assert.NotNull(quadTree.Elements);
            Assert.Equal(3, quadTree.Elements.Count);
        }

        [Fact]
        public void Test_QuadTree_Insert_SameLocation_AboveSize()
        {
            var quadTree = new QuadTree(new(0, Size, Size, 0));

            foreach (var body in CreateCelestialBodies(QuadTree.Size + 1))
            {
                body.X = body.Y = body.Radius = 1;
                quadTree.Insert(body);
            }

            Assert.Null(quadTree.Elements);

            var depth = 1;
            while (quadTree.Elements == null)
            {
                depth++;
                quadTree = quadTree.TopLeft;
            }
            
            Assert.Equal(QuadTree.MaxDepth, depth);
        }

        private CelestialBody CreateCelestialBody()
        {
            var rnd = new Random();

            return new Planet(
                $"Test {rnd.Next(100, 1000)}",
                rnd.NextDouble() * Size,
                rnd.NextDouble() * Size,
                rnd.NextDouble() * Speed + 1,
                rnd.NextDouble() * Speed + 1,
                rnd.Next(2, 8), Color.Green,
                new NullCollisionState()
            );
        }

        private IEnumerable<CelestialBody> CreateCelestialBodies(int count)
        {
            for (var i = 0; i < count; i++)
            {
                yield return CreateCelestialBody();
            }
        }
    }
}
