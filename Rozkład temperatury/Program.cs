using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Rozkład_temperatury
{
    

    class Program
    {
        static void Main(string[] args)
        {
            JObject jObject = JObject.Parse(File.ReadAllText(@"..\..\node.json"));
            JArray jArray = (JArray) jObject["node"];
            List<Node> nodes = jArray.ToObject<List<Node>>();

            JObject jObject2 = JObject.Parse(File.ReadAllText(@"..\..\node2.json"));
            Node node2 = jObject2.ToObject<Node>();

            foreach (var node in nodes)
            {
                Console.WriteLine(node.ToString());
            }
            Console.WriteLine(node2);
            Console.ReadKey();
        }
    }
}
