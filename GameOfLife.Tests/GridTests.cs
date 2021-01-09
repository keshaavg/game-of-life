using GameOfLife.Domain;
using System.Linq;
using Xunit;

namespace GameOfLife.Tests
{
    public class GridTests
    {
        [Fact]
        public void WhenGridRunsGenaration2_GetExpectedResult()
        {
            var gen1 = new string[]
                {
                    "........",
                    "....*...",
                    "...**...",
                    "........"
                };

            var gen2 = new Grid().NextGeneration(gen1, 4, 8);
            Assert.True(gen2.Count() == 4);
            Assert.Equal("........", gen2[0]);
            Assert.Equal("...**...", gen2[1]);
            Assert.Equal("...**...", gen2[2]);
            Assert.Equal("........", gen2[3]);
        }

        [Fact]
        public void WhenGridRunsGenaration2WithEdgeCase1_GetExpectedResult()
        {
            var gen1 = new string[]
                {
                    "*......*",
                    "....*...",
                    "...**...",
                    "*......*"
                };

            var gen2 = new Grid().NextGeneration(gen1, 4, 8);
            Assert.True(gen2.Count() == 4);
            Assert.Equal("........", gen2[0]);
            Assert.Equal("...**...", gen2[1]);
            Assert.Equal("...**...", gen2[2]);
            Assert.Equal("........", gen2[3]);
        }

        [Fact]
        public void WhenGridRunsGenaration2WithEdgeCase2_GetExpectedResult()
        {
            var gen1 = new string[]
                {
                    "........",
                    "..***...",
                    "...**...",
                    "........"
                };

            var gen2 = new Grid().NextGeneration(gen1, 4, 8);
            Assert.True(gen2.Count() == 4);
            Assert.Equal("...**...", gen2[0]);
            Assert.Equal("..*.....", gen2[1]);
            Assert.Equal("...*....", gen2[2]);
            Assert.Equal("........", gen2[3]);
        }
    }
}
