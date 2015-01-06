using FluentAssertions;
using NUnit.Framework;

namespace HiveEngine.Tests.Unit
{
    [TestFixture]
    class InsectTypeParsingTests
    {
        [Test]
        [TestCase("q", Insect.Queen)]
        [TestCase("a", Insect.Ant)]
        public void can_parse_insect_types_correctly(string identifier, Insect expectedType)
        {
            var tile = new Tile(identifier);

            tile.Insect.Should().Be(expectedType);
        }
    }
}
