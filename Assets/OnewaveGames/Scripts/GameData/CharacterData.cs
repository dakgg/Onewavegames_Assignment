using Newtonsoft.Json;

public class CharacterData
{
    [JsonProperty("uid")]
    public uint Id { get; private set; }

    [JsonProperty("name")]
    public string Name { get; private set; }

    [JsonProperty("hp")]
    public uint Hp { get; private set; }

    [JsonProperty("mp")]
    public uint Mp { get; private set; }

    [JsonProperty("moveSpeed")]
    public uint MoveSpeed { get; private set; }
}