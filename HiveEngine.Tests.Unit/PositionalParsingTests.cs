using FluentAssertions;

using NUnit.Framework;

namespace HiveEngine.Tests.Unit
{
    [TestFixture]
    class PositionalParsingTests
    {
        [Test]
        public void grid_is_26_by_26()
        {
            var grid = new Grid();

            grid.TileAt.GetLength(0).Should().Be(26);
            grid.TileAt.GetLength(1).Should().Be(26);
        }

        [Test, Ignore]
        public void single_tile_is_at_0_0()
        {
            var grid = GridResourceParser.ParseGrid("single-tile");

            grid.TileAt[0, 0].Should().NotBe(Tile.None);
        }
    }
}
