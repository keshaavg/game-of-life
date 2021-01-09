using GameOfLife.Domain;
using System;
using Xunit;

namespace GameOfLife
{
    public class CellTest
    {
        [Theory]
        [InlineData('a')]
        [InlineData('@')]
        public void Throws_ArgumentOutOfRangeException_ForInvalidValues(char cellStatus)
        {
            // Arrange + Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Cell(cellStatus));
        }

        [Theory]
        [InlineData('.', '*')]
        [InlineData('.')]
        [InlineData('.', '.', '.')]
        public void WhenActiveCellHas_LessThanTwoNeighbours_CellDies(params char[] neighbours)
        {
            var sut = new Cell('*');
            var result = sut.Evaluate(neighbours);
            Assert.Equal('.', result);
        }

        [Theory]
        [InlineData('.', '*', '*', '*', '*')]
        [InlineData('.', '*', '*', '*', '*', '*')]
        public void WhenActiveCellHas_MoreThanThreeNeighbours_CellDies(params char[] neighbours)
        {
            var sut = new Cell('*');
            var result = sut.Evaluate(neighbours);
            Assert.Equal('.', result);
        }

        [Theory]
        [InlineData('.', '*', '*')]
        [InlineData('.', '*', '*', '*')]
        public void WhenActiveCellHas_TwoOrThreeNeighbours_RemainsActive(params char[] neighbours)
        {
            var sut = new Cell('*');
            var result = sut.Evaluate(neighbours);
            Assert.Equal('*', result);
        }

        [Theory]
        [InlineData('.', '*', '*', '*')]
        public void WhenDeadCellHas_ExactlyThreeNeighbours_BecomesActive(params char[] neighbours)
        {

            var sut = new Cell('.');
            var result = sut.Evaluate(neighbours);
            Assert.Equal('*', result);
        }
    }
}
