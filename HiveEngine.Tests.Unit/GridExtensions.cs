using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace HiveEngine.Tests.Unit
{
    public static class GridExtensions
    {
        public static IEnumerable<Tile> AsEnumerable(this Tile[,] tileGrid)
        {
            for (var x = 0; x < tileGrid.GetLength(0); x++)
            {
                for (var y = 0; y < tileGrid.GetLength(1); y++)
                {
                    var tile = tileGrid[x, y];
                    yield return tile;
                }
            }
        }

        public static IEnumerable<Tile> PlacedOnly(this IEnumerable<Tile> tiles)
        {
            return tiles.Where(t => t != Tile.None);
        }

        public static void AssertAllEmptyExcept(this Tile[,] tileGrid, IEnumerable<Tuple<int, int>> exceptionPoints)
        {
            tileGrid.ForAll((x, y, t) =>
            {
                if(exceptionPoints.SingleOrDefault(p => p.Item1 == x && p.Item2 == y) == null)
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
