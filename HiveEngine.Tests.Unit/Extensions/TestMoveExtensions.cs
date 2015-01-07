using System.Collections.Generic;
using FluentAssertions;

namespace HiveEngine.Tests.Unit.Extensions
{
    public static class TestMoveExtensions
    {
        public static void ShouldContainMovingTileToPositions(this IEnumerable<Move> moves, TileColor tileColor,
            Insect insect, IEnumerable<Position> expectedPositions)
        {
            foreach (var expectedPosition in expectedPositions)
            {
                Position position = expectedPosition;
                moves.Should().Contain(m => m.Tile.Color == tileColor && m.Tile.Insect == insect && m.To.Equals(position));
            }
        }
    }
}
