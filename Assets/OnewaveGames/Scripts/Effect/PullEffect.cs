public class PullEffect : Effect
{
    public override void Apply(Actor source, Actor target, CharacterSkillData skillData)
    {
        UnityEngine.Debug.Log("PullEffect");
        target.transform.localPosition = source.transform.localPosition;
    }
}