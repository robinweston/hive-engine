using System.Collections.Generic;

namespace HiveEngine.Tests.Unit
{
    public static class GridExtensions
    {
        public static IEnumerable<Tile> AllPlaced(this Tile[,] tileGrid)
        {
            for (var x = 0; x < tileGrid.GetLength(0); x++)
            {
                for (var y = 0; y < tileGrid.GetLength(1); y++)
                {
                    var tile = tileGrid[x, y];
                    if (tile != Tile.None)
                    {
                        yield return tile;
                    }
                }
            }
        }
    }
}
