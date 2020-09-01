using CSharpDS;
using System.Collections.Generic;
using Xunit;

namespace CSharpDSTests
{
    public class PromotionWinnerProblemTests
    {
        PromotionWinnerProblem tSub;

        public PromotionWinnerProblemTests()
        {
            tSub = new PromotionWinnerProblem();
        }

        [Fact]
        public void IsWinnerTest1()
        {
            //Given
            var codeList = new List<List<string>> {
                new List<string>{"apple", "apple"},
                new List<string>{"banana", "anything", "banana"}
             };

            var shoppingCart = new List<string>
            {
                "orange", "apple", "apple", "banana", "orange", "banana"
            };

            //When
            var expected = 1;
            var actual = tSub.IsWinner(codeList, shoppingCart);

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsWinnerTest2()
        {
            //Given
            var codeList = new List<List<string>> {
                new List<string>{"apple", "apple"},
                new List<string>{"banana", "anything", "banana"}
             };

            var shoppingCart = new List<string>
            {
                "banana", "orange", "banana", "apple", "apple"
            };

            //When
            var expected = 0;
            var actual = tSub.IsWinner(codeList, shoppingCart);

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsWinnerTest3()
        {
            //Given
            var codeList = new List<List<string>> {
                new List<string>{"apple", "apple"},
                new List<string>{"banana", "anything", "banana"}
             };

            var shoppingCart = new List<string>
            {
                "apple", "banana", "apple", "banana", "orange", "banana"
            };

            //When
            var expected = 0;
            var actual = tSub.IsWinner(codeList, shoppingCart);

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsWinnerTest4()
        {
            //Given
            var codeList = new List<List<string>> {
                new List<string>{"apple", "apple"},
                new List<string>{"apple", "apple", "banana"}
             };

            var shoppingCart = new List<string>
            {
                "apple", "apple", "apple", "banana"
            };

            //When
            var expected = 0;
            var actual = tSub.IsWinner(codeList, shoppingCart);

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsWinnerTest5()
        {
            //Given
            var codeList = new List<List<string>> {
                new List<string>{"apple", "apple", "banana"}
             };

            var shoppingCart = new List<string>
            {
                "apple", "apple", "apple", "apple", "apple", "apple", "banana"
            };

            //When
            var expected = 1;
            var actual = tSub.IsWinner(codeList, shoppingCart);

            //Then
            Assert.Equal(expected, actual);
        }

    }
}