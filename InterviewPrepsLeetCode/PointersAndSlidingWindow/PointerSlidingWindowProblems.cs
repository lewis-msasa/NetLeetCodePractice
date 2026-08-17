using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrepsLeetCode.PointersAndSlidingWindow
{
    public class PointerSlidingWindowProblems
    {
        //Problem: Given an array of people weights and a limit (max weight per boat), each boat carries at most 2 people. Return the minimum number of boats needed.
        //BRUTE FORCE: Look at all possible combinations
        //Intuition: Use two pointers: Sort the weights, compare left and right combo with target, if not, the left doesn't move because it is small.
        public static int NumberRescueBoats(int[] weights, int limit)
        {
            if(weights.Length == 0) return 0;
            var boats = 0;
            int left = 0, right = weights.Length - 1;
            Array.Sort(weights);
            while (left <= right)
            {
                if (weights[left] + weights[right] <= limit)
                {
                    left++;
                }

                right--;
                boats++;
            }
            return boats;
           
        }

        //For each boat, always take the heaviest remaining, then try to fill with the lightest + second lightest. Use left/right pointers and check if a triple fits, then a pair, then solo.
        public static int NumberRescueBoatsCanTakeThree(int[] weights, int limit)
        {
            Array.Sort(weights);
            int left = 0, right = weights.Length - 1, boats = 0;
            while (left <= right)
            {
                if (left == right)
                {
                    boats++;
                    break;
                }
                if (weights[left] + weights[left + 1] + weights[right] <= limit)
                {
                    left += 2;
                }
                else if (weights[left] + weights[right] <= limit)
                {
                    left++;
                }
                right--;
                boats++;

            }
            return boats;
        }

        //Given an array height where each element is a vertical line at index i, find two lines that together with the x-axis form a container holding the most water.
        //Brute force: all pairs while tracking maxArea
        //Intuition: the height to multiply by is the shortest, to have better area, we have to get a better shortest
        public static int MaxArea(int[] heights)
        {
            if(heights.Length == 0) return 0;
            int maxArea = 0, left =0, right = heights.Length -1;
            while (left < right)
            {
                var area = Math.Min(heights[left], heights[right]) * (right - left);
                maxArea = Math.Max(maxArea, area);
                //finding a better short one
                if (heights[left] < heights[right]) left++;
                else right--;
            }
            return maxArea;
           
        }

        //Problem: Given an array, return true if it's a valid mountain — meaning it strictly increases to a single peak, then strictly decreases. Peak cannot be the first or last element.
        //Look at all possible picks
        //INTUITION: climb then check if we are at the end or beginning...then descend...check if we are at the end
        public static bool ValidMountainArray(int[] arr)
        {
            if(arr.Length == 0) return false;
            int i = 0, n = arr.Length - 1;
            //ascend
            while (i < n && arr[i] < arr[i + 1]) i++;
            //check if at end or beginning
            if (i == 0 || i == n) return false;
            //descend
            while (i < n && arr[i] > arr[i + 1]) i++;

            return i == n;

        }
        //INTUITION - two pointers to ascend and descend and then compare the pointers. Edge case, when there's one element in the array
        public static bool ValidMountainArrayTwoPointers(int[] arr)
        {
            if (arr.Length < 2) return false;
            int left = 0; int right = arr.Length - 1;
            //ascend - the extra -1 to cater forthe left + 1
            while (left < arr.Length - 2 && arr[left] < arr[left+1]) left++;
            //descend - the extra +1 to cater for right - 1
            while(right > 1 && arr[right]  < arr[right-1]) right--;


            return left == right;
        }
        //Problem: Given an array, move all 0s to the end while maintaining the relative order of non-zero elements. Do it in-place.
        public static void MoveZeroes(int[] arr)
        {
            int slow = 0;
            for (int fast = 0; fast < arr.Length; fast++)
            {
                if (arr[fast] != 0)
                {
                    arr[slow] = arr[fast];
                    if (fast != slow) arr[fast] = 0;
                    slow++;
                }
            }
        }
        //Problem: Given a string, find the length of the longest substring with no duplicate characters.
        //Bruteforce intuition: loop n^2, track maxLength. In the second loop, init a hashset before you start it. In the inner loop break whenever you come something already seen
        public static int LengthOfLongestSubstringBruteForce(string s)
        {
            int maxLength = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var seen = new HashSet<char>();
                for (int j = 0; j < s.Length; j++)
                {
                    if (seen.Contains(s[j]))
                    {
                        break;
                    }
                    seen.Add(s[j]);
                    maxLength = Math.Max(maxLength, j - i + 1);

                }
            }
            return maxLength;
        }
        //Problem: Given a string, find the length of the longest substring with no duplicate characters.
        //use dict to track last seen of char(its index). As you look, check if character was already seen and after the current left(then update left). Update last seen of current char and update maxLength 
        public static int LengthOfLongestSubstring(string s)
        {
            int maxLength = 0;
            int left = 0;
            var lastSeen = new Dictionary<char, int>();
            for (int right = 0; right < s.Length; right++)
            {
                if (lastSeen.ContainsKey(s[right]) && lastSeen[s[right]] >= left)
                {
                    left = lastSeen[s[right]] + 1;
                }
                lastSeen[s[right]] = right;
                maxLength = Math.Max(maxLength, right - left + 1);
            }
            return maxLength;
        }
        public static int[] SearchRangeBruteForce(int[] nums, int target)
        {
            int first = -1, last = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    if (first == -1) first = i;
                    last = i;
                }
            }
            return [first, last];
        }
        public static int[] SearchRange(int[] nums, int target)
        {
            return [BinarySearch(nums, target, true), BinarySearch(nums, target, false)];
        }
        private static int BinarySearch(int[] nums, int target, bool biasLeft)
        {
            int result = -1, left = 0, right = nums.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    result = mid;
                    if (biasLeft) right = mid - 1;
                    else left = mid + 1;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else right = mid - 1;
            }
            return result;
        }
        public static int MissingNumberBrute(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i) return i;
            }
            return nums.Length;
        }
        public static int MissingNumber(int[] nums)
        {
            var set = new HashSet<int>(nums);
            for (int i = 1; i < nums.Length; i++)
            {
                if (!set.Contains(nums[i])) return i;
            }
            return -1;
        }
        public static int MissingNumberGaussian(int[] nums)
        {
            int n = nums.Length;
            int expected = n * (n + 1) / 2;
            int actual = nums.Sum();
            int diff = expected - actual;
            return diff == 0 ? -1 : diff;
        }
        public static int[] TwoSumBrute(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 1; j < nums.Length; j++)
                {
                    var sum = nums[j] + nums[i];
                    if (sum == target) return [i, j];
                }
            }
            return [-1, -1];
        }
        public static int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int comp = target - nums[i];
                if (dict.ContainsKey(comp)) return [nums[comp], i];

                dict[nums[i]] = i;
            }
            return [-1, -1];
        }

        //Problem: Given one array and a target, return all unique quadruplets that sum to target.
        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            var result = new List<IList<int>>();
            int n = nums.Length;
            Array.Sort(nums);

            for (int i = 0; i < n - 3; i++)
            {
                //skip duplicates
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                for (int j = i + 1; j < n - 2; j++)
                {
                    //skip duplicates
                    if (j > i + 1 && nums[j] == nums[j - 1]) continue;
                    int left = j + 1, right = n - 1;
                    while (left < right)
                    {
                        var sum = nums[i] + nums[j] + nums[left] + nums[right];
                        if (sum == target)
                        {
                            result.Add([nums[i], nums[j], nums[left], nums[right]]);
                            //skip duplicates
                            while (left < right && nums[left] == nums[left + 1]) left++;
                            while (left < right && nums[right] == nums[right - 1]) right--;
                            //move
                            left++; right--;
                        }
                        else if (sum < target) left++;
                        else right--;
                    }
                }
            }

            return result;
        }
        //Minimum Window Substring - Problem: Find the smallest window in s that contains all characters of t.
        //Intuition: Find a window that contains all and try to minimize. Use Hashmap for frequency calculation
        //Frequency of the substring
        //Initialize window and keep extending it right - as you extend, check if formed so far is required and try to minimize - as you minimize, update the current min
        public static string MinWindow(string s, string t)
        {
            if(s.Length == 0 || t.Length == 0) return "";
            //build substring freq dict
            var need = new Dictionary<char,int>();
            foreach (char c in t)
            {
                need[c] = need.GetValueOrDefault(c, 0) + 1;
            }
            int required = need.Count, formed = 0;
            //init
            var window = new Dictionary<char,int>();
            int left = 0, bestLeft = 0, bestLength = int.MaxValue;

            for(int right = 0; right < s.Length; right++)
            {
                //increase window by adding right
                char c = s[right];
                window[c] = window.GetValueOrDefault(c, 0) + 1;
                //check if c is enough now in substring freq dict, if yes increment frequency
                if (need.ContainsKey(c) && window[c] == need[c]) formed++;
                //check if window valid
                while(formed == required)
                {
                    //update best - left and right are indices that's why we are adding 1
                    if(right - left + 1 < bestLength)
                    {
                        bestLength = right - left + 1;
                        bestLeft = left;
                    }
                    //remove left char and check if the left char we are removing from window is in need and if it has enough counts, if not, decrement formed
                    char leftChar = s[left];
                    window[leftChar]--;
                    if(need.ContainsKey(leftChar) && window[leftChar] < need[leftChar])
                    {
                        formed--;
                    }

                    //minimize window
                    left++;
                }
            }

            return bestLength == int.MaxValue ? "" : s.Substring(bestLeft, bestLength);

        }

        //Given a string s, determine if it is a palindrome.
        //INTUITION: two pointers. Last and first. Skip non-digits and non-letters. compare first and last and return false if not equal
        public static bool IsPalindrome(string s)
        {
            if(s  == null || s.Length == 0) return false;
            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(s[left])) left++;
                while(left < right && !char.IsLetterOrDigit(s[right])) right--;

                if (char.ToLower(s[left]) != char.ToLower(s[right]))
                    return false;
                right--;
                left++;
            }

            return true;
        }
        //INTUITION: reverse the number using modulus and /10
        public static bool IsPalindromeNumber(int x)
        {
            var original = x;
            var expected = 0;
            while(x > 0)
            {
                expected = expected * 10 + x % 10;
                x /= 10;
            }
            return original == expected;
        }
    }
}
