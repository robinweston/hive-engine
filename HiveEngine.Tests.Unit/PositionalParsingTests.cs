using FluentAssertions;

using NUnit.Framework;

namespace HiveEngine.Tests.Unit
{
    [TestFixture]
    class PositionalParsingTests
    {
        [Test]
        public void grid_is_created_100_by_100()
        {
            var grid = new Grid();

            grid.TileAt.GetLength(0).Should().Be(100);
            grid.TileAt.GetLength(1).Should().Be(100);
        }

        [Test]
        public void new_grid_contains_no_tiles()
        {
            var grid = new Grid();

            for (var x = 0; x < grid.TileAt.GetLength(0); x++)
            {
                for (var y = 0; y < grid.TileAt.GetLength(1); y++)
                {
                    grid.TileAt[x, y].Should().Be(Tile.None);
                }
            }
        }

        [Test]
        public void single_tile_is_at_position_50_50()
        {
            var grid = GridResourceParser.ParseGrid("single-white-queen");

            grid.TileAt[50, 50].Should().NotBe(Tile.None);
        }
    }
}
