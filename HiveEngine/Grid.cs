using System.Collections.Generic;

namespace HiveEngine
{
    public class Grid
    {
        public Grid(int width, int height)
        {
            Tiles = new Tile[width, height];

            FileWithEmptyTiles();
        }

        private void FileWithEmptyTiles()
        {
            for (var x = 0; x < Tiles.GetLength(0); x++)
            {
                for (var y = 0; y < Tiles.GetLength(1); y++)
                {
                    Tiles[x, y] = Tile.None;
                }
            }
        }

        public Tile[,] Tiles { get; private set; }
    }
}