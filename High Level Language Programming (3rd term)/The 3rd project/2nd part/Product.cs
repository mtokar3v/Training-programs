using System;

namespace _2nd_part
{
    public class Product : IDisposable
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Size { get; set; }

        public void Dispose()
        {
            Console.WriteLine("Поздравляю, вы вызвали Dispose, жаль что он бесполезен");
            GC.SuppressFinalize(this);
        }

        ~Product()
        {
            Dispose();
        }
    }
}
