using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileEffect : Effect
{
    public override void Apply(Actor source, Actor target, CharacterSkillData skillData)
    {
        UnityEngine.Debug.Log("ProjectileEffect");
        // 스킬데이터의 projectile 값으로 protectile의 row를 가져온다
        var projectile = GameDataManager.Instance.Projectiles.Single(p => p.Name == skillData.Projectile);
        var prefab = Resources.Load(projectile.Prefab);
        var go = GameObject.Instantiate(prefab, source.transform.localPosition, Quaternion.identity);
        go.GetComponent<Projectile>().SetData(projectile, source, target);
    }
}