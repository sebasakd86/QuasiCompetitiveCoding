using System;
using System.Collections.Generic;

namespace Competitive.Code
{
    public class DivideAndConquer
    {
        private static int[] array = null;
        private static int[] auxArray = null;
        public static int[] MergeSort(int[] arrToSort)
        {
            array = new int[arrToSort.Length];
            auxArray = new int[arrToSort.Length];

            Array.Copy(arrToSort, array, arrToSort.Length);
            Sort(arrToSort, 0, arrToSort.Length);
            // System.Console.WriteLine(String.Join('|', array));
            // System.Console.WriteLine(String.Join('|', auxArray));
            return array;
        }
        private static bool Sort(int[] arrToSort, int left, int right)
        {
            if (left >= right)
                return true;
            int middle = (left + right) / 2;
            Sort(arrToSort, left, middle);
            Sort(arrToSort, middle + 1, right);
            //Now i've to merge the arrays.
            Merge(left, middle, right);
            return true;
        }
        private static void Merge(int left, int middle, int right)
        {
            int i = left;
            int ix = 0;
            int j = middle + 1;
            //Compare a[i] with a[j] (they're sorted asc)
            //The value whos smaller, raises the pointer
            //until i == middle or j == right
            while (i <= middle && j <= right && j < array.Length)
            {
                if (array[i] < array[j])
                    auxArray[ix++] = array[i++];
                else
                    auxArray[ix++] = array[j++];
            }
            //just adding the remaining of the arrays to the auxiliar array.
            while (i <= middle)
                auxArray[ix++] = array[i++];
            while (j <= right && j < array.Length)
                auxArray[ix++] = array[j++];
            //copy the sorted array into the actual array
            for (i = left; i <= right && i < array.Length; i++)
            {
                array[i] = auxArray[i - left];
            }
        }

        public static int ZTraversal(int dimensions, int x, int y)
        {
            //hes bitwising everything, its not LL but << which means 2^X
            int dimMinus1 = (int) Math.Pow(2, dimensions-1);
            if (dimensions == 0)
                return 1;
            if (x <= dimMinus1)
            { //the row belongs to the first half of the matrix
                if (y <= dimMinus1) //the column belongs to the firts half of the matrix
                { 
                    return ZTraversal(dimensions - 1, x, y); //Get the value from the first square.
                }
                //shorten the dimension
                return (int) Math.Pow(2, 2 * dimensions - 2) + ZTraversal(dimensions - 1, x, y - dimMinus1);
            }
            if (y <= dimMinus1) //the column belongs to the firts half of the matrix
            { 
                return (int) Math.Pow(2, 2*dimensions-1) + ZTraversal(dimensions - 1, x - dimMinus1, y);
            } //the ix belongs to the last quadrant of the matrix
            return 3 * (int) ( Math.Pow(2, 2 * dimensions - 2)) + ZTraversal(dimensions - 1, x - dimMinus1, y - dimMinus1);
        }

        public static int MaximumSumSubArray(int[] array)
        {
            return SolveMaximumSumSubArray(array, 0, array.Length - 1);
        }
        private static int SolveMaximumSumSubArray(int[] array, int left, int right)
        {
            if (left == right)
                return array[left];
            int middle = (left + right) / 2;
            //Get the max sum from between left & right subarrays.
            int max = Math.Max(
                        SolveMaximumSumSubArray(array, left, middle),
                        SolveMaximumSumSubArray(array, middle + 1, right));
            max = Math.Max(max,
                            MaxSumLeft(array, left, middle) + MaxSumRight(array, middle + 1, right));
            return max;
        }
        private static int MaxSumLeft(int[] array, int left, int middle)
        {
            //Goes from middle to left looking for the max sum
            //Since its going from right to left, either the first value is the max sum or the whole array
            int max = array[middle];
            int sum = 0;
            for (int i = middle; i >= left; i--)
            {
                sum += array[i];
                if (sum > max)
                {
                    max = sum;
                }
            }
            return max;
        }
        private static int MaxSumRight(int[] array, int left, int right)
        {
            int max = array[left];
            int sum = 0;
            for (int i = left; i <= right; i++)
            {
                sum += array[i];
                if (sum > max)
                {
                    max = sum;
                }
            }
            return max;
        }
    }
}