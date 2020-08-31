using Xunit;
using Competitive.MathFundamentals;
using System.Collections.Generic;

namespace Competitive.Tests
{
    public class Test_Prime
    {
        [Theory]
        [InlineData(5)]
        [InlineData(17)]
        [InlineData(101)]
        public void IsPrime_Passing(int value)
        {
            Assert.True(Prime.IsPrime(value));
        }
        [Theory]
        [InlineData(8)]
        [InlineData(15)]
        [InlineData(100)]
        public void IsPrime_Failing(int value)
        {
            Assert.False(Prime.IsPrime(value));
        }

        [Fact]
        public void PrimeFactorizacion_Passing()
        {
            Assert.Equal("2^2 * 5^2", Prime.PrimeFactorization(100));
        }
        [Fact]
        public void PrimeFactorizacion_Failing()
        {
            Assert.NotEqual("9^1", Prime.PrimeFactorization(9));
        }

        [Fact]
        public void Seave_Passing()
        {
            bool result = true;
            //Prime numbers up to 50
            List<int> supposedResults = new List<int> {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47 };
            foreach (int r in Prime.Seave(50))
            {
                if (!supposedResults.Contains(r))
                {
                    result = false;
                    break;
                }
            }
            Assert.True(result);
        }
    }
}