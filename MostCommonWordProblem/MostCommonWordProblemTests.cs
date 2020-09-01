using Xunit;
using CSharpDS;

namespace CSharpDSTests
{
    public class MostCommonWordProblemTests
    {
        private MostCommonWordProblem tSub;

        public MostCommonWordProblemTests()
        {
            tSub = new MostCommonWordProblem();
        }

        [Fact]
        public void UniqueSubstringTest1()
        {
            //Given
            var paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            var banned = new string[] { "hit" };

            //When
            var expected = "ball";
            var actual = tSub.MostCommonWord(paragraph, banned);

            //Then
            Assert.Equal(expected, actual);
        }
    }
}