using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class ShuffleNumbers
    {
        private static Random random = new Random();


        public static void Test()
        {
            Console.WriteLine(CountAll2s(250555555));
        }

        public static void Test1()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 , 6, 7, 8, 9, 0};

            int[] selected = SelectRandomly(array, 5);


            for (int i = 0; i < selected.Length; i++)
            {
                Console.Write(selected[i] + " ");
            }

            Console.WriteLine();

        }

        public static void Test0()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };

            Shuffle(array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
            array = new int[] { 1, 2, 3, 4, 5 };
            Shuffle2(array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }

        public static void Shuffle(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int index = random.Next(i + 1, array.Length - 1);
                int temp = array[i];
                array[i] = array[index];
                array[index] = temp;

            }
        }

        public static void Shuffle2(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int index = random.Next(0, array.Length - 1);
                int temp = array[i];
                array[i] = array[index];
                array[index] = temp;

            }
        }


        public static int[] SelectRandomly(int[] array, int quantity)
        {
            int[] selected = new int[quantity];

            for (int i = 0; i < quantity; i++)
            {
                int index = random.Next(i, array.Length);
                selected[i] = array[index];

                //put used number to the left of the array
                int temp = array[i];
                array[i] = array[index];
                array[index] = temp;
            }

            return selected;
        }

        public static int CountAll2s(int n)
        {
            int count = 0;

            for (int i = 0; i <= n; i++)
            {
                count = count + Count2sRec(i);
            }

            return count;
        }

        public static int Count2sRec(int n)
        {
            if (n == 0) return 0;

            if (n % 10 == 2) return 1 + Count2sRec(n / 10);
            else return Count2sRec(n / 10);
        }

        public static int Count2sx(int n)
        {
            int count = 0;

            while (n > 0)
            {
                if (n % 10 == 2) count++;
                n = n / 10;
            }

            return count;
        }
    }
}
