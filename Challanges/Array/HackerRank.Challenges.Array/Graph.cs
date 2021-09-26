using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Interview.Challenges
{
    public class Graph
    {
        #region roadsAndLibraries
        public long roadsAndLibraries(int n, int c_lib, int c_road, List<List<int>> cities)
        {
            if (c_lib <= c_road || cities.Count() == 0)
                return c_lib * n;

            long[,] adjacentMatrix = new long[n + 1, n + 1];
            Stack<long> stack = new Stack<long>();
            bool[] visited = new bool[n + 1];

            foreach (var city in cities)
            {
                adjacentMatrix[city[0], city[1]] = 1;
                adjacentMatrix[city[1], city[0]] = 1;
            }

            // for(int i = 0; i < n + 1; i++){
            //     for(int j = 0; j < n + 1; j++){
            //         Console.Write(adjacentMatrix[i,j]+" ");
            //     }
            //     Console.WriteLine();
            // }

            long noOfComponents = 0;
            long noOfEdges = 0;

            for (long i = 1; i <= n; i++)
            {
                if (visited[i])
                {
                    continue;
                }
                stack.Push(i);
                visited[i] = true;
                noOfComponents++;
                while (stack.Count > 0)
                {
                    long top = stack.Pop();
                    for (long j = 0; j <= n; j++)
                    {
                        if (!visited[j] && adjacentMatrix[top, j] == 1)
                        {
                            stack.Push(j);
                            visited[j] = true;
                            noOfEdges++;
                        }
                    }
                }
            }

            // Console.WriteLine(noOfCycles+" "+noOfRoads);

            return noOfComponents * c_lib + noOfEdges * c_road;
        }
        #endregion

        #region Number Of Islands
        public int NumIslands(char[][] grid)
        {

            if (grid == null || grid.Length == 0)
                return 0;

            int rows = grid.Length;
            int columns = grid[0].Length;

            var numIslands = 0;
            char sand = '1';

            bool[,] visited = new bool[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (grid[row][column].Equals(sand) && !visited[row, column])
                    {
                        numIslands++;
                        searchIsland(grid, row, column, sand, visited);
                    }
                }
            }

            return numIslands;
        }

        private static void searchIsland(char[][] grid, int row, int column, char sand, bool[,] visited)
        {
            if (row < 0 || row >= grid.Length || column < 0 || column >= grid[0].Length)
            {
                return;
            }

            if (!visited[row, column])
            {
                if (grid[row][column].Equals(sand))
                {
                    visited[row, column] = true;

                    searchIsland(grid, row - 1, column, sand, visited); // up
                    searchIsland(grid, row + 1, column, sand, visited); // down
                    searchIsland(grid, row, column - 1, sand, visited); // left
                    searchIsland(grid, row, column + 1, sand, visited); // right
                }
            }
        }
        #endregion

        #region Max Area Of Island
        public int[][] grid { get; set; }
        public bool[,] visited { get; set; }
        //Complexity Analysis
        //Time Complexity: O(R* C)O(R∗C), where RR is the number of rows in the given grid, and CC is the number of columns.We visit every square once.
        //Space complexity: O(R* C) O(R∗C), the space used by seen to keep track of visited squares, and the space used by the call stack during our recursion.
        public int MaxAreaOfIsland(int[][] grid)
        {
            this.grid = grid;

            int response = 0;

            this.visited = new bool[grid.Length, grid[0].Length];

            for (int row = 0; row < this.grid.Length; row++)
            {
                for (int column = 0; column < grid[0].Length; column++)
                {
                    response = Math.Max(response, maxArea(row, column));
                }
            }

            return response;
        }
        private int maxArea(int row, int column)
        {
            if (row < 0 || row >= grid.Length || column < 0 || column >= grid[0].Length)
            {
                return 0;
            }

            int response = 0;



            if (!visited[row, column] && grid[row][column].Equals(1))
            {
                this.visited[row, column] = true;
                return (1 +
                        maxArea(row - 1, column) +
                        maxArea(row + 1, column) +
                        maxArea(row, column - 1) +
                        maxArea(row, column + 1));
            }
            else
            {
                return 0;
            }

        }
        #endregion

        #region Island PErimeter
        //Time Complexity : O(RC).
        public int IslandPerimeter(int[][] grid)
        {
            int islands = 0, neighbours = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        islands++; // count islands
                        if (i < grid.Length - 1 && grid[i + 1][j] == 1) neighbours++; // count down neighbours
                        if (j < grid[i].Length - 1 && grid[i][j + 1] == 1) neighbours++; // count right neighbours
                    }
                }
            }

            return islands * 4 - neighbours * 2;
        }
        #endregion

        #region FloodFill
        //Time Complexity: O(N)O(N), where NN is the number of pixels in the image.We might process every pixel.
        //Space Complexity: O(N) O(N), the size of the implicit call stack when calling dfs.
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            int color = image[sr][sc];
            if (color != newColor) dfs(image, sr, sc, color, newColor);
            return image;
        }

        public void dfs(int[][] image, int r, int c, int color, int newColor)
        {
            if (image[r][c] == color)
            {
                image[r][c] = newColor;
                if (r >= 1) dfs(image, r - 1, c, color, newColor);
                if (c >= 1) dfs(image, r, c - 1, color, newColor);
                if (r + 1 < image.Length) dfs(image, r + 1, c, color, newColor);
                if (c + 1 < image[0].Length) dfs(image, r, c + 1, color, newColor);
            }
        }
        #endregion

        #region LargestSubmatrix
        // Count and sort solution
        // 1. Count continuous 1 per column
        // 2. Sort each row and calculate the sub-matrix size by count * length.
        // Time complexity: O(M*N*logN)
        // Space compexity: O(logN)
        //Array, Greedy, Sorting, Matrix
        public int LargestSubmatrix(int[][] matrix)
        {
            // Ask whether matrix could be null, whether we can modify the input matrix.
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) return 0;
            int M = matrix.Length, N = matrix[0].Length;
            // Count continuous 1 per column
            for (int i = 1; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (matrix[i][j] == 1)
                    {
                        matrix[i][j] = matrix[i - 1][j] + 1;
                    }
                }
            }
            int res = 0;
            for (int i = 0; i < M; i++)
            {
                Array.Sort(matrix[i]); // sort row
                for (int j = 0; j < N; j++)
                {
                    if (matrix[i][j] == 0) continue;
                    int size = matrix[i][j] * (N - j); // size = count * length
                    res = Math.Max(res, size);
                }
            }
            return res;
        }

        #endregion

    }
}
