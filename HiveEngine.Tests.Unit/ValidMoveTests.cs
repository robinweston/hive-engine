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
            var gameEngine = new GameEngine();

            var validMoves = gameEngine.ComputeValidMoves();

            validMoves.Single().TileId.Should().Be("queen");
            validMoves.Single().To.Should().Be(new Position(0, 0));
        }
    }
}
