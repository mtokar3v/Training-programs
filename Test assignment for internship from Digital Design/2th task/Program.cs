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

            Console.WriteLine(tree.Find("абв"));
            Console.ReadKey();
        }
    }
}
