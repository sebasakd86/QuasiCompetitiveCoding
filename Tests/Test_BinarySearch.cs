using System.Collections.Generic;
using Xunit;

namespace Competitive.Tests
{
    public class Test_BinarySearch
    {
        private int[] sortedArray = new int[] { 3, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41 };
        [Theory]
        [InlineData(7)]
        [InlineData(29)]
        [InlineData(41)]
        public void Test_BinarySearch_Passing(int value)
        {
            Assert.InRange(BinarySearch.Search(sortedArray, value), 0, sortedArray.Length);
        }
        [Theory]
        [InlineData(2)]
        [InlineData(8)]
        [InlineData(35)]
        [InlineData(50)]
        public void Test_BinarySearch_Fail(int value)
        {
            Assert.Equal(-1, BinarySearch.Search(sortedArray, value));
        }
        [Theory]
        [MemberData(nameof(MinimumCapacityTransport_TestData))]
        public void Test_MinimumCapacityTransport_3_Passing(int expected, int ammountOfTrucks, int[] boxes)
        {
            Assert.Equal(expected, BinarySearch.MinimumCapacityTransport(boxes, ammountOfTrucks));
        }
        private static int[] boxes = new int[] { 5, 3, 7, 2, 4, 9, 6 };
        public static IEnumerable<object[]> MinimumCapacityTransport_TestData()
        {
            yield return new object[] { 21, 3, new int[] { 7, 5, 8, 10, 9, 4, 9, 8 } };
            yield return new object[] { 13, 4, boxes };
            yield return new object[] { 15, 3, boxes };
        }

        [Theory]
        [MemberData(nameof(MaximumNumberOfGroups_TestData))]
        public void Test_MaximumNumberOfGroups(int expected, int typeOfThingsPerGroup, int[] ammountOfThings)
        {
            Assert.Equal(expected, BinarySearch.MaximumNumberOfGroups(ammountOfThings, typeOfThingsPerGroup));
        }
        public static IEnumerable<object[]> MaximumNumberOfGroups_TestData()
        {
            yield return new object[] { 5, 3, new int[] { 1, 2, 3, 4, 100 } };
            yield return new object[] { 10, 3, new int[] { 2, 4, 6, 8, 10 } };
            yield return new object[] { 5, 5, new int[] { 1, 2, 3, 4, 5, 6, 7 } };
        }
        [Theory]
        [MemberData(nameof(MaximumSpecialDistance_TestData))]
        public void Test_MaximumSpecialDistance(int expected, int[,] points)
        {
            Assert.Equal(expected, BinarySearch.MaximumSpecialDistance(points));
        }
        public static IEnumerable<object[]> MaximumSpecialDistance_TestData()
        {
            yield return new object[] { 5, new int[4, 2] { { 0, 0 }, { 1, 1 }, { 5, 1 }, { 5, 5 } } };
            yield return new object[] { 3, new int[5, 2] { { 1, 3 }, { 2, 1 }, { 3, 2 }, { 5, 4 }, { 4, 0 } } };
        }
    }
}