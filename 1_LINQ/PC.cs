using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_LINQ
{
    class PC
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CPUType { get; set; }
        public int CPUFrequency { get; set; }
        public int RAMSize { get; set; }
        public int HDDSize { get; set; }
        public int VideoSize { get; set; }
        public int Cost { get; set; }
        public int Count { get; set; }

        public void Print()
        {
            Console.WriteLine($"{ID}, {Name}, {CPUType}");
        }
    }
}
