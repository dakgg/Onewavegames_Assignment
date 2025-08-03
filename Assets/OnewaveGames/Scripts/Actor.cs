using UnityEngine;

public class Actor : MonoBehaviour
{
    protected bool _dataReady;
    protected ActorStat _acotrStat = new();
    protected Skill _skill;

    public virtual void ApplySkill(Actor target) { }

    public void UpdateHp(int hp) => _acotrStat.UpdateHp(hp);

    public void UpdateMp(int mp) => _acotrStat.UpdateMp(mp);

    public void ApplyDelayEffects(Actor source, Actor target)
    {
        _skill.ApplyDelaySkill(source, target);
    }
}

