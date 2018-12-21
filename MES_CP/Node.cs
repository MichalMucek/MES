using Newtonsoft.Json;

namespace MES_CP
{
    public struct Node
    {
        [JsonProperty("X")] public double X { get; set; }
        [JsonProperty("Y")] public double Y { get; set; }
        [JsonProperty("InitialTemperature")] public double T0 { get; set; }
        [JsonProperty("Id")] public int Id { get; set; }
        public bool IsBoundary { get; set; }

        public override string ToString()
        {
            return $">>NODE<< ID: {Id} => X: {X} | Y: {Y} | InitialTemperature: {T0} | IsBoundary: {IsBoundary}";
        }
    }
}
