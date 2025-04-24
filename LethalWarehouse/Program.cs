using System;
using System.Collections.Generic;
using System.Linq;
//Mogło być równieź KuriozumWarehouse ale chce LethalWarehouse
namespace LethalWarehouse
{
    public static class Program
    {
        public class Item
        {
            public string Name { get; set; }
            public double WeightKg { get; set; }
            public int WeirdnessLevel { get; set; }
            public bool IsFragile { get; set; }
        }
        public class Warehouse
        {
            //nie wiem. list
        }
        public static void Main()
        {
            //max pojemność magazynu
            Console.WriteLine("Enter warehouse item capacity: ");
            int maxCapacity = int.Parse(Console.ReadLine());
            //max waga magazynu
            Console.WriteLine("Enter warehouse max weight in kg: ");
            double maxWeight = double.Parse(Console.ReadLine());

            //Warehouse warehouse = new Warehouse(maxCapacity, maxWeight);
        }
    }
}