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
        [Theory]
        [MemberData(nameof(MinimumNumberOfPlatformsTestData))]
        public void MinimumNumberOfPlatforms(int expected, List<ScheduleActivity> trainActivity)
        {
            Assert.Equal(expected, Greedy.MinimumNumberOfPlatforms(trainActivity));
        }
        public static TheoryData<int, List<ScheduleActivity>> MinimumNumberOfPlatformsTestData
        {
            get
            {
                var d = new TheoryData<int, List<ScheduleActivity>>();
                d.Add(0, new List<ScheduleActivity>());
                d.Add(1, new List<ScheduleActivity>() { new ScheduleActivity(0, 1) });
                d.Add(1, new List<ScheduleActivity>() { new ScheduleActivity(0, 1), new ScheduleActivity(1, 2), new ScheduleActivity(2, 3) });
                d.Add(4, new List<ScheduleActivity>()
                {
                    new ScheduleActivity(2,3), new ScheduleActivity(2,4), new ScheduleActivity(3,4),
                    new ScheduleActivity(3,5), new ScheduleActivity(3,4), new ScheduleActivity(5,6)
                });
                d.Add(5, new List<ScheduleActivity>()
                {
                    new ScheduleActivity(0,1), new ScheduleActivity(0,1),new ScheduleActivity(0,1),new ScheduleActivity(0,1),
                    new ScheduleActivity(1,3), new ScheduleActivity(1,3),
                    new ScheduleActivity(2,3), new ScheduleActivity(2,3),new ScheduleActivity(2,3)
                });
                d.Add(2, new List<ScheduleActivity>()
                {
                    new ScheduleActivity(0,1), new ScheduleActivity(0,2), new ScheduleActivity(1,3), new ScheduleActivity(2,4)
                });
                d.Add(2, new List<ScheduleActivity>()
                {
                    new ScheduleActivity(2,2.3),
                    new ScheduleActivity(2.10, 3.40),
                    new ScheduleActivity(3, 3.20),
                    new ScheduleActivity(3.2, 4.3),
                    new ScheduleActivity(3.5,4),
                    new ScheduleActivity(5.5,20)
                });
                return d;
            }
        }

        [Fact]
        public void MonsterKiller()
        {
            Assert.Equal(0, Greedy.MonsterKiller(new int[] { }, 10, 2));
            Assert.Equal(1, Greedy.MonsterKiller(new int[] { -1 }, 10, 2));
            Assert.Equal(0, Greedy.MonsterKiller(new int[] { 11 }, 10, 0));
            Assert.Equal(3, Greedy.MonsterKiller(new int[] { 1, 2, 3 }, 10, 0));
            Assert.Equal(2, Greedy.MonsterKiller(new int[] { 1, 2, 3 }, 5, 0));
            Assert.Equal(3, Greedy.MonsterKiller(new int[] { 1, 2, 3 }, 5, 1));
            Assert.Equal(8, Greedy.MonsterKiller(new int[] { -3, 2, 3, -2, 8, 8, 6, 4, 3, 3 }, 10, 2));
            Assert.Equal(2, Greedy.MonsterKiller(new int[] { 4, 6, 2 }, 5, 1));
        }

        [Theory]
        [MemberData(nameof(MinimumNumberOfBoatsTestData))]
        public void MinimumNumberOfBoats(int expected, int[] weights, int maxWeight, int weightDiff)
        {
            Assert.Equal(expected, Greedy.MinimumNumberOfBoats(weights, maxWeight, weightDiff));
        }

        [Theory]
        [MemberData(nameof(MinimumNumberOfBoatsTestData))]
        public void MinimumNumberOfBoats_UdemySolution(int expected, int[] weights, int maxWeight, int weightDiff)
        {
            Assert.Equal(expected, Greedy.MinimumNumberOfBoats_UdemySolution(weights, maxWeight, weightDiff));
        }
        public static TheoryData<int, int[], int, int> MinimumNumberOfBoatsTestData
        {
            get
            {
                var d = new TheoryData<int, int[], int, int>();
                d.Add(0, new int[] { }, 1, 1);
                d.Add(1, new int[] { 1 }, 1, 1);
                d.Add(0, new int[] { 5 }, 1, 1);
                d.Add(3, new int[] { 2, 6, 5, 1 }, 10, 3);
                d.Add(4, new int[] { 1, 2, 2, 2, 3, 4, 4, 4 }, 10, 3);
                d.Add(6, new int[] { 81, 37, 32, 88, 55, 93, 45, 72 }, 100, 10);
                return d;
            }
        }
    }
}