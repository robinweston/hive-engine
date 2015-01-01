using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HiveEngine
{
    public class GridParser
    {
        public Grid ParseGrid(string gridText)
        {
            var tiles = new List<Tile>();

            var tileMatches = Regex.Matches(gridText, "[A-Za-z]");

            var gridLines = gridText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var gridWidth = CalculateGridWidth(gridLines);
            var gridHeight = CalculateGridHeight(gridLines);

            var grid = new Grid(gridWidth, gridHeight);

            for (var lineNumber = 0; lineNumber < gridLines.Length; lineNumber++)
            {
                var line = gridLines[lineNumber];
                var lineMatches = Regex.Matches(gridText, "[A-Za-z]");
                foreach (Match lineMatch in lineMatches)
                {
                    var matchIndex = lineMatch.Index;
                }

            }

            foreach (Match match in tileMatches)
            {
                var tileColor = Regex.Match(match.Value, "[A-Z]").Success ? TileColor.Black : TileColor.White;
                var tile = new Tile(tileColor);

                tiles.Add(tile);

                //grid.TileAt[50, 50] = tile;
            }

            grid.Tiles = tiles;

            return grid;
        }

        private static int CalculateGridWidth(string[] gridLines)
        {
            if (gridLines.Any() == false)
            {
                // special case for empty board
                return 1;
            }

            const int HorizontalCharsPerTile = 5;
            var longestLineLength = gridLines.Max(l => l.Length);
            var tilesInLongestLine = (longestLineLength + 1) / HorizontalCharsPerTile;

            // add 2 to allow playing to the left or right of existing tiles
            return tilesInLongestLine + 2;
        }

        private static int CalculateGridHeight(string[] gridLines)
        {
            if (gridLines.Any() == false)
            {
                // special case for empty board
                return 1;
            }

            const int VerticalCharsPerTile = 3;
            var tilesInHighestColumn = (gridLines.Length + 1) / VerticalCharsPerTile;

            // add 2 to allow playing above or below existing tiles
            return tilesInHighestColumn + 2;
        }
    }
}