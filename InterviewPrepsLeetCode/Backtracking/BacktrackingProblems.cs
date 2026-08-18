using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InterviewPrepsLeetCode.Backtracking
{
    public class BacktrackingProblems
    {
        //Given an integer array nums of unique elements, return all possible subsets (the power set). The solution set must not contain duplicate subsets.Return the solution in any order.
        //INTUITION: Backtracking: 
        //Complexity - O( n * 2 ^ n) - time, Space - O(n)
        public static IList<IList<int>> Subsets(int[] nums)
        {
            if(nums.Length == 0) return new List<IList<int>>();
            var result = new List<IList<int>>();
            //start at 0, and current at empty
            Backtracking(0, new List<int>(), nums, result);

            return result;
        }

        private static void Backtracking(int start, List<int> current, int[] nums, List<IList<int>> result)
        {
            //add current to result
            result.Add([..current]);
            for (int i = start; i < nums.Length; i++)
            {
                //add current iter value to current so we can pass current to backtracking
                current.Add(nums[i]);
                //backtrack
                Backtracking(i + 1, current, nums, result);
                //undo add to current
                current.RemoveAt(current.Count - 1);
            }
        }
        //Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.
        //The old keypads
        /*
         *  2 → abc
            3 → def
            4 → ghi
            5 → jkl
            6 → mno
            7 → pqrs
            8 → tuv
            9 → wxyz
         */
        public static IList<string> LetterCombinations(string digits)
        {
            var result = new List<string>();

            if (string.IsNullOrEmpty(digits))
                return result;
            //the first empty for 0 index, the second for 1 which has no numbers
            string[] letters =
             {
                    "",     "",     "abc",  "def",
                    "ghi",  "jkl",  "mno",  "pqrs",
                    "tuv",  "wxyz"
             };
            Backtracking(0, new StringBuilder(), letters, digits, result);



            return result;
        }

        private static void Backtracking(int index, StringBuilder current, string[] letters, string digits, List<string> result)
        {
           //if we are at the end
           if(digits.Length == index)
           {
                result.Add(current.ToString());
                return;
           }
            //possible letters for the the number e.g. 2 => "abc", 3 => "def"
            var possibleLetters = letters[digits[index] - '0'];
            foreach (var c in possibleLetters)
            {
                //add to current
                current.Append(c);
                //backtrack
                Backtracking(index + 1, current, letters, digits, result);
                //undo
                current.Remove(current.Length-1,1);
            }
        }

        /*
        * Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of candidates where the chosen numbers sum to target.
        * You may return the combinations in any order.
        * The same number may be chosen from candidates an unlimited number of times. 
        * Two combinations are unique if the frequency of at least one of the chosen numbers is different.
        *  At every Position:
        *  Choose candidate
               ↓
           Reduce target
               ↓
           Continue searching
               ↓
           Backtrack
        * 
        * 
        */
        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var result = new List<IList<int>>();

            Backtrack(0, new List<int>(), candidates, target, result);


            return result;
        }

        private static void Backtrack(int start, List<int> current, int[] candidates, int remaining, List<IList<int>> result)
        {
            //found target
            if (remaining == 0)
            {
                result.Add([.. current]);
                return;
            }
            //no valid combinations possible
            if (remaining < 0) return;

            for (int i = 0; i < candidates.Length; i++)
            {
                int candidate = candidates[i];
                current.Add(candidate);
                //i not i+1
                Backtrack(i, current, candidates, remaining - candidate, result);
                //undo
                current.RemoveAt(current.Count - 1);
            }

        }
    }
}
