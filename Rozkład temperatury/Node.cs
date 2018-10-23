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

        public override string ToString()
        {
            return $@"x: {x} | y: {y} | t0: {t0}";
        }
    }
}
