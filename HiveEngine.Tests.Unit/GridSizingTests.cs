﻿using FluentAssertions;

using NUnit.Framework;

namespace HiveEngine.Tests.Unit
{
    [TestFixture]
    class GridSizingTests
    {
        [Test]
        [TestCase("empty", 1, 1)]
        [TestCase("single-black-queen", 3, 3)]
        [TestCase("two-queens-horizontal", 4, 4)]
        public void grids_are_sized_correctly(string gridName, int expectedWidth, int expectedHeight)
        {
            var grid = GridResourceParser.ParseGrid(gridName);

            grid.TileAt.GetLength(0).Should().Be(expectedWidth);
            grid.TileAt.GetLength(1).Should().Be(expectedHeight);
        }
    }
}
