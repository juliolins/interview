using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class BitArrayTest
    {
        public static void Test()
        {
            BitArray array = new BitArray(19);

            array.Set(0);
            array.Set(11);
            array.Set(19);

            Console.WriteLine(array.IsSet(0));
            Console.WriteLine(array.IsSet(11));
            Console.WriteLine(array.IsSet(19));
            Console.WriteLine(!array.IsSet(2));
            Console.WriteLine(!array.IsSet(13));
        }
    }


    public class BitArray
    {
        private byte[] array;

        public BitArray(int size)
        {
            array = new byte[size / 8 + 1];
        }

        public void Set(int n)
        {
            Set(n, true);
        }

        public void Reset(int n)
        {
            Set(n, false);
        }

        public bool IsSet(int n)
        {
            int bitIndex = n % 8;
            int byteIndex = n / 8;

            byte valueByte = (byte)(1 << bitIndex);

            return ((array[byteIndex] & valueByte) > 0);
        }

        private void Set(int n, bool isTrue)
        {
            int bitIndex = n % 8;
            int byteIndex = n / 8;

            if (isTrue)
            {
                byte valueByte = (byte) (1 << bitIndex);
                array[byteIndex] = (byte) (array[byteIndex] | valueByte);
            }
            else
            {
                byte valueByte = (byte) ~(1 << bitIndex);
                array[byteIndex] = (byte)(array[byteIndex] & valueByte);
            }
        }
    }
}
