using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrepsLeetCode.Tests
{
    public class MiscellaneousProblemsTests
    {
        [Theory]
        [InlineData(new int[] { }, true)]
        [InlineData(new int[] {1,2,2 }, false)]
        public void SingleNumber_ArrayEmpty_ShouldReturn_NegativeOne(int[] nums, bool expected)
        {
            var result = MiscellaneousProblems.SingleNumber(nums);
            Assert.Equal(expected, result == -1);
        }
        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, true)]
        [InlineData(new int[] { 1, 2, 2 }, false)]
        public void SingleNumber_NoSingleNumber_ShouldReturn_Zero(int[] nums, bool expected)
        {
            var result = MiscellaneousProblems.SingleNumber(nums);
            Assert.Equal(expected, result == 0);
        }
        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, 0)]
        [InlineData(new int[] { 1, 2, 2 }, 1)]
        public void SingleNumber_ShouldReturn_SingleNumber(int[] nums, int expected)
        {
            var result = MiscellaneousProblems.SingleNumber(nums);
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(new int[] { }, true)]
        public void MajorityElement_EmptyArrayShould_Should_Return_Zero(int[] nums, bool expected)
        {
            var result = MiscellaneousProblems.MajorityElement(nums);
            Assert.Equal(expected, result == 0);
        }
    }
}
