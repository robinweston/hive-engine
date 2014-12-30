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

        [Test]
        public void single_tile_grid_parses_correctly()
        {
            var singleTileText = ParseFile("single-tile.txt");

            var gridParser = new GridParser();
            var grid = gridParser.ParseGrid(singleTileText);

            grid.Tiles.Count().Should().Be(1);
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
}
