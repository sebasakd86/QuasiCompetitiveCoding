using System;
using System.Collections.Generic;

namespace Competitive.Code
{
    public class HeapProblemSolving
    {
        public static int ConnectRopes(int[] ropes)
        {
            MaxHeap<int> minHeap = new MaxHeap<int>();
            for (int i = 0; i < ropes.Length; i++)
            {
                minHeap.Insert(ropes[i] * -1);
            }
            int ret = 0;
            while (!minHeap.IsEmpty())
            {
                int x = minHeap.RemoveTop() * -1;
                if (!minHeap.IsEmpty())
                {
                    int y = minHeap.RemoveTop() * -1;
                    int newVal = (x + y) * -1;
                    minHeap.Insert(newVal);
                    ret += newVal * -1;
                }
            }
            return ret;
        }
    }
}