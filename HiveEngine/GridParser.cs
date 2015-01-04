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
            var gridLines = gridText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var grid = CreateGrid(gridLines);

            for (var lineNumber = 0; lineNumber < gridLines.Length; lineNumber++)
            {
                var line = gridLines[lineNumber];
                var lineMatches = Regex.Matches(line, "[A-Za-z]");
                foreach (Match lineMatch in lineMatches)
                {
                    var tileX = lineMatch.Index / 2;
                    var tileY = (lineNumber + 3) / 2;

                    var tileColor = Regex.Match(lineMatch.Value, "[A-Z]").Success ? TileColor.Black : TileColor.White;
                    var tile = new Tile(tileColor);

                    grid.Tiles[tileX, tileY] = tile;
                }

            }

            return grid;
        }

        static Grid CreateGrid(string[] gridLines)
        {
            var gridWidth = CalculateGridWidth(gridLines);
            var gridHeight = CalculateGridHeight(gridLines);

            var grid = new Grid(gridWidth, gridHeight);
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