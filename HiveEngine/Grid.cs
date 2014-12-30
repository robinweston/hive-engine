using System.Collections.Generic;

namespace HiveEngine
{
    public class Grid
    {
        const int GridSize = 100;

        public Grid()
        {
            Tiles = new List<Tile>();
            TileAt = new Tile[GridSize, GridSize];

            FileWithEmptyTiles();
        }

        private void FileWithEmptyTiles()
        {
            for (var x = 0; x < TileAt.GetLength(0); x++)
            {
                for (var y = 0; y < TileAt.GetLength(1); y++)
                {
                    TileAt[x, y] = Tile.None;
                }
            }
        }

        public IEnumerable<Tile> Tiles { get; internal set; }

        public Tile[,] TileAt { get; private set; }
    }
}