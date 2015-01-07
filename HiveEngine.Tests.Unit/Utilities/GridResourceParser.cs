using System.IO;

namespace HiveEngine.Tests.Unit.Utilities
{
    public static class GridResourceParser
    {
        public static Grid ParseGrid(string gridName)
        {
            var gridParser = new GridParser();

            var fileName = gridName + ".txt";
            var gridText = ParseFile(fileName);

            return gridParser.ParseGrid(gridText);
        }

        private static string ParseFile(string fileName)
        {
            var assembly = typeof(GridSizingTests).Assembly;
            var resourceName = "HiveEngine.Tests.Unit.Grids." + fileName;

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
