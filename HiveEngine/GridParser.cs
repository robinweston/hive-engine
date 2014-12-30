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

            foreach (var index in matches)
            {
                var tileColor = Regex.Match(gridText, "[A-Z]").Success ? TileColor.Black : TileColor.White;
                tiles.Add(new Tile(tileColor));   
            }

            return new Grid { Tiles = tiles };
        }
    }
}