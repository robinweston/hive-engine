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
                    var tileX = ((lineMatch.Index - 2) / 4) + 1;
                    var tileY = lineNumber + 1;

                    var tile = new Tile(lineMatch.Value);

                    grid.Tiles[tileX, tileY] = tile;
                }

            }

            return grid;
        }

        private static Grid CreateGrid(string[] gridLines)
        {
            var gridWidth = CalculateGridWidth(gridLines);
            var gridHeight = CalculateGridHeight(gridLines);

            var grid = new Grid(gridWidth, gridHeight);
            return grid;
        }

        private static int CalculateGridWidth(string[] gridLines)
        {
            var longestGridLine = gridLines.Any() ? gridLines.Max(gl => gl.Length) : 0;

            switch (longestGridLine)
            {
                case 0:
                    return 1;
                default:
                    return (longestGridLine + 7) / 4;
            }
        }

        private static int CalculateGridHeight(IEnumerable<string> gridLines)
        {
            var gridLinesCount = gridLines.Count();

            switch (gridLinesCount)
            {
                case 0:
                    return 1;
                case 3:
                    return 3;
                default:
                    return gridLinesCount + 2;

            }
        }
    }
}