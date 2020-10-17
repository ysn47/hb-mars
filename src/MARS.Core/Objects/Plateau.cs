
namespace MARS.Core.Objects
{
    using MARS.Core.Abstract;
    public class Plateau : IPlateau
    {
        public Position BottomLeft { get; private set; } = new Position(0, 0);
        public Position TopRight { get; private set; }
        public Plateau(int topX, int topY)
        {
            TopRight = new Position(topX, topY);
        }

        public bool IsOutOfPlateau(Position point)
        {
            return
                point.X < BottomLeft.X ||
                point.Y < BottomLeft.Y ||
                point.X > TopRight.X ||
                point.Y > TopRight.Y;
        }
    }
}
