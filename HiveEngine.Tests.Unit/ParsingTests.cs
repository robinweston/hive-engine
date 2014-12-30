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
            var grid = ParseGrid("empty");

            grid.Tiles.Count().Should().Be(0);
        }

        [Test]
        public void single_tile_grid_parses_correctly()
        {
            var grid = ParseGrid("single-tile");

            grid.Tiles.Count().Should().Be(1);
        }

        private Grid ParseGrid(string gridName)
        {
            var gridParser = new GridParser();

            var fileName = gridName + ".txt";
            var gridText = ParseFile(fileName);

            return gridParser.ParseGrid(gridText);
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
