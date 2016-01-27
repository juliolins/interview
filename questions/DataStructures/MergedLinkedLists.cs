using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.DataStructures
{
    public class MergedLinkedLists
    {

        public static void Test()
        {
            //int[] a1 = new int[] { 5,7,17,13,11 };
            //int[] a2 = new int[] { 10, 12, 2, 4, 6, 0, 20 };

            //Node l1 = CreateList(a1);
            //Node l2 = CreateList(a2);

            //Enumerate(l1).PrintToConsole();
            //Enumerate(l2).PrintToConsole();

            //Merge(ref l1, ref l2);

            //Enumerate(l1).PrintToConsole();
            //Enumerate(l2).PrintToConsole();

            int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            Node list = CreateList(a);
            Enumerate(list).PrintToConsole();
            Reverse2(ref list, 3);
            Enumerate(list).PrintToConsole();
        }

        static Node CreateList(int[] array)
        {
            if (array.Length == 0) return null;

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

        //http://www.geeksforgeeks.org/merge-a-linked-list-into-another-linked-list-at-alternate-positions/
        static void Merge(ref Node headFirst, ref Node headSecond)
        {
            if (headFirst == null)
            {
                return;
            }

            Node currentFirst = headFirst;

            while (currentFirst != null && headSecond != null)
            {
                Node temp = currentFirst.Next;
                currentFirst.Next = headSecond;
                headSecond = headSecond.Next;

                currentFirst = currentFirst.Next;
                currentFirst.Next = temp;
                currentFirst = currentFirst.Next;
            }
        }

        //http://www.geeksforgeeks.org/reverse-a-list-in-groups-of-given-size/
        static void Reverse(ref Node head, int k)
        {
            if (head == null || k == 1) return;

            Node current = head;
            head = null;
            int count = 0;

            Node tempTail = null;
            Node tempHead = null;
            Node lastTail = null;

            while (current != null)
            {
                count++;
                Node next = current.Next;

                if (tempTail == null)
                {
                    tempTail = current;
                    tempHead = tempTail;
                }
                else
                {
                    current.Next = tempHead;
                    tempHead = current;
                }

                if (count == k || next == null)
                {
                    count = 0;

                    if (head == null)
                    {
                        lastTail = tempTail;
                        head = tempHead;
                        tempTail.Next = next;
                        tempTail = tempHead = null;
                    }
                    else
                    {
                        lastTail.Next = tempHead;
                        lastTail = tempTail;
                        tempTail.Next = next;
                        tempTail = tempHead = null;
                    }
                }

                current = next;
            }
        }

        static void Reverse2(ref Node head, int k)
        {
            head = ReverseRec(head, k);
        }

        //http://www.geeksforgeeks.org/reverse-a-list-in-groups-of-given-size/
        static Node ReverseRec(Node head, int k)
        {
            Node current = head;
            Node prev = null;
            Node next = null;
            int count = 0;

            while (count < k && current != null)
            {
                next = current.Next;                
                current.Next = prev;
                prev = current;
                current = next;
                count++;
            }

            if (next != null)
            {
                head.Next = ReverseRec(next, k);
            }

            return prev;
        }

        class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }
        }
    }
}
