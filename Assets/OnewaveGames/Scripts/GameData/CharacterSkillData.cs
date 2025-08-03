using Newtonsoft.Json;

public class CharacterSkillData
{
    [JsonProperty("id")]
    public uint Id { get; private set; }

    [JsonProperty("name")]
    public string Name { get; private set; }

    [JsonProperty("costType")]
    public SkillCostType CostType { get; private set; }

    [JsonProperty("cost")]
    public uint Cost { get; private set; }

    [JsonProperty("cooltime")]
    public uint CoolTime { get; private set; }

    [JsonProperty("damage")]
    public uint Damage { get; private set; }

    [JsonProperty("projectile")]
    public string Projectile { get; private set; }
}