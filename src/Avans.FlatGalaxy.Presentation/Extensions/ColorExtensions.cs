using System.Windows.Media;

namespace Avans.FlatGalaxy.Presentation.Extensions
{
    public static class ColorExtensions
    {
        public static Color ToColor(this System.Drawing.Color color)
        {
            return Color.FromArgb(color.A, color.R, color.G, color.B);
        }
    }
}
