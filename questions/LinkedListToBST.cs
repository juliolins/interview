using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class LinkedListToBST
    {
        public static void Test()
        {
            var list = BuildList(new int[] { 1, 2, 3, 4, 5, 6, 7 });

            var tree = Convert(list);


        }



        static ListNode BuildList(int[] array)
        {
            ListNode head = new ListNode() { Value = array[0] };
            var current = head;

            for (int i = 1; i < array.Length; i++)
            {
                current.Next = new ListNode() { Value = array[i] };
                current = current.Next;
            }

            return head;
        }


        static TreeNode Convert(ListNode head)
        {
            int n = Count(head);

            return DoConvert(ref head, n);
        }

        static private TreeNode DoConvert(ref ListNode head, int n)
        {
            if (n <= 0)
            {
                return null;
            }

            TreeNode left = DoConvert(ref head, n / 2);

            TreeNode root = new TreeNode() { Value = head.Value, Left = left };

            head = head.Next;

            root.Right = DoConvert(ref head, n - n / 2 - 1);

            return root;
        }

        static int Count(ListNode head)
        {
            int count = 0;
            while (head != null)
            {
                count++;
                head = head.Next;
            }

            return count;
        }

        class ListNode
        {
            public int Value { get; set; }
            public ListNode Next { get; set; }
        }

        class TreeNode
        {
            public int Value { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
        }
    }
}
