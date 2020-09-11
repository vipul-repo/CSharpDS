using CSharpDS;
using System.Collections.Generic;
using Xunit;

namespace CSharpDSTests
{
    public class ProductSuggestionsProblemTests
    {
        ProductSuggestionsProblem tSub;

        public ProductSuggestionsProblemTests()
        {
            tSub = new ProductSuggestionsProblem();
        }

        [Fact]
        public void GetTopMentionedWordsTest1()
        {
            //Given
            var products = new string[] {
                "mobile","mouse","moneypot","monitor","mousepad"
            };

            var searchWord = "mouse";

            //When
            var expected = new List<IList<string>>
            {
                new List<string>{"mobile","moneypot","monitor"},
                new List<string>{"mobile","moneypot","monitor"},
                new List<string>{"mouse","mousepad"},
                new List<string>{"mouse","mousepad"},
                new List<string>{"mouse","mousepad"}
            };

            var actual = tSub.SuggestedProducts(products, searchWord);

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetTopMentionedWordsTest2()
        {
            //Given
            var products = new string[] {
                "havana"
            };

            var searchWord = "havana";

            //When
            var expected = new List<IList<string>>
            {
                new List<string>{"havana"},
                new List<string>{"havana"},
                new List<string>{"havana"},
                new List<string>{"havana"},
                new List<string>{"havana"},
                new List<string>{"havana"}
            };

            var actual = tSub.SuggestedProducts(products, searchWord);

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetTopMentionedWordsTest3()
        {
            //Given
            var products = new string[] {
                "bags","baggage","banner","box","cloths"
            };

            var searchWord = "bags";

            //When
            var expected = new List<IList<string>>
            {
                new List<string>{"baggage","bags","banner"},
                new List<string>{"baggage","bags","banner"},
                new List<string>{"baggage","bags"},
                new List<string>{"bags"}
            };

            var actual = tSub.SuggestedProducts(products, searchWord);

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetTopMentionedWordsTest4()
        {
            //Given
            var products = new string[] {
                "havana"
            };

            var searchWord = "tatiana";

            //When
            var expected = new List<IList<string>>
            {
                new List<string>{},
                new List<string>{},
                new List<string>{},
                new List<string>{},
                new List<string>{},
                new List<string>{},
                new List<string>{}
            };

            var actual = tSub.SuggestedProducts(products, searchWord);

            //Then
            Assert.Equal(expected, actual);
        }
    }
}