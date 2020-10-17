namespace MARS.ConsoleApp
{
    using MARS.Core;
    using MARS.Core.Abstract;
    using MARS.Core.Objects;
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var plateauPosition = Console.ReadLine().Split(' ');
            var firstRoverData = Console.ReadLine().Split(' ');
            var firstRoverCommands = Console.ReadLine();
            var secondRoverData = Console.ReadLine().Split(' ');
            var secondRoverCommands = Console.ReadLine();

            var plateauPoints = plateauPosition.Select(p => Convert.ToInt32(p)).ToArray();
            IPlateau plateau = new Plateau(plateauPoints[0], plateauPoints[1]);

            IRover firstRover = new Rover(plateau, Convert.ToInt32(firstRoverData[0]), Convert.ToInt32(firstRoverData[1]), (Direction)Enum.Parse(typeof(Direction), firstRoverData[2]));
            firstRover.ApplyCommandBulk(firstRoverCommands);

            IRover secondRover = new Rover(plateau, Convert.ToInt32(secondRoverData[0]), Convert.ToInt32(secondRoverData[1]), (Direction)Enum.Parse(typeof(Direction), secondRoverData[2]));
            secondRover.ApplyCommandBulk(secondRoverCommands);

            Console.WriteLine(firstRover.GetCurrentPositionAndDirection());
            Console.WriteLine(secondRover.GetCurrentPositionAndDirection());

            Console.ReadLine();
        }
    }
}
