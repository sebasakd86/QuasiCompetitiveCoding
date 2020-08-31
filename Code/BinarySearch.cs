using System;
using System.Collections.Generic;
using System.Linq;

namespace Competitive
{
    public class BinarySearch
    {
        public static int Search(int[] array, int v)
        {
            int leftIx = 0;
            int rightIx = array.Length;
            if (array[rightIx - 1] < v) //greater than the last element
                return -1;
            if (array[0] > v) //smaller than the first element
                return -1;
            int middleIx = (leftIx + rightIx) / 2;
            // Console.WriteLine($"--> {v}");
            if (array[middleIx] == v)
                return middleIx;
            while (leftIx <= rightIx)
            {
                // System.Console.WriteLine($"{leftIx}-{middleIx}-{rightIx}");
                if (array[middleIx] == v)
                    return middleIx;
                if (array[middleIx] < v)
                    leftIx = middleIx + 1;
                else if (array[middleIx] > v)
                    rightIx = middleIx - 1;
                middleIx = (leftIx + rightIx) / 2;
            }
            if (array[middleIx] == v)
                return middleIx;
            return -1;
        }

        public static int MinimumCapacityTransport(int[] boxes, int ammountOfTrucks)
        {
            // Console.WriteLine("TEST");
            int max = boxes.Max();
            int rightIx = boxes.Sum();
            int leftIx = max;
            int res = 0;
            //instead of going from leftIx --> rightIx, i try the values in the middle
            //trying to reduce the ammount of tries we do.
            while (leftIx <= rightIx)
            {
                int middleIx = (leftIx + rightIx) / 2;
                // System.Console.WriteLine($"{middleIx}");
                int result = GetAmmountOfTrucks(boxes, middleIx);
                if (result > ammountOfTrucks)
                    leftIx = middleIx + 1;
                else
                {
                    res = middleIx;
                    rightIx = middleIx - 1;
                }
            }
            return res;
        }
        public static int MaximumNumberOfGroups(int[] ammountOfThings, int typeOfThingsPerGroup)
        {
            int leftIx = 0;
            int rightIx = ammountOfThings.Sum() / typeOfThingsPerGroup;
            int ret = 0;
            while (leftIx <= rightIx)
            {
                int middle = (leftIx + rightIx) / 2;
                if(isGroupValid(ammountOfThings, typeOfThingsPerGroup, middle)){
                    ret = middle;
                    leftIx = middle + 1;
                }
                else
                    rightIx = middle - 1;                
            }
            return ret;
        }

        public static int MaximumSpecialDistance(int[,] points)
        {
            int leftDistance = 0;            
            int maxDistance = 0;
            var sortedPointList = sortPoinsByX(points);
            int rightDistance = Math.Max(sortedPointList.Last().Key, sortedPointList.Max(kv => kv.Value));
            // Console.WriteLine($"XXXX");
            // foreach(var kv in sortedPointList)
            //     Console.WriteLine($"{kv.Key}-{kv.Value}");

            while(leftDistance <= rightDistance){
                int middleDistance = (leftDistance + rightDistance) / 2;
                if(isMaxDistance(sortedPointList, middleDistance)){
                    maxDistance = middleDistance;
                    leftDistance = middleDistance + 1;
                }
                else
                    rightDistance = middleDistance - 1;
            }
            return maxDistance;
        }
        private static List<KeyValuePair<int,int>> sortPoinsByX(int[,] points)
        {
            List<KeyValuePair<int,int>> p = new List<KeyValuePair<int, int>>();
            for(int i = 0; i < points.GetLength(0); i++){
                p.Add(new KeyValuePair<int, int>(points[i,0],points[i,1]));
            }
            return p.OrderBy(pt => pt.Key).ToList();
        }

        private static bool isMaxDistance(List<KeyValuePair<int,int>> points, int middleDistance)
        {
            int p = -1;
            int minY = Int32.MaxValue;
            int maxY = Int32.MinValue;
            for(int i = 0; i < points.Count; i++){
                while(p + 1 < i && (points[i].Key - points[p+1].Key >= middleDistance) ){ //found a pair where Xp - Xi >= distance
                    p++;
                    minY = Math.Min(minY, points[p].Value);
                    maxY = Math.Max(maxY, points[p].Value);
                }
                //p is the ammount of points that might satisfy the condition to the distance
                //since I've to find the Max value between the min values of Xi-Xj >= Dist && Yi - Yj >= Dist
                //I know up to this point that Xj (p) meet the first requirement.
                //Is there some other point whose distance - the distance from the actual point >= Dist
                //I need only to check for the max & min value so far, since the other values won't matter on an Abs rest.
                if(p != -1 && (Math.Abs(minY - points[i].Value) >= middleDistance))
                    return true;
                if(p != -1 && (Math.Abs(maxY - points[i].Value) >= middleDistance))
                    return true;
            }
            return false;
        }

        private static bool isGroupValid(int[] ammountOfThings, int typeOfThingsPerGroup, int ammountOfGroups){
            int count = 0;
            for (int i = 0; i < ammountOfThings.Length; i++)
            {
                count += Math.Min(ammountOfGroups, ammountOfThings[i]);
            }
            return count >= typeOfThingsPerGroup * ammountOfGroups;
        }
        public static int MaximumNumberOfGroups_MyWay(int[] ammountOfThings, int typeOfThingsPerGroup)
        {
            /*
                my way -- this works, the time complexity is O(m * n), i dont really know if its smaller than O(n * log n), dont think so, but doesnt require aditional analisis                
                I'm getting the minimun ammount of groups, but cant find by hand the last case.
            */
            int l = ammountOfThings.Length;
            int ret = 0;
            int availableThings = l;
            while (availableThings >= typeOfThingsPerGroup)
            {
                int distinctTypes = 0;
                for (int i = l - 1; i >= 0; i--)
                {
                    if (ammountOfThings[i] > 0)
                    {
                        ammountOfThings[i]--;
                        distinctTypes++;
                    }
                    else
                        availableThings--;
                    if (distinctTypes == typeOfThingsPerGroup)
                        break;
                }
                ret++;
            }
            return ret;
        }
        private static int GetAmmountOfTrucks(int[] boxes, int truckCapacity)
        {
            int capacity = truckCapacity;
            int l = boxes.Length;
            int trucks = 0;
            for (int i = 0; i < l; i++)
            {
                if (boxes[i] <= capacity)
                {
                    capacity -= boxes[i];
                }
                else
                {
                    capacity = truckCapacity - boxes[i];
                    trucks++;
                }
            }
            return trucks + ((capacity > 0) ? 1 : 0);
        }
    }
}