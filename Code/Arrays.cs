using System;
using System.Collections.Generic;

namespace Competitive
{
    public class Arrays
    {
        //partial sum on array
        //whats the sum between x & y.
        public static List<int> PartialSumsOnArray(List<KeyValuePair<int, int>> queries, int[] array)
        {
            //Precompute the sums
            int[] sumsArray = new int[array.Length];
            sumsArray[0] = array[0];
            for (int i = 1; i < sumsArray.Length; i++)
                sumsArray[i] = sumsArray[i - 1] + array[i];
            //Solve the querys
            List<int> ret = new List<int>();
            foreach (var kv in queries){
                ret.Add(sumsArray[kv.Value] - sumsArray[kv.Key - 1]);
            }
            return ret;
        }
        public static int[] RangeUpdate(int[] array, int x, int y, int val)
        {
            //update every value between x & y and after every update compute the array
            int[] b = new int[array.Length+1];
            b[x] += val;
            b[y + 1] -= val; //max limit?
            int[] sumsArray = new int[array.Length+1];
            int[] updatedArray = new int[array.Length+1];
            //after every update is made, we update the real array.
            for (int i = 1; i < array.Length+1; i++)
            {
                sumsArray[i] = sumsArray[i - 1] + b[i];
                array[i] += array[i];
            }
            return array;
        }
        private static void FrequencyArray()
        {
            //Works with small numbers, otherwise use Dictionary/HashSet
            //How many times X is found in an array.
            //How many distinct elements are in an array.
            //counts the time and element appears in an array O(n)
        }
        public static long MaximumSumSubarray_Greedy(int[] a)
        {
            //Finds the subarray whos sum its the biggest
            //BF O(n^3) or O(n^2)
            //Greedy Approach O(n)            
            int left = 0;
            int right = 0;
            int ans = 0;
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
                if (sum > ans)
                {
                    right = i;
                    ans = sum;
                }
                //without negative numbers, the max sum subarray will always be from 0 to a.Length
                if (sum < 0)
                {
                    left = i + 1;
                    sum = 0;
                }
            }
            // System.Console.WriteLine($"MaxSum:{ans}-Left:{left}|Right:{right}");
            return ans;
        }
        public static long MaximumSumSubarray_PartialSums(int[] a)
        {
            //BF O(n^3) or O(n^2)
            //O(2*n) --> (n)
            //Create the partial sums array
            if (a.Length == 0) return 0;

            int[] sums = new int[a.Length];
            sums[0] = a[0];
            for (int i = 1; i < sums.Length; i++)
            {
                sums[i] = a[i] + sums[i - 1];
            }
            int left = 0;
            int right = 0;
            int ans = a[0];
            int minS = 0;
            //iterate it and keep track of the minimum sum value
            for (int i = 0; i < a.Length; i++)
            {
                if (sums[i] - minS > ans)
                {
                    right = i;
                    ans = sums[i] - minS;
                }
                if (sums[i] < minS)
                {
                    left = i + 1;
                    minS = sums[i];
                }
            }
            // System.Console.WriteLine($"MaxSum:{ans}-Left:{left}|Right:{right}");
            return ans;
        }
        public static long LongestConsecutiveNumbersSubArray(int[] a)
        {
            //All elements in subarray should be distinct
            //The subarray should contain every element in the range. 
            //X,X+1,X+2,...X+N should appear
            //Max - Min + 1 = Right - Left + 1
            int l = a.Length;
            int lIx = 0;
            int rIx = 0;
            int ans = 0;
            int ansLIx = 0;
            int ansRIx = 0;
            for (lIx = 0; lIx < l; lIx++)
            {
                HashSet<int> hash = new HashSet<int>();
                int min = a[lIx];
                int max = a[lIx];
                for (rIx = lIx; rIx < l; rIx++)
                {
                    if (hash.Contains(a[rIx])) //repeated element
                        break;
                    hash.Add(a[rIx]);
                    min = Math.Min(min, a[rIx]);
                    max = Math.Max(max, a[rIx]);
                    if (rIx - lIx == max - min)
                    {
                        if (ans < rIx - lIx + 1)
                        {
                            ans = rIx - lIx + 1;
                            ansLIx = lIx;
                            ansRIx = rIx;
                        }
                    }
                }
            }
            // System.Console.WriteLine($"{ans}-Left:{ansLIx}-Right:{ansRIx}");
            return ans;
        }

        public static int SlidingWindow(int[] a, int maxAmmountOfNumberPerSubArray)
        {
            //Optimal Subarray
            //Max Cost / Min Cost and so on
            //Ammount of subarrays.
            //Find the longest subarray with most distinct elements.
            int l = a.Length;
            Dictionary<int, int> freqArray = new Dictionary<int, int>();
            int ret = 0;
            int counter = 0; //ammount of unique elements in the subarray
            int leftIx = 0;
            int rightIx = 0;
            //goes to the right UNTIL
            //runs out of elements or the subarray between 0 and rightIx becomes invalid.
            for(int i = 0; i < l; i++)
                if(!freqArray.ContainsKey(a[i]))
                    freqArray.Add(a[i],0);
            for (rightIx = 0; rightIx < l; rightIx++)
            {
                int v = a[rightIx];
                freqArray[v]++;
                if (freqArray[v] == 1)
                {
                    counter++;
                }
                //found the required ammount of elements in the subarray.
                if (counter > maxAmmountOfNumberPerSubArray)
                {
                    break;
                }
            }
            //if the subarray is valid, return it     
            if (counter <= maxAmmountOfNumberPerSubArray)
                return l;
            //otherwise, decrease the rightIX
            //meaning the frequency & the pointer
            freqArray[a[rightIx]]--;            
            //if the element is no longer in the freq
            //decrease the ammount of unique numbers in the subarray.
            if (freqArray[a[rightIx]] == 0)
                counter--;
            rightIx--;
            ret = rightIx;
            //start sliding the left ix
            for (leftIx = 1; leftIx < l; leftIx++)
            {
                //remove the value from left -1 from the freq
                freqArray[a[leftIx - 1]]--;
                //if its no longer in the subarray decrease the counter
                if (freqArray[a[leftIx - 1]] == 0)
                    counter--;
                //slide the rightIx until
                //there are no more places to go or the subarray becomes invalid
                while (++rightIx < l) //had to do it here to avoid out of bound ixs
                {
                    freqArray[a[rightIx]]++;
                    //add the new value from a[rix] to the freq & 
                    //if its 1, add increase the counter, if its more than one, we dont care since we're looking for unique items
                    if (freqArray[a[rightIx]] == 1)
                        counter++;
                    //the subarray now becomes invalid                        
                    if (counter > maxAmmountOfNumberPerSubArray)
                        break;
                }
                //the subarray is valid
                if (counter <= maxAmmountOfNumberPerSubArray)
                    return Math.Max(ret, l - leftIx + 1);
                //the subarray is not valid
                //decrease the value from freq pointing to the element on the rightIx                
                freqArray[a[rightIx]]--;                
                //if its 0, then the ammount of unique subelements in the subarray is reduced by 1
                if (freqArray[a[rightIx]] == 0)
                    counter--;
                //decrease rightIX, to evaluate once again.
                rightIx--;
                ret = Math.Max(ret, rightIx - leftIx + 1);
            }
            return ret;
        }      
    }
}