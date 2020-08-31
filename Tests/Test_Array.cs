using System.Collections.Generic;
using Xunit;
using Competitive;
namespace Competitive.Tests
{
    public class Test_Array
    {
        public static IEnumerable<object[]> PartialSumsOnArray_TestData()
        {
            yield return new object[] {
                new List<KeyValuePair<int, int>>(){
                    new KeyValuePair<int, int>(1,3),
                    new KeyValuePair<int, int>(3,6),
                    new KeyValuePair<int, int>(4,8),
                    new KeyValuePair<int, int>(2,6),
                    new KeyValuePair<int, int>(2,10)
                },
                new int[] { 5, 24, 21, 18, 35 },
                new int[] { 1, 2, -6, 9, 4, 5, 6, -1, 7, 8, 3, -2 }
            }; 
        }
        
        [Theory]
        [MemberData(nameof(PartialSumsOnArray_TestData))]
        public void Test_PartialSumsOnArray_Passing(List<KeyValuePair<int, int>> queries, int[] queryResult, int[] arr)
        {
            int ix = 0;
            bool result = true;
            foreach (var i in Arrays.PartialSumsOnArray(queries, arr))
            {
                if (queryResult[ix++] != i)
                {
                    result = false;
                    break;
                }
            }
            Assert.True(result);
        }
        [Fact]
        public void Test_MaximumSumSubarray_Greedy_Passing()
        {
            //9+4+5+6
            int[] arr = new int[] { 1, 2, -6, 9, 4, 5, 6, -20, 7, 8, 3, -2 };
            Assert.Equal(24, Arrays.MaximumSumSubarray_Greedy(arr));
        }
        [Fact]
        public void Test_MaximumSumSubArray_PartialSums_Passing()
        {
            //9+4+5+6
            int[] arr = new int[] { 1, 2, -6, 9, 4, 5, 6, -20, 7, 8, 3, -2 };
            Assert.Equal(24, Arrays.MaximumSumSubarray_PartialSums(arr));
        }
        [Fact]
        public void Test_LongestConsecutiveNumbersSubArray_Passing()
        {
            //4 -> 9 --> 4, 6, 3, 5, 7, 8 = 6
            int[] arr = new int[] { 1, 2, -6, 7, 4, 6, 3, 5, 7, 8, 3, -2 };
            Assert.Equal(6, Arrays.LongestConsecutiveNumbersSubArray(arr));
        }
        [Fact]
        public void Test_SlidingWindow_Passing()
        {
            //Will find the max length of a subarray with K unique values in it
            //1-2-7-1-2
            int[] slidingArray = new int[] { 1, 5, 2, 1, 7, 2, 5, 1, 2, 7, 1, 2, 5, 5, 7 };
            Assert.Equal(5, Arrays.SlidingWindow(slidingArray, 3));
        }
    }
}