using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Strings
{
    public class ExpressionEvaluator
    {
        public static void Test()
        {
            Console.WriteLine(Evaluate("(1 + (4 + 5 + 2) - 3) + (6 + 8)"));
        }


        //"(1 + (4 + 5 + 2) - 3) + (6 + 8)"
        public static int Evaluate(string expression)
        {
            var operands = new Stack<int>();
            var operators = new Stack<Operator>();

            int index = 0;

            while (index < expression.Length)
            {
                char ch = expression[index];
                if (IsOperator(ch))
                {
                    operators.Push(GetOperator(ch));
                }
                else if (IsOperand(ch))
                {
                    operands.Push(ReadNextOperand(expression, ref index));
                }
                else if (ch == ')')
                {
                    Compute(operands, operators);
                }

                index++;
            }

            while (operators.Count > 0)
            {
                Compute(operands, operators);
            }

            return operands.Pop();
        }

        private static void Compute(Stack<int> operands, Stack<Operator> operators)
        {
            int right = operands.Pop();
            int left = operands.Pop();
            Operator op = operators.Pop();

            operands.Push(Compute(left, right, op));
        }

        private static int Compute(int left, int right, Operator op)
        {
            if (op == Operator.Add)
            {
                return left + right;
            }
            else if (op == Operator.Sub)
            {
                return left - right;
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        private static int ReadNextOperand(string expression, ref int index)
        {
            int value = expression[index] - '0';
            while (++index < expression.Length && IsOperand(expression[index]))
            {
                value *= 10;
                value += expression[index] - '0';
            }

            //leave index at the last digit
            index--;

            return value;
        }

        private static bool IsOperator(char ch)
        {
            return ch == '+' || ch == '-';
        }

        private static bool IsOperand(char ch)
        {
            return ch >= '0' && ch <= '9';
        }

        private static Operator GetOperator(char ch)
        {
            if (ch == '+') 
            {
                return Operator.Add;
            }
            else if (ch == '-') 
            {
                return Operator.Sub;
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        enum Operator
        {
            Add,
            Sub
        }
    }
}
