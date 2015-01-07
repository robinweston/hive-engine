using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace HiveEngine.Tests.Unit.Extensions
{
    public static class TestTilesExtensions
    {
        public static void AssertAllEmptyExcept(this Tile[,] tileGrid, IEnumerable<Position> exceptionPoints)
        {
            tileGrid.ForAll((x, y, t) =>
            {
                if(exceptionPoints.SingleOrDefault(p => p.X == x && p.Y == y) == null)
                {
                    t.Should().Be(Tile.None);
                }
            });
        }

        public static void ForAll(this Tile[,] tileGrid, Action<int, int, Tile> action)
        {
            for (var x = 0; x < tileGrid.GetLength(0); x++)
            {
                for (var y = 0; y < tileGrid.GetLength(1); y++)
                {
                    action(x, y, tileGrid[x, y]);
                }
            }
        }
    }
}
