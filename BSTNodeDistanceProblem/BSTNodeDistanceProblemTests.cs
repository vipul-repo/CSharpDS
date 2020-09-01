using CSharpDS;
using Xunit;

namespace CSharpDSTests
{
    public class BSTNodeDistanceProblemTests
    {
        private BSTNodeDistanceProblem bst;
        private int[] nums;

        public BSTNodeDistanceProblemTests()
        {
            bst = new BSTNodeDistanceProblem();
            nums = new int[] { 5, 2, 1, 7, 3, 6, 4, 8, 9 };
        }

        [Theory]
        [InlineData(5, 5, 0)]
        [InlineData(4, 9, 6)]
        [InlineData(4, 1, 3)]
        [InlineData(6, 8, 2)]
        [InlineData(7, 6, 1)]
        [InlineData(60, 80, -1)]
        [InlineData(2, 25, -1)]
        public void NodeDistanceShouldMatch(int num1, int num2, int distance)
        {
            Assert.Equal(distance, bst.GetDistance(nums, num1, num2));
        }
    }
}