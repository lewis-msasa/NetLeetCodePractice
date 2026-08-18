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
        /*
         * Given an m x n grid of characters board and a string word, return true if word exists in the grid.

            The word can be constructed from letters of sequentially adjacent cells, where adjacent cells are horizontally or vertically neighboring. 
            The same letter cell may not be used more than once.
         * 
         * 
         */
        public static bool Exist(char[][] board, string word)
        {
            int m = board.Length; int n = board[0].Length;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(WordDFS(board, word, i, j, 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool WordDFS(char[][] board, string word, int row, int col, int index)
        {
            //entire word found
            if (index == word.Length) return true;
            //out of bounds or wrong word
            if (row < 0 || row >= board.Length || col < 0 || col >= board[0].Length || board[row][col] != word[index]) return false;

            //mark visited - to avoid visiting twice
            var original = board[row][col];
            board[row][col] = '#';

            var found = WordDFS(board, word, row - 1, col, index + 1) ||
                        WordDFS(board, word, row + 1, col, index + 1) ||
                        WordDFS(board, word, row, col - 1, index + 1) ||
                        WordDFS(board, word, row, col+1, index+1);

            //backtrack
            board[row][col] = original;


            return found;


        }

       
    }
}
