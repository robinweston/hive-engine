using System.Linq;
using FluentAssertions;
using HiveEngine.Tests.Unit.Extensions;
using HiveEngine.Tests.Unit.Utilities;
using NUnit.Framework;

namespace HiveEngine.Tests.Unit
{
    [TestFixture]
    class SecondMoveTests
    {
        [Test]
        public void white_second_turns_with_one_available_tile_has_correct_valid_moves_available()
        {
            var grid = GridResourceParser.ParseGrid("two-queens-horizontal");

            var whiteTilesToPlay = new[] { new Tile(TileColor.White, Insect.Ant) };
            var gameState = new GameState(grid, 2, whiteTilesToPlay, Enumerable.Empty<Tile>());

            var gameEngine = new GameEngine();
            var validMoves = gameEngine.FindValidMoves(gameState);

            validMoves.Count().Should().Be(3);

            validMoves.ShouldContainMovingTileToPositions(TileColor.White, Insect.Ant, new[]
            {
                new Position(1, 0), 
                new Position(0, 1), 
                new Position(0, 3), 
            });
        }

        [Test]
        public void black_second_turns_with_two_available_tiles_has_correct_valid_moves_available()
        {
            var grid = GridResourceParser.ParseGrid("two-queens-and-a-white-spider");

            var blackTilesToPlay = new[]
            {
                new Tile(TileColor.Black, Insect.Ant), 
                new Tile(TileColor.Black, Insect.Spider)
            };
            var gameState = new GameState(grid, 3, Enumerable.Empty<Tile>(), blackTilesToPlay);

            var gameEngine = new GameEngine();
            var validMoves = gameEngine.FindValidMoves(gameState);

            validMoves.Count().Should().Be(6);

            var validPositions = new[]
            {
                new Position(4, 2),
                new Position(4, 4),
                new Position(3, 5),
            };

            validMoves.ShouldContainMovingTileToPositions(TileColor.Black, Insect.Ant, validPositions);
            validMoves.ShouldContainMovingTileToPositions(TileColor.Black, Insect.Spider, validPositions);
        }
    }
}