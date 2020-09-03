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

        public static int MonsterKiller(int[] dmg, int hp, int potions)
        {
            if (dmg.Length == 0)
                return 0;
            MaxHeap<int> kills = new MaxHeap<int>();
            int i = 0;
            int l = dmg.Length;
            while (hp > 0 && i < l)
            {
                if (dmg[i] > hp)
                {
                    if (potions == 0)
                    {
                        return i;
                    }
                    else
                    {
                        potions--;
                        if (!kills.IsEmpty())
                        {
                            if (dmg[i] <= kills.Top())
                            {
                                hp += kills.RemoveTop();
                                kills.Insert(dmg[i]);
                            }
                        }
                    }
                }
                else
                {
                    hp -= dmg[i];
                    if (dmg[i] > 0)
                        kills.Insert(dmg[i]);
                }
                i++;
            }
            return i;
        }
        public static int MinimumNumberOfBoats(int[] weights, int maxW, int wDif)
        {
            int l = weights.Length;
            if (l == 0)
                return 0;
            if (l == 1)
            {
                if (weights[0] <= maxW)
                    return 1;
                return 0;
            }
            Array.Sort(weights);
            int trips = l;
            for (int i = 0; i < l; i++)
            {
                if (i + 1 >= l)
                    break;
                if (weights[i + 1] - weights[i] <= wDif)
                {
                    if (weights[i] + weights[i + 1] <= maxW)
                    {
                        i++;
                        trips--;
                    }
                }
            }
            return trips;
        }

        public static int MinimumNumberOfBoats_UdemySolution(int[] weights, int maxWeight, int weightDiff)
        {
            // * the solution provided by the instructor doesn't take edge cases into account. Had to add them by had.
            // * algo on the last if, i had to add a comparison, since the top.key && i might be the same, and if !isTaken[i]
            // * that value is never popped
            // * this solution seems overly complicated, since every solution works for every other lower solution
            int n = weights.Length;
            if (n == 0)
                return 0;
            if (n == 1)
            {
                if (weights[0] <= weightDiff)
                    return 1;
                return 0;
            }
            Array.Sort(weights);
            int ans = 0;
            int p = 0;
            List<bool> isTaken = new List<bool>(new bool[n]);
            MaxHeap<BoatKey> pq = new MaxHeap<BoatKey>();
            for (int i = n - 1; i >= 0; i--)
            {
                while (p < i && weights[p] + weights[i] <= maxWeight)
                {
                    pq.Insert(new BoatKey(p, weights[p]));
                    p++;
                }
                if (isTaken[i]) continue;

                while (!pq.IsEmpty() && weights[i] - pq.Top().Weight <= weightDiff)
                {
                    if (isTaken[pq.Top().Key] || i == pq.Top().Key)
                    {
                        pq.RemoveTop();
                        continue;
                    }
                    isTaken[i] = isTaken[pq.Top().Key] = true;
                    pq.RemoveTop();
                    break;
                }
                ans++;
            }
            return ans;
        }
    }
    class BoatKey : IComparable
    {
        public int Weight { get; }
        public int Key { get; }
        public BoatKey(int key, int weight)
        {
            this.Key = key;
            this.Weight = weight;
        }
        public int CompareTo(object obj)
        {
            return this.Weight.CompareTo(((BoatKey)obj).Weight);
        }
    }
}