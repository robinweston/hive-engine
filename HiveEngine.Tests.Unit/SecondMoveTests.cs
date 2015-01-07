using System.Linq;
using FluentAssertions;
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
            validMoves.Should().Contain(m => m.Tile.Color == TileColor.White && m.Tile.Insect == Insect.Ant && m.To.Equals(new Position(1, 0)));
            validMoves.Should().Contain(m => m.Tile.Color == TileColor.White && m.Tile.Insect == Insect.Ant && m.To.Equals(new Position(0, 1)));
            validMoves.Should().Contain(m => m.Tile.Color == TileColor.White && m.Tile.Insect == Insect.Ant && m.To.Equals(new Position(0, 3)));
        }
    }
}