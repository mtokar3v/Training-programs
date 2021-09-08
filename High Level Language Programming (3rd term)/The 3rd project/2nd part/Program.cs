using System;
using System.Collections.Generic;
using System.Text;

namespace _2nd_part
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к файлу");
            string path = Console.ReadLine();

            Stack<Product> products = new Stack<Product>();

            FileManager manager = new FileManager(path);

            manager.Pull(ref products);
            byte choise = byte.MaxValue;

            while (choise != 0)
            {
                Console.Clear();
                Console.WriteLine("Главное меню");
                Console.WriteLine("1.Вывести все товары");
                Console.WriteLine("2.Добавить нового элемента");
                Console.WriteLine("3.Удалить элемент + чистка");
                Console.WriteLine("4.Редактировать элемент");
                Console.WriteLine("5.Производство товара странами");
                Console.WriteLine("6.Товары с минимальной партией");
                Console.WriteLine("7.Вызвать Dispose для объекта");
                Console.WriteLine("8.Вызвать сборщик мусора");
                Console.WriteLine("9.Вывод товаров с поколением");
                Console.WriteLine("0.Выход");

                int id;
                string country;
                string name;

                try
                {
                    choise = byte.Parse(Console.ReadLine());
                }
                catch
                {
                    choise = byte.MaxValue;
                }

                switch (choise)
                {
                    case 1: PrintAllProducts(products); break;
                    case 2: products.Push(Add()); break;
                    case 3:
                        Console.Write("Введите номер товара: ");
                        try
                        {
                            id = Int32.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            id = Int32.MaxValue;
                        }
                        Del(ref products, id); break;
                    case 4:
                        Console.Write("Введите номер товара: ");
                        try
                        {
                            id = Int32.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            id = Int32.MaxValue;
                        }
                        Change(ref products, id); break;
                    case 5:
                        Console.WriteLine("Введите название товара");
                        name = Console.ReadLine();
                        PrintProductFromCountry(products, name);
                        break;
                    case 6:
                        Console.WriteLine("Введите название страны");
                        country = Console.ReadLine();
                        PrintMinProductFromCountry(products, country);
                        break;
                    case 7:
                        Console.WriteLine("Введите номер товара: ");
                        try
                        {
                            id = Int32.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            id = Int32.MaxValue;
                        }
                        callDispose(products, id); break;
                    case 8: callGC(); break;
                    case 9: PrintGenerationList(products); break;
                }

            }
            Console.ReadLine();
            manager.Push(products);
        }

        static Product Add()
        {
            Product product = new Product();
            Console.WriteLine("Создание новой позиции");
            Console.WriteLine("Введите название");
            try
            {
                product.Name = Console.ReadLine();
            }
            catch
            {
                product.Name = string.Empty;
            }
            Console.WriteLine("Введите страну-импортер");

            try
            {
                product.Country = Console.ReadLine();
            }
            catch
            {
                product.Country = string.Empty;
            }

            Console.WriteLine("Введите объем продукции");
            try
            {
                product.Size = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                product.Size = 0;
            }

            Console.ReadLine();
            return product;
        }

        static void Del(ref Stack<Product> products, int i)
        {
            Stack<Product> NewProducts = new Stack<Product>();
            int count = 0;
            string choise = string.Empty;
            if (i < products.Count)
            {
                foreach (var p in products)
                {
                    if (count == i)
                    {
                        Console.WriteLine("Вы хотите удалить товар (да/нет)");
                        PrintProduct((Product)p);

                        while (!choise.Equals("да") && !choise.Equals("нет"))
                        {
                            choise = Console.ReadLine();
                        }
                        break;
                    }
                    count++;
                }

                count = 0;

                if (choise.Equals("да"))
                {
                    foreach (var p in products)
                    {
                        if (count != i)
                            NewProducts.Push(p);
                        count++;
                    }
                    products = NewProducts;
                    Console.WriteLine("Товар удален");
                    GC.Collect(0);
                }
            }
            else
                Console.WriteLine("Товар не найден");
            Console.ReadLine();
        }

        static void PrintProduct(Product p)
        {
            Console.WriteLine("Название: " + p.Name);
            Console.WriteLine("Страна-импортер: " + p.Country);
            Console.WriteLine("Объем: " + p.Size);
        }

        static void Change(ref Stack<Product> products, int i)
        {
            Stack<Product> NewProducts = new Stack<Product>();
            int count = 0;
            string choise = string.Empty;
            if (i < products.Count)
            {
                foreach (var p in products)
                {
                    if (count == i)
                    {
                        Console.WriteLine("Вы хотите редактирвоать товар (да/нет)");
                        PrintProduct(p);

                        while (!choise.Equals("да") && !choise.Equals("нет"))
                        {
                            choise = Console.ReadLine();
                        }
                        break;
                    }
                    count++;
                }

                count = 0;
                if (choise.Equals("да"))
                {
                    foreach (var p in products)
                    {
                        if (count != i)
                            NewProducts.Push(p);
                        else
                            NewProducts.Push(Add());
                        count++;
                    }
                    products = NewProducts;
                    Console.WriteLine("Товар изменен");
                }
            }
            else
                Console.WriteLine("Товар не найден");
            Console.ReadLine();
        }

        static void PrintRow(string[] words, int col, int length)
        {
            int offset = length / (col + 1);

            string row = string.Empty;
            int partLetter = 0;
            for (int i = 0; i < col; i++)
            {
                int wordPlace = offset - words[i].Length / 2 - partLetter;
                partLetter = words[i].Length / 2;
                if (wordPlace <= 0)
                {
                    Console.WriteLine("Недостаточный размер строки");
                    return;
                }
                String space = new String(' ', wordPlace);
                row += string.Concat(space, words[i]);
            }

            row += new String(' ', length - row.Length);

            Console.WriteLine(String.Concat('|', row, '|'));
        }

        static void PrintProductFromCountry(Stack<Product> products, string name)
        {
            Dictionary<string, int> countryAndSize = new Dictionary<string, int>();

            foreach (Product product in products)
            {
                if (product.Name.Equals(name))
                {
                    if (countryAndSize.ContainsKey(product.Country))
                        countryAndSize[product.Country] += product.Size;
                    else
                        countryAndSize.Add(product.Country, product.Size);
                }

            }
            Console.WriteLine(countryAndSize.Count);
            Console.WriteLine('|' + new String('-', 50) + '|');
            PrintRow(new string[] { name }, 1, 50);
            Console.WriteLine('|' + new String('-', 50) + '|');

            PrintRow(new string[] { "Страна", "Общий объем товара" }, 2, 50);

            if (countryAndSize.Count == 0)
                PrintRow(new string[] { "нет данных" }, 1, 50);
            else
                foreach (var p in countryAndSize)
                {
                    PrintRow(new string[] { p.Key, p.Value.ToString() }, 2, 50);
                }

            Console.WriteLine('|' + new String('-', 50) + '|');
            Console.ReadLine();
        }

        static void PrintMinProductFromCountry(Stack<Product> products, string country)
        {
            Dictionary<string, int> ProductAndMinSize = new Dictionary<string, int>();

            int minSize = int.MaxValue;

            foreach (var i in products)
                if (i.Size < minSize && i.Country == country)
                    minSize = i.Size;

            //т.к. может быть несколько товаров с минимальным значением
            foreach (Product product in products)
            {
                if (product.Size == minSize && product.Country == country)
                    if (!ProductAndMinSize.ContainsKey(product.Name))
                        ProductAndMinSize.Add(product.Name, product.Size);
            }

            Console.WriteLine('|' + new String('-', 50) + '|');
            PrintRow(new string[] { country }, 1, 50);
            Console.WriteLine('|' + new String('-', 50) + '|');

            PrintRow(new string[] { "Продукт", "Объем товара" }, 2, 50);

            if (ProductAndMinSize.Count == 0)
                PrintRow(new string[] { "нет данных" }, 1, 50);
            else
                foreach (var p in ProductAndMinSize)
                {
                    PrintRow(new string[] { p.Key, p.Value.ToString() }, 2, 50);
                }

            Console.WriteLine('|' + new String('-', 50) + '|');
            Console.ReadLine();
        }

        static void PrintAllProducts(Stack<Product> products)
        {
            Console.WriteLine('|' + new String('-', 75) + '|');
            PrintRow(new string[] { "Все товары" }, 1, 75);
            Console.WriteLine('|' + new String('-', 75) + '|');

            PrintRow(new string[] { "Название", "Страна-импортер", "Объем" }, 3, 75);
            Console.WriteLine('|' + new String('-', 75) + '|');
            foreach (var i in products)
            {
                PrintRow(new string[] { i.Name, i.Country, i.Size.ToString() }, 3, 75);
            }
            Console.ReadLine();
        }

        static void callDispose(Stack<Product> products, int id)
        {
            int count = 0;
            if (id < products.Count)
            {
                foreach (var i in products)
                {
                    if (id == count)
                    {
                        i.Dispose();
                        break;
                    }
                    count++;
                }
            }
            else
                Console.WriteLine("Товар не найден");
            Console.ReadLine();
        }

        static void callGC()
        {
            GC.Collect();
            Console.WriteLine("Память очищена. Всего занято {0}", GC.GetTotalMemory(false));
            Console.ReadLine();
        }

        static void PrintGenerationList(Stack<Product> products)
        {
            foreach (var i in products)
            {
                PrintProduct(i);
                Console.WriteLine("Поколение объекта: {0}", GC.GetGeneration(i));
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
