using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InterviewPrepsLeetCode.HashMap
{
    public class HashMapProblems
    {
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            if(strs.Length == 0) return new List<IList<string>>();
            var map = new Dictionary<string, IList<string>>();
            foreach( var str in strs)
            {
                string key = string.Concat(str.OrderBy(c => c));
                map[key] = map.GetValueOrDefault(key, new List<string>());
                map[key].Add(str);
            }

            return [.. map.Values];
        }
        public static IList<IList<string>> GroupAnagramsAlt(string[] strs)
        {
            var map = new Dictionary<string, IList<string>>();
            foreach (var str in strs)
            {
                var chars = new int[26];
                foreach (var c in str) chars[c - 'a']++;
                string key = string.Join("#", chars);
                map[key] = map.GetValueOrDefault(key, new List<string>());
                map[key].Add(str);
            }
            return map.Values.ToList();
        }


        //Given four integer arrays nums1, nums2, nums3, and nums4 all of length n, return the number of tuples (i, j, k, l)
        //s.t 0 <= i, j, k, l < n
        //nums1[i] + nums2[j] + nums3[k] + nums4[l] == 0
        //Intuition: It is like TwoSum: add the first 2 arrays and put their sums in a dict. Then for the last 2 check for complement in the dict
        //Given four arrays A, B, C, D, count tuples(i, j, k, l) such that A[i]+B[j]+C[k]+D[l] == 0
        public static int FourSumCount(int[] a, int[] b, int[] c, int[] d)
        {
            var sums = new Dictionary<int, int>();
            foreach (var i in a)
            {
                foreach (var j in b)
                {
                    sums[i + j] = sums.GetValueOrDefault(i + j, 0) + 1;
                }
            }
            int count = 0;
            foreach (var i in c)
            {
                foreach (var j in d)
                {
                    if (sums.ContainsKey(-(i + j)))
                    {
                        count += sums[-(i + j)];
                    }
                }
            }
            return count;
        }


        //Given an array of integers nums and an integer target, return the indices of the two numbers such that they add up to target.
        //Assume only one solution exists and you can't use the same element twice
        //Intuition : Two numbers that add up to a target; use complement num1 + num2 = target, num1 = target - num2 (num1 is the complement so if I find complement in the dict, I have my answer)
        public static int[] TwoSum(int[] nums, int target)
        {
            if (nums.Length == 0) return [];
            var result = new int[] { };
            var dict = new Dictionary<int, int>();
            for(int i=0; i < nums.Length; i++)
            {
                int comp = target - nums[i];
                if (dict.ContainsKey(comp))
                    return [dict[comp], i];
                dict[nums[i]] = dict.GetValueOrDefault(nums[i], i);
            }
            return result;
        }
    }
}
