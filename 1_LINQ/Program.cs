using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PC> listPC = new List<PC>()
            {
                new PC(){ID=1, Name="Laptop", CPUType="Intel Core", CPUFrequency=4096, RAMSize=16384, HDDSize=512000, VideoSize=2048, Cost=93250,Count=18},
                new PC(){ID=2, Name="Office Light", CPUType="Intel Xeon", CPUFrequency=3850, RAMSize=8192, HDDSize=256000, VideoSize=2048, Cost=54320,Count=48},
                new PC(){ID=3, Name="Office Hard", CPUType="Intel Xeon", CPUFrequency=3300, RAMSize=16384, HDDSize=512000, VideoSize=2048, Cost=65650,Count=32},
                new PC(){ID=4, Name="Home", CPUType="AMD Ryzen", CPUFrequency=4096, RAMSize=8192, HDDSize=512000, VideoSize=2048, Cost=75600,Count=30},
                new PC(){ID=5, Name="Multimedia", CPUType="AMD Turion", CPUFrequency=4096, RAMSize=8192, HDDSize=1024000, VideoSize=2048, Cost=95650,Count=41},
                new PC(){ID=6, Name="Workstation", CPUType="Intel Core", CPUFrequency=3680, RAMSize=16384, HDDSize=1024000, VideoSize=4096, Cost=150000,Count=44},
                new PC(){ID=7, Name="Workstation PRO", CPUType="Intel Xeon", CPUFrequency=4096, RAMSize=32768, HDDSize=2048000, VideoSize=4096, Cost=270567,Count=25},
                new PC(){ID=8, Name="Gamer Light", CPUType="AMD Ryzen", CPUFrequency=4096, RAMSize=16384, HDDSize=1024000, VideoSize=2048, Cost=160500,Count=22},
                new PC(){ID=9, Name="Gamer Gold", CPUType="Intel Core", CPUFrequency=4096, RAMSize=16384, HDDSize=2048000, VideoSize=4096, Cost=250456,Count=31},
                new PC(){ID=10, Name="Unbelievable", CPUType="AMD Epyc", CPUFrequency=5120, RAMSize=131072, HDDSize=8192000, VideoSize=8192, Cost=456300,Count=5},
            };

            string formatString = $"{"ID",3} {"Name",17} {"CPU",12} {"CPUF",4} {"RAMSize",7} {"HDD",7} {"Video",5} {"Cost",6} {"Count",3}";
            Console.Write("Введите название процессора: ");
            string cpuName = Console.ReadLine();
            Console.Write("Введите объем оперативной памяти: ");
            int ramSize = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\n\tКомпьютеры с процессором \"{cpuName}\"");
            List<PC> listCPUName = listPC
                .Where(d => d.CPUType == cpuName)
                .ToList();
            Print(listCPUName);

            Console.WriteLine($"\n\tКомпьютеры с объемом оперативной памяти не ниже \"{ramSize}\"");
            List<PC> listRAMSize = listPC
                .Where(d => d.RAMSize >= ramSize)
                .ToList();
            Print(listRAMSize);

            Console.WriteLine($"\n\tКомпьютеры отсортированы по увеличению стоимости");
            List<PC> listSortedCost = listPC
                .OrderBy(d => d.Cost)
                .ToList();
            Print(listSortedCost);

            Console.WriteLine($"\n\tКомпьютеры сгруппированы по типу процессора");
            IEnumerable<IGrouping<string, PC>> listGroupByCPUType = listPC
                .GroupBy(d => d.CPUType);

            Console.WriteLine(formatString);
            foreach (IGrouping<string, PC> group in listGroupByCPUType)
            {
                Console.WriteLine(group.Key);
                foreach (PC d in group)
                    Console.WriteLine($"{d.ID,3} {d.Name,17} {d.CPUType,12} {d.CPUFrequency,4} {d.RAMSize,7} {d.HDDSize,7} {d.VideoSize,5} {d.Cost,6} {d.Count,3}");
            }

            Console.WriteLine($"\n\tСамый дорогой компьютер");
            PC pcMaxCost = listPC
                .OrderByDescending(d => d.Cost)
                .FirstOrDefault();

            Console.WriteLine(formatString);
            Console.WriteLine($"{pcMaxCost.ID,3} {pcMaxCost.Name,17} {pcMaxCost.CPUType,12} {pcMaxCost.CPUFrequency,4} {pcMaxCost.RAMSize,7} {pcMaxCost.HDDSize,7} {pcMaxCost.VideoSize,5} {pcMaxCost.Cost,6} {pcMaxCost.Count,3}");

            Console.WriteLine($"\n\tСамый бюджетный компьютер");
            PC pcMinCost = listPC
                .OrderBy(d => d.Cost)
                .FirstOrDefault();
            Console.WriteLine(formatString);
            Console.WriteLine($"{pcMinCost.ID,3} {pcMinCost.Name,17} {pcMinCost.CPUType,12} {pcMinCost.CPUFrequency,4} {pcMinCost.RAMSize,7} {pcMinCost.HDDSize,7} {pcMinCost.VideoSize,5} {pcMinCost.Cost,6} {pcMinCost.Count,3}");

            Console.Write($"\nЕсть ли хотя бы один компьютер в количестве не менее 30 шт?: ");
            Console.WriteLine(listPC.Any(d => d.Count >= 30) ? "Есть" : "Нет");

            Console.ReadKey();
        }

        static void Print(List<PC> collection)
        {
            Console.WriteLine($"{"ID",3} {"Name",17} {"CPU",12} {"CPUF",4} {"RAMSize",7} {"HDD",7} {"Video",5} {"Cost",6} {"Count",3}");
            foreach (PC d in collection)
                Console.WriteLine($"{d.ID,3} {d.Name,17} {d.CPUType,12} {d.CPUFrequency,4} {d.RAMSize,7} {d.HDDSize,7} {d.VideoSize,5} {d.Cost,6} {d.Count,3}");
        }
    }
}
