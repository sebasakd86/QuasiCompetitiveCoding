using System;
using System.Collections.Generic;
using Competitive.Code;
using Xunit;

namespace Competitive.Tests
{
    public class Test_DivideAndConquer
    {
        [Theory]
        [MemberData(nameof(MergeSort_TestData))]
        public void MergeSort(int[] arrayToSort)
        {
            int[] sortedResult = new int[arrayToSort.Length];
            arrayToSort.CopyTo(sortedResult, 0);
            Array.Sort(sortedResult);
            arrayToSort = Code.DivideAndConquer.MergeSort(arrayToSort);
            bool res = true;
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                if (arrayToSort[i] != sortedResult[i])
                {
                    res = false;
                    break;
                }
            }
            Assert.True(res);
        }
        public static IEnumerable<object[]> MergeSort_TestData()
        {
            yield return new object[] { new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 11, 12, 13, 21, 23, 34 } };
            yield return new object[] { new int[] { 10, -1, 20, -10, 30, -4, 0, -2 } };
        }

        [Theory]
        [MemberData(nameof(MaximumSumSubArray_TestData))]
        public void MaximumSumSubArray(int expectedResult, int[] array)
        {
            Assert.Equal(expectedResult, DivideAndConquer.MaximumSumSubArray(array));
        }
        public static IEnumerable<object[]> MaximumSumSubArray_TestData()
        {
            yield return new object[] { 8, new int[] { 2, -6, 5, -2, 4, 1, -3 } };
            yield return new object[] { 8, new int[] { 5, -6, 3, 4, -2, 3, -3 } };
            yield return new object[] { 0, new int[] { -1, -6, -4, -2, -3, 0, -3 } };
            yield return new object[] { 5, new int[] { -1, -6, -4, -2, -3, 5, -3 } };
        }

        [Theory]
        [MemberData(nameof(ZTraversalTestData))]
        public void ZTraversal(int expected, int dimensions, int x, int y)
        {
            Assert.Equal(expected, DivideAndConquer.ZTraversal(dimensions,x,y));
        }

        public static TheoryData<int, int, int, int> ZTraversalTestData
        {
            get
            {
                var data = new TheoryData<int, int, int, int>();
                data.Add(14, 2, 3, 4);
                data.Add(1, 1, 1, 1);
                data.Add(2, 1, 1, 2);
                data.Add(3, 1, 2, 1);
                data.Add(4, 1, 2, 2);
                return data;
            }
        }
    }
}