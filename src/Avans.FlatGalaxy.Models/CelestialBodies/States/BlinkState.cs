using System.Drawing;
using System.Threading.Tasks;

namespace Avans.FlatGalaxy.Models.CelestialBodies.States
{
    public class BlinkState : ICollisionState
    {
        private const int Times = 4;
        private const int Delay = 250;

        private bool _blinking;

        public void Collide(CelestialBody self, CelestialBody other)
        {
            if (!_blinking)
            {
                _blinking = true;
                Task.Run(async () => {
                    var color = self.OriginalColor;
                    var invertedColor = Color.FromArgb(self.OriginalColor.ToArgb() ^ 0xFFFFFF);
                    for (var i = 0; i < Times; i++)
                    {
                        self.Color = invertedColor;
                        await Task.Delay(Delay);
                        self.Color = color;
                        await Task.Delay(Delay);
                    }
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
