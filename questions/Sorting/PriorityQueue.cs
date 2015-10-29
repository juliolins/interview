using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Sorting
{
    public class PriorityQueueMaxTest
    {
        public static void Test()
        {
            const int size = 5;
            var pq = new PriorityQueueMax(size);
            int[] a = new int[] { 3, 2, 5, 1, 9, 4, 8, 6, 7 };

            for (int i = 0; i < a.Length; i++)
            {
                if (pq.Count() < size)
                {
                    pq.Add(a[i]);
                }
                else if (a[i] < pq.GetMax())
                {
                    pq.RemoveMax();
                    pq.Add(a[i]);
                }
            }

            pq.GetAll().PrintToConsole();
            pq.GetAll().PrintToConsole();
        }
    }



    public class PriorityQueueMax
    {
        private int index = 1;
        private int[] array;

        public PriorityQueueMax(int size)
        {
            array = new int[size + 1];
        }

        public int Count()
        {
            return index - 1;
        }

        public void Add(int x)
        {
            if (index >= array.Length)
            {
                throw new NotSupportedException();
            }

            array[index] = x;
            Swim(index);
            index++;
        }

        public int RemoveMax() 
        {
            int result = array[1];
            array.Swap(1, --index);
            Sink(1);

            return result;
        }

        public int GetMax()
        {
            return array[1];
        }


        private void Swim(int k)
        {
            while ((k / 2) >= 1)
            {
                if (array[k] > array[k / 2])
                {
                    array.Swap(k, k / 2);
                    k /= 2;
                }
                else
                {
                    break;
                }
            }
        }

        private void Sink(int k) 
        {
            while ((2*k + 1) < index) 
            {
                k *= 2;
                if (array[k] < array[k + 1]) k++;

                if (array[k / 2] < array[k])
                {
                    array.Swap(k / 2, k);
                }
            }
        }

        public IEnumerable<int> GetAll()
        {
            return array;
        }

        public IEnumerable<int> GetAllInOrder()
        {
            var list = new List<int>();
            List(array, 1, list);
            return list;
        }

        private void List(int[] array, int k, List<int> list)
        {
            if ((2 * k + 1) < array.Length)
            {
                if (array[2 * k] < array[(2 * k) + 1])
                {
                    List(array, 2 * k, list);
                    List(array, 2 * k + 1, list);
                }
                else
                {
                    List(array, 2 * k + 1, list);
                    List(array, 2 * k, list);
                }
            }

            list.Add(array[k]);
        }

    }
}
