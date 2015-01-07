using FluentAssertions;
using HiveEngine.Tests.Unit.Utilities;
using NUnit.Framework;

namespace HiveEngine.Tests.Unit
{
    [TestFixture]
    class GridSizingTests
    {
        [Test]
        [TestCase("empty", 1, 1)]
        [TestCase("single-black-queen", 3, 3)]
        [TestCase("two-queens-horizontal", 4, 6)]
        [TestCase("two-queens-vertical", 3, 7)]
        public void grids_are_sized_correctly(string gridName, int expectedWidth, int expectedHeight)
        {
            var grid = GridResourceParser.ParseGrid(gridName);

            grid.Tiles.GetLength(0).Should().Be(expectedWidth);
            grid.Tiles.GetLength(1).Should().Be(expectedHeight);
        }
    }
}
