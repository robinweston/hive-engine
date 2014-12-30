using System.Collections.Generic;

namespace HiveEngine
{
    public class Grid
    {
        public Grid()
        {
            Tiles = new List<Tile>();
        }

        public IEnumerable<Tile> Tiles { get; set; }
    }
}