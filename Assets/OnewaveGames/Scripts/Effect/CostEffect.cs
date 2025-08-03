public class CostEffect : Effect
{
    public override void Apply(Actor source, Actor target, CharacterSkillData skillData)
    {
        UnityEngine.Debug.Log("CostEffect");
        if (skillData.CostType == SkillCostType.Hp)
        {
            source.UpdateHp((int)skillData.Cost);
        }
        else if (skillData.CostType == SkillCostType.Mp)
        {
            source.UpdateMp((int)skillData.Cost);
        }
    }
}