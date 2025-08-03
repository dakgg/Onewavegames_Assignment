
using System;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    const int COLLIDER_RANGE = 1;
    ProjectileData _data;
    Vector3 _dir;
    DateTime _fireTime;
    Actor _source;
    Actor _target;
    bool _ready;
    bool _hit;

    public void SetData(ProjectileData data, Actor source, Actor target)
    {
        _fireTime = DateTime.Now;
        _data = data;
        _source = source;
        _target = target;
        _dir = (target.transform.position - source.transform.position).normalized;
        _hit = false;
        _ready = true;
    }

    void Update()
    {
        if (!_ready) return;
        transform.Translate(_data.Speed * Time.deltaTime * new Vector3(_dir.x, 0, _dir.z));

        if (CheckCollider() && !_hit)
        {
            _source.ApplyDelayEffects(_source, _target);
            _hit = true;
        }

        DestoryCheck();
    }

    bool CheckCollider()
    {
        var vec = _target.transform.position - this.transform.position;
        return vec.sqrMagnitude < COLLIDER_RANGE * COLLIDER_RANGE;
    }

    void DestoryCheck()
    {
        if (!_ready) return;
        if (WillDestory())
        {
            Destroy(this.gameObject);
        }
    }

    bool WillDestory()
    {
        if ((DateTime.Now - _fireTime).TotalSeconds > _data.LifeTime)
        {
            return true;
        }

        if (_hit)
        {
            return true;
        }

        return false;
    }
}