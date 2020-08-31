using System;
using System.Collections.Generic;

namespace Competitive.Code
{
    public class Greedy
    {
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
                double valuePerWeight = (double) items[i, 0] / items[i, 1];
                while(items[i,1]-- > 0){
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
    }
}