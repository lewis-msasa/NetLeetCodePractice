using InterviewPrepsLeetCode.LinkedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrepsLeetCode.Tests
{
    public class LinkedListProblemsTests
    {
        public static IEnumerable<object[]> MergeKListTestArray()
        {
           yield return new object[]
           {
                new ListNode[] { new int[] { 1, 4, 5 }.ArrayToListNode(), new int[] { 1, 3, 4 }.ArrayToListNode(), new int[] { 2, 6 }.ArrayToListNode() },
                new int[] { 1, 1, 2, 3, 4, 4, 5, 6 }
          };
        }
        [Theory]
        [InlineData(new int[] { 1, 2, 4 }, new int[] { 1, 3, 4 }, new int[] { 1, 1, 2, 3, 4, 4 })]
        public void MergeTwoSortedLists_ReturnSortedList(int[] arr1, int[] arr2, int[] expected )
        {
            var result = LinkedListProblems.MergeTwoSortedLists(arr1.ArrayToListNode(), arr2.ArrayToListNode());
            Assert.Equal(expected, result.ListNodeToArray());
        }
        [Theory]
        [MemberData(nameof(MergeKListTestArray))]
        public void MergeKListsBrute_ReturnSortedList(ListNode[] lists, int[] expected)
        {
            var result = LinkedListProblems.MergeKListsBrute(lists);
            var r = result.ListNodeToArray();
            Assert.Equal(expected, r);
        }
        [Theory]
        [MemberData(nameof(MergeKListTestArray))]
        public void MergeKListsHeapSort_ReturnSortedList(ListNode[] lists,int[] expected)
        {
            var result = LinkedListProblems.MergeKListsHeapSort(lists);
            var r = result.ListNodeToArray();
            Assert.Equal(expected, r);
        }
        [Theory]
        [MemberData(nameof(MergeKListTestArray))]
        public void MergeKLists_ReturnSortedList(ListNode[] lists, int[] expected)
        {
            var result = LinkedListProblems.MergeKLists(lists);
            var r = result.ListNodeToArray();
            Assert.Equal(expected, r);
        }
    }
    public static class Helpers
    {
        public static ListNode ArrayToListNode(this int[] arr)
        {
            var dummy = new ListNode(0);
            var tail = dummy;
            for (int i = 0; i < arr.Length; i++)
            {
                var v = arr[i];
                tail.Next = new ListNode(v);
                tail = tail.Next;
            }
            return dummy.Next;
        }
        public static int[] ListNodeToArray(this ListNode node)
        {
            var list = new List<int>();
            while (node != null)
            {
                list.Add(node.Value);
                node = node.Next;
            }
            return list.ToArray();
        }
    }
}
