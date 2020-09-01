using Xunit;
using CSharpDS;

namespace CSharpDSTests
{
    public class DistinctCharacterSubstringProblemTests
    {
        private DistinctCharacterSubstringProblem tSub;

        public DistinctCharacterSubstringProblemTests()
        {
            tSub = new DistinctCharacterSubstringProblem();
        }

        [Fact]
        public void UniqueSubstringTest1()
        {
            //Given
            var s = "abcabc";
            var k = 3;

            //When
            var expected = new string[] { "abc", "bca", "cab" };
            var actual = tSub.UniqueSubstring(s, k);

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UniqueSubstringTest2()
        {
            //Given
            var s = "abacab";
            var k = 3;

            //When
            string[] expected = { "bac", "cab" };
            var actual = tSub.UniqueSubstring(s, k);

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UniqueSubstringTest3()
        {
            //Given
            var s = "awaglknagawunagwkwagl";
            var k = 4;

            //When
            string[] expected = { "wagl", "aglk", "glkn", "lkna", "knag", "gawu", "awun", "wuna", "unag", "nagw", "agwk", "kwag" };
            var actual = tSub.UniqueSubstring(s, k);

            //Then
            Assert.Equal(expected, actual);
        }
    }
}