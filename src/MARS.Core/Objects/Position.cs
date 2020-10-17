namespace MARS.Core.Objects
{
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        private Position() { }
        public Position(int x, int y) => Set(x, y);
        public void Set(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
