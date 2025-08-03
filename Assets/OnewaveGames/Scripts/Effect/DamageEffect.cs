public class DamageEffect : Effect
{
    public override void Apply(Actor source, Actor target, CharacterSkillData skillData)
    {
        UnityEngine.Debug.Log("DamageEffect");

        target.UpdateHp((int)skillData.Damage);
    }
}