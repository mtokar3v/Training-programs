using System;
using System.Timers;

namespace The_1st_project
{
    abstract class Tree : IGrowable
    {
        public string Name { get; set; }
        private readonly DateTime landingDay;
        private readonly int maxFruitAmount;
        public int HP { get; private set; }
        public int NowFruitAmount { get; private set; }
        public TimeSpan Age { get; private set; }
        //in meters
        public float Height { get; private set; }
        //brief status description
        public string HealthStatus { get; private set; }

        public Tree(string name)
        {
            Name = name;
            landingDay = DateTime.Now;
            Age = TimeSpan.Zero;
            HP = 100;
            Height = 3f;
            HealthStatus = "Хорошее";
            NowFruitAmount = 0;
            maxFruitAmount = 200;
            Live();
        }

        public Tree(string name, float height) : this(name)
        {
            Height = height;
        }

        public Tree(string name, int fruitAmount) : this(name)
        {
            maxFruitAmount = fruitAmount;
        }
        public Tree(string name, float height, int fruitAmount) : this(name, height)
        {
            maxFruitAmount = fruitAmount;
        }

        public override string ToString()
        {
            return "Тип дерева: " + Name + "\nВозраст: " + Age.ToString() + "\nCостояние дерева: " + HealthStatus + "\nУрожай: " + NowFruitAmount;
        }

        private void Treat(int hp)
        {
            HP += hp;
            if (HP > 100)
                HP = 100;
        }

        //get 25HP
        public virtual string TakeCare()
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

        protected virtual void Live()
        {
            Timer AgeTimer = new Timer { Interval = 1000 };
            AgeTimer.Elapsed += (Object source, ElapsedEventArgs e) =>
            {
                if (HealthStatus.Equals("Завяло"))
                {
                    AgeTimer.Stop();
                    AgeTimer.Dispose();
                }
                else
                {
                    Age = DateTime.Now.Subtract(landingDay);
                }
            };
            AgeTimer.Start();

            Timer HPtimer = new Timer { Interval = 5000 };
            HPtimer.Elapsed += (Object source, ElapsedEventArgs e) =>
            {
                int _hp = 5;

                Console.WriteLine(Name + " потерял(а/о) " + _hp + " ед. здоровья");
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
                    HPtimer.Dispose();
                }
            };
            HPtimer.Start();

            Timer HarvestTimer = new Timer { Interval = 1000 };
            HarvestTimer.Elapsed += (Object source, ElapsedEventArgs e) =>
            {
                if (HealthStatus.Equals("Завяло"))
                {
                    HarvestTimer.Stop();
                    HarvestTimer.Dispose();
                }
                else
                {
                    int fruit = 1;
                    if (NowFruitAmount == maxFruitAmount)
                        Console.WriteLine(Name + " пора собрать урожай");
                    else
                        NowFruitAmount += fruit;
                }
            };
            HarvestTimer.Start();
        }

        public string Harvest()
        {
            int harvest = NowFruitAmount;
            NowFruitAmount = 0;
            return "Вы собрали: " + harvest + " плодов";
        }
        public abstract string GetPerfectMusic();
    }

    class Cherry : Tree
    {
        public int BeetlesAmount { get; private set; }
        public Cherry() : base("Вишня")
        {
            BeetlesAmount = 0;
        }

        public Cherry(float height) : base("Вишня", height)
        {
            BeetlesAmount = 0;
        }

        public Cherry(int fruitAmount) : base("Вишня", fruitAmount)
        {
            BeetlesAmount = 0;
        }

        public Cherry(float height, int fruitAmount) : base("Вишня", height, fruitAmount)
        {
            BeetlesAmount = 0;
        }

        protected override void Live()
        {
            base.Live();
            Timer BeetlesSpawnTimer = new Timer { Interval = 10000 };
            BeetlesSpawnTimer.Elapsed += (Object source, System.Timers.ElapsedEventArgs e) =>
            {
                if (HealthStatus.Equals("Завяло"))
                {
                    BeetlesSpawnTimer.Stop();
                    BeetlesSpawnTimer.Dispose();
                }
                else
                {
                    BeetlesAmount++;
                }
            };
            BeetlesSpawnTimer.Start();
        }

        override public string TakeCare()
        {
            BeetlesAmount = 0;
            return base.TakeCare() + ", вредителей больше нет";
        }

        public override string ToString()
        {
            return base.ToString() + "\nКоличество вредителей: " + BeetlesAmount;
        }

        override public string GetPerfectMusic()
        {
            return "Modern Talking - Cheri Cheri Lady";
        }   
    }

    class Apple : Tree
    {
        public int NewtonAmount { get; set; }
        public Apple() : base("Яблоня")
        {
            NewtonAmount = 0;
        }

        public Apple(float height) : base("Яблоня", height)
        {
            NewtonAmount = 0;
        }

        public Apple(int fruitAmount) : base("Яблоня", fruitAmount)
        {
            NewtonAmount = 0;
        }

        public Apple(float height, int fruitAmount) : base("Яблоня", height, fruitAmount)
        {
            NewtonAmount = 0;
        }

        public override string ToString()
        {
            return base.ToString() + "\nКоличество cидящих под деревом Ньютонов: " + NewtonAmount;
        }

        override public string GetPerfectMusic()
        {
            return "Русская народная песня - Эх, яблочко, да на тарелочке";
        }
    }

    sealed class Maple : Tree
    {
        public bool IsNearRiver { get; set; }

        public Maple() : base("Клен")
        {
            IsNearRiver = false;
        }

        public Maple(float height) : base("Клен", height)
        {
            IsNearRiver = false;
        }

        public Maple(float height, int fruitAmount) : base("Клен", height, fruitAmount)
        {
            IsNearRiver = false;
        }

        public override string ToString()
        {
            string answer = string.Empty;
            answer = IsNearRiver ? "да" : "нет"; 
            return base.ToString() + "\nРека рядом: " + answer;
        }

        override public string GetPerfectMusic()
        {
            return "Фёдор Добронравов - Там где клён шумит";
        }
    }
}


