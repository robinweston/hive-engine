﻿using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace HiveEngine.Tests.Unit
{
    [TestFixture]
    class ValidMoveTests
    {
        [Test]
        public void at_start_of_game_and_with_only_one_tile_white_has_one_valid_move()
        {
            var grid = GridResourceParser.ParseGrid("empty");
            var gameEngine = new GameEngine();

            var whiteTilesToPlay = new[] { new Tile(TileColor.White, Insect.Queen) };
            var gameState = new GameState(grid, 0, whiteTilesToPlay, Enumerable.Empty<Tile>());

            var validMoves = gameEngine.FindValidMoves(gameState);

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

            var gameEngine = new GameEngine();

            var validMoves = gameEngine.FindValidMoves(gameState);

            validMoves.Should().Contain(m => m.Tile.Color == TileColor.White && m.Tile.Insect == Insect.Queen && m.To.Equals(new Position(0, 0)));
            validMoves.Should().Contain(m => m.Tile.Color == TileColor.White && m.Tile.Insect == Insect.Ant && m.To.Equals(new Position(0, 0)));
        }
    }
}
