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
            public int Capacity { get; private set; }
            public double MaxTotalWeight { get; private set; }
            public List<Item> Items { get; private set; }

            public Warehouse(int capacity, double maxTotalWeight)
            {
                Capacity = capacity;
                MaxTotalWeight = Math.Round(maxTotalWeight, 3);
                Items = new List<Item>();
            }
            public int CurrentItemCount => Items.Count;
            public double CurrentTotalWeight => Items.Sum(i => i.WeightKg);
            public (bool, string) AddItem(Item item)
            {
                if (CurrentItemCount >= Capacity)
                    return (false, "Error: Storage full");
                if (CurrentTotalWeight + item.WeightKg > MaxTotalWeight)
                    return (false, "Error: This item weights too much(still less than ur mom lmao)");
                if (item.IsFragile && item.WeirdnessLevel == 7 && CurrentItemCount >= Capacity / 2)
                    return (false, "Error: This item is too dangerous, its strange level is 7 and it's fragile.\nNot possible to storage rn");
                Items.Add(item);
                return (true, "Item added succesfully ☺");
            }
            public bool RemoveItem(string itemName)
            {
                var item = Items.FirstOrDefault(i => i.Name == itemName);
                if (item != null)
                {
                    Items.Remove(item);
                    return true;
                }
                return false;
            }
            public List<Item> GetFragileOrHeavy(double weightThreshold)
            {
                return Items.Where(i => i.IsFragile || i.WeightKg > weightThreshold).ToList();
            }
            public double GetAverageWeirdness()
            {
                return Items.Count == 0 ? 0 : Items.Average(i => i.WeirdnessLevel);
            }
            public void PrintAll()
            {
                foreach (var item in Items)
                {
                    Console.WriteLine(item.Desc());
                }
            }
        }
        public static void Main()
        {
            //max pojemność magazynu
            Console.WriteLine("Enter warehouse item capacity: ");
            int capacity = int.Parse(Console.ReadLine());
            //max waga magazynu
            Console.WriteLine("Enter warehouse max weight in kg: ");
            double maxWeight = double.Parse(Console.ReadLine());
            
            Warehouse warehouse = new Warehouse(capacity, maxWeight);

            Console.WriteLine("Storage created. add items thru frontend idgaf");
        }
    }
}