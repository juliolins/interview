using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.DataStructures
{
    public class SortLinkedList
    {

        public static void Test()
        {
            int[] a = new int[] { 3, 6, 2, 5, 1, 8, 7, 9, 4 };
            Node list = Create(a);
            MergeSort(ref list);
            Enumerate(list).PrintToConsole();
        }

        static IEnumerable<int> Enumerate(Node node)
        {
            List<int> list = new List<int>();
            while (node != null)
            {
                list.Add(node.Value);
                node = node.Next;
            }

            return list;
        }


        static Node Create(int[] array)
        {
            Node head = null;
            Node tail = null;

            for (int i = 0; i < array.Length; i++)
            {
                if (head == null)
                {
                    head = new Node() { Value = array[i] };
                    tail = head;
                }
                else
                {
                    tail.Next = new Node() { Value = array[i] };
                    tail = tail.Next;
                }
            }

            return head;
        }

        static void MergeSort(ref Node head)
        {
            //0 or 1 list is sorted
            if (head == null || head.Next == null)
            {
                return;
            }

            Node first, second;
            SplitInHalves(head, out first, out second);

            //call recursively for each half
            MergeSort(ref first);
            MergeSort(ref second);

            //merge the results
            head = Merge(first, second);
        }

        static Node Merge(Node first, Node second)
        {
            if (first == null && second == null)
            {
                return null;
            }
            else if (second == null)
            {
                return first;
            }
            else if (first == null)
            {
                return second;
            }
            else //neither is null
            {
                Node result;
                if (first.Value <= second.Value)
                {
                    result = first;
                    result.Next = Merge(first.Next, second);
                }
                else
                {
                    result = second;
                    result.Next = Merge(first, second.Next);
                }

                return result;
            }
        }

        static void SplitInHalves(Node head, out Node first, out Node second)
        {
            if (head == null || head.Next == null)
            {
                first = head;
                second = null;
                return;
            }

            Node fast = head.Next;
            Node slow = head;

            while (fast != null)
            {
                fast = fast.Next;

                if (fast != null)
                {
                    slow = slow.Next;
                    fast = fast.Next; 
                }
            }

            first = head;
            second = slow.Next;
            slow.Next = null; //break the list in two now
        }

        class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }
        }
    }
}
