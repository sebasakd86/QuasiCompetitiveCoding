using System;
using System.Collections.Generic;

namespace Competitive.Code
{
    public class Stack
    {
        public static bool IsValidParenthesis(string testData)
        {
            if (string.IsNullOrWhiteSpace(testData))
                return true;

            Dictionary<char, char> validChars = new Dictionary<char, char>()
            {
                {'{','}'},
                {'[',']'},
                {'(',')'}
            };
            Stack<char> s = new Stack<char>();
            foreach (char c in testData)
            {
                if (validChars.ContainsKey(c))
                {
                    s.Push(c);
                }
                else if (validChars.ContainsValue(c))
                {
                    if (s.Count == 0) //nothing to pop
                        return false;
                    char pop = s.Pop();
                    if (validChars[pop] != c) //the popped value doesnt match the closing value.
                        return false;
                }
                else
                    return false; //invalid value
            }
            return s.Count == 0; //false when there are still elements to pop
        }

        public static int[] FirstGreaterElement(int[] searchArray)
        {
            Stack<KeyValuePair<int, int>> sortedDescendingStack = new Stack<KeyValuePair<int, int>>();
            int[] retArray = new int[searchArray.Length];
            for (int i = 0; i < searchArray.Length; i++)
            {
                while (sortedDescendingStack.Count > 0 && sortedDescendingStack.Peek().Key < searchArray[i])
                {
                    var kv = sortedDescendingStack.Pop();
                    retArray[kv.Value] = i;
                }
                sortedDescendingStack.Push(new KeyValuePair<int, int>(searchArray[i], i));
            }
            // System.Console.WriteLine(String.Join('-', retArray));
            return retArray;
        }

        public static ulong LargestRectangularArea(int[] vs)
        {
            int l = vs.Length;

            if (l == 0)
                return 0;
            if (l == 1)
                return (ulong)vs[0];

            List<int> left = new List<int>();
            for (int i = 0; i < l; i++)
                left.Add(-1); //if there no smaller element, then it should go to the leftmost column.
            List<int> right = new List<int>();
            for (int i = 0; i < l; i++)
                right.Add(l);  //if there're  no smaller elements to the right, the it should go to the rightmost column
            Stack<int> stack = new Stack<int>();
            //get for every position, the first smaller element than itself to the right
            //by keeping a sorted stack like in FirstGreaterElement
            for (int i = 0; i < l; i++)
            {
                while (stack.Count > 0 && vs[stack.Peek()] > vs[i])
                {
                    right[stack.Pop()] = i;
                }
                stack.Push(i);
            }
            stack.Clear();
            for (int i = l - 1; i >= 0; i--) //get for every position, the first smaller element than itself to the left
            {
                while (stack.Count > 0 && vs[stack.Peek()] > vs[i])
                {
                    left[stack.Pop()] = i;
                }
                stack.Push(i);
            }
            ulong ret = 0;
            for (int i = 0; i < l; i++)
            {
                ret = Math.Max(ret, (ulong)((right[i] - left[i] - 1) * vs[i])); //r-l * minHeight == (r[i] - l[i]) * vs[i]
            }
            // System.Console.WriteLine("-------------------");
            // System.Console.WriteLine($"Array-->\t{String.Join('\t', vs)}");
            // System.Console.WriteLine($"Left--> \t{String.Join('\t', left)}");
            // System.Console.WriteLine($"Right-->\t{String.Join('\t', right)}");
            // System.Console.WriteLine($"{ret}");
            return ret;
        }

        public static ulong MaximumSizeRectangleWithValue(int[,] v, int valueToFind)
        {
            if (v.GetLength(0) == 0 && v.GetLength(1) == 0)
                return 0;
            /*
            precompute tower values, they hold the cumulative height of the column for every cell
            with tower computed, the problem becomes basically the same as LargestRectangularArea
            but you need to query every row from the computed tower.
            */
            int rows = v.GetLength(0);
            int cols = v.GetLength(1);
            List<int[]> tower = new List<int[]>();
            for (int i = 0; i < rows; i++)
            {
                tower.Add(new int[cols]);
                for (int j = 0; j < cols; j++)
                {
                    if (v[i, j] == valueToFind)
                        tower[i][j] = 1 + ((i > 0) ? tower[i - 1][j] : 0);
                    else
                        tower[i][j] = 0;
                }
            }
            ulong ret = 0;
            for (int i = 0; i < rows; i++)
            {
                ret = Math.Max(ret, Stack.LargestRectangularArea(tower[i]));
            }
            return ret;
        }
    }
}