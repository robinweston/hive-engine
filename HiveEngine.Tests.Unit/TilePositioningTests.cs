using FluentAssertions;

using NUnit.Framework;

namespace HiveEngine.Tests.Unit
{
    [TestFixture]
    class TilePositioningTests
    {

        [Test]
        public void new_grid_contains_no_tiles()
        {
            var grid = GridResourceParser.ParseGrid("empty");

            for (var x = 0; x < grid.TileAt.GetLength(0); x++)
            {
                for (var y = 0; y < grid.TileAt.GetLength(1); y++)
                {
                    grid.TileAt[x, y].Should().Be(Tile.None);
                }
            }
        }

        [Test, Ignore]
        public void single_tile_is_at_position_50_50()
        {
            var grid = GridResourceParser.ParseGrid("single-white-queen");

            grid.TileAt[50, 50].Should().NotBe(Tile.None);
        }
    }
}