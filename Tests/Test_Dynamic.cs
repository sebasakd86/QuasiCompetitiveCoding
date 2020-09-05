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

        [Fact]
        public void LongestCommonSubsequence()
        {
            Assert.Equal(0, Dynamic.LongestCommonSubsequence(new int[] { }, new int[] { }));
            Assert.Equal(0, Dynamic.LongestCommonSubsequence(new int[] { }, new int[] { 1 }));
            Assert.Equal(0, Dynamic.LongestCommonSubsequence(new int[] { 1 }, new int[] { }));
            Assert.Equal(1, Dynamic.LongestCommonSubsequence(new int[] { 1 }, new int[] { 1 }));
            Assert.Equal(0, Dynamic.LongestCommonSubsequence(new int[] { 1 }, new int[] { 0 }));
            Assert.Equal(1, Dynamic.LongestCommonSubsequence(new int[] { 1 }, new int[] { 1, 2, 3 }));
            Assert.Equal(1, Dynamic.LongestCommonSubsequence(new int[] { 3 }, new int[] { 1, 2, 3 }));
            Assert.Equal(2, Dynamic.LongestCommonSubsequence(new int[] { 1, 3 }, new int[] { 1, 2, 3 }));
            Assert.Equal(4, Dynamic.LongestCommonSubsequence(new int[] { 3, 1, 2, 4, 5 }, new int[] { 1, 2, 4, 3, 2, 5 }));
            Assert.Equal(3, Dynamic.LongestCommonSubsequence(new int[] { 1, 7, 1, 8, 3, 6, 5, 9 }, new int[] { 7, 3, 9, 8 }));
        }
    }
}