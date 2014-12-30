using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HiveEngine
{
    public class GridParser
    {
        public Grid ParseGrid(string gridText)
        {
            var tiles = new List<Tile>();

            var matches = Regex.Matches(gridText, "[A-Za-z]");

            var grid = new Grid();

            foreach (Match match in matches)
            {               
                var tileColor = Regex.Match(match.Value, "[A-Z]").Success ? TileColor.Black : TileColor.White;
                var tile = new Tile(tileColor);
                
                tiles.Add(tile);

                grid.TileAt[50, 50] = tile;
            }

            grid.Tiles = tiles;

            return grid;
        }
    }
}