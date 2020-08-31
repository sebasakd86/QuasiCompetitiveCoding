using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Competitive.Tests
{
    public class Test_Recursion
    {
        [Theory]
        [ClassData(typeof(FillAlgorithm_TestData))]
        public void Test_FillAlgorithm(int expectedIslands, int expectedMaxSize, int[,] map)
        {
            Assert.Equal($"Islands:{expectedIslands}-MaxSize:{expectedMaxSize}", Code.Recursion.FillAlgorithm(map));
        }
    }
    //Using a class to pass the test data.
    //When data is complex, this should be the default way.
    public class FillAlgorithm_TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {0,0,
                new int[3,3]{
                    {0,0,0},
                    {0,0,0},
                    {0,0,0}
                }
            };
            yield return new object[] {1,9,
                new int[3,3]{
                    {1,1,1},
                    {1,1,1},
                    {1,1,1}
                }
            };
            yield return new object[] {1,4,
                new int[3,3]{
                    {0,1,0},
                    {0,1,0},
                    {1,1,0}
                }
            };
            yield return new object[] {4,8,
            new int[5,6]{
                {1,0,1,0,0,1},
                {0,1,1,0,1,1},
                {0,1,0,1,1,0},
                {0,1,1,0,0,1},
                {1,1,0,1,1,1}
            }
        };
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}