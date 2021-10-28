using System.Drawing;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Models.CelestialBodies.States;
using Avans.FlatGalaxy.Simulation.Collision;
using Moq;
using Xunit;

namespace Avans.FlatGalaxy.Simulation.Tests
{
    public class CollisionTests
    {
        [Fact]
        public void Test_Collision()
        {
            var mockCollisionState = CreateTestState();
            var body1 = new Asteroid(5, 5, 0, 0, 3, Color.Green, mockCollisionState.Object);
            var body2 = new Asteroid(7, 7, 0, 0, 3, Color.Green, mockCollisionState.Object);

            var sim = new Simulator(new Galaxy(new[] { body1, body2 }));

            var handler = new CollisionHandler();
            handler.Detect(sim);
            handler.Next();
            handler.Detect(sim);
            handler.Next();
            handler.Detect(sim);

            mockCollisionState.Verify(state => state.Collide(body1, body2), Times.Once);
            mockCollisionState.Verify(state => state.Collide(body2, body1), Times.Once);
        }

        [Fact]
        public void Test_Collision_Naive()
        {
            var mockCollisionState = CreateTestState();
            var body1 = new Asteroid(5, 5, 0, 0, 3, Color.Green, mockCollisionState.Object);
            var body2 = new Asteroid(7, 7, 0, 0, 3, Color.Green, mockCollisionState.Object);

            var sim = new Simulator(new Galaxy(new[] { body1, body2 }));

            var detector = new NaiveCollisionDetector();
            detector.Detect(sim, new CollisionHandler());

            mockCollisionState.Verify(state => state.Collide(body1, body2), Times.Once);
            mockCollisionState.Verify(state => state.Collide(body2, body1), Times.Once);
        }

        [Fact]
        public void Test_Collision_QuadTree()
        {
            var mockCollisionState = CreateTestState();
            var body1 = new Asteroid(5, 5, 0, 0, 3, Color.Green, mockCollisionState.Object);
            var body2 = new Asteroid(7, 7, 0, 0, 3, Color.Green, mockCollisionState.Object);

            var sim = new Simulator(new Galaxy(new[] { body1, body2 }));

            var detector = new QuadTreeCollisionDetector();
            detector.Detect(sim, new CollisionHandler());

            mockCollisionState.Verify(state => state.Collide(body1, body2), Times.Once);
            mockCollisionState.Verify(state => state.Collide(body2, body1), Times.Once);
        }

        [Fact]
        public void Test_Collision_QuadTree_AboveSize()
        {
            var mockCollisionState = CreateTestState();
            var body1 = new Asteroid(7, 7, 0, 0, 3, Color.Green, mockCollisionState.Object);
            var body2 = new Asteroid(7, 7, 0, 0, 3, Color.Green, mockCollisionState.Object);
            var body3 = new Asteroid(7, 7, 0, 0, 3, Color.Green, mockCollisionState.Object);
            var body4 = new Asteroid(7, 7, 0, 0, 3, Color.Green, mockCollisionState.Object);
            var body5 = new Asteroid(7, 7, 0, 0, 3, Color.Green, mockCollisionState.Object);

            var sim = new Simulator(new Galaxy(new[] { body1, body2, body3, body4, body5 }));

            var detector = new QuadTreeCollisionDetector();
            detector.Detect(sim, new CollisionHandler());

            mockCollisionState.Verify(state => state.Collide(It.IsAny<CelestialBody>(), It.IsAny<CelestialBody>()), Times.Exactly(20));
        }

        private Mock<ICollisionState> CreateTestState()
        {
            var mock = new Mock<ICollisionState>();
            return mock;
        }
    }
}
