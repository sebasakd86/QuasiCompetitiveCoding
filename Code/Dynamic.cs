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
                        if (i > 0 && j > 0)
                            val = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                        else if (i > 0)
                            val = dp[i - 1, j];
                        else if (j > 0)
                            val = dp[i, j - 1];
                        dp[i, j] = val;
                    }
                }
            }
            return dp[l1 - 1, l2 - 1];
        }

        public static int Knapsack(List<KeyValuePair<int, int>> lists, int maxWeight)
        {

            // Console.WriteLine(String.Join("-", lists));
            // Console.Write($"\t\t");
            // for (int j = 1; j <= maxWeight; j++)
            //     Console.Write($"{j}\t");
            // Console.WriteLine();
            int[,] dp = new int[lists.Count + 1, maxWeight + 1];
            for (int i = 1; i <= lists.Count; i++)
            {
                // Console.Write($"{i}{lists[i-1]}-->\t");
                int w = lists[i - 1].Key;
                int v = lists[i - 1].Value;
                for (int j = 1; j <= maxWeight; j++)
                {
                    dp[i, j] = dp[i - 1, j];
                    if (w <= j)
                    {
                        dp[i, j] = Math.Max(dp[i, j], v + dp[i - 1, j - w]);
                    }
                }
                // for (int j = 1; j <= maxWeight; j++)
                // {
                //     Console.Write($"{dp[i, j]}\t");
                // }
                // Console.WriteLine();
            }
            int ans = 0;
            for (int i = 0; i <= maxWeight; i++)
            {
                ans = Math.Max(ans, dp[lists.Count, i]);
            }
            // Console.WriteLine($"res --> {ans}");
            return ans;
        }

        public static int MinimumEditDistance(string v1, string v2, int c1, int c2, int c3)
        {
            if (string.IsNullOrWhiteSpace(v1) || string.IsNullOrWhiteSpace(v2))
            {
                return (v1.Length > v2.Length) ? v1.Length * c2 : v2.Length * c1;
            }
            int n = v1.Length;
            int m = v2.Length;
            int[,] dp = new int[n + 1, m + 1];

            for (int i = 0; i < n; i++)
            {
                dp[i, 0] = i * c2; //Cost of deleting everything
            }
            for (int j = 0; j < m; j++)
            {
                dp[0, j] = j * c1; //Cost of adding everything
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    //I can choose 1 out of 4 options
                    //insert
                    //delete
                    //replace
                    //do nothing
                    int val = Math.Min(c1 + dp[i, j - 1], c2 + dp[i - 1, j]); //Less cost between inserting and deleting
                    val = Math.Min(val, c3 + dp[i - 1, j - 1]); //Less cost between the value and replacing
                    if (v1[i - 1] == v2[j - 1]) //if the values happen to be the same
                        val = Math.Min(val, dp[i - 1, j - 1]); //Less cost between the current value and doing nothing.
                    dp[i,j] = val;
                }
            }
            return dp[n,m];
        }
    }
}