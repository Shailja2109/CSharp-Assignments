using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the dictionary with prime ministers and their years
            Dictionary<int, string> primeMinisters = new Dictionary<int, string>()
        {
            { 1998, "Atal Bihari Vajpayee" },
            { 2014, "Narendra Modi" },
            { 2004, "Manmohan Singh" }
        };

            // Find the Prime Minister of 2004
            if (primeMinisters.ContainsKey(2004))
            {
                Console.WriteLine($"Prime Minister of 2004: {primeMinisters[2004]}");
            }
            else
            {
                Console.WriteLine("Prime Minister of 2004 not found.");
            }

            // Add the current Prime Minister
            int currentYear = DateTime.Now.Year;
            string currentPrimeMinister = "Current Prime Minister";
            primeMinisters.Add(currentYear, currentPrimeMinister);

            // Sort the dictionary by year
            var sortedPrimeMinisters = primeMinisters.OrderBy(x => x.Key);

            // Display the sorted dictionary
            Console.WriteLine("\nSorted Prime Ministers:");
            foreach (var primeMinister in sortedPrimeMinisters)
            {
                Console.WriteLine($"{primeMinister.Key}: {primeMinister.Value}");
            }
        }
    }

}
