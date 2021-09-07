using System;
using System.Collections.Generic;

namespace The_1st_project
{
    class Program
    {
        static void Main(string[] args)
        {
            byte choise = byte.MaxValue;

            Console.WriteLine("Какую часть тестируем?");
            Console.WriteLine("1.Первая часть");
            Console.WriteLine("2.Вторая часть");
            Console.WriteLine("3.Третья часть");

            while (choise < 1 || choise > 3)
            {
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
                    case 1: firstLVL(); break;
                    case 2: secondLVL(); break;
                    case 3: thirdLVL(); break;
                }
            }
        }

        static void firstLVL()
        {
            Console.Clear();
            byte choise = byte.MaxValue;
            float h = 0;
            int harvest = 0;
            Console.WriteLine("Введите высоту дерева: ");
            try
            {
                h = float.Parse(Console.ReadLine());
                if (h < 0 || h > 25)
                    throw new Exception();
            }
            catch
            {
                h = 0;
            }

            Console.WriteLine("Введите урожайность дерева:");
            try
            {
                harvest = Int32.Parse(Console.ReadLine());
                if (harvest < 0)
                    throw new Exception();
            }
            catch
            {
                harvest = 0;
            }

            LemonTree lemonTree = null;
            if (harvest != 0 && h != 0)
                lemonTree = new LemonTree(h, harvest);
            else
                if (harvest != 0)
                lemonTree = new LemonTree(harvest);
            else if (h != 0)
                lemonTree = new LemonTree(h);
            else
                lemonTree = new LemonTree();

            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Тестирование:");
            Console.WriteLine("1.Вывести возраст дерева");
            Console.WriteLine("2.Вывести урожайность");
            Console.WriteLine("3.Вывести высоту дерева");
            Console.WriteLine("4.Вывести состояние дерева");
            Console.WriteLine("5.Позаботься о дереве");
            Console.WriteLine("6.Потрогать дерево");
            Console.WriteLine("7.Собрать урожай");
            Console.WriteLine("8.Вывести название идеальной композиции для прогулки меж деревьев");
            Console.WriteLine("9.Вывести информацию о дереве");
            Console.WriteLine("0.Выход");
            Console.WriteLine("-----------------------------------------------------------------");

            while (choise != 0)
            {
                try
                {
                    choise = Byte.Parse(Console.ReadLine());
                }
                catch
                {
                    choise = byte.MaxValue;
                }
                switch (choise)
                {
                    case 1: Console.WriteLine(lemonTree.Age.ToString()); break;
                    case 2: Console.WriteLine(lemonTree.NowFruitAmount); break;
                    case 3: Console.WriteLine(lemonTree.Height); break;
                    case 4: Console.WriteLine(lemonTree.HealthStatus); break;
                    case 5: Console.WriteLine(lemonTree.TakeCare()); break;
                    case 6: Console.WriteLine(lemonTree.Touch()); break;
                    case 7: Console.WriteLine(lemonTree.Harvest()); break;
                    case 8: Console.WriteLine(LemonTree.GetPerfectMusic()); break;
                    case 9: Console.WriteLine(lemonTree.ToString()); break;
                    case 0: break;
                    default: Console.WriteLine("Неизвестная команда"); break;
                }
            }
            Console.ReadKey();
        }
        static void secondLVL()
        {
            Console.Clear();
            byte treeType = 0;

            while (treeType > 3 || treeType < 1)
            {
                Console.WriteLine("Что посадим?");
                Console.WriteLine("1.Вишня");
                Console.WriteLine("2.Яблоня");
                Console.WriteLine("3.Клен");

                try
                {
                    treeType = byte.Parse(Console.ReadLine());
                }
                catch
                {
                    treeType = 0;
                }
            }

            Tree tree = null;

            switch (treeType)
            {
                case 1: CherryHandler(tree); break;
                case 2: AppleHandler(tree); break;
                case 3: MapleHandler(tree); break;
            }
        }

