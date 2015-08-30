using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class StreamReaderTest
    {
        public static void Test()
        {
            byte[] bytes = new byte[6];

            BufferedStreamReader reader = new BufferedStreamReader();

            reader.Read(bytes);

            bytes.PrintToConsole();
        }



    }

    public class BufferedStreamReader
    {
        private const int BLOCK_SIZE = 4;

        private byte[] readBuffer = new byte[BLOCK_SIZE];
        private int readIndex = 0;

        private FourBytesStreamReader reader = new FourBytesStreamReader();

        public BufferedStreamReader()
        {
            Update();
        }

        //reads the size of the buffer
        public void Read(byte[] buffer)
        {
            int bytesToRead = buffer.Length;
            int start = 0;

            while (bytesToRead > 0)
            {
                int bytesCopied = CopyReadBytes(buffer, start, bytesToRead);
                start += bytesCopied;
                bytesToRead -= bytesCopied;

                Update();
            }
        }

        private void Update()
        {
            reader.Read(readBuffer);
            readIndex = 0;
        }

        private int CopyReadBytes(byte[] buffer, int start, int maxBytes)
        {
            Array.Copy(readBuffer, readIndex, buffer, start, Math.Min(maxBytes,  BLOCK_SIZE - readIndex));
            return BLOCK_SIZE - readIndex;
        }
    }

    public class FourBytesStreamReader 
    {
        private byte index = 1;

        public byte[] Read(byte[] buffer)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = index++;
            }

            return buffer;
        }
    }
}
