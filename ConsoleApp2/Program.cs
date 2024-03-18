namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            List<Product> inventory = new List<Product>();

            // Adding initial products to the inventory
            inventory.Add(new Product("lettuce", 10.5, 50, "Leafy green"));
            inventory.Add(new Product("cabbage", 20, 100, "Cruciferous"));
            inventory.Add(new Product("pumpkin", 30, 30, "Marrow"));
            inventory.Add(new Product("cauliflower", 10, 25, "Cruciferous"));
            inventory.Add(new Product("zucchini", 20.5, 50, "Marrow"));
            inventory.Add(new Product("yam", 30, 50, "Root"));
            inventory.Add(new Product("spinach", 10, 100, "Leafy green"));
            inventory.Add(new Product("broccoli", 20.2, 75, "Cruciferous"));
            inventory.Add(new Product("garlic", 30, 20, "Leafy green"));
            inventory.Add(new Product("silverbeet", 10, 50, "Marrow"));

            // Print total number of products
            Console.WriteLine("Total number of products: " + inventory.Count);

            // Add a new product (Potato)
            inventory.Add(new Product("potato", 10, 50, "Root"));

            // Print list of all products and total number of products
            Console.WriteLine("\nList of all products:");
            foreach (var product in inventory)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("Total number of products: " + inventory.Count);

            // Print all products of type Leafy green
            Console.WriteLine("\nProducts of type Leafy green:");
            foreach (var product in inventory)
            {
                if (product.Type == "Leafy green")
                {
                    Console.WriteLine(product.ToString());
                }
            }

            // Remove garlic from the list
            inventory.RemoveAll(product => product.Name == "garlic");

            // Print total number of products left
            Console.WriteLine("\nTotal number of products left: " + inventory.Count);

            // Find and print final quantity of cabbage
            Product cabbage = inventory.Find(product => product.Name == "cabbage");
            if (cabbage != null)
            {
                Console.WriteLine("\nFinal quantity of cabbage: " + cabbage.Quantity);
            }

            // Calculate total price for the given purchases
            double totalPrice = CalculateTotalPrice(inventory, "lettuce", 1) +
                                CalculateTotalPrice(inventory, "zucchini", 2) +
                                CalculateTotalPrice(inventory, "broccoli", 1);
            Console.WriteLine("\nTotal price for the given purchases: " + totalPrice.ToString("0.00") + " RS");
        }

        static double CalculateTotalPrice(List<Product> inventory, string productName, int quantity)
        {
            Product product = inventory.Find(p => p.Name == productName);
            if (product != null)
            {
                if (product.Quantity >= quantity)
                {
                    product.Quantity -= quantity;
                    return product.Price * quantity;
                }
                else
                {
                    Console.WriteLine($"Insufficient quantity of {productName} in inventory.");
                    return 0;
                }
            }
            else
            {
                Console.WriteLine($"{productName} not found in inventory.");
                return 0;
            }
        }
    }

    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }

        public Product(string name, double price, int quantity, string type)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Name}, {Price} RS, {Quantity}, {Type}";
        }
    }

}
