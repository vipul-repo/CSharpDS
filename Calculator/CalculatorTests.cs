using Xunit;
using CSharpDS;

namespace CSharpDSTests
{
    public class CalculatorTests
    {
        private Calculator calculator;

        public CalculatorTests()
        {
            calculator = new Calculator();
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(1, -1, 0)]
        [InlineData(-1, -1, -2)]
        public void AddTest(int num1, int num2, int sum)
        {
            Assert.Equal(sum, calculator.Add(num1, num2));
        }
    }
}