using System;
using System.Collections.Generic;
using System.Text;

namespace The_2nd_project
{
    interface IProduct
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Size { get; set; }
    }

    public struct Product : IProduct
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Size { get; set; }
    } 
}
