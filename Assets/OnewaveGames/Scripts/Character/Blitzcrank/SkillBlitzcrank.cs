using System;

public class SkillBlitzcrank : Skill
{
    DateTime _fireTime;

    public override bool ApplyDelaySkill(Actor source, Actor target)
    {
          for (int i = 0; i < _delayEffectList.Count; i++)
        {
            _delayEffectList[i].Apply(source, target, _skillData);
        }

        return true;
    }

    public override bool ApplyInstantSkill(Actor source, Actor target)
    {
        TimeSpan ts = DateTime.Now - _fireTime;
        if (ts.TotalSeconds < _skillData.CoolTime) return false;

        for (int i = 0; i < _instantEffectList.Count; i++)
        {
            _instantEffectList[i].Apply(source, target, _skillData);
        }

        _fireTime = DateTime.Now;
        return true;
    }

    public override void Set()
    {
        _skillData = GameDataManager.Instance.GetCharacterSkillData("grab");
        _delayEffectList.Add(new PullEffect());
        _delayEffectList.Add(new DamageEffect());
        _instantEffectList.Add(new ProjectileEffect());
        _instantEffectList.Add(new CostEffect());
    }
}