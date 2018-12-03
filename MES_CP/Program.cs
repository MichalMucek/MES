using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace MES_CP
{
    static class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Grid grid = new Grid(@"..\..\data\initialData.json");

                Console.WriteLine(grid);
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}