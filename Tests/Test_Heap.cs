using System;
using Competitive.Code;
using Xunit;

namespace Competitive.Tests
{
    public class Test_Heap
    {
        [Fact]
        public void GetTop_EmptyHeap()
        {
            MaxHeap<int> p = new MaxHeap<int>();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                p.Top();
            });
        }
        [Fact]
        public void RemoveTop_EmptyHeap()
        {
            MaxHeap<int> p = new MaxHeap<int>();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                p.RemoveTop();
            });
        }
        [Fact]
        public void InsertTopNode_EmptyHeap()
        {
            MaxHeap<int> p = new MaxHeap<int>();
            int x = 10;
            p.Insert(x);
            Assert.Equal(x, p.Top());
        }
        [Fact]
        public void Insert2Values_EmptyHeap()
        {
            MaxHeap<int> p = new MaxHeap<int>();
            p.Insert(10);
            p.Insert(20);
            Assert.Equal(20, p.Top());
        }
        [Fact]
        public void InsertXValues_EmptyHeap()
        {
            int maxVal = 20;
            MaxHeap<int> p = GetMaxHeapUpToX(maxVal);
            Assert.Equal(maxVal, p.Top());
        }
        [Fact]
        public void RemoveFromTop_FullHeap()
        {
            int maxValue = 20;
            var p = GetMaxHeapUpToX(maxValue);
            for (int i = maxValue; i > 0; i--)
            {
                Assert.Equal(i, p.RemoveTop());
            }
        }

        [Fact]
        public void MaxHeapAsMinHeap()
        {
            int maxValue = 20;
            var p = GetMinHeapUpToX(maxValue);
            for (int i = 1; i <= maxValue; i++)
            {
                Assert.Equal(i * -1, p.RemoveTop());
            }
        }

        [Fact]
        public void ConnectTheRopes()
        {
            Assert.Equal(0, Code.HeapProblemSolving.ConnectRopes(new int[] { 2 }));
            Assert.Equal(5, Code.HeapProblemSolving.ConnectRopes(new int[] { 2, 3 }));
            Assert.Equal(14, Code.HeapProblemSolving.ConnectRopes(new int[] { 2, 3, 4 }));
            Assert.Equal(29, Code.HeapProblemSolving.ConnectRopes(new int[] { 4, 3, 2, 6 }));
        }

        private static MaxHeap<int> GetMaxHeapUpToX(int maxVal)
        {
            var p = new MaxHeap<int>();
            for (int i = 1; i <= maxVal; i++)
                p.Insert(i);
            return p;
        }
        private static MaxHeap<int> GetMinHeapUpToX(int maxVal)
        {
            var p = new MaxHeap<int>();
            for (int i = 1; i <= maxVal; i++)
                p.Insert(i * -1);
            return p;
        }
    }
}