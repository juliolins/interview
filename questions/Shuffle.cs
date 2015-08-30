using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class ShuffleList
    {
        public static void Test()
        {
            ShuffleList list = new ShuffleList();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);

            list.Print();
            list.Shuffle();
            //list.Print();
        }


        private static Random random = new Random();

        private ListNode head;
        private ListNode tail;
        private int count = 0;

        public void Print()
        {
            ListNode current = head;

            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }

            Console.WriteLine();
        }

        public void Add(int x)
        {
            count++;

            if (head == null)
            {
                head = new ListNode(x);
                tail = head;
                return;
            }

            tail.next = new ListNode(x);
            tail = tail.next;
        }


        public static void Shuffle(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int j = random.Next(0, i + 1);

                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }


        public void Shuffle()
        {
            ShuffleRecursive(head, count);
        }

        private void ShuffleRecursive(ListNode head, int size)
        {
            if (size <= 1)
            {
                return;
            }

            int halfSize = size / 2;

            ListNode right = head;

            for (int i = 0; i < halfSize; i++)
            {
                right = right.next;
            }

            ShuffleRecursive(head, halfSize);
            ShuffleRecursive(right, size - halfSize);

            if (ShouldFlip() || true)
            {
                Flip(head, halfSize, right, size - halfSize);
            }
        }


        private void Flip(ListNode left, int leftSize, ListNode right, int rightSize)
        {
            ListNode leftTail = left;
            ListNode rightTail = right;

            //find last element on the left
            for (int i = 1; i < leftSize; i++)
            {
                leftTail = leftTail.next;
            }

            //find last element on the right
            for (int i = 1; i < rightSize; i++)
            {
                rightTail = rightTail.next;
            }

            ListNode temp = rightTail.next;
            
            //last element of right points to first element of the left
            rightTail.next = left;

            //last element of left, points to right's old tail
            leftTail.next = temp;
        }

        private bool ShouldFlip()
        {
            int number = random.Next(0, 1000);
            return number < 500;
        }

    }

    public class ListNode
    {
        public ListNode(int data)
        {
            this.data = data;
        }

        public int data;
        public ListNode next;
    }
}
