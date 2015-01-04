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

            for (var x = 0; x < grid.Tiles.GetLength(0); x++)
            {
                for (var y = 0; y < grid.Tiles.GetLength(1); y++)
                {
                    grid.Tiles[x, y].Should().Be(Tile.None);
                }
            }
        }

        [Test]
        public void single_tile_is_at_position_1_2()
        {
            var grid = GridResourceParser.ParseGrid("single-white-queen");

            grid.Tiles[1, 2].Color.Should().Be(TileColor.White);
        }

        [Test]
        public void spaces_exist_around_single_tile()
        {
            var grid = GridResourceParser.ParseGrid("single-white-queen");

            for (var x = 0; x < grid.Tiles.GetLength(0); x++)
            {
                for (var y = 0; y < grid.Tiles.GetLength(1); y++)
                {
                    if (x != 1 && y != 2)
                    {
                        grid.Tiles[x, y].Should().Be(Tile.None);
                    }
                }
            }
        }
    }
}