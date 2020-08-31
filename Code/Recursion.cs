using System;
using System.Collections.Generic;

namespace Competitive.Code
{
    public class Recursion
    {
        private static int islandCount = 0;
        private static int maxIslandSize = 0;
        public static string FillAlgorithm(int[,] map)
        {
            // Console.WriteLine($"{map.GetLength(0)} - {map.GetLength(1)}");
            islandCount = 0;
            maxIslandSize = 0;          
            int mapRows = map.GetLength(0);
            int mapColumns = map.GetLength(1);
            for(int i = 0; i < mapRows; i++) 
            {
                for (int j = 0; j < mapColumns; j++)
                {
                    int size = GetIslandSize(i,j, map, mapRows, mapColumns);
                    if(size > maxIslandSize)
                        maxIslandSize = size;
                    if(size > 0)
                        islandCount++;
                }
            }            
            return $"Islands:{islandCount}-MaxSize:{maxIslandSize}";
        }
        private static int GetIslandSize(int i, int j, int[,] map, int mapRows, int mapColumns){            
            if(i >= mapRows || j >= mapColumns || i < 0 || j < 0){
                return 0;
            }
            if(map[i,j] == 0)
                return 0;
            map[i,j] = 0; //So i dont return to it.
            return 1 
                + GetIslandSize(i+1, j, map, mapRows, mapColumns) 
                + GetIslandSize(i-1, j, map, mapRows, mapColumns) 
                + GetIslandSize(i, j+1, map, mapRows, mapColumns) 
                + GetIslandSize(i, j-1, map, mapRows, mapColumns);
        }
    }
}