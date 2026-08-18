using InterviewPrepsLeetCode.Backtracking;
using InterviewPrepsLeetCode.GraphAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrepsLeetCode.Tests
{
    public class BacktrackingProblemTests
    {
        public static IEnumerable<object[]> BacktrackingProblem_TestData()
        {
            yield return new object[] {
                new int[]{ 1,2,3 },
                new List<IList<int>>([[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]])
            };
            yield return new object[] {
                new int[]{ },
                new List<IList<int>>()
            };
        }
        public static IEnumerable<object[]> CombinationSumCases()
        {
            yield return new object[]
            {
            new int[]
            {
                2,3,6,7
            },
            7,
            new List<IList<int>>
            (
                [[2,2,3],[7]]
             )
            };
            yield return new object[]
          {
            new int[]
            {
                2,3,5
            },
            8,
            new List<IList<int>>
            (
                [[2,2,2,2],[2,3,3],[3,5]]
             )
          };
            yield return new object[]
           {
            new int[]
            {
                2
            },
            1,
            new List<IList<int>>
            (
                []
             )
           };
        }
        public static IEnumerable<object[]> LetterCombinations_TestData()
        {
            yield return new object[] {
                "", 
                new List<string>()
            };
            yield return new object[]{
                "23",
                new List<string>(["ad","ae","af","bd","be","bf","cd","ce","cf"])
            };
        }

        [Theory]
        [MemberData(nameof(BacktrackingProblem_TestData))]
        public void Subsets_EmptyArray_ReturnListOfSubLists(int[] arr, IList<IList<int>> expected)
        {
            var result = BacktrackingProblems.Subsets(arr);
            Assert.Equal(expected.OrderBy(c => c.Count), result.OrderBy(c => c.Count));
        }
        [Theory]
        [MemberData(nameof(LetterCombinations_TestData))]
        public void LetterCombinations_ReturnsArrayOfStrings(string input, List<string> expected)
        {
            var result = BacktrackingProblems.LetterCombinations(input);
            Assert.Equal(expected,result);
        }
        [Theory]
        [MemberData(nameof(CombinationSumCases))]
        public void CombinationSum_Returns_CombinationListOfList(int[] array, int target, IList<IList<int>> expected)
        {
            var result = BacktrackingProblems.CombinationSum(array, target);
            
            Assert.All(expected, list =>
            {
                result.Contains(list);
            });
        }
    }
}
