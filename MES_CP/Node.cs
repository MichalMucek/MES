using Newtonsoft.Json;

namespace MES_CP
{
    public struct Node
    {
        [JsonProperty("X")] public double X { get; set; }
        [JsonProperty("Y")] public double Y { get; set; }
        [JsonProperty("T0")] public double T0 { get; set; }
        [JsonProperty("Id")] public int Id { get; set; }
        public bool IsBoundry { get; set; }

        public override string ToString()
        {
            return $">>NODE<< ID: {Id} => X: {X} | Y: {Y} | T0: {T0} | IsBoundry: {IsBoundry}";
        }
    }
}
