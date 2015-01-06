using System;
using System.Collections.Generic;
using System.Linq;
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
            
            grid.Tiles.AssertAllEmptyExcept(Enumerable.Empty<Position>());
        }

        [Test]
        public void single_tile_is_at_position_1_2()
        {
            var grid = GridResourceParser.ParseGrid("single-white-queen");

            grid.Tiles[1, 2].Color.Should().Be(TileColor.White);
            grid.Tiles[1, 2].Insect.Should().Be(Insect.Queen);

            grid.Tiles.AssertAllEmptyExcept(new []
            {
                new Position(1, 2)
            });
        }

        [Test]
        public void two_horizontal_tiles_with_left_above_right_are_positioned_correctly()
        {
            var grid = GridResourceParser.ParseGrid("two-queens-horizontal");

            grid.Tiles[1, 2].Color.Should().Be(TileColor.White);
            grid.Tiles[2, 3].Color.Should().Be(TileColor.Black);

            grid.Tiles.AssertAllEmptyExcept(new []{
                new Position(1, 2),
                new Position(2, 3)
            });
        }

        [Test]
        public void two_vertical_tiles_with_left_above_right_are_positioned_correctly()
        {
            var grid = GridResourceParser.ParseGrid("two-queens-vertical");

            grid.Tiles[1, 2].Color.Should().Be(TileColor.White);
            grid.Tiles[1, 4].Color.Should().Be(TileColor.Black);

            grid.Tiles.AssertAllEmptyExcept(new []
            {
                new Position(1, 2),
                new Position(1, 4)
            });
        }
    }
}