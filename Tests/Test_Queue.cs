using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace Competitive.Tests
{
    public class Test_Queue
    {
        [Theory]
        [ClassData(typeof(FindShortestPathTestData))]
        public void FindShortestPath(FindShortestPathTestData test)
        {
            Assert.Equal(test.Expected, Code.Queue.FindShortestPath(test.Maze, test.Source, test.Destination));
        }
    }
    public class FindShortestPathTestData : TheoryData<FindShortestPathTestData>
    {
        private static int[,] maze1 = new int[,]{
                {1,1,1,1},
                {1,0,1,1},
                {1,1,1,0},
                {0,0,0,1}
            };
        public int Expected { get; set; }
        public int[,] Maze { get; set; }
        public KeyValuePair<int, int> Source { get; set; }
        public KeyValuePair<int, int> Destination { get; set; }
        public FindShortestPathTestData()
        {
            Add(new FindShortestPathTestData(-1, new int[,] { { 0 } }, new KeyValuePair<int, int>(0, 0), new KeyValuePair<int, int>(0, 0)));
            Add(new FindShortestPathTestData(0, new int[,] { { 1 } }, new KeyValuePair<int, int>(0, 0), new KeyValuePair<int, int>(0, 0)));
            Add(new FindShortestPathTestData(1, new int[,] { { 1, 1 } }, new KeyValuePair<int, int>(0, 0), new KeyValuePair<int, int>(0, 1)));
            Add(new FindShortestPathTestData(3, maze1, new KeyValuePair<int, int>(0, 0), new KeyValuePair<int, int>(0, 3)));
            Add(new FindShortestPathTestData(4, maze1, new KeyValuePair<int, int>(0, 0), new KeyValuePair<int, int>(2, 2)));
            Add(new FindShortestPathTestData(-1, maze1, new KeyValuePair<int, int>(3, 3), new KeyValuePair<int, int>(2, 2)));
            Add(new FindShortestPathTestData(3, maze1, new KeyValuePair<int, int>(2, 0), new KeyValuePair<int, int>(1, 2)));

        }
        public FindShortestPathTestData(int expected, int[,] maze, KeyValuePair<int, int> source, KeyValuePair<int, int> destination)
        {
            this.Expected = expected;
            this.Maze = maze;
            this.Source = source;
            this.Destination = destination;
        }
    }
}