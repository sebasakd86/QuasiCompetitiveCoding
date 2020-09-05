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
                if (vs[i] > minLast[minLastIx])
                {
                    minLast[++minLastIx] = vs[i];
                }
                else
                {
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
            while (left <= right)
            {
                int middle = (left + right) / 2;
                if (minLast[middle] > value)
                    return FindFirstGreaterValueIndex(minLast, value, left, middle - 1);
                else
                    return FindFirstGreaterValueIndex(minLast, value, middle + 1, right);
            }
            return left;
        }

        public static int LongestCommonSubsequence(int[] vs1, int[] vs2)
        {
            int l1 = vs1.Length;
            int l2 = vs2.Length;
            if (l1 == 0 || l2 == 0)
                return 0;
            if (l1 == 1 && l2 == 1)
                return (vs1[0] == vs2[0]) ? 1 : 0;
            int[,] dp = new int[l1, l2];
            for (int i = 0; i < l1; i++)
            {
                for (int j = 0; j < l2; j++)
                {
                    if (vs1[i] == vs2[j])
                    {
                        dp[i, j] = ((i > 0 && j > 0) ? 1 + dp[i - 1, j - 1] : 1);
                    }
                    else
                    {              
                        int val = 0;   
                        if(i > 0 && j > 0) 
                            val = Math.Max(dp[i - 1, j], dp[i, j - 1]); 
                        else if(i > 0) 
                            val = dp[i-1,j];
                        else if(j > 0) 
                            val = dp[i,j-1];
                        dp[i, j] = val;
                    }
                }
            }
            return dp[l1 - 1, l2 - 1];
        }
    }
}