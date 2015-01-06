using System;
using System.Collections.Generic;

namespace HiveEngine
{
    public class GameState
    {
        public GameState(Grid grid, TileColor playerToPlay, IEnumerable<Tile> tilesToPlay)
        {
            if(grid == null)throw new ArgumentNullException("grid");
            if (playerToPlay == TileColor.None) throw new ArgumentException("playerToPlay");
            if(tilesToPlay == null)throw new ArgumentNullException("tilesToPlay");

            Grid = grid;
            PlayerToPlay = playerToPlay;
            TilesToPlay = tilesToPlay;
        }

        public Grid Grid { get; private set; }

        public TileColor PlayerToPlay { get; private set; }

        public IEnumerable<Tile> TilesToPlay { get; private set; }
    }
}