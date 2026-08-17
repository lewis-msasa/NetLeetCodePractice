using InterviewPrepsLeetCode.GraphAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrepsLeetCode.Tests
{
    public class GraphProblemsTest
    {
        public static IEnumerable<object[]> ColorCases()
        {
            yield return new object[]
            {
            new int[][]
            {
                new int[] { 1, 1, 1 },
                new int[] { 1, 1, 0 },
                new int[] { 1, 0, 1 }
            },
            1, // sr
            1, // sc
            2, // color
            new int[][]
            {
                new int[] { 2, 2, 2 },
                new int[] { 2, 2, 0 },
                new int[] { 2, 0, 1 }
            }
            };
        }
        public static IEnumerable<object[]> GridCases()
        {
            yield return new object[]
            {
            new char[][]
            {
                new char[] { '1', '1', '1', '1', '0' },
                new char[] { '1', '1', '0', '1', '0' },
                new char[] { '1', '1', '0', '0', '0' },
                new char[] { '0', '0', '0', '0', '0' }
            },
            1 // expected number of islands
            };

            yield return new object[]
            {
            new char[][]
            {
                new char[] { '1', '1', '0', '0', '0' },
                new char[] { '1', '1', '0', '0', '0' },
                new char[] { '0', '0', '1', '0', '0' },
                new char[] { '0', '0', '0', '1', '1' }
            },
            3
            };
        }
        [Theory]
        [MemberData(nameof(GridCases))]
        public void NumIslands_Return_NumberOfIslands(char[][] arr, int expected) {
            var result = GraphProblems.NumIslands(arr);
            Assert.Equal(expected, result);
        }
        [Theory]
        [MemberData(nameof(ColorCases))]
        public void FloodFill_Return_FilledImage(int[][] image, int sr, int sc, int color, int[][] expected)
        {
            var result = GraphProblems.FloodFill(image,sr,sc,color);
            Assert.Equal(expected, result);
        }
    }
}
