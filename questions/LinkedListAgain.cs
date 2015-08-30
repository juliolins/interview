using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class LinkedListAgain
    {
        public static void Test()
        {
            LinkedListAgain list = new LinkedListAgain();

            list.Add(2);
            list.Add(1);
            list.Add(4);
            list.Add(3);            
            list.Add(5);

            //LinkedListAgain list2 = new LinkedListAgain();

            //list2.Add(2);
            //list2.Add(4);
            //list2.Add(6);
            //list2.Add(8);

            //list.MergeWith(list2);

            list.Print();
            list.SwapElements();
            list.Print();
            list.Add(6);
            list.Print();
        }


        private Node head;
        private Node tail;


        public LinkedListAgain()
        {
        }

        private LinkedListAgain(Node head, Node tail)
        {
            this.head = head;
            this.tail = tail;
        }

        public void Add(int x)
        {
            InsertIntoList(ref head, ref tail, new Node(x));
        }

        public void Print()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }

            Console.WriteLine();
        }

        //public static LinkedListAgain Merge(LinkedListAgain listA, LinkedListAgain listB)
        //{

        //}

        public void SwapElements()
        {
            Node first = head;
            Node last = null;

            while (first != null)
            {
                Node second = first.Next;
                if (second == null) break;//done
                
                if (head == first)
                {
                    head = second;
                }

                if (tail == second)
                {
                    tail = first;
                }

                //element before current exchange
                if (last != null)
                {
                    last.Next = second;
                }

                last = first;
                first.Next = second.Next;
                second.Next = first;

                first = first.Next;
            }
        }


        public void MergeWith(LinkedListAgain otherList)
        {
            Node myCurrent = head;
            Node otherCurrent = otherList.head;

            Node newHead = null;
            Node newTail = null;

            //pick one from each list and add both per iteration
            while (myCurrent != null || otherCurrent != null)
            {
                if (myCurrent != null)
                {
                    InsertIntoList(ref newHead, ref newTail, myCurrent);
                    myCurrent = myCurrent.Next;
                }

                if (otherCurrent != null)
                {
                    InsertIntoList(ref newHead, ref newTail, otherCurrent);
                    otherCurrent = otherCurrent.Next;
                }
            }

            this.head = newHead;
            this.tail = newTail;
        }

        private static void InsertIntoList(ref Node head, ref Node tail, Node newNode)
        {
            if (head == null)
            {
                head = newNode;
                tail = head;
            }
            else
            {
                tail.Next = newNode;
                tail = tail.Next;
            }
        }

        class Node
        {
            public int Data;
            public Node Next;

            public Node(int data)
            {
                this.Data = data;
            }
        }
    }
}
