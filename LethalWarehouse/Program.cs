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
                return $"{{\n\t\"name\": \"{Name}\",\n\t\"weight_kg\": {WeightKg},\n\t\"Weird 1-10\": {WeirdnessLevel},\n\t\"is_fragile\": {(IsFragile ? "YES" : "NO")}\n}}";
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
                    return (false, "Error: This item is too dangerous, its weirdness level is 7 and it's fragile.\nNot possible to storage rn");
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
            //Console.WriteLine("Storage created. add items thru frontend idgaf");
            //Jeżeli frontend istnieje wtedy program działa do tej pory
            //i reszte można wykomentować/wykasować
            //else
            while (true)
            {
                Console.WriteLine("\nLethalTerminal™ menu");
                Console.WriteLine("1) Add item");
                Console.WriteLine("2) Remove item");
                Console.WriteLine("3) SELECT *(all)");
                Console.WriteLine("4) SELECT fragile AND heavier than (treshold)");
                Console.WriteLine("5) Get average strangeness ");
                Console.WriteLine("0) Escape");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Weight (kg): ");
                        double weight = double.Parse(Console.ReadLine());

                        Console.Write("How weird (1-10): ");
                        int weirdness = int.Parse(Console.ReadLine());

                        Console.Write("Is it fragile? (true/false): ");
                        bool fragile = bool.Parse(Console.ReadLine());

                        Item newItem = new Item(name, weight, weirdness, fragile);
                        var (success, message) = warehouse.AddItem(newItem);
                        Console.WriteLine(message);
                        break;

                    case "2":
                        Random random = new Random();
                        int jk = random.Next(100);
                        if (jk == 100)
                            Console.Write("Say my name: ");
                        else
                            Console.Write("Type the name of the object to delete: ");
                        string nameToRemove = Console.ReadLine();
                        bool removed = warehouse.RemoveItem(nameToRemove);
                        Console.WriteLine(removed ? "Item destroyed." : "404: Item not found.");
                        break;

                    case "3":
                        warehouse.PrintAll();
                        break;

                    case "4":
                        Console.Write("Enter treshold: ");
                        double threshold = double.Parse(Console.ReadLine());
                        var selectedItems = warehouse.GetFragileOrHeavy(threshold);
                        foreach (var item in selectedItems)
                        {
                            Console.WriteLine(item.Desc());
                        }
                        break;

                    case "5":
                        double avg = warehouse.GetAverageWeirdness();
                        Console.WriteLine($"Average weirdness: {avg:F2}");
                        break;

                    case "0":
                        Console.WriteLine("THERE IS NO ESCAPE");
                        return;

                    default:
                        Console.WriteLine("Unknown Option.");
                        break;
                }
            }
        }
    }
}