        static void CherryHandler(IGrowable cherry)
        {
            if (cherry == null)
            {
                IFullForm form = new FullCherryTreeForm();
                form.Create(ref cherry);
            }
            byte choise = byte.MaxValue;

            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Тестирование:");
            Console.WriteLine("1.Вывести возраст дерева");
            Console.WriteLine("2.Вывести урожайность");
            Console.WriteLine("3.Вывести высоту дерева");
            Console.WriteLine("4.Вывести состояние дерева");
            Console.WriteLine("5.Позаботься о дереве");
            Console.WriteLine("6.Потрогать дерево");
            Console.WriteLine("7.Собрать урожай");
            Console.WriteLine("8.Вывести название идеальной композиции для прогулки меж деревьев");
            Console.WriteLine("9.Вывести информацию о дереве");
            Console.WriteLine("10.Вывести информацию о вредителях");
            Console.WriteLine("11.Вывести тип класса");
            Console.WriteLine("0.Выход");
            Console.WriteLine("-----------------------------------------------------------------");

            while (choise != 0)
            {
                try
                {
                    choise = Byte.Parse(Console.ReadLine());
                }
                catch
                {
                    choise = byte.MaxValue;
                }
                switch (choise)
                {
                    case 1: Console.WriteLine(((Tree)cherry).Age.ToString()); break;
                    case 2: Console.WriteLine(((Tree)cherry).NowFruitAmount); break;
                    case 3: Console.WriteLine(((Tree)cherry).Height); break;
                    case 4: Console.WriteLine(cherry.HealthStatus); break;
                    case 5: Console.WriteLine(cherry.TakeCare()); break;
                    case 6: Console.WriteLine(cherry.Touch()); break;
                    case 7: Console.WriteLine(cherry.Harvest()); break;
                    case 8: Console.WriteLine(((Tree)cherry).GetPerfectMusic()); break;
                    case 9: Console.WriteLine(cherry.ToString()); break;
                    case 10: Console.WriteLine("Всего вредителей: " + ((Cherry)cherry).BeetlesAmount); break;
                    case 11: Console.WriteLine("Класс: " + cherry.GetType()); break;
                    case 0: break;
                    default: Console.WriteLine("Неизвестная команда"); break;
                }
            }
            Console.ReadKey();
        }

        static void AppleHandler(IGrowable apple)
        {
            if (apple == null)
            {
                IFullForm form = new FullAppleTreeForm();
                form.Create(ref apple);
            }
            byte choise = byte.MaxValue;

            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Тестирование:");
            Console.WriteLine("1.Вывести возраст дерева");
            Console.WriteLine("2.Вывести урожайность");
            Console.WriteLine("3.Вывести высоту дерева");
            Console.WriteLine("4.Вывести состояние дерева");
            Console.WriteLine("5.Позаботься о дереве");
            Console.WriteLine("6.Потрогать дерево");
            Console.WriteLine("7.Собрать урожай");
            Console.WriteLine("8.Вывести название идеальной композиции для прогулки меж деревьев");
            Console.WriteLine("9.Вывести информацию о дереве");
            Console.WriteLine("10.Добавить одного Ньютона");
            Console.WriteLine("11.Вывести тип класса");
            Console.WriteLine("0.Выход");
            Console.WriteLine("-----------------------------------------------------------------");

            while (choise != 0)
            {
                try
                {
                    choise = Byte.Parse(Console.ReadLine());
                }
                catch
                {
                    choise = byte.MaxValue;
                }
                switch (choise)
                {
                    case 1: Console.WriteLine(((Tree)apple).Age.ToString()); break;
                    case 2: Console.WriteLine(((Tree)apple).NowFruitAmount); break;
                    case 3: Console.WriteLine(((Tree)apple).Height); break;
                    case 4: Console.WriteLine(((Tree)apple).HealthStatus); break;
                    case 5: Console.WriteLine(apple.TakeCare()); break;
                    case 6: Console.WriteLine(apple.Touch()); break;
                    case 7: Console.WriteLine(apple.Harvest()); break;
                    case 8: Console.WriteLine(((Tree)apple).GetPerfectMusic()); break;
                    case 9: Console.WriteLine(apple.ToString()); break;
                    case 10: ((Apple)apple).NewtonAmount++; Console.WriteLine("Вы добавили одного Ньютона"); break;
                    case 11: Console.WriteLine("Класс: " + apple.GetType()); break;
                    case 0: break;
                    default: Console.WriteLine("Неизвестная команда"); break;
                }
            }
            Console.ReadKey();
        }

