using System;
using System.Collections.Generic;

namespace Competitive.Code
{
    public class HashMap
    {
        public static int NumberOfPais(int[] vs, int s)
        {
            if (vs.Length == 1)
                return 0;
            Dictionary<int, int> values = new Dictionary<int, int>();
            int ret = 0;
            for (int i = 0; i < vs.Length; i++)
            {
                //S = a[i] + a[j] ==> a[i] = S - a[j]
                //if the dictionary contains such a[i], then we've a solution and add the ammount of times you've found a[i] to the result.
                if (values.ContainsKey(s - vs[i]))
                    ret += values[s - vs[i]];
                if (!values.ContainsKey(vs[i]))
                    values.Add(vs[i], 0);
                values[vs[i]]++;
            }
            return ret;
        }

        public static int[] IWonTheLotto(int[] vs, int expected)
        {
            Dictionary<int, List<int>> mySums = new Dictionary<int, List<int>>();
            int l = vs.Length;
            //Precompute the sums of every number within the values provided and save the triplets that reach said value
            for (int i = 0; i < l; i++)
            {
                for (int j = i; j < l; j++)
                {
                    for (int z = j; z < l; z++)
                    {
                        int sum = vs[i] + vs[j] + vs[z];
                        if (!mySums.ContainsKey(sum))
                        {
                            mySums.Add(sum, new List<int>() { vs[i], vs[j], vs[z] });
                        }
                    }
                }
            }
            //Find the remaining 3 values
            for (int i = 0; i < l; i++)
            {
                for (int j = i; j < l; j++)
                {
                    for (int z = j; z < l; z++)
                    {                        
                        int sum = expected - vs[i] - vs[j] - vs[z];
                        if(mySums.ContainsKey(sum)){ //If there's a sum that satisfies the remaining 3 values.
                            List<int> ret = mySums[sum]; //get the tripplets from the sum maps.
                            ret.AddRange(new List<int>(){vs[i], vs[j], vs[z]}); //add the values that satisfies the sum
                            // System.Console.WriteLine(String.Join('|', ret));
                            return ret.ToArray();
                        }
                    }
                }
            }
            return new int[]{-1};
        }
    }
}