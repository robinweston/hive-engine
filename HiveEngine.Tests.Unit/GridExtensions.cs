using System.Collections.Generic;
using System.Linq;

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
    }
}
