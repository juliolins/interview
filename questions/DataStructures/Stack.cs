using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.DataStructures
{
    public class Stack
    {
        private int[] elements;
        private int index = -1;

        public Stack(int size)
        {
            elements = new int[size];
        }

        public void Push(int x)
        {
            index++;

            if (index < elements.Length)
            {
                elements[index] = x;
            }
            else
            {
                throw new Exception("Stack is full");
            }
        }

        public int Pop()
        {
            if (index < 0)
            {
                throw new Exception("Stack is empty");
            }

            return elements[index--];
        }

        public bool IsEmpty()
        {
            return index < 0;
        }
    }
}
