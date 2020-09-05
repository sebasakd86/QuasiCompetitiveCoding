using Code;
using Xunit;

namespace Tests
{
    public class Test_Dynamic
    {
        [Theory]
        [MemberData(nameof(LongestIncreasingSubsequenceTestData))]
        public void LongestIncreasingSubsequence(int expected, int[] values)
        {
            Assert.Equal(expected, Dynamic.LongestIncreasingSubsequence(values));
        }
        public static TheoryData<int, int[]> LongestIncreasingSubsequenceTestData
        {
            get
            {
                var d = new TheoryData<int, int[]>();
                d.Add(0, new int[] { });
                d.Add(1, new int[] { 1 });
                d.Add(1, new int[] { 2, 1 });
                d.Add(2, new int[] { 1, 2 });
                d.Add(3, new int[] { 1, 2, 3 });
                d.Add(3, new int[] { 1, 5, 2, 3 });
                d.Add(7, new int[] { 4, 5, 1, 2, 3, 6, 7, 8, 9 });
                /*
                    4-5-6-7-8-9
                    5-6-7-8-9
                    1-2-3-6-7-8-9
                */
                d.Add(4, new int[] { 3, 9, 11, 13, 10, 12 });
                d.Add(4, new int[] { 3, 9, 7, 13, 10, 12 });
                return d;
            }
        }

        [Theory]
        [MemberData(nameof(LongestCommonSubsequenceTestData))]
        public void LongestCommonSubsequence(int expected, int[] firstArray, int[] secondArray)
        {
            Assert.Equal(expected, Dynamic.LongestCommonSubsequence(firstArray, secondArray));
        }

        public static TheoryData<int, int[], int[]> LongestCommonSubsequenceTestData
        {
            get
            {
                var d = new TheoryData<int, int[], int[]>();
                d.Add(0, new int[] { }, new int[] { });
                d.Add(0, new int[] { }, new int[] { 1 });
                d.Add(0, new int[] { 1 }, new int[] { });
                d.Add(1, new int[] { 1 }, new int[] { 1 });
                d.Add(0, new int[] { 1 }, new int[] { 0 });
                d.Add(1, new int[] { 1 }, new int[] { 1, 2, 3 });
                d.Add(1, new int[] { 3 }, new int[] { 1, 2, 3 });
                d.Add(2, new int[] { 1, 3 }, new int[] { 1, 2, 3 });
                d.Add(4, new int[] { 3, 1, 2, 4, 5 }, new int[] { 1, 2, 4, 3, 2, 5 });
                d.Add(3, new int[] { 1, 7, 1, 8, 3, 6, 5, 9 }, new int[] { 7, 3, 9, 8 });
                return d;
            }
        }
    }
}