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
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";
            
            //Node node = new Node(@"..\..\node.json");
            JObject jObject = JObject.Parse(File.ReadAllText(@"..\..\node.json"));
            JArray jArray = (JArray) jObject["node"];
            List<Node> nodes = jArray.ToObject<List<Node>>();

            JObject jObject2 = JObject.Parse(File.ReadAllText(@"..\..\node2.json"));
            Node node2 = jObject2.ToObject<Node>();

            double a = 1.3;
            Console.WriteLine(a.ToString(numberFormatInfo));

            foreach (var node in nodes)
            {
                Console.WriteLine(node.ToString());
            }
            Console.WriteLine(node2);
            Console.ReadKey();
        }
    }
}
