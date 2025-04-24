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

            public Item(string name, double weightKg, int weirdnessLevel, bool isFragile)
            {
                Name = name;
                WeightKg = Math.Round(weightKg, 3);//zaokrąglenie do 3 po ,
                WeirdnessLevel = weirdnessLevel;
                IsFragile = isFragile;
            }
            //Desc 
            public string Desc()
            {
                return $"{{\n\t\"name\": \"{Name}\",\n\t\"weight_kg\": {WeightKg},\n\t\"Weird 1-10\": {WeirdnessLevel},\n\t\"is_fragile\": \"{(IsFragile ? "YES" : "NO")}\n}}";
            }
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