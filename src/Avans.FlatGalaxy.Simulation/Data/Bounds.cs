namespace Avans.FlatGalaxy.Simulation.Data
{
    public class Bounds
    {
        public Bounds(double north, double east, double south, double west)
        {
            North = north;
            East = east;
            South = south;
            West = west;
        }

        public double North { get; }

        public double East { get; }

        public double South { get; }

        public double West { get; }

        public double Height => South - North;

        public double Width => West - East;

        public bool Inside(double x1, double y1, double x2, double y2)
        {
            return x2 >= East && x1 <= West && y2 >= North && y1 <= South;
        }

        public Bounds NorthEast => new(North, East, North + Height / 2, East + Width / 2);

        public Bounds NorthWest => new(North, East + Width / 2, North + Height / 2, West);

        public Bounds SouthEast => new(North + Height / 2, East, South, East + Width / 2);

        public Bounds SouthWest => new(North + Height / 2, East + Width / 2, South, West);
    }
}
