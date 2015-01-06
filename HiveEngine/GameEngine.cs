using System.Collections.Generic;

namespace HiveEngine
{
    public class GameEngine
    {
        public IEnumerable<Move> ComputeValidMoves()
        {
            var move = new Move("queen", new Position(0, 0));

            return new[]
            {
                move
            };
        }
    }
}