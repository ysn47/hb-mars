using MARS.Core.Abstract;
using MARS.Core.Objects;
using System;
using System.Linq;
using Xunit;

namespace MARS.Tests
{
    public class PlateauTests
    {
        [Theory]
        [InlineData("4 4", "5 1")]
        [InlineData("4 4", "1 5")]
        [InlineData("4 4", "-1 0")]
        [InlineData("4 4", "0 -1")]
        public void Out_Of_Plateau_Should_Return_True(string plateauPosition, string position)
        {
            var maxPointCoordinates = plateauPosition.Split(' ').Select(p => Convert.ToInt32(p)).ToArray();
            IPlateau plateau = new Plateau(maxPointCoordinates[0], maxPointCoordinates[1]);

            var coordinates = position.Split(' ').Select(p => Convert.ToInt32(p)).ToArray();
            var outPosition = new Position(coordinates[0], coordinates[1]);

            Assert.True(plateau.IsOutOfPlateau(outPosition));
        }
    }
}
