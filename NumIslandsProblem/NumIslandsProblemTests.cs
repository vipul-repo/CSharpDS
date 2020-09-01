using Xunit;
using CSharpDS;

namespace CSharpDSTests
{
    public class NumIslandsProblemTests
    {
        private NumIslandsProblem tSub;

        public NumIslandsProblemTests()
        {
            tSub = new NumIslandsProblem();
        }

        [Fact]
        public void NumIslandsTest1()
        {
            //Given
            char[][] grid = {
                new char[]{'1','1','1','1','0'},
                new char[]{'1','1','0','1','0'},
                new char[]{'1','1','0','0','0'},
                new char[]{'0','0','0','0','0'}
            };

            //When
            var expected = 1;
            var actual = tSub.NumIslands(grid);

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NumIslandsTest2()
        {
            //Given
            char[][] grid = {
                new char[]{'1','1','0','0','0'},
                new char[]{'1','1','0','0','0'},
                new char[]{'0','0','1','0','0'},
                new char[]{'0','0','0','1','1'}
            };

            //When
            var expected = 3;
            var actual = tSub.NumIslands(grid);

            //Then
            Assert.Equal(expected, actual);
        }

    }
}