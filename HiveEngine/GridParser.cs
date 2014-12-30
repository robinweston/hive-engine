using System.Collections.Generic;

namespace HiveEngine
{
    public class GridParser
    {
        public Grid ParseGrid(string gridText)
        {
            if (gridText.Length > 0)
            {
                return new Grid { Tiles = new List<Tile> { new Tile() } };
            }
            return new Grid();
        }
    }
}