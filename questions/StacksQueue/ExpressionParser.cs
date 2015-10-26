using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.StacksQueue
{
    public class ExpressionParser
    {
        public static void Test()
        {
            Console.WriteLine(Compute("((3 + 4) * 50)"));
        }

        public static int Compute(string expression)
        {
            Stack<int> valueStack = new Stack<int>();
            Stack<char> symbolStack = new Stack<char>();
            int operand = -1;

            for (int i = 0; i < expression.Length; i++)
            {
                char ch = expression[i];


                if (ch >= '0' && ch <= '9')
                {
                    if (operand > 0)
                    {
                        operand *= 10;
                        operand += ch - '0';
                    }
                    else
                    {
                        operand = ch - '0';
                    }
                }
                else if (operand > 0)
                {
                    valueStack.Push(operand);
                    operand = -1;
                } 
                    
                if (ch == '+' || ch == '*')
                {
                    symbolStack.Push(ch);
                }
                else if (ch == ')')
                {
                    char symbol = symbolStack.Pop();

                    if (symbol == '+')
                    {
                        valueStack.Push(valueStack.Pop() + valueStack.Pop());
                    }
                    else
                    {
                        valueStack.Push(valueStack.Pop() * valueStack.Pop());
                    }
                }

            }

            return valueStack.Pop();
        }
    }
}
