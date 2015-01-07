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
            if (gameState == null) throw new ArgumentNullException("gameState");

            if (gameState.TurnNumber == 0)
            {
                foreach (var tile in gameState.WhiteTilesToPlay)
                {
                    yield return new Move(tile, new Position(0, 0));
                }
            }
            else if (gameState.TurnNumber == 1)
            {
                foreach (var adjacentPosition in FindAdjacentPositions(new Position(1, 2)))
                {
                    foreach (var tile in gameState.BlackTilesToPlay)
                    {
                        yield return new Move(tile, adjacentPosition);
                    }
                }
            }
            else
            {
                var positionsAdjacentToCurrentPlayer = new List<Position>();
                var positionsAdjacentToOpposition = new List<Position>();
                var emptyPositions = new List<Position>();

                for (var x = 0; x < gameState.Grid.Tiles.GetLength(0); x++)
                {
                    for (var y = 0; y < gameState.Grid.Tiles.GetLength(1); y++)
                    {
                        var position = new Position(x, y);
                        var tile = gameState.Grid.Tiles[x, y];
                        if (tile.Color == TileColor.None)
                        {
                            emptyPositions.Add(position);
                        }
                        else
                        {
                            var adjacentPositions = FindAdjacentPositions(position);
                            if (tile.Color == gameState.PlayerToPlay)
                            {
                                positionsAdjacentToCurrentPlayer.AddRange(adjacentPositions);
                            }
                            else
                            {
                                positionsAdjacentToOpposition.AddRange(adjacentPositions);
                            }
                        }
                    }
                }

                var playablePositions = positionsAdjacentToCurrentPlayer.Intersect(emptyPositions).Except(positionsAdjacentToOpposition);
                var currentPlayerTiles = gameState.PlayerToPlay == TileColor.White
                    ? gameState.WhiteTilesToPlay
                    : gameState.BlackTilesToPlay;
                foreach (var position in playablePositions)
                {
                    foreach (var tile in currentPlayerTiles)
                    {
                        yield return new Move(tile, position);
                    }
                }
            }
        }

        private static IEnumerable<Position> FindAdjacentPositions(Position position)
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