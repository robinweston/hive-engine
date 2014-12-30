using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using FluentAssertions;

using NUnit.Framework;

namespace HiveEngine.Tests.Unit
{
    [TestFixture]
    public class ParsingTests
    {
        [Test]
        public void empty_file_parses_to_empty_grid()
        {
            var gridText = ParseFile("empty.txt");

            var gridParser = new GridParser();
            var grid = gridParser.ParseGrid(gridText);

            grid.Tiles.Count().Should().Be(0);
        }

        private static string ParseFile(string fileName)
        {
            var assembly = typeof(ParsingTests).Assembly;
            var resourceName = "HiveEngine.Tests.Unit.Grids." + fileName;

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }

    public class GridParser
    {
        public Grid ParseGrid(string gridText)
        {
            return new Grid();
        }
    }

    public class Grid
    {
        public Grid()
        {
            Tiles = new List<Tile>();
        }

        public IEnumerable<Tile> Tiles { get; set; }
    }

    public class Tile
    {
    }
}
