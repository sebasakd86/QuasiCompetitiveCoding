using Xunit;
using Competitive;
using System.Collections.Generic;
using Competitive.Code;
using System;

namespace Competitive.Tests
{
    public class Test_Greedy
    {
        [Fact]
        public void Knapsack()
        {
            Assert.Equal(3, Greedy.Knapsack(1, new int[,] { { 6, 2 } }));
            Assert.Equal(6, Greedy.Knapsack(2, new int[,] { { 6, 2 } }));
            Assert.Equal(3, Greedy.Knapsack(1, new int[,] { { 10, 5 }, { 3, 1 } }));
            Assert.Equal(43, Greedy.Knapsack(10, new int[,] { { 10, 2 }, { 5, 3 }, { 15, 5 }, { 7, 7 }, { 6, 1 }, { 18, 4 }, { 3, 1 } }));
        }
        [Theory]
        [MemberData(nameof(ActivitySelectionTestData))]
        public void ActivitySelection(int expected, List<Activity> activities)
        {
            Assert.Equal(expected, Greedy.ActivitySelection(activities));
        }
        public static TheoryData<int, List<Activity>> ActivitySelectionTestData
        {
            get
            {
                var d = new TheoryData<int, List<Activity>>();
                d.Add(0, new List<Activity>() { });
                d.Add(1, new List<Activity>() { new Activity(1, 2) });
                d.Add(1, new List<Activity>() { new Activity(1, 2), new Activity(1, 3) });
                d.Add(2, new List<Activity>() { new Activity(1, 2), new Activity(2, 3) });
                d.Add(2, new List<Activity>() { new Activity(1, 2), new Activity(2, 3), new Activity(2, 4) });
                d.Add(2, new List<Activity>() { new Activity(1, 5), new Activity(1, 2), new Activity(2, 3), new Activity(2, 4) });
                d.Add(4, new List<Activity>() { new Activity(1, 2), new Activity(3, 4), new Activity(0, 6), new Activity(5, 7), new Activity(8, 9), new Activity(5, 9) });
                return d;
            }
        }
        [Fact]
        public void Activity_StartGreaterValue_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var a = new Activity(5, 1);
            });
        }

        [Fact]
        public void Activity_StartEqualValue_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var a = new Activity(5, 5);
            });
        }
        [Fact]
        public void Activity_CorrectValue()
        {
            int start = 5;
            int end = 10;
            var a = new Activity(start, end);
            Assert.Equal(start, a.Start);
            Assert.Equal(end, a.End);
        }

        [Fact]
        public void Activity_IsSorted()
        {
            var l = new List<Activity>()
            {
                new Activity(1,2),
                new Activity(2,3),
                new Activity(0,1)
            };
            l.Sort();
            for (int i = 0; i < l.Count; i++)
                Assert.Equal(i + 1, l[i].End);
        }
    }
}