using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class StackQueue
    {
        private Stack<int> leftStack = new Stack<int>();
        private Stack<int> rightStack = new Stack<int>();

        public void Enqueue(int x)
        {
            //move all to the left stack
            while (rightStack.Count > 0)
            {
                leftStack.Push(rightStack.Pop());
            }

            //push on left
            leftStack.Push(x);

            //move all back to the right stack
            while (leftStack.Count > 0)
            {
                rightStack.Push(leftStack.Pop());
            }
        }

        public int Dequeue()
        {
            return rightStack.Pop();
        }


        public static void Test()
        {
            StackQueue queue = new StackQueue();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
        }
    }
}
