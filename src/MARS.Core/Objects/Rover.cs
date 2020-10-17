namespace Mars.Core.Objects
{
    using Mars.Core.Abstract;
    using System;

    public class Rover : IRover
    {
        private readonly IPlateau plateau;
        private Position Position { get; set; }
        private int DirectionNumber { get; set; }
        private Direction Direction => (Direction)DirectionNumber;

        public Rover(IPlateau plateau, int x, int y, Direction direction)
        {
            this.plateau = plateau;
            Position = new Position(x, y);
            DirectionNumber = (int)direction;
        }

        public void ApplyCommandBulk(string commands)
        {
            foreach (var command in commands)
            {
                ApplyCommand(command);
            }
        }

        public void ApplyCommand(char command)
        {
            switch (command)
            {
                case 'L':
                    RotateLeft();
                    break;
                case 'R':
                    RotateRight();
                    break;
                case 'M':
                    MoveForward();
                    break;
                default:
                    throw new InvalidOperationException($"Command '{command}' is invalid");
            }
        }

        private void MoveForward()
        {
            switch (Direction)
            {
                case Direction.N:
                    ApplyNewPosition(new Position(Position.X, Position.Y + 1));
                    break;
                case Direction.E:
                    ApplyNewPosition(new Position(Position.X + 1, Position.Y));
                    break;
                case Direction.S:
                    ApplyNewPosition(new Position(Position.X, Position.Y - 1));
                    break;
                case Direction.W:
                    ApplyNewPosition(new Position(Position.X - 1, Position.Y));
                    break;
            }
        }

        private void ApplyNewPosition(Position position)
        {
            if (plateau.IsOutOfPlateau(position))
                throw new ArgumentOutOfRangeException("The rover can't move forward");
            Position = position;
        }

        private void RotateRight()
        {
            DirectionNumber = DirectionNumber == 4 ? 1 : DirectionNumber + 1;
        }

        private void RotateLeft()
        {
            DirectionNumber = DirectionNumber == 1 ? 4 : DirectionNumber - 1;
        }
        
        public string GetCurrentPositionAndDirection()
        {
            return $"{Position.X} {Position.Y} {Direction}";
        }
    }
}
