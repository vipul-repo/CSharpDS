using Xunit;
using CSharpDS;
using System.Collections.Generic;

namespace CSharpDSTests
{
    public class ZombieInMatrixProblemTests
    {
        private ZombieInMatrixProblem tSub;

        public ZombieInMatrixProblemTests()
        {
            tSub = new ZombieInMatrixProblem();
        }

        [Fact]
        public void MinHoursTest()
        {
            //Given
            List<List<int>> grid = new List<List<int>>
            {
                new List<int> { 0, 1,1,0,1 },
                new List<int> { 0, 1,0,1,0 },
                new List<int> { 0, 0,0,0,1 },
                new List<int> { 0, 1,0,0,0 }
            };
            int rows = grid.Count;
            int columns = grid[0].Count;

            //When
            var expected = 2;
            var actual = tSub.MinHours(rows, columns, grid);

            //Then
            Assert.Equal(expected, actual);
        }
    }
}