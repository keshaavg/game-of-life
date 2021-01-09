using GameOfLife.Domain;
using System;
using System.IO;
using System.Linq;

namespace GameOfLife.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var input = File.ReadLines("grid.txt").ToArray();
                var dimensions = input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int.TryParse(dimensions[0], out int rowCount);
                int.TryParse(dimensions[1], out int columnCount);
                string[] data = input.Where(w => w != input[0]).ToArray();
                var output = new Grid().NextGeneration(data, rowCount, columnCount);
                Console.WriteLine(input[0]);
                foreach (string x in output)
                {
                    Console.WriteLine(x);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
