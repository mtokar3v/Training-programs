using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace testUsingDLL
{
    class Program
    {
        [DllImport("localMax.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr findLocalMax( double[] array, int size);

        static void Main()
        {
            int size = 45;
            double[] array = new double[size];

            Random rand = new Random();
            for (int i = 0; i < size; i++)
                array[i] = rand.NextDouble() + rand.Next();

            IntPtr pint = findLocalMax(array, size);

            int[] index = new int[size];
            Marshal.Copy(pint, index, 0, size);

            Console.WriteLine("Ключ" + '\t' + '-' + '\t' + "Значение");

            for (int i = 0; i < size; i++)
            {
                if (index[i] < size)
                    Console.WriteLine(index[i] + "\t" + "-" + "\t" + array[i]);
            }

            Console.ReadKey();
        }
    }
}
