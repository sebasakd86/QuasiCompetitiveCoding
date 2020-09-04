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
            int[] dp = new int[l];
            int[] minLast = new int[l];

            dp[0] = 1;
            int minLastIx = 0;
            minLast[minLastIx] = vs[0];            
            for (int i = 1; i < l; i++)
            {
                if(vs[i] > minLast[minLastIx]){
                    dp[i] = dp[i-1] + 1;
                    minLast[++minLastIx] = vs[i];
                }
                else {
                    //find the ix of the value greater than vs[i].
                    //dp[i] is the value from dp[ix]
                    int ix = FindFirstGreaterValueIndex(minLast, vs[i], 0, minLastIx);
                    minLast[ix] = vs[i];
                    dp[i] = dp[ix];
                }
            }
            return dp.Max();
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
    }
}