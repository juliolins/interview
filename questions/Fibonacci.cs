using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class Fibonacci
    {

        public static void Test()
        {
            //DateTime start = DateTime.Now;

            //int[] map = new int[43];
            //Console.WriteLine("Fibonacci(42) = " + F(42, map));
            //Console.WriteLine("Fibonacci(42) = " + Fib(42));

            //DateTime end = DateTime.Now;
            //Console.WriteLine("Seconds: " + (end - start).TotalSeconds);

            for (int i = 0; i <= 6; i++)
            {
                Console.WriteLine("FastFib(" + i + ") = " + FastFib(i));
            }
        }


        public static int FastFib(int n)
        {
            if (n <= 1) return n;

            int last = 0;
            int fib = 1;

            for (int i = 1; i < n; i++)
            {
                fib = fib + last;
                last = fib - last;
            }

            return fib;
        }

        public static int FibH(int n)
        {
            if (n <= 1) return n;

            return Fib(n - 1) + Fib(n - 2);
        }


































        public static int F(int x, int[] map)
        {
            if (x == 0)
            {
                return 0;
            }
            else if (x == 1)
            {
                return 1;
            }
            else if (map[x] > 0)
            {
                return map[x];
            }
            else
            {
                map[x] = F(x - 1, map) + F(x - 2, map);
                return map[x];
            }
        }
        public static int Fib(int x)
        {
            if (x <= 1)
            {
                return x;
            }

            int a = 0;
            int b = 1;

            for (int i = 2; i <= x; i++)
            {
                b = a + b; // new value of b is fatorial
                a = b - a; //keep old value of b in a
            }

            return b;
        }
    }
}
