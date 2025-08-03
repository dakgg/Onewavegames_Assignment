using Newtonsoft.Json;

public class ProjectileData
{
    [JsonProperty("name")]
    public string Name { get; private set; }

    [JsonProperty("lifetime")]
    public uint LifeTime { get; private set; }

    [JsonProperty("speed")]
    public uint Speed { get; private set; }

    [JsonProperty("prefab")]
    public string Prefab { get; private set; }
}