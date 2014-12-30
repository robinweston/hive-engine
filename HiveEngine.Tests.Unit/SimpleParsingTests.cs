using System.Linq;

using FluentAssertions;

using NUnit.Framework;

namespace HiveEngine.Tests.Unit
{
    [TestFixture]
    public class SimpleParsingTests
    {
        [Test]
        public void empty_file_parses_to_empty_grid()
        {
            var grid = GridResourceParser.ParseGrid("empty");

            grid.Tiles.Count().Should().Be(0);
        }

        [Test]
        public void single_tile_grid_parses_correctly()
        {
            var grid = GridResourceParser.ParseGrid("single-tile");

            grid.Tiles.Count().Should().Be(1);
        }

        [Test]
        public void single_white_queen_tile_parses_correctly()
        {
            var grid = GridResourceParser.ParseGrid("single-white-queen");

            grid.Tiles.Single().Color.Should().Be(TileColor.White);
        }

        [Test]
        public void single_black_queen_tile_parses_correctly()
        {
            var grid = GridResourceParser.ParseGrid("single-black-queen");

            grid.Tiles.Single().Color.Should().Be(TileColor.Black);
        }

        [Test]
        [TestCase("two-tiles-horizontal")]
        [TestCase("two-tiles-vertical")]
        public void two_tile_grids_parse_correctly(string gridName)
        {
            var grid = GridResourceParser.ParseGrid(gridName);

            grid.Tiles.Count().Should().Be(2);
        }
    }
}
