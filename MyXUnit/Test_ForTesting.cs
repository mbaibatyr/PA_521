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
            var result = test.GetSum(a, b);
            Assert.Equal(expected, result);
        }
    }
}