using System;
using System.Text;

namespace _1st_part
{
    class GCProgram
    {
        private const long maxGarbage = 1000;

        static void Main()
        {
            GCProgram myGCCol = new GCProgram();

            Console.WriteLine("The highest generation is {0}", GC.MaxGeneration);

            myGCCol.MakeSomeGarbage();

            Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));

            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));

            GC.Collect(0);

            Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));

            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));

            GC.Collect(2);

            Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
            Console.Read();
        }

        void MakeSomeGarbage()
        {
            Version vt;
            StringBuilder sb;
            for (int i = 0; i < maxGarbage; i++)
            {
                vt = new Version();
                sb = new StringBuilder();
            }  
        }
    }

}
