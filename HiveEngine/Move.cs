using System;

namespace HiveEngine
{
    public class Move
    {
        public Move(string tileId, Position to)
        {
            if (string.IsNullOrWhiteSpace(tileId)) throw new ArgumentNullException("tileId");
            if (to == null) throw new ArgumentNullException("to");

            TileId = tileId;
            To = to;
        }

        public string TileId { get; private set; }
        public Position To { get; private set; }
    }
}