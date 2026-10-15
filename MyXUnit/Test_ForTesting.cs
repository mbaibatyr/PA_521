using Xunit;
using System;
using System.Collections.Generic;

namespace MyXUnit
{
    public class Test_ForTesting
    {
        private readonly ForTesting test = new ForTesting();

        [Fact]
        public void GetSum_ReturnsCorrectSum()
        {
            int a = 2;
            int b = 3;
            int expected = 5;
            var fact = test.GetSum(a, b);
            Assert.Equal(expected, fact);
            Assert.True(expected == fact);            
        }


        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(0, 0, 0)]
        [InlineData(-2, -3, -5)]
        [InlineData(-5, 10, 5)]
        [InlineData(100, 200, 300)]
        public void GetSum_ReturnsCorrectSum2(int a, int b, int expected)
        {
            var result = test.GetSum(a, b);
            Assert.Equal(expected, result);
        }
    }
}