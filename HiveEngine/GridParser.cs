using System.Collections.Generic;
using System.Linq;

using HiveEngine.Extensions;

namespace HiveEngine
{
    public class GridParser
    {
        public Grid ParseGrid(string gridText)
        {
            var tiles = new List<Tile>();

            var forwardSlashIndexes = gridText.GetAllIndexes("/");

            for (var i = 0; i < forwardSlashIndexes.Count() / 2; i++)
            {
                tiles.Add(new Tile());
            }

            return new Grid { Tiles = tiles };
        }
    }
}