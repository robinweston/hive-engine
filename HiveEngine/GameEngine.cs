using System;
using System.Collections.Generic;

namespace HiveEngine
{
    public class GameEngine
    {
        public IEnumerable<Move> FindValidMoves(GameState gameState)
        {
            if(gameState == null)throw new ArgumentNullException("gameState");

            if (gameState.Grid.Tiles.GetLength(0) == 1 && gameState.Grid.Tiles.GetLength(1) == 1)
            {
                foreach (var tile in gameState.TilesToPlay)
                {
                    yield return new Move(tile, new Position(0, 0));
                }
            }           
        }
    }
}