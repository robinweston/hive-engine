namespace HiveEngine
{
    public class Tile
    {
        static Tile()
        {
            None = new Tile(TileColor.None);
        }

        public Tile(TileColor color)
        {
            Color = color;
        }

        public TileColor Color { get; private set; }

        public static Tile None { get; private set; }
    }
}