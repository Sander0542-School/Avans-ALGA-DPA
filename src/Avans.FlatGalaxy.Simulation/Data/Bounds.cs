namespace Avans.FlatGalaxy.Simulation.Data
{
    public class Bounds
    {
        public Bounds(double top, double right, double bottom, double left)
        {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
        }

        public double Top { get; }

        public double Right { get; }

        public double Bottom { get; }

        public double Left { get; }

        public double Height => Bottom - Top;

        public double Width => Right - Left;

        public bool Inside(double x1, double y1, double x2, double y2)
        {
            return x1 <= Right && x2 >= Left && y1 <= Bottom && y2 >= Top;
        }

        public Bounds TopRight => new(Top, Right, Top + Height / 2, Right - Width / 2);

        public Bounds TopLeft => new(Top, Left + Width / 2, Top + Height / 2, Left);

        public Bounds BottomRight => new(Bottom - Height / 2, Right, Bottom, Right - Width / 2);

        public Bounds BottomLeft => new(Bottom - Height / 2, Left + Width / 2, Bottom, Left);
    }
}
