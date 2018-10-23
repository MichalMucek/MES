using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace MES
{
    class Program
    {
        static void Main(string[] args)
        {
            JObject dataSetJObject = JObject.Parse(File.ReadAllText(@"..\..\dataSet.json"));
            DataSet dataSet = dataSetJObject.ToObject<DataSet>();

            Grid grid = new Grid();
            grid.Generate(dataSet);

            Console.WriteLine(grid);
            Console.ReadKey();
        }
    }
}
