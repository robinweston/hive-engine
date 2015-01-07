using System;
using System.Collections.Generic;
using System.Linq;
using HiveEngine.Extensions;

namespace HiveEngine
{
    public class GameEngine
    {
        public IEnumerable<Move> FindValidMoves(GameState gameState)
        {
            if(gameState == null)throw new ArgumentNullException("gameState");

            if (gameState.TurnNumber == 0)
            {
                foreach (var tile in gameState.WhiteTilesToPlay)
                {
                    yield return new Move(tile, new Position(0, 0));
                }
            }
            else
            {
                foreach(var adjacentPosition in FindAdjacentPositions(new Position(1, 2)))
                {
                    yield return new Move(new Tile(TileColor.Black, Insect.Queen), adjacentPosition);
                }
            }
        }

        private IEnumerable<Position> FindAdjacentPositions(Position position)
        {
            // above
            yield return new Position(position.X, position.Y - 2);
            // above left
            yield return new Position(position.X - 1, position.Y - 1);
            // above right
            yield return new Position(position.X + 1, position.Y - 1);
            // below left
            yield return new Position(position.X - 1, position.Y + 1);
            // below right
            yield return new Position(position.X + 1, position.Y + 1);
            // below
            yield return new Position(position.X, position.Y + 2);
        }
    }
}