using System;
using System.ComponentModel;

namespace HiveEngine
{
    public class Move
    {
        public Move(Tile tile, Position to)
        {
            if (tile == null) throw new ArgumentNullException("tile");
            if (to == null) throw new ArgumentNullException("to");

            Tile = tile;
            To = to;
        }

        public Position To { get; private set; }
        public Tile Tile { get; private set; }
    }
}