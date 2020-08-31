using System;
using System.Collections.Generic;

//build test project to test everything everytime.

namespace Competitive
{
    public class Matrix
    {

        public static void PartialSums(int[,] matrix, int l1, int c1, int l2, int c2)
        {
            /*
                find the sum of all the elements within a submatrix in the matrix
                in several queries, just a one its simple enough.
                bf1: just iterate O(MxN)
                bf2: create the partial sum array for every row and then add them for every column. O(N)
                s[i][j] = sum of all elements in submatrix (1,1,i,j)
                s[i][j] = s[i][j-1] + s[i-1][j] + a[i][j] - s[i-1][j-1]
            */
            //precompute the matrix
            int n = 6;
            int m = 6;
            int[,] s = new int[n, m];
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    s[i, j] = s[i, j - 1] + s[i - 1, j] + matrix[i, j] - s[i - 1, j - 1];
                }
            }
            //add the result from S AND substracting everything BEFORE the submatrix
            //ret = s[l2,c2] - s[l1-1, c2] - s[l2,l1-1] + s[l1-1,c1-1]
            //ret = 9
        }

        public static int MaximimSizeSquareSubmatrix(int[,] matrix, int v)
        {
            /*
                Finds the maximum length of a Square containing the value V inside Matrix.
                Basically we check the maxLen neighbors in looking for the min value & 
                adding 1 to the length so we can guarantee that the square keeps growing
            */
            int ret = 0;
            int n = matrix.GetLength(0); //rows
            int m = matrix.GetLength(1); //columns
            int[,] maxLen = new int[n,m]; //
            // Console.WriteLine($"");
            for (int i = 0; i < n; i++)
            {
                // Console.WriteLine($"");
                for (int j = 0; j < m; j++)
                {
                    if(matrix[i,j] != v)
                        maxLen[i,j] = 0;
                    else
                        maxLen[i,j] = 1 + Math.Min(
                                        ((i > 0) ? maxLen[i-1,j] : 0),
                                        Math.Min(
                                            ((j > 0) ? maxLen[i,j-1] : 0), 
                                            ((i > 0 && j > 0) ? maxLen[i-1,j-1] : 0)
                                        )
                                    );
                    // Console.Write($"{maxLen[i,j]}\t");
                    ret = Math.Max(ret, maxLen[i,j]);
                }
            }
            return ret;
        }

        public static void UpdateRange(int[,] matrix, int l1, int c1, int l2, int c2, int value)
        {
            /*
                To update the matrix several times (after N queries) withouth doing a bf
                update every item within the submatrix with a value.
                start by increasing L1,C1 
                then substracting L1,C2+1 
                then substract from L2+1,C1 
                and finally add L2+1,C2+1
                now the sums matrix is evened out
                Useful when you need to update lots of operations and print out 1 result.
                Building and rebuilding the sumsMatrix is expensive, so it's not such a great idea
                to update X times, get re sult, update once again and get the result and so on.
                Bottomline dont use it always.
            */
            matrix[l1, c1] += value;
            matrix[l1, c2 + 1] -= value;
            matrix[l2 + 1, c1] -= value;
            matrix[l2 + 1, c2 + 1] += value;
        }
        public static long MaximumSumSubmatrix(int[,] matrix)
        {
            /*
                Fixing the rows (r1,r2) to reduce the O(n)
                ValueArray = the sum from r1 to r2 from every column, 
                so it has as many elements as columns.
                Now the sum value from r1,c1 --> r2,c2 = Sum(ValueArray, c1 --> c2)                
            */
            long ret = matrix[0, 0];
            int n = matrix.GetLength(0); //rows
            int m = matrix.GetLength(1); //columns
            //precompute the sumArray so we can create the valueArray
            //using the PartialSumsOnArray method for every column between rows
            int[,] upSum = new int[n, m]; //upSum[i,j] = a[1,j] + a[2,j]
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    upSum[i, j] = ((i > 0) ? upSum[i - 1, j] : 0) + matrix[i, j]; //watch out for the i-1 ix
                    // System.Console.Write($"{upSum[i,j]}\t");
                }
                System.Console.WriteLine("");
            }
            //create the value array
            int[] valueArray = new int[m]; // v[i] = a[r1,i] + a[r1+1,i] + ... a[r2,i]
            for (int r1 = 0; r1 < n; r1++)
            {
                // Console.Write($"r1={r1}");
                for (int r2 = r1; r2 < n; r2++)
                {
                    // Console.WriteLine($"\tr2={r2}");
                    for (int i = 0; i < m; i++)
                    {
                        //PartialSumsOnArray
                        valueArray[i] = upSum[r2, i] - ((r1 > 0) ? upSum[r1 - 1, i] : 0);
                        // Console.Write($"{valueArray[i]}\t");
                    }
                    // Console.WriteLine("");
                    ret = Math.Max
                            (ret,
                            Arrays.MaximumSumSubarray_Greedy(valueArray));
                    // Console.WriteLine($"ret={ret}");                    
                }
            }
            return ret;
        }
    }
}