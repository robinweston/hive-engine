using System;
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

                    var tile = CreateTile(lineMatch.Value);

                    grid.Tiles[tileX, tileY] = tile;
                }

            }

            return grid;
        }

        static Tile CreateTile(string tileIdentifier)
        {
            var tileColor = Regex.Match(tileIdentifier, "[A-Z]").Success ? TileColor.Black : TileColor.White;
            var insect = Insect.None;
            switch (tileIdentifier.ToLower())
            {
                case "q":
                    insect = Insect.Queen;
                    break;
            }
            return new Tile(tileColor, insect);
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
            var longestGridLine = gridLines.Any() ? gridLines.Max(gl => gl.Length) : 0;

            switch (longestGridLine)
            {
                case 0:
                    return 1;
                default:
                    return (longestGridLine + 7) / 4;
            }
        }

        private static int CalculateGridHeight(string[] gridLines)
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