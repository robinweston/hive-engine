using System;
using System.Collections.Generic;
using System.Linq;

namespace HiveEngine
{
    public class GameState
    {
        public GameState(Grid grid, int turnNumber, IEnumerable<Tile> whiteTilesToPlay, IEnumerable<Tile> blackTilesToPlay)
        {
            if (grid == null) throw new ArgumentNullException("grid");
            if (turnNumber < 0) throw new ArgumentException("turnNumber");
            if (whiteTilesToPlay == null) throw new ArgumentNullException("whiteTilesToPlay");
            if (blackTilesToPlay == null) throw new ArgumentNullException("whiteTilesToPlay");
            if(whiteTilesToPlay.Any(t => t.Color == TileColor.Black))throw new ArgumentException("Black tiles in white tile list");
            if(blackTilesToPlay.Any(t => t.Color == TileColor.White))throw new ArgumentException("White tiles in black tile list");

            Grid = grid;
            TurnNumber = turnNumber;
            WhiteTilesToPlay = whiteTilesToPlay;
            BlackTilesToPlay = blackTilesToPlay;
        }

        public int TurnNumber { get; private set; }

        public Grid Grid { get; private set; }

        public TileColor PlayerToPlay
        {
            get
            {
                return TurnNumber % 2 == 0 ? TileColor.White : TileColor.Black;
            }
        }

        public IEnumerable<Tile> WhiteTilesToPlay { get; private set; }
        public IEnumerable<Tile> BlackTilesToPlay { get; set; }
    }
}