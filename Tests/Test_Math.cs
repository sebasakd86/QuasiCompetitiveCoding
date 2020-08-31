using Xunit;
using Competitive.MathFundamentals;

namespace Competitive.Tests
{
    public class Test_Math
    {
        [Fact]
        public void ModularExponentiation_Recursion_Passing()
        {
            Assert.Equal((ulong) 1048576, GeneralMath.FastModularExponentiation_Recursive(2,20));
        }
        [Fact]
        public void ModularExponentiation_Iterative_Passing()
        {
            Assert.Equal((ulong) 1048576, GeneralMath.FastModularExponentiation_Recursive(2,20));
        }
    }
}