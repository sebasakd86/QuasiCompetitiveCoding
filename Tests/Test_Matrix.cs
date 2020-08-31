using Xunit;
using Competitive;
using System.Collections.Generic;

namespace Competitive.Tests
{
    public class Test_Matrix
    {
        [Fact]
        public void Test_MaximumSumSubmatrix_Passing()
        {
            int[,] matrix = new int[4, 5]
            {
                {1,2,-1,-4,-20},
                {-8, -3, 4, 2, 1},
                {3,8,10,1,3},
                {-4,-1,1,7,-6}
            };
            Assert.Equal(29, Matrix.MaximumSumSubmatrix(matrix));
        }
        
        [Theory]
        [MemberData(nameof(MaximimSizeSquareSubmatrix_TestData))]
        public void Test_MaximumSizeSquareSubmatrixWithValue(int expected, int valueToFind, int[,] matrix)
        {
            Assert.Equal(expected, Matrix.MaximimSizeSquareSubmatrix(matrix, valueToFind));
        }

        public static IEnumerable<object[]> MaximimSizeSquareSubmatrix_TestData()
        {
            yield return new object[] {4, 5,
                new int[6,6] {
                    {1,1,1,1,1,5},
                    {1,1,0,1,1,5},
                    {0,5,5,5,5,5},
                    {1,4,5,5,5,5},
                    {1,5,5,5,5,5},
                    {1,5,5,5,5,5}
                }
            };
            yield return new object[] {3, 1,
                new int[5,5] {
                    {1,1,1,1,1},
                    {1,1,0,1,1},
                    {0,1,1,1,1},
                    {1,1,1,1,0},
                    {1,1,1,1,0}
                }
            };
            yield return new object[] {2, 1,
                new int[4, 4] {
                    {0,1,0,1},
                    {1,1,1,0},
                    {1,0,1,1},
                    {1,1,1,1}
                }
            };
        }
    }
}