using System;
using System.Timers;

namespace The_1st_project
{
    class LemonTree
    {
        private readonly string name;
        private readonly int maxFruitAmount;
        private readonly DateTime landingDay;
        private int HP { get; set; }
        public TimeSpan Age { get; private set; }
        public int NowFruitAmount { get; private set; }
        //in meters
        public float Height { get; private set; }
        //brief status description
        public string HealthStatus { get; private set; }

        public LemonTree()
        {
            name = "Лимонное дерево";
            landingDay = DateTime.Now;
            Age = TimeSpan.Zero;
            HP = 100;
            NowFruitAmount = 0;
            maxFruitAmount = 200;
            Height = 2.6f;
            HealthStatus = "Хорошее";
            Live();
        }

        public LemonTree(float height) : this()
        {
            Height = height;
        }

        public LemonTree(int fruitAmount) : this()
        {
            maxFruitAmount = fruitAmount;
        }

        public LemonTree(float height, int fruitAmount) : this()
        {
            Height = height;
            maxFruitAmount = fruitAmount;
        }

        public override string ToString()
        {
            return "Тип дерева: " + name + ", Возраст: " + Age.ToString() + ", урожай: " + NowFruitAmount + ", состояние дерева: " + HealthStatus;
        }

        public string Harvest()
        {
            int harvest = NowFruitAmount;
            NowFruitAmount = 0;
            return "Вы собрали: " + harvest + " лимонов";
        }

        private void Treat(int hp)
        {
            HP += hp;
            if (HP > 100)
                HP = 100;
        }

        //get 25HP
        public string TakeCare()
        {
            if (HP == 100)
                return "Дерево в полном порядке";
            else
            {
                Treat(25);
                return "Вы позаботились о дереве. Теперь его состояние: " + HP + "/100";
            }
        }

        public string Touch()
        {
            Treat(1);
            return "Вы прикоснулись к дереву. Состояние дерева: " + HealthStatus;
        }

        private void Live()
        {
            Timer AgeTimer = new Timer { Interval = 1000 };
            AgeTimer.Elapsed += (Object source, System.Timers.ElapsedEventArgs e) =>
            {
                if (HealthStatus.Equals("Завяло"))
                    AgeTimer.Stop();
                else
                {
                    Age = DateTime.Now.Subtract(landingDay);
                }
            };
            AgeTimer.Start();

            Timer HarvestTimer = new Timer { Interval = 1000 };
            HarvestTimer.Elapsed += (Object source, System.Timers.ElapsedEventArgs e) =>
            {
                if (HealthStatus.Equals("Завяло"))
                    HarvestTimer.Stop();
                else
                {
                    int fruit = 1;
                    if (NowFruitAmount == maxFruitAmount)
                        Console.WriteLine(name + " пора собрать урожай");
                    else
                        NowFruitAmount += fruit;
                }
            };
            HarvestTimer.Start();
            Timer HPtimer = new Timer { Interval = 5000 };
            HPtimer.Elapsed += (Object source, ElapsedEventArgs e) =>
            {
                int _hp = 5;

                Console.WriteLine(name + " потеряло " + _hp + " ед. здоровья");
                HP -= _hp;

                if (HP >= 85 && !HealthStatus.Equals("Хорошее"))
                    HealthStatus = "Хорошее";
                else
                    if (HP < 85 && HP >= 35 && !HealthStatus.Equals("Нормальное"))
                    HealthStatus = "Нормальное";
                else
                    if (HP < 35 && !HealthStatus.Equals("Плохое"))
                    HealthStatus = "Плохое";
                else
                    if (HP <= 0 && !HealthStatus.Equals("Завяло"))
                {
                    HealthStatus = "Завяло";
                    HPtimer.Stop();
                }
            };
            HPtimer.Start();

        }

        public static string GetPerfectMusic()
        {
            return "The Beatles - Yellow Submarine";
        }
    }
}
