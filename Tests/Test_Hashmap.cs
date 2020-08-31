using System.Linq;
using Xunit;

namespace Competitive.Tests
{
    public class Test_Hashmap
    {
        [Theory]
        [MemberData(nameof(NumberOfPaisTestData))]
        public void Test_NumberOfPais(int expected, int[] a, int s)
        {
            Assert.Equal(expected, Code.HashMap.NumberOfPais(a, s));
        }

        public static TheoryData<int, int[], int> NumberOfPaisTestData
        {
            get
            {
                var d = new TheoryData<int, int[], int>();
                d.Add(0, new int[] { 0 }, 1);
                d.Add(1, new int[] { 1, 1 }, 2);
                d.Add(3, new int[] { 1, 1, 1 }, 2);
                d.Add(6, new int[] { 3, -2, 9, 3, -2, 4, 9 }, 7);
                return d;
            }
        }

        [Theory]
        [MemberData(nameof(IWonTheLottoTestData))]
        public void Test_IWonTheLotto(int expected, int[] arr)
        {
            int[] result = Code.HashMap.IWonTheLotto(arr, expected);
            Assert.Equal(6, result.Length); //Should be 6 items in the array.
            Assert.Equal(expected, result.Sum()); //They should sum the expected value.
        }

        public static TheoryData<int, int[]> IWonTheLottoTestData
        {
            get
            {
                var d = new TheoryData<int, int[]>();
                d.Add(21, new int[] { 3, 7, 2, -1, -10 });
                d.Add(10, new int[] { 1,2,3,4,5,6 });
                d.Add(15, new int[] { 1,2,3,4,5,6 });
                return d;
            }
        }
    }
}