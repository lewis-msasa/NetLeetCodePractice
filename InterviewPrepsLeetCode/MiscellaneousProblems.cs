using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrepsLeetCode
{
    public class MiscellaneousProblems
    {
        //You are given a non-empty array of integers where every element appears twice except for one.
        //Intuition: bit problem. When you XOR all numbers, the one left is the loner
        public static int SingleNumber(int[] nums)
        {
            if(nums.Length == 0) return -1;
            int result = 0;
            foreach(var num in nums)
            {
                result ^= num;
            }

            return result;
        }
        //Given an array nums, return the majority element. More than n/2 times
        //BRUTE Force - use two loops to go through all, then count when @i and @j equal, then in the out loop, check if >= n/2
        //Optimal - Use Boyer Moore voting. If counter = 0, pick a candidate. If current number = candidate, increase count else decrease
        public static int MajorityElement(int[] nums)
        {
            if (nums.Length == 0) return 0;
            var candidate = 0;
            var counter = 0;
            foreach (var num in nums)
            {
                if(counter == 0)
                {
                    candidate = num;
                }
                if(candidate == num)
                {
                    counter++;
                }
                else
                {
                    counter--;
                }
            }
            return candidate;

        }
    }
}