        static void MapleHandler(IGrowable maple)
        {
            if (maple == null)
            {
                IFullForm form = new FullMapleTreeForm();
                form.Create(ref maple);
            }

            byte choise = byte.MaxValue;

            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Тестирование:");
            Console.WriteLine("1.Вывести возраст дерева");
            Console.WriteLine("2.Вывести урожайность");
            Console.WriteLine("3.Вывести высоту дерева");
            Console.WriteLine("4.Вывести состояние дерева");
            Console.WriteLine("5.Позаботься о дереве");
            Console.WriteLine("6.Потрогать дерево");
            Console.WriteLine("7.Собрать урожай");
            Console.WriteLine("8.Вывести название идеальной композиции для прогулки меж деревьев");
            Console.WriteLine("9.Вывести информацию о дереве");
            Console.WriteLine("10.Вывести тип класса");
            Console.WriteLine("0.Выход");
            Console.WriteLine("-----------------------------------------------------------------");

            while (choise != 0)
            {
                try
                {
                    choise = Byte.Parse(Console.ReadLine());
                }
                catch
                {
                    choise = byte.MaxValue;
                }
                switch (choise)
                {
                    case 1: Console.WriteLine(((Tree)maple).Age.ToString()); break;
                    case 2: Console.WriteLine(((Tree)maple).NowFruitAmount); break;
                    case 3: Console.WriteLine(((Tree)maple).Height); break;
                    case 4: Console.WriteLine(maple.HealthStatus); break;
                    case 5: Console.WriteLine(maple.TakeCare()); break;
                    case 6: Console.WriteLine(maple.Touch()); break;
                    case 7: Console.WriteLine(maple.Harvest()); break;
                    case 8: Console.WriteLine(((Tree)maple).GetPerfectMusic()); break;
                    case 9: Console.WriteLine(maple.ToString()); break;
                    case 10: Console.WriteLine("Класс: " + maple.GetType()); break;
                    case 0: break;
                    default: Console.WriteLine("Неизвестная команда"); break;
                }
            }
            Console.ReadKey();
        }

        static void thirdLVL()
        {
            Console.Clear();
            List<IGrowable> plants = new List<IGrowable>();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Что нужно сделать?");
            Console.WriteLine("1.Добавить растение на грядку");
            Console.WriteLine("2.Получить список растений");
            Console.WriteLine("3.Взаимодействовать с конкретным растением (Расширенное)");
            Console.WriteLine("4.Взаимодействовать с конкретным растением, как с объектом интерфейса IGrowable");
            Console.WriteLine("0.Выход");
            Console.WriteLine("----------------------------------------------------------------");

            byte choise = byte.MaxValue;

            while (choise != 0)
            {
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
                    case 1: plants.Add(AddPlant()); break;
                    case 2: PrintListOfPlants(plants); break;
                    case 3:
                        Console.WriteLine("Введите номер растения:");
                        int j = 0;
                        try
                        {
                            j = Int32.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Неверное значение");
                            j = Int32.MaxValue;
                        }
                        finally
                        {
                            if (j < plants.Count)
                            {
                                IGrowable growable = plants[j];
                                if (growable != null)
                                {
                                    if (growable is Apple)
                                    {
                                        AppleHandler(growable);
                                    }
                                    else
                                        if (growable is Cherry)
                                        CherryHandler(growable);
                                    else
                                        if (growable is Maple)
                                        MapleHandler(growable);
                                    else
                                        if (growable is Watermelon)
                                        WatermelonHandler(growable);
                                }

                            }
                            else
                                Console.WriteLine("Растение не найдено");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Введите номер растения:");
                        int i = 0;
                        try
                        {
                            i = Int32.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Неверное значение");
                            i = Int32.MaxValue;
                        }
                        finally
                        {
                            if (i < plants.Count)
                            {
                                IGrowable growable = plants[i];
                                if (growable != null)
                                    UseInterfaceAPI(growable);
                            }
                            else
                                Console.WriteLine("Растение не найдено");
                        }
                        break;



                    default: Console.WriteLine("Неизвестная команда"); break;
                }
            }

        }

