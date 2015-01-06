using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace HiveEngine.Tests.Unit
{
    [TestFixture]
    class ValidMoveTests
    {
        [Test]
        public void at_start_of_game_and_with_only_one_tile_user_only_has_one_valid_move()
        {
            var grid = GridResourceParser.ParseGrid("empty");
            var gameEngine = new GameEngine();

            var gameState = new GameState(grid, TileColor.Black, new[] { new Tile(TileColor.Black, Insect.Queen) });

            var validMoves = gameEngine.FindValidMoves(gameState);

            validMoves.Single().Tile.Color.Should().Be(TileColor.Black);
            validMoves.Single().Tile.Insect.Should().Be(Insect.Queen);
            validMoves.Single().To.Should().Be(new Position(0, 0));
        }

        [Test]
        public void at_start_of_game_and_with_two_tiles_user_has_two_valid_moves()
        {
            var grid = GridResourceParser.ParseGrid("empty");
            var blackTilesToPlay = new[] {new Tile(TileColor.Black, Insect.Queen), new Tile(TileColor.Black, Insect.Ant) };
            var gameState = new GameState(grid, TileColor.Black, blackTilesToPlay);

            var gameEngine = new GameEngine();

            var validMoves = gameEngine.FindValidMoves(gameState);

            validMoves.Should().Contain(m => m.Tile.Color == TileColor.Black && m.Tile.Insect == Insect.Queen && m.To.Equals(new Position(0,0 )));
            validMoves.Should().Contain(m => m.Tile.Color == TileColor.Black && m.Tile.Insect == Insect.Ant && m.To.Equals(new Position(0,0 )));
        }
    }
}
