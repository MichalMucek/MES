using Newtonsoft.Json;

namespace MES_CP
{
    struct InitialData
    {
        [JsonProperty("Height")] public double Height { get; set; }
        [JsonProperty("Length")] public double Length { get; set; }
        [JsonProperty("NodesCountAlongTheHeight")] public int NodesCountAlongTheHeight { get; set; }
        [JsonProperty("NodesCountAlongTheLength")] public int NodesCountAlongTheLength { get; set; }
        [JsonProperty("InitialTemperature")] public double T0 { get; set; }
        [JsonProperty("SimulationTime")] public double SimulationTime { get; set; }
        [JsonProperty("SimulationTimeStep")] public double SimulationTimeStep { get; set; }
        [JsonProperty("AmbientTemperature")] public double AmbientTemperature { get; set; }
        [JsonProperty("Alpha")] public double Alpha { get; set; }
        [JsonProperty("SpecificHeat")] public double SpecificHeat { get; set; }
        [JsonProperty("Conductivity")] public double Conductivity { get; set; }
        [JsonProperty("Density")] public double Density { get; set; }
    }
}