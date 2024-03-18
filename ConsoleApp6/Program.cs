using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
namespace ConsoleApp6
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.Write("Enter the URL to read content from: ");
            string url = Console.ReadLine();

            try
            {
                string content = await ReadUrlContentAsync(url);
                await WriteToFileAsync("A.txt", content);
                Console.WriteLine("Content has been successfully written to A.txt.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static async Task<string> ReadUrlContentAsync(string url)
        {
            using (var client = new WebClient())
            {
                return await client.DownloadStringTaskAsync(url);
            }
        }

        private static async Task WriteToFileAsync(string fileName, string content)
        {
            using (var writer = new StreamWriter(fileName))
            {
                await writer.WriteAsync(content);
            }
        }
    }

}
