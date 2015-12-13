using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.CrackingTough
{
    public class MedianTrackerTest
    {
        public static void Test()
        {
            var tracker = new MedianTracker();
            var numbers = new int[] { 3, 13, 7, 5, 21, 24, 39, 23, 40, 25, 14, 12, 56, 26, 29 };
            foreach (var number in numbers)
            {
                tracker.Add(number);
            }

            Console.WriteLine(tracker.GetMedian());
        }
    }

    public class MedianTracker
    {
        private PriorityHeap smallerHeap = new PriorityHeap((a, b) => a > b); //max heap
        private PriorityHeap greaterHeap = new PriorityHeap((a, b) => a < b); //min heap

        public void Add(int value)
        {
            if (smallerHeap.Count() == 0)
            {
                smallerHeap.Push(value);
            }
            else if (value < smallerHeap.Peek())
            {
                smallerHeap.Push(value);
            } else
            {
                greaterHeap.Push(value);
            }

            if (smallerHeap.Count() < greaterHeap.Count())
            {
                smallerHeap.Push(greaterHeap.Pop());
            }
            else
            {
                greaterHeap.Push(smallerHeap.Pop());
            }
        }

        public int GetMedian()
        {
            return smallerHeap.Peek();
        }
    }

    public class PriorityHeap
    {
        private int[] heap = new int[32];
        private int index = 1;
        private Func<int, int, bool> IsHigherPriority;

        public PriorityHeap(Func<int, int, bool> IsHigherPriority)
        {
            this.IsHigherPriority = IsHigherPriority;
        }

        public void Push(int x)
        {
            heap[index] = x;
            Swim(index);
            index++;
        }

        public int Count()
        {
            return index - 1;
        }

        public int Pop()
        {
            int max = heap[1];

            if (index > 1)
            {
                heap[1] = heap[--index];
                Sink(1);
            }

            return max;
        }

        public int Peek()
        {
            return heap[1];
        }

        private void Swim(int i)
        {
            while (i > 1 && !IsHigherPriority(heap[i / 2], heap[i]))
            {
                heap.Swap(i, i / 2);
                i /= 2;
            }
        }

        private void Sink(int i)
        {
            int child = i * 2;
            while (child < index && !IsHigherPriority(heap[i], heap[child]))
            {
                if (child + 1 < index && !IsHigherPriority(heap[child], heap[child + 1])) child++;

                heap.Swap(i, child);
                i = child;
                child *= 2;
            }
        }
    }
}
