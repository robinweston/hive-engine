using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using HiveEngine.Extensions;

namespace HiveEngine.Tests.Unit.Extensions
{
    public static class TestTilesExtensions
    {
        public static void AssertAllEmptyExcept(this Tile[,] tileGrid, IEnumerable<Position> exceptionPoints)
        {
            tileGrid.ForAll((p, t) =>
            {
                if(exceptionPoints.Contains(p) == false)
                {
                    t.Should().Be(Tile.None);
                }
            });
        }
    }
}
