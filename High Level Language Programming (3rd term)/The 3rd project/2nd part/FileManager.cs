
using System;
using System.Collections.Generic;
using System.IO;


namespace _2nd_part
{
    class FileManager : IDisposable
    {
        private readonly string _path;
        public FileManager(string path)
        {
            _path = path;
        }

        public void Push(Stack<Product> products)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(_path, FileMode.Create)))
            {
                foreach (var p in products)
                {
                    writer.Write(p.Name);
                    writer.Write(p.Country);
                    writer.Write(p.Size);
                }
            }
        }

        //тут должен быть стек
        public void Pull(ref Stack<Product> products)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(_path, FileMode.OpenOrCreate)))
            {
                int i = 0;

                Product product = new Product();

                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    switch (i % 3)
                    {
                        case 0: product.Name = reader.ReadString(); break;
                        case 1: product.Country = reader.ReadString(); break;
                        case 2: product.Size = reader.ReadInt32(); break;
                    }

                    if (i % 3 == 2)
                        products.Push(product);
                    i++;
                }
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        ~FileManager()
        {
            Dispose();
        }
    }
}