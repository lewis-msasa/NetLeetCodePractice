using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrepsLeetCode.LinkedList
{

    public class ListNode
    {

        public int Value { get; set; }
        public ListNode? Next { get; set; }
        public ListNode(int value, ListNode? next = null) {

            Value = value;
            Next = next;
        }
    }
    public class LinkedListProblems
    {
        public static ListNode MergeTwoSortedLists(ListNode l1, ListNode l2)
        {
            var dummy = new ListNode(0);
            var tail = dummy;
            while (l1 != null && l2 != null)
            {
                if (l1.Value <= l2.Value)
                {
                    tail.Next = l1;
                    l1 = l1.Next;
                }
                else
                {
                    tail.Next = l2;
                    l2 = l2.Next;

                }
                tail = tail.Next;
            }
            tail.Next = l1 ?? l2;
            return dummy.Next;
        }
        // O ( N log k) - time
        // O ( k) - space
        public static ListNode MergeKListsHeapSort(ListNode[] lists)
        {

            var queue = new PriorityQueue<ListNode, int>();
            //put all first into heap sort
            foreach (var list in lists)
            {
                if (list != null)
                {
                    queue.Enqueue(list, list.Value);
                }
            }

            var dummy = new ListNode(0);
            var tail = dummy;
            while (queue.Count > 0)
            {

                var node = queue.Dequeue();
                tail.Next = node;
                tail = tail.Next;
                if (node.Next != null)
                {
                    queue.Enqueue(node.Next, node.Next.Value);
                }

            }
            return dummy.Next;
        }
        // O( N log k) - time
        // 0(1) - space
        public static ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0) return null;
            int interval = 1;
            while (interval < lists.Length)
            {
                for (int i = 0; i < lists.Length - interval; i += interval * 2)
                {
                    lists[i] = MergeTwoSortedLists(lists[i], lists[i + interval]);
                }
                interval *= 2;
            }
            return lists[0];
        }
        // O(N log N) - Time
        // O(N) - space
        public static ListNode MergeKListsBrute(ListNode[] lists)
        {
            //flatten
            var list = new List<int>();
            foreach (ListNode node in lists)
            {
                var current = node;
                while (current != null)
                {
                    list.Add(current.Value);
                    current = current.Next;
                }
            }

            //sort
            list.Sort();
            //create list
            var dummy = new ListNode(0);
            var tail = dummy;
            foreach(var value in list)
            {
                tail.Next = new ListNode(value);
                tail = tail.Next;
            }
            return dummy.Next;

        }
    }
}
