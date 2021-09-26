using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Interview.Challenges
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Array
            List<int> result = Arrays.rotLeft(new List<int> { 1, 2, 3, 4, 5 }, 4);
            Arrays.minimumBribes(new List<int> { 2, 1, 5, 3, 4 });
            Arrays.minimumSwaps(new int[] { 4, 3, 1, 2 });


            //Graph (DFS)
            Graph graph = new Graph();

            char[][] grid1 = { "11110".ToArray(), "11010".ToArray(), "11000".ToArray(), "00000".ToArray() };
            graph.NumIslands(grid1);

            int[][] grid2 = { new int[] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 }, new int[] { 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0 }, new int[] { 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 } };

            graph.MaxAreaOfIsland(grid2);

            int[][] grid3 = new int[][]
        {
            new int[] {0, 1, 0, 0, 0},
            new int[] {1, 1, 1, 0, 0},
            new int[] {1, 0, 0, 0, 0}
        };

            graph.IslandPerimeter(grid3);

        }
    }
}
