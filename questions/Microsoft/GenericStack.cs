using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Microsoft
{
    /*
    Implement a data structure that 
    -	Pushes an element
    -	Pops an element
    -	Gets min seen so far on the data structure without removing it. 
     */
    public class MyStack<T> where T : IComparable
    {
        private Element head;

        public void Push(T value)
        {
            var element = new Element() { Value = value };

            //manage the minimum
            if (head == null || value.CompareTo(head.Min) < 0)
            {
                element.Min = value;
            }
            else
            {
                element.Min = head.Min;
            }

            //add to the head
            element.Next = head;
            head = element;
        }

        public T Pop()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            var element = head;
            head = head.Next;
            return element.Value;
        }

        public T Minimum()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            return head.Min;
        }

        class Element
        {
            public T Value { get; set; }
            public T Min { get; set; }
            public Element Next { get; set; }
        }
    }

}
