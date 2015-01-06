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

            grid.Tiles.AsEnumerable().PlacedOnly().Count().Should().Be(0);
        }

        [Test]
        public void single_white_queen_tile_parses_correctly()
        {
            var grid = GridResourceParser.ParseGrid("single-white-queen");

            grid.Tiles.AsEnumerable().PlacedOnly().Single().Color.Should().Be(TileColor.White);
            grid.Tiles.AsEnumerable().PlacedOnly().Single().Insect.Should().Be(Insect.Queen);
        }

        [Test]
        public void single_black_queen_tile_parses_correctly()
        {
            var grid = GridResourceParser.ParseGrid("single-black-queen");

            grid.Tiles.AsEnumerable().PlacedOnly().Single().Color.Should().Be(TileColor.Black);
        }

        [Test]
        public void black_and_white_queen_parse_correctly()
        {
            var grid = GridResourceParser.ParseGrid("two-queens-horizontal");

            grid.Tiles.AsEnumerable().PlacedOnly().ElementAt(0).Color.Should().Be(TileColor.White);
            grid.Tiles.AsEnumerable().PlacedOnly().ElementAt(1).Color.Should().Be(TileColor.Black);
        }

        [Test]
        [TestCase("two-queens-horizontal")]
        [TestCase("two-queens-vertical")]
        public void two_tile_grids_parse_correctly(string gridName)
        {
            var grid = GridResourceParser.ParseGrid(gridName);

            grid.Tiles.AsEnumerable().PlacedOnly().Count().Should().Be(2);
        }
    }
}
