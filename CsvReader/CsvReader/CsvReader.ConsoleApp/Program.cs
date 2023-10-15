using System.Diagnostics;

namespace CsvReader.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            byte[] binaryData = File.ReadAllBytes(@"B:\CODE\PROJECTS\Chimera\stany-magazynowe-ok.csv");

            var reader = new CsvReader.CsvReader();

            for (int i = 0; i < 50; i++)
            {
                var timer = new Stopwatch();
                
                timer.Start();
                var resultData = reader.Read(binaryData);
                timer.Stop();

                Console.WriteLine(timer.ElapsedMilliseconds.ToString());
            }
        }
    }
}