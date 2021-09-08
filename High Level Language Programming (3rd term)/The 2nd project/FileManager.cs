using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace The_2nd_project
{
    class FileManager
    {
        private readonly string _path;
        public FileManager(string path)
        {
            _path = path;
        }

        public void Push(Stack<IProduct> products)
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
        public void Pull(ref Stack<IProduct> products)
        {
            using(BinaryReader reader = new BinaryReader(File.Open(_path, FileMode.OpenOrCreate)))
            {
                int i = 0;

                Product product = new Product();

                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    switch (i % 3) 
                    {
                        case 0: product.Name = reader.ReadString(); break;
                        case 1: product.Country = reader.ReadString();break;
                        case 2: product.Size = reader.ReadInt32();break;
                    }

                    if (i % 3 == 2)
                        products.Push(product);
                    i++;
                }
            }
        }
    }
}