        static void WatermelonHandler(IGrowable wm)
        {
            IFullForm form = new FullWatermelonForm();
            form.Create(ref wm);

            byte choise = byte.MaxValue;

            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Тестирование:");
            Console.WriteLine("1.Вывести возраст дерева");
            Console.WriteLine("2.Вывести диаметр арбуза");
            Console.WriteLine("3.Созрел ли арбуз?");
            Console.WriteLine("4.Вывести состояние дерева");
            Console.WriteLine("5.Позаботься о дереве");
            Console.WriteLine("6.Потрогать дерево");
            Console.WriteLine("7.Собрать урожай");
            Console.WriteLine("8.Вывести информацию о дереве");
            Console.WriteLine("9.Вывести тип класса");
            Console.WriteLine("0.Выход");
            Console.WriteLine("-----------------------------------------------------------------");

            while (choise != 0)
            {
                try
                {
                    choise = Byte.Parse(Console.ReadLine());
                }
                catch
                {
                    choise = byte.MaxValue;
                }
                switch (choise)
                {
                    case 1: Console.WriteLine(wm.Age.ToString()); break;
                    case 2: Console.WriteLine(((Watermelon)wm).Diameter); break;
                    case 3: Console.WriteLine(((Watermelon)wm).IsDone ? "Арбуз созрел" : "Арбуз еще не созрел"); break;
                    case 4: Console.WriteLine(wm.HealthStatus); break;
                    case 5: Console.WriteLine(wm.TakeCare()); break;
                    case 6: Console.WriteLine(wm.Touch()); break;
                    case 7: Console.WriteLine(wm.Harvest()); break;
                    case 8: Console.WriteLine(wm.ToString()); break;
                    case 9: Console.WriteLine("Класс: " + wm.GetType()); break;
                    case 0: break;
                    default: Console.WriteLine("Неизвестная команда"); break;

                }
            }
            Console.ReadKey();
        }

        static IGrowable AddPlant()
        {
            Console.WriteLine("Что посадим?");
            Console.WriteLine("1.Вишня");
            Console.WriteLine("2.Яблоня");
            Console.WriteLine("3.Клен");
            Console.WriteLine("4.Арбуз");

            byte choise = byte.MaxValue;

            try
            {
                choise = byte.Parse(Console.ReadLine());
            }
            catch
            {
                choise = byte.MaxValue;
            }

            IGrowable plant = null;
            IFullForm form;

            switch (choise)
            {
                case 1: form = new FullCherryTreeForm(); form.Create(ref plant); break;
                case 2: form = new FullAppleTreeForm(); form.Create(ref plant); break;
                case 3: form = new FullMapleTreeForm(); form.Create(ref plant); break;
                case 4: form = new FullWatermelonForm(); form.Create(ref plant); break;
            }
            return plant;
        }

        static void PrintListOfPlants(IEnumerable<IGrowable> plants)
        {
            Console.WriteLine("Название\t\tТип");
            int count = 0;
            foreach (var i in plants)
            {
                Console.WriteLine(count + ". " + i.Name + "\t\t" + i.GetType());
                count++;
            }
        }

        static void UseInterfaceAPI(IGrowable plant)
        {
            Console.Clear();
            Console.WriteLine("Тестирование");
            Console.WriteLine("1.Вывести название");
            Console.WriteLine("2.Вывести количество здоровья");
            Console.WriteLine("3.Вывести состояние здоровья");
            Console.WriteLine("4.Вывести возраст");
            Console.WriteLine("5.Позаботиться о растении");
            Console.WriteLine("6.Прикоснуться к растению");
            Console.WriteLine("7.Собрать урожай");
            Console.WriteLine("8.Вывести статус");
            Console.WriteLine("9.Вывести тип");
            Console.WriteLine("0.Выход");

            byte choise = byte.MaxValue;

            while (choise != 8)
            {
                try
                {
                    choise = Byte.Parse(Console.ReadLine());
                }
                catch
                {
                    choise = byte.MaxValue;
                }
                switch (choise)
                {
                    case 1: Console.WriteLine(plant.Name); break;
                    case 2: Console.WriteLine(plant.HP + "/100"); break;
                    case 3: Console.WriteLine(plant.HealthStatus); break;
                    case 4: Console.WriteLine(plant.Age); break;
                    case 5: Console.WriteLine(plant.TakeCare()); break;
                    case 6: Console.WriteLine(plant.Touch()); break;
                    case 7: Console.WriteLine(plant.Harvest()); break;
                    case 8: Console.WriteLine(plant.ToString()); break;
                    case 9: Console.WriteLine("Класс: " + plant.GetType()); break;
                    case 0: break;
                    default: Console.WriteLine("Неизвестная команда"); break;
                }
            }
            Console.ReadKey();

        }
    }
}
