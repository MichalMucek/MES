using Newtonsoft.Json;

namespace MES_CP
{
    struct DataSet
    {
        [JsonProperty("H")] public double H;
        [JsonProperty("L")] public double L;
        [JsonProperty("nH")] public int nH;
        [JsonProperty("nL")] public int nL;
        [JsonProperty("t0")] public double t0;
    }
}