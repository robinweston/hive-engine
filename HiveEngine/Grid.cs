using System.Collections.Generic;

namespace HiveEngine
{
    public class Grid
    {


        public Grid()
        {
            Tiles = new List<Tile>();
            TileAt = new Tile[26, 26];
        }

        public IEnumerable<Tile> Tiles { get; set; }

        public Tile[,] TileAt { get; set; }
    }
}