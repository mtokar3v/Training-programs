using System;
using System.Collections.Generic;
using System.Text;

namespace The_1st_project
{
    interface IGrowable
    {
        public string Name { get; }
        public int HP { get; }
        public string HealthStatus { get; }
        public TimeSpan Age { get;}
        public string TakeCare();
        public string Touch();
        public string Harvest();
    }
}
