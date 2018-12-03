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

            /*JObject ksiEtaBcJObject = JObject.Parse(File.ReadAllText(@"..\..\data\ksi_eta_BC.json"));
            JArray surfacesJArray = (JArray)ksiEtaBcJObject["Surface"];
            /*JObject[] ksiEtaJObject =
            {
                surfacesJArray[0],
                surfacesJArray[1],
                surfacesJArray[2],
                surfacesJArray[3],
            };#1#
            Console.WriteLine(surfacesJArray[0]["ksi"].ToString());
            Console.ReadKey();*/
        }
    }
}