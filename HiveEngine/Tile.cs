using System.Text.RegularExpressions;

namespace HiveEngine
{
    public class Tile
    {
        static Tile()
        {
            None = new Tile(TileColor.None, Insect.None);
        }

        public Tile(string identifier) : 
            this(ParseColor(identifier), ParseInsect(identifier))
        {
          
        }

        public Tile(TileColor color, Insect insect)
        {
            Color = color;
            Insect = insect;
        }

        public TileColor Color { get; private set; }
        public Insect Insect { get; private set; }

        public static Tile None { get; private set; }

        private static TileColor ParseColor(string identifier)
        {
            return Regex.Match(identifier, "[A-Z]").Success ? TileColor.Black : TileColor.White;
        }

        private static Insect ParseInsect(string identifier)
        {
            switch (identifier.ToLower())
            {
                case "q":
                    return Insect.Queen;
            }

            return Insect.None;
        }
    }
}