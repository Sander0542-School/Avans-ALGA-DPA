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

        public bool Inside(double x1, double y1, double x2, double y2)
        {
            return x2 >= East && x1 <= West && y2 >= North && y1 <= South;
        }

        public Bounds NorthEast => new(North, East, South / 2, West / 2);

        public Bounds NorthWest => new(North, East / 2, South / 2, West);

        public Bounds SouthEast => new(North / 2, East, South, West / 2);

        public Bounds SouthWest => new(North / 2, East / 2, South, West);
    }
}
