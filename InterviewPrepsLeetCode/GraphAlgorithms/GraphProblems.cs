using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrepsLeetCode.GraphAlgorithms
{
    public class GraphProblems
    {

        public static List<int> BFS(Dictionary<int, List<int>> graph, int start)
        {
            var visited = new HashSet<int>();
            var queue = new Queue<int>();
            var order = new List<int>();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                order.Add(node);
                foreach (int neighbour in graph[node])
                {
                    if (!visited.Contains(neighbour))
                    {
                        visited.Add(neighbour);
                        queue.Enqueue(neighbour);
                    }
                }
            }

            return order;
        }
        //An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.
        //1. For loops i, j
        //2. Check if grid is 1, increase count and turn to 0
        public static int NumIslands(char[][] grid)
        {
            int m = grid.Length, n = grid[0].Length, count = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        count++;
                        Sink(grid, i, j);
                    }
                }
            }
            return count;
        }

        private static void Sink(char[][] grid, int i, int j)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] != '1') return;

            grid[i][j] = '0';
            Sink(grid, i + 1, j);
            Sink(grid, i - 1, j);
            Sink(grid, i, j + 1);
            Sink(grid, i, j - 1);
        }
        public static int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            var originalColor = image[sr][sc];
            if (originalColor == color) return image;

            DFS(image, sr, sc, originalColor, color);

            return image;
        }

        private static void DFS(int[][] image, int sr, int sc, int originalColor, int color)
        {
            if (sr < 0 || sr >= image.Length || sc < 0 || sc >= image[0].Length || image[sr][sc] != originalColor) return;

            image[sr][sc] = color;

            DFS(image, sr + 1, sc, originalColor, color);
            DFS(image, sr -1, sc, originalColor, color);
            DFS(image, sr, sc + 1, originalColor, color);
            DFS(image, sr, sc - 1, originalColor, color);

        }
    }
}
