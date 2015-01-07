using System.Linq;
using FluentAssertions;
using HiveEngine.Tests.Unit.Extensions;
using HiveEngine.Tests.Unit.Utilities;
using NUnit.Framework;

namespace HiveEngine.Tests.Unit
{
    [TestFixture]
    class InitialMoveTests
    {
        private GameEngine _gameEngine;

        [SetUp]
        public void SetUp()
        {
            _gameEngine = new GameEngine();
        }

        [Test]
        public void at_start_of_game_and_with_only_one_tile_white_has_one_valid_move()
        {
            var grid = GridResourceParser.ParseGrid("empty");

            var whiteTilesToPlay = new[] { new Tile(TileColor.White, Insect.Queen) };
            var gameState = new GameState(grid, 0, whiteTilesToPlay, Enumerable.Empty<Tile>());

            var validMoves = _gameEngine.FindValidMoves(gameState);

            validMoves.Single().Tile.Color.Should().Be(TileColor.White);
            validMoves.Single().Tile.Insect.Should().Be(Insect.Queen);
            validMoves.Single().To.Should().Be(new Position(0, 0));
        }

        [Test]
        public void at_start_of_game_and_with_two_tiles_user_white_two_valid_moves()
        {
            var grid = GridResourceParser.ParseGrid("empty");
            var whiteTilesToPlay = new[] { new Tile(TileColor.White, Insect.Queen), new Tile(TileColor.White, Insect.Ant) };
            var gameState = new GameState(grid, 0, whiteTilesToPlay, Enumerable.Empty<Tile>());

            var validMoves = _gameEngine.FindValidMoves(gameState);

            validMoves.Count().Should().Be(2);

            var onlyValidPosition = new[] { new Position(0, 0) };
            validMoves.ShouldContainMovingTileToPositions(TileColor.White, Insect.Queen, onlyValidPosition);
            validMoves.ShouldContainMovingTileToPositions(TileColor.White, Insect.Ant, onlyValidPosition);
        }

        [Test]
        public void if_black_has_only_one_tile_they_have_correct_initial_valid_moves()
        {
            var grid = GridResourceParser.ParseGrid("single-white-queen");

            var blackTilesToPlay = new[] { new Tile(TileColor.Black, Insect.Queen) };
            var gameState = new GameState(grid, 1, Enumerable.Empty<Tile>(), blackTilesToPlay);

            var validMoves = _gameEngine.FindValidMoves(gameState);

            validMoves.Count().Should().Be(6);
            validMoves.ShouldContainMovingTileToPositions(TileColor.Black, Insect.Queen, new[]
            {
                new Position(1, 0),
                new Position(0, 1),
                new Position(2, 1),
                new Position(0, 3),
                new Position(1, 4),
                new Position(2, 3)
            });
        }

        [Test]
        public void if_black_has_two_tiles_tile_they_have_correct_initial_valid_moves()
        {
            var grid = GridResourceParser.ParseGrid("single-white-queen");

            var blackTilesToPlay = new[]
            {
                new Tile(TileColor.Black, Insect.Queen),
                new Tile(TileColor.Black, Insect.Ant)
            };
            var gameState = new GameState(grid, 1, Enumerable.Empty<Tile>(), blackTilesToPlay);

            var validMoves = _gameEngine.FindValidMoves(gameState);

            validMoves.Count().Should().Be(12);

            var validMovePositions = new[]
            {
                new Position(1, 0),
                new Position(0, 1),
                new Position(2, 1),
                new Position(0, 3),
                new Position(1, 4),
                new Position(2, 3)
            };

            validMoves.ShouldContainMovingTileToPositions(TileColor.Black, Insect.Queen, validMovePositions);
            validMoves.ShouldContainMovingTileToPositions(TileColor.Black, Insect.Ant, validMovePositions);

        }
    }
}
