using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace HiveEngine.Tests.Unit
{
    [TestFixture]
    public class TurnOrderingTests
    {
        [Test]
        public void white_plays_first()
        {
            var gameState = CreateGameStateForTurn(0);

            gameState.PlayerToPlay.Should().Be(TileColor.White);
        }

        [Test]
        public void black_plays_second()
        {
            var gameState = CreateGameStateForTurn(1);

            gameState.PlayerToPlay.Should().Be(TileColor.Black);
        }

        [Test]
        public void white_plays_third()
        {
            var gameState = CreateGameStateForTurn(2);

            gameState.PlayerToPlay.Should().Be(TileColor.White);
        }

        public GameState CreateGameStateForTurn(int turnNumber)
        {
            return new GameState(new Grid(0, 0), turnNumber, Enumerable.Empty<Tile>(), Enumerable.Empty<Tile>());
        }
    }
}