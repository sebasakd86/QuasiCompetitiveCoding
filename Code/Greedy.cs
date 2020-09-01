using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Competitive.Code
{
    public class Greedy
    {
        /*
            Given a Knapsack of capacity G, and X items with weight W and values V,
            fill the sack with the max value possible.
            Items can be splitted in parts.
        */
        public static double Knapsack(int g, int[,] items)
        {
            int itemCount = items.GetLength(0);
            double ret = 0;
            if (itemCount == 0)
                return 0;
            if (itemCount == 1)
            {
                while (g > 0)
                {
                    ret += items[0, 0] / items[0, 1];
                    g--;
                }
                return ret;
            }
            MaxHeap<double> mh = new MaxHeap<double>();

            for (int i = 0; i < itemCount; i++)
            {
                double valuePerWeight = (double)items[i, 0] / items[i, 1];
                while (items[i, 1]-- > 0)
                {
                    mh.Insert(valuePerWeight);
                }
            }
            while (g > 0 && !mh.IsEmpty())
            {
                double x = mh.RemoveTop();
                ret += x;
                g--;
            }
            return ret;
        }

        /*
            Given N activities with start & end times, get the max number of activities
            that can be performed by a person, knowing a person can only perform 1 activity at a time.
        */
        public static int ActivitySelection(List<Activity> activities)
        {
            if (activities.Count < 2)
                return activities.Count;
            // *Sort activities by end time, so I can get the one that end sooners (thus maximizing the ammount of activities to perform)
            activities.Sort();
            int ret = 0;
            int currentTime = 0;
            var currentActivity = activities.FirstOrDefault(a => a.Start >= currentTime);
            // * As long as an activity that starts after the current time exists, 
            // * get the first one (since they're sorted, it will always be the one that ends first)                
            // * could iterate through the array instead of using FirstOrDefault
            while (currentActivity != null)
            {
                ret++;
                currentTime = currentActivity.End;
                currentActivity = activities.FirstOrDefault(a => a.Start >= currentTime);
            }
            return ret;
        }

        /*
            Given arrivals & departures from several trains, find the min number of platforms needed to avoid waiting trains.
        */
        public static int MinimumNumberOfPlatforms(List<ScheduleActivity> schedule)
        {
            if (schedule.Count < 2)
                return schedule.Count;
            // * Using a MinHeap, I can always get the minimun time value (prioritizing departures over arrivals at the same time)
            // * alongside it's operation (Arrival or Departure)
            var realSchedule = new MaxHeap<ScheduleNode>();
            foreach (var t in schedule)
            {
                realSchedule.Insert(new ScheduleNode(t.Start * -1, true));
                realSchedule.Insert(new ScheduleNode(t.End * -1, false));
            }
            int ret = 0;
            int remainingPlatforms = 0;
            // * Whenever a train arrives, if there're remaining platforms, use them
            // * Otherwise, you need a new platform.
            // * When a train departs, the you've got a new remaining platform to use.
            while (!realSchedule.IsEmpty())
            {
                var s = realSchedule.RemoveTop();
                if (s.Arriving)
                {
                    if (remainingPlatforms > 0)
                        remainingPlatforms--;
                    else
                        ret++;
                }
                else
                    remainingPlatforms++;
            }
            return ret;
        }
    }
}