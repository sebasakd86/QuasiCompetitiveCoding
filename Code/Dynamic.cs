using System;
using System.Collections.Generic;
using System.Linq;

namespace Code
{
    public class Dynamic
    {
        public static int LongestIncreasingSubsequence(int[] vs)
        {
            int l = vs.Length;
            if (l < 2)
                return l;

            int[] minLast = new int[l];

            int minLastIx = 0;
            minLast[minLastIx] = vs[0];            
            for (int i = 1; i < l; i++)
            {
                if(vs[i] > minLast[minLastIx]){
                    minLast[++minLastIx] = vs[i];
                }
                else {
                    //find the ix of the value greater than vs[i].
                    //dp[i] is the value from dp[ix] --> there's no need to keep this value.
                    int ix = FindFirstGreaterValueIndex(minLast, vs[i], 0, minLastIx);
                    minLast[ix] = vs[i];                    
                }
            }
            //the longest sequence = the lenght of the minLast array
            return minLastIx + 1;
        }

        private static int FindFirstGreaterValueIndex(int[] minLast, int value, int left, int right)
        {            
            while(left <= right)
            {
                int middle = (left + right) / 2;
                if(minLast[middle] > value)
                    return FindFirstGreaterValueIndex(minLast, value, left, middle-1);
                else
                    return FindFirstGreaterValueIndex(minLast, value, middle + 1, right);
            }
            return left;
        }

        public static int LongestCommonSubsequence(int[] vs1, int[] vs2)
        {
            return 0;
        }
    }
}