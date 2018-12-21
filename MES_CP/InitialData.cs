using System.Text;
using Newtonsoft.Json;

namespace MES_CP
{
    struct InitialData
    {
        [JsonProperty("Length")] public double Length { get; set; }
        [JsonProperty("Height")] public double Height { get; set; }
        [JsonProperty("NodesCountAlongTheLength")] public int NodesCountAlongTheLength { get; set; }
        [JsonProperty("NodesCountAlongTheHeight")] public int NodesCountAlongTheHeight { get; set; }
        [JsonProperty("InitialTemperature")] public double InitialTemperature { get; set; }
        [JsonProperty("AmbientTemperature")] public double AmbientTemperature { get; set; }
        [JsonProperty("SimulationTime")] public double SimulationTime { get; set; }
        [JsonProperty("SimulationTimeStep")] public double SimulationTimeStep { get; set; }
        [JsonProperty("ConvectionCoefficient")] public double ConvectionCoefficient { get; set; }
        [JsonProperty("SpecificHeat")] public double SpecificHeat { get; set; }
        [JsonProperty("Conductivity")] public double Conductivity { get; set; }
        [JsonProperty("Density")] public double Density { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("");

            stringBuilder.AppendLine($"Length: {Length}");
            stringBuilder.AppendLine($"Height: {Height}");
            stringBuilder.AppendLine($"NodesCountAlongTheLength: {NodesCountAlongTheLength}");
            stringBuilder.AppendLine($"NodesCountAlongTheHeight: {NodesCountAlongTheHeight}");
            stringBuilder.AppendLine($"InitialTemperature: {InitialTemperature}");
            stringBuilder.AppendLine($"AmbientTemperature: {AmbientTemperature}");
            stringBuilder.AppendLine($"SimulationTime: {SimulationTime}");
            stringBuilder.AppendLine($"SimulationTimeStep: {SimulationTimeStep}");
            stringBuilder.AppendLine($"ConvectionCoefficient: {ConvectionCoefficient}");
            stringBuilder.AppendLine($"SpecificHeat: {SpecificHeat}");
            stringBuilder.AppendLine($"Conductivity: {Conductivity}");
            stringBuilder.AppendLine($"Density: {Density}");

            return stringBuilder.ToString();
        }
    }
}