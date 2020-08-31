using Xunit;

namespace Competitive.Tests
{
    public class Test_Stack
    {
        [Theory]
        [MemberData(nameof(ValidParenthesisTestData))]
        public void ValidParenthesis(bool expected, string testData)
        {
            Assert.Equal(expected, Code.Stack.IsValidParenthesis(testData));
        }
        public static TheoryData<bool, string> ValidParenthesisTestData
        {
            get
            {
                var data = new TheoryData<bool, string>();
                data.Add(true, "([]{})");
                data.Add(true, "([{}])");
                data.Add(false, "(([]{})");
                data.Add(false, "(()){");
                data.Add(false, "((((");
                data.Add(true, "{[]}");
                data.Add(false, "{(})");
                data.Add(true, "({}[()])");
                return data;
            }
        }


        [Theory]
        [MemberData(nameof(FirstGreaterElementTestData))]
        public void FirstGreaterElement(int[] expected, int[] searchArray)
        {
            bool bResult = true;
            int[] result = Code.Stack.FirstGreaterElement(searchArray);
            for (int i = 0; i < result.Length; i++)
            {
                if (expected[i] != result[i])
                {
                    bResult = false;
                }
            }
            Assert.True(bResult);
        }

        public static TheoryData<int[], int[]> FirstGreaterElementTestData
        {
            get
            {
                var data = new TheoryData<int[], int[]>();
                data.Add(new int[] { 4, 3, 3, 4, 8, 7, 7, 8, 0 }, new int[] { 7, 3, 2, 6, 11, 9, 8, 10, 13 });
                data.Add(new int[] { 0, 0, 0, 0, 0 }, new int[] { 5, 4, 3, 2, 1 });
                data.Add(new int[] { 1, 2, 3, 4, 0 }, new int[] { 1, 2, 3, 4, 5 });
                return data;
            }
        }

        [Theory]
        [MemberData(nameof(LargestRectangularAreaTestData))]
        public void LargestRectangularArea(ulong expected, int[] array)
        {
            Assert.Equal(expected, Code.Stack.LargestRectangularArea(array));
        }

        public static TheoryData<ulong, int[]> LargestRectangularAreaTestData
        {
            get
            {
                var d = new TheoryData<ulong, int[]>();
                d.Add((ulong)0, new int[] { });
                d.Add((ulong)1, new int[] { 1 });
                d.Add((ulong)4, new int[] { 2, 2 });
                d.Add((ulong)6, new int[] { 2, 2, 2 });
                d.Add((ulong)6, new int[] { 2, 5, 2 });
                d.Add((ulong)6, new int[] { 1,1,1,1,1,1 });
                d.Add((ulong)12, new int[] { 6,2,5,4,5,1,6 });
                return d;
            }
        }
        [Theory]
        [MemberData(nameof(MaximumSizeRectangleWithValueTestDate))]
        public void MaximumSizeRectangleWithValue(ulong expected, int[,] matrix, int valueToFind)
        {
            Assert.Equal(expected, Code.Stack.MaximumSizeRectangleWithValue(matrix, valueToFind));
        }

        public static TheoryData<int, int[,], int> MaximumSizeRectangleWithValueTestDate
        {
            get
            {
                var d = new TheoryData<int,int[,], int>();
                d.Add(0, new int[,]{}, 1);
                d.Add(0, new int[,]{{0}}, 1);
                d.Add(1, new int[,]{{1}}, 1);
                d.Add(0, new int[,]{{0,0}}, 1);
                d.Add(1, new int[,]{{1,0}}, 1);
                d.Add(2, new int[,]{{1,1}}, 1);
                d.Add(0, new int[,]{{0,0}, {0,0}}, 1);
                d.Add(2, new int[,]{{0,1}, {1,1}}, 1);
                d.Add(4, new int[,]{{1,1}, {1,1}}, 1);
                d.Add(8, new int[,]{{1,1,0,1,1,0,1},{1,1,1,0,1,1,1},{1,1,1,1,1,1,1},{0,1,1,1,1,0,1}}, 1);
                return d;
            }
        }
    }
}