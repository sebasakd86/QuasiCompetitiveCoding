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
            while(currentActivity != null)
            {
                ret++;
                currentTime = currentActivity.End;
                currentActivity = activities.FirstOrDefault(a => a.Start >= currentTime);
            }
            return ret;
        }
    }
    public class Activity : IComparable<Activity>
    {
        public int Start { get; }
        public int End { get; }
        public Activity(int start, int end)
        {
            if (start >= end)
                throw new ArgumentOutOfRangeException("Start is greater or equal than end");
            this.End = end;
            this.Start = start;
        }

        public int Compassare(object x, object y)
        {
            int endX = ((Activity)x).End;
            int endY = ((Activity)y).End;
            return endX.CompareTo(endY);
        }
        public int CompareTo(Activity other)
        {
            return End.CompareTo(other.End);
        }
    }
}