namespace HiveEngine
{
    public class Tile
    {
        static Tile()
        {
            None = new Tile(TileColor.None, Insect.None);
        }

        public Tile(TileColor color, Insect insect)
        {
            Color = color;
            Insect = insect;
        }

        public TileColor Color { get; private set; }
        public Insect Insect { get; private set; }

        public static Tile None { get; private set; }
    }
}