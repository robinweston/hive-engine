using System;

namespace HiveEngine
{
    public class Position
    {
        public Position(int x, int y)
        {
            if(x < 0)throw new ArgumentOutOfRangeException("x");
            if(y < 0)throw new ArgumentOutOfRangeException("y");

            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        protected bool Equals(Position other)
        {
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X*397) ^ Y;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Position) obj);
        }
    }
}