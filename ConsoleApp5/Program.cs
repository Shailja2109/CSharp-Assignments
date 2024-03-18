using System;
using System.IO;
using System.Threading.Tasks;
namespace ConsoleApp5
{
    public class Program
    {
        private static readonly BackgroundOperation backgroundOperation = new BackgroundOperation();

        public static async Task Main(string[] args)
        {
            while (true)
            {
                DisplayMenu();
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await WriteToFileAsync("Hello World");
                        break;
                    case "2":
                        await WriteToFileAsync(DateTime.Now.ToString());
                        break;
                    case "3":
                        await WriteToFileAsync(Environment.OSVersion.VersionString);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static async Task WriteToFileAsync(string message)
        {
            Console.WriteLine("Writing to file...");
            await backgroundOperation.WriteToFileAsync(message);
            Console.WriteLine("Write operation complete.");
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("Kiosk System Menu:");
            Console.WriteLine("1. Write \"Hello World\"");
            Console.WriteLine("2. Write Current Date");
            Console.WriteLine("3. Write OS Version");
            Console.Write("Enter your choice: ");
        }
    }

    public class BackgroundOperation
    {
        public async Task WriteToFileAsync(string message)
        {
            await Task.Delay(3000);
            await File.WriteAllTextAsync("tmp.txt", message);
        }
    }

}
