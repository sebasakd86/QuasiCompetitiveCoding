using Xunit;
using Competitive;

namespace Competitive.Tests
{
    public class Test_Greedy
    {
        [Fact]
        public void Knapsack()
        {
            Assert.Equal(3, Competitive.Code.Greedy.Knapsack(1, new int[,]{{6,2}}));
            Assert.Equal(6, Competitive.Code.Greedy.Knapsack(2, new int[,]{{6,2}}));
            Assert.Equal(3, Competitive.Code.Greedy.Knapsack(1, new int[,]{{10,5},{3,1}}));
            Assert.Equal(43, Competitive.Code.Greedy.Knapsack(10, new int[,]{{10,2},{5,3},{15,5},{7,7},{6,1},{18,4},{3,1}}));
        }
    }
}