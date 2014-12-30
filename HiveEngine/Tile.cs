namespace HiveEngine
{
    public class Tile
    {
        public Tile(TileColor color)
        {
            Color = color;
        }

        public TileColor Color { get; private set; }
    }
}