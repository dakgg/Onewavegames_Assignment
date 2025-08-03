using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
    protected CharacterSkillData _skillData;

    protected List<Effect> _instantEffectList { get; } = new(); // 즉시 발동
    protected List<Effect> _delayEffectList { get; } = new(); // 충돌 후 발동

    public abstract bool ApplyInstantSkill(Actor source, Actor target);
    public abstract bool ApplyDelaySkill(Actor source, Actor target);
    public abstract void Set();    
}
