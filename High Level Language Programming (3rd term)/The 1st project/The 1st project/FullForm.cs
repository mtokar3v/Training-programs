using System;
using System.Collections.Generic;
using System.Text;

namespace The_1st_project
{
    interface IFullForm
    {
        public void Create(ref IGrowable plant);
    }

    class FullCherryTreeForm : IFullForm
    {
        public void Create(ref IGrowable plant)
        {
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

            if (harvest != 0 && h != 0)
                plant = new Cherry(h, harvest);
            else
                if (harvest != 0)
                plant = new Cherry(harvest);
            else if (h != 0)
                plant = new Cherry(h);
            else
                plant = new Cherry();
        }
    }

    class FullAppleTreeForm : IFullForm
    {
        public void Create(ref IGrowable plant)
        {
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

            if (harvest != 0 && h != 0)
                plant = new Apple(h, harvest);
            else
                if (harvest != 0)
                plant = new Apple(harvest);
            else if (h != 0)
                plant = new Apple(h);
            else
                plant = new Apple();

            Console.WriteLine("Сколько Ньютонов сидит под яблоней?");
            int count;
            try
            {
                count = Int32.Parse(Console.ReadLine());
                if (count < 0 || count > 42)
                    throw new Exception();
            }
            catch
            {
                count = 0;
            }
            ((Apple)plant).NewtonAmount = count;

        }
    }

    class FullMapleTreeForm : IFullForm
    {
        public void Create(ref IGrowable plant)
        {
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

            if (harvest != 0 && h != 0)
                plant = new Maple(h, harvest);
            else
                if (harvest != 0)
                plant = new Maple(harvest);
            else if (h != 0)
                plant = new Maple(h);
            else
                plant = new Maple();

            Console.WriteLine("Находится ли рядом река? (да/нет)");

            string answer = string.Empty;

            while (!answer.Equals("да") && !answer.Equals("нет"))
            {
                answer = Console.ReadLine();
            }

            if (answer.Equals("да"))
                ((Maple)plant).IsNearRiver = true;
            //else не нужен, так как он стоит по умолчанию

        }
    }

    class FullWatermelonForm : IFullForm
    {
        public void Create(ref IGrowable plant)
        {
            float diameter = 0;

            Console.WriteLine("Введите диаметр арбуза: ");
            try
            {
                diameter = float.Parse(Console.ReadLine());
                if (diameter < 0 || diameter > 2)
                    throw new Exception();
            }
            catch
            {
                diameter = 0;
            }

            if (diameter == 0)
                plant = new Watermelon();
            else
                plant = new Watermelon(diameter);
            
        }
    }
}
