using System.Drawing;
using System.Threading.Tasks;

namespace Avans.FlatGalaxy.Models.CelestialBodies.States
{
    public class BlinkState : ICollisionState
    {
        private bool _blinking;

        public void Collide(CelestialBody self, CelestialBody other)
        {
            if (!_blinking)
            {
                _blinking = true;
                Task.Run(async () => {
                    var color = self.Color;
                    self.Color = Color.DeepPink;
                    await Task.Delay(1000);
                    self.Color = color;
                    _blinking = false;
                });
            }
        }
        
        public ICollisionState Clone()
        {
            return new BlinkState();
        }
    }
}
