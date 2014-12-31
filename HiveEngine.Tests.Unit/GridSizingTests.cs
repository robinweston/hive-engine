using FluentAssertions;

using NUnit.Framework;

namespace HiveEngine.Tests.Unit
{
    [TestFixture]
    class GridSizingTests
    {
        [Test]
        public void empty_grid_has_only_one_place_a_tile_can_go()
        {
            var grid = GridResourceParser.ParseGrid("empty");

            grid.TileAt.GetLength(0).Should().Be(1);
            grid.TileAt.GetLength(1).Should().Be(1);
        }

        [Test]
        public void grid_with_one_tile_is_large_enough_to_allow_all_possible_moves()
        {
            var grid = GridResourceParser.ParseGrid("single-black-queen");

            grid.TileAt.GetLength(0).Should().Be(3);
            grid.TileAt.GetLength(1).Should().Be(3);
        }
    }
}
