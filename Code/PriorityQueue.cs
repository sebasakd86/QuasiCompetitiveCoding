using System;
using System.Collections.Generic;

namespace Competitive.Code
{
    public interface IHeap<T>
    {
        T Top();
        void Insert(T value);
        T RemoveTop();
        bool IsEmpty();
    }
    public class MaxHeap<T> : IHeap<T> where T: IComparable
    {
        private List<T> items = new List<T>();

        public MaxHeap()
        {
            this.items = new List<T>();
        }

        private void Swap(int pos1, int pos2)
        {
            T aux = items[pos1];
            items[pos1] = items[pos2];
            items[pos2] = aux;
        }
        public void Insert(T value)
        {
            items.Add(value);
            UpHeap(items.Count - 1);
        }
        private void UpHeap(int pos)
        {
            while(pos > 0 && items[pos].CompareTo(items[pos/2]) > 0)
            {
                Swap(pos, pos/2);
                pos /= 2;
            }
        }
        public T RemoveTop()
        {
            if(items.Count > 0){
                T ret = items[0];
                // System.Console.WriteLine(string.Join('-', items));
                //Take last items to the top
                items[0] = items[items.Count - 1];
                items.RemoveAt(items.Count - 1);
                //Downheap
                DownHeap(0);
                return ret;
            }
            throw new ArgumentOutOfRangeException("Heap is empty");
        }

        private void DownHeap(int pos)
        {
            int largest = pos;
            int left = 2 * pos + 1;
            int right = 2 * pos + 2;
            if(left < items.Count && items[left].CompareTo(items[largest]) > 0)
                largest = left;
            if(right < items.Count && items[right].CompareTo(items[largest]) > 0)
                largest = right;
            if(largest != pos)
            {
                // System.Console.WriteLine($"Swaps --> items[{pos}]:{items[pos]} x items[{largest}]:{items[pos]}");
                Swap(pos, largest);
                DownHeap(largest);
            }
        }
        public T Top()
        {
            if(items.Count > 0)
                return items[0];
            throw new ArgumentOutOfRangeException("Heap is empty");
        }

        public bool IsEmpty()
        {
            return items.Count == 0;
        }
    }
}