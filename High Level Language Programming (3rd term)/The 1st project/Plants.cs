using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace The_1st_project
{
    class Watermelon : IGrowable
    {
        private readonly DateTime landingDay;
        public string Name { get; private set; }
        public bool IsDone { get; private set; }
        public int HP { get; private set; }
        public TimeSpan Age { get; private set; }
        //in meters
        public float Diameter { get; private set; }
        //brief status description
        public string HealthStatus { get; private set; }

        public Watermelon()
        {
            Name = "Арбуз";
            landingDay = DateTime.Now;
            HP = 100;
            Age = TimeSpan.Zero;
            Diameter = 0.4f;
            HealthStatus = "Хорошее";
            IsDone = false;
            Live();
        }

        public Watermelon(float diameter) : this()
        {
            Diameter = diameter;
        }

        private void Live()
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

            Timer HarvestTimer = new Timer { Interval = 10000 };
            HarvestTimer.Elapsed += (Object source, ElapsedEventArgs e) =>
            {
                if (HealthStatus.Equals("Завяло"))
                {
                    HarvestTimer.Stop();
                    HarvestTimer.Dispose();
                }
                else
                {
                    Console.WriteLine(Name + " пора собрать урожай");
                    IsDone = true;
                }
            };
            HarvestTimer.Start();
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
                return Name + " в полном порядке";
            else
            {
                Treat(25);
                return "Вы позаботились о "+ Name +". Теперь его состояние: " + HP + "/100";
            }
        }

        public string Touch()
        {
            Treat(1);
            return "Вы прикоснулись к "+Name+". Состояние дерева: " + HealthStatus;
        }
        public string Harvest()
        {
            IsDone = false;
            return "Вы собрали один" + Name;
        }

        public override string ToString()
        {
            string status = IsDone ? "да" : "нет";
            return "Тип растения: " + Name + "\nВозраст: " + Age.ToString() + "\nCостояние растения: " + HealthStatus + "\nДиаметр: "+ Diameter +"\nСозрел ли: " + status;
        }
    }
}
