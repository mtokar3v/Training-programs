using System;

namespace _2th_task
{
    class Program
    {
        static void Main(string[] args)
        {
            PrefixTree tree = new PrefixTree();
            try
            {
                tree.Add("АбВ");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine((int)'ѣ');
            Console.ReadKey();
        }
    }
}
