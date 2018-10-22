using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Rozkład_temperatury
{
    public class Node
    {
        [JsonProperty("x")]
        public double x { get; set; }
        [JsonProperty("y")]
        public double y { get; set; }
        [JsonProperty("t0")]
        public double t0 { get; set; }

        /*public Node(string jsonFile)
        {
            JObject jObject = JObject.Parse(File.ReadAllText(jsonFile));
            JToken jNode = jObject["node"];
            x = (double)jNode["x"];
            y = (double)jNode["y"];
            t0 = (double)jNode["t0"];
        }

        public Node()
        {

        }*/

        public override string ToString()
        {
            return $@"x: {x} | y: {y} | t0: {t0}";
        }
    }
}
