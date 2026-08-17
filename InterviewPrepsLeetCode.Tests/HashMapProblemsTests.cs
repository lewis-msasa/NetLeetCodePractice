using InterviewPrepsLeetCode.HashMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrepsLeetCode.Tests
{
    public class HashMapProblemsTests
    {
        [Theory]
        [InlineData(new int[] { }, true)]
        public void TwoSum_ArrayEmpty_ReturnEmptyArray(int[] nums, bool expected)
        {
            var result = HashMapProblems.TwoSum(nums, 1);
            Assert.Equal(expected, result.Length == 0);
        }
        [Theory]
        [InlineData(new int[] { 1 }, 20, true)]
        public void TwoSum_TargetNotFound_ReturnEmptyArray(int[] nums, int target, bool expected)
        {
            var result = HashMapProblems.TwoSum(nums, target);
            Assert.Equal(expected, result.Length == 0);
        }
        [Theory]
        [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] {0,1})]
        public void TwoSum_TargetNotFound_ReturnArrayOfIndices(int[] nums, int target, int[] expected)
        {
            var result = HashMapProblems.TwoSum(nums, target);
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(new string[] { }, true)]
        public void GroupAnagrams_EmptyArray_ReturnEmptyList(string[] sts, bool expected)
        {
            var result = HashMapProblems.GroupAnagrams(sts);
            Assert.Equal(expected, result.Count == 0);
        }
        public static IEnumerable<object[]> AnagramCases()
        {
            yield return new object[]
       {
            new string[] { "eat", "tea", "tan", "ate", "nat", "bat" },
            new List<IList<string>>
            {
                new List<string> { "eat", "tea", "ate" },
                new List<string> { "tan", "nat" },
                new List<string> { "bat" }
            }
       };

            yield return new object[]
            {
            new string[] { "" },
            new List<IList<string>> { new List<string> { "" } }
            };

            yield return new object[]
            {
            new string[] { "a" },
            new List<IList<string>> { new List<string> { "a" } }
            };
        }
        [Theory]
        [MemberData(nameof(AnagramCases))]
        public void GroupAnagrams_ReturnList(string[] sts, List<IList<string>> expected)
        {
            var result = HashMapProblems.GroupAnagrams(sts);
            Assert.Equal(expected, result);
        }
    }
}
