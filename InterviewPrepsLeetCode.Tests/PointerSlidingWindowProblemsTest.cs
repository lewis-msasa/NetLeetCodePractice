using InterviewPrepsLeetCode.PointersAndSlidingWindow;

namespace InterviewPrepsLeetCode.Tests
{
    public class PointerSlidingWindowProblemsTests
    {
        [Theory]
        [InlineData("", "", true)]
        [InlineData("notEmpty","", true)]
        [InlineData("notEmpty","notEmpty", false)]
        public void MinWindow_EmptyStringVars_Should_Return_EmptyString(string s, string t, bool expected)
        {
             var result = PointerSlidingWindowProblems.MinWindow(s,t);
            Assert.Equal(expected,result == "");
        }
        [Theory]
        [InlineData("ADOBECODEBANC", "ABC", "BANC")]
        [InlineData("a", "a", "a")]
        [InlineData("a", "aa", "")]
        public void MinWindow_Should_Return_MinSubString(string s, string t, string expected)
        {
            var result = PointerSlidingWindowProblems.MinWindow(s, t);
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData("", false)]
        public void IsPalindrome_StringEmpty_Return_False(string s, bool expected)
        {
            var result = PointerSlidingWindowProblems.IsPalindrome(s);
            Assert.Equal(expected, result);

        }
        [Theory]
        [InlineData("A man, a plan, a canal: Panama", true)]
        [InlineData("race a car", false)]
        public void Is_Palindrome_ContainsPalindrome_ReturnTrue(string s, bool expected)
        {
            var result = PointerSlidingWindowProblems.IsPalindrome(s);
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(121, true)]
        [InlineData(100, false)]
        public void Is_PalindromeNumber_ContainsPalindrome_ReturnTrue(int num, bool expected)
        {
            var result = PointerSlidingWindowProblems.IsPalindromeNumber(num);
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(new int[] { }, true)]
        public void NumberRescueBoats_Empty_ReturnZero(int[] weights, bool expected)
        {
            var result = PointerSlidingWindowProblems.NumberRescueBoats(weights,3);
            Assert.Equal(expected, result == 0);
        }
        [Theory]
        [InlineData(new int[] { 3, 2, 2, 1 }, 3, 3)]
        [InlineData(new int[] { 1, 2 },3,1)]
        [InlineData(new int[] { 3, 5, 3, 4 },5, 4)]
        public void NumberRescueBoats_Empty_ReturnNumberOfBoats(int[] weights, int limit, int expected)
        {
            var result = PointerSlidingWindowProblems.NumberRescueBoats(weights, limit);
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(new int[] { }, true)]
        public void MaxArea_EmptyArray_ReturnZero(int[] heights, bool expected)
        {
            var result = PointerSlidingWindowProblems.MaxArea(heights);
            Assert.Equal(expected, result == 0);
        }

        [Theory]
        [InlineData(new int[] { 1, 8, 6, 2, 5 }, 15)]
        [InlineData(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
        public void MaxArea_ReturnArea(int[] heights, int expected)
        {
            var result = PointerSlidingWindowProblems.MaxArea(heights);
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(new int[] { }, true)]
        public void ValidMountainArray_EmptyArray_ReturnsFalse(int[] vals, bool expected)
        {
            var result = PointerSlidingWindowProblems.ValidMountainArray(vals);
            Assert.Equal(expected, result == false);
        }
        [Theory]
        [InlineData(new int[] { 1, 3, 5, 4, 2 }, true)]
        [InlineData(new int[] { 1, 2, 2, 3 }, false)]
        [InlineData(new int[] { 1 }, false)]
        [InlineData(new int[] { 3, 2, 1 }, false)]
        [InlineData(new int[] {1,2,3 }, false)]
        public void ValidMountainArray_Valid_ReturnsTrue(int[] vals, bool expected)
        {
            var result = PointerSlidingWindowProblems.ValidMountainArrayTwoPointers(vals);
            Assert.Equal(expected, result);
        }
    }
}
