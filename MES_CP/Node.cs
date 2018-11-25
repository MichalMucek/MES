using Newtonsoft.Json;

namespace MES_CP
{
    public struct Node
    {
        [JsonProperty("x")] public double x { get; set; }
        [JsonProperty("y")] public double y { get; set; }
        [JsonProperty("t0")] public double t0 { get; set; }
        [JsonProperty("id")] public int id { get; set; }
        public bool isBoundry { get; set; }

        public override string ToString()
        {
            return $@">>NODE<< ID: {id} => x: {x} | y: {y} | t0: {t0} | isBoundry: {isBoundry}";
        }
    }
}
