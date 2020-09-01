using CSharpDS;
using System.Collections.Generic;
using Xunit;

namespace CSharpDSTests
{
    public class TopMentionedWordsProblemTests
    {
        TopMentionedWordsProblem tSub;

        public TopMentionedWordsProblemTests()
        {
            tSub = new TopMentionedWordsProblem();
        }

        [Fact]
        public void GetTopMentionedWordsTest1()
        {
            //Given
            var topNWords = 2;
            var words = new List<string> { "anacell", "cetracular", "betacellular" };
            var reviews = new List<string>{
                "Anacell provides the best services in the city",
                "betacellular has awesome services",
                "Best services provided by anacell, everyone should use anacell"
                };

            //When
            var expected = new List<string> { "anacell", "betacellular" };
            var actual = tSub.GetTopMentionedWords(topNWords, words, reviews);


            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetTopMentionedWordsTest2()
        {
            //Given
            var topNWords = 2;
            var words = new List<string> { "anacell", "betacellular", "cetracular", "deltacellular", "eurocell" };
            var reviews = new List<string>{
                "I love anacell Best services; Best services provided by anacell",
                "betacellular has great services",
                "deltacellular provides much better services than betacellular",
                "cetracular is worse than anacell",
                "Betacellular is better than deltacellular."
                };

            //When
            var expected = new List<string> { "betacellular", "anacell" };
            var actual = tSub.GetTopMentionedWords(topNWords, words, reviews);


            //Then
            Assert.Equal(expected, actual);
        }
    }
}