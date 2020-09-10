using CSharpDS;
using System.Collections.Generic;
using Xunit;

namespace CSharpDSTests
{
    public class TrieTests
    {
        Trie tSub;

        public TrieTests()
        {
            tSub = new Trie();

            List<string> words = new List<string>
            {
                "wordtest",
                "wordtest1",
                "wordtest3",
                "testword"
            };

            foreach (var word in words)
                tSub.Insert(word);
        }

        [Fact]
        public void SearchTest()
        {
            //Given
            List<string> words = new List<string>
            {
                "wordtest",
                "wordtestne",
                "wordtest1",
                "wordtest3",
                "ne",
                "testword",
                "testwordne"
            };

            //When
            var expected = new List<bool> {
                true,
                false,
                true,
                true,
                false,
                true,
                false
            };

            var actual = new List<bool>();

            foreach (var word in words)
                actual.Add(tSub.Search(word));


            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DeleteTest()
        {
            //Given
            List<string> words = new List<string>
            {
                "wordtest",
                "wordtest1",
                "wordtest3",
                "testword"
            };

            List<string> deleteWords = new List<string>
            {
                "wordtest",
                "wordtest1",
                "testword"
            };

            //When
            var expected = new List<bool> {
                false,
                false,
                true,
                false
            };

            foreach (var word in deleteWords)
                tSub.Delete(word);

            var actual = new List<bool>();

            foreach (var word in words)
                actual.Add(tSub.Search(word));


            //Then
            Assert.Equal(expected, actual);
        }
    }
}