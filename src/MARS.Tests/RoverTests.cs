namespace MARS.Tests
{
    using MARS.Core;
    using MARS.Core.Abstract;
    using MARS.Core.Objects;
    using System;
    using System.Linq;
    using Xunit;

    public class RoverTests
    {
        [Theory]
        [InlineData("5 5", "1 2 N", "LMLMLMLMM", "1 3 N")]
        [InlineData("5 5", "3 3 E", "MMRMMRMRRM", "5 1 E")]
        public void Rover_Should_Move_Correctly(string plateauPosition, string roverPosition, string commands, string expected)
        {
            var plateauPoints = plateauPosition.Split(' ').Select(p => Convert.ToInt32(p)).ToArray();
            IPlateau plateau = new Plateau(plateauPoints[0], plateauPoints[1]);

            var roverData = roverPosition.Split(' ');
            IRover rover = new Rover(plateau, Convert.ToInt32(roverData[0]), Convert.ToInt32(roverData[1]), (Direction)Enum.Parse(typeof(Direction), roverData[2]));
            rover.ApplyCommandBulk(commands);

            Assert.Equal(rover.GetCurrentPositionAndDirection(), expected);
        }
    }
}