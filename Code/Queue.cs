using System;
using System.Collections.Generic;

namespace Competitive.Code
{
    public class Queue
    {
        public static int FindShortestPath(int[,] v, KeyValuePair<int, int> source, KeyValuePair<int, int> destination)
        {
            int rows = v.GetLength(0);
            int cols = v.GetLength(1);
            if (rows == 0 && cols == 0)
                return -1;
            if(source.Key == destination.Key && source.Value == destination.Value){
                if(v[source.Key, source.Value] == 0)
                    return - 1;
                return 0;
            }
            int[,] aux = new int[rows,cols];
            Array.Copy(v, aux,cols*rows);
            return Solve(aux, source, destination, rows, cols);
        }
        private static int Solve(int[,] maze, KeyValuePair<int, int> source, KeyValuePair<int, int> destination, int rows, int columns)
        {
            Queue<Search> availableCells = new Queue<Search>();
            availableCells.Enqueue(new Search(source.Key, source.Value, 0));
            while (availableCells.Count > 0)
            {
                var next = availableCells.Dequeue();
                if (IsDestination(next, destination))
                    return next.Cost;
                if (next.J < columns - 1 && maze[next.I, next.J + 1] == 1)
                {
                    maze[next.I, next.J + 1] = 0; //mark as visited
                    availableCells.Enqueue(new Search(next.I, next.J + 1, next.Cost + 1));
                }
                if (next.J > 0 && maze[next.I, next.J - 1] == 1)
                {
                    maze[next.I, next.J - 1] = 0; //mark as visited
                    availableCells.Enqueue(new Search(next.I, next.J - 1, next.Cost + 1));
                }
                if (next.I < rows - 1 && maze[next.I + 1, next.J] == 1)
                {
                    maze[next.I + 1, next.J] = 0; //mark as visited
                    availableCells.Enqueue(new Search(next.I + 1, next.J, next.Cost + 1));
                }
                if (next.I > 0 && maze[next.I - 1, next.J] == 1)
                {
                    maze[next.I - 1, next.J] = 0; //mark as visited
                    availableCells.Enqueue(new Search(next.I - 1, next.J, next.Cost + 1));
                }
            }
            return -1;
        }

        private static bool IsDestination(Search next, KeyValuePair<int, int> destination)
        {
            return next.I == destination.Key && next.J == destination.Value;
        }
    }
    public class Search
    {
        public int Cost { get; set; }
        public int J { get; set; }
        public int I { get; }
        public Search(int i, int j, int cost)
        {
            this.I = i;
            this.J = j;
            this.Cost = cost;
        }
    }
}