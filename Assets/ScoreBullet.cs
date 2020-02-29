using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBullet : Bullet
{

    public TrailRenderer trail;
    public override void Activate(Vector2 pos, Vector2 direction, float delay)
    {
        base.Activate(pos, direction, delay);
        trail.enabled = true;
    }

    public override void DeActivate()
    {
        trail.enabled = false;
        base.DeActivate();
    }

    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override void HandleCollision(GameObject target)
    {
        if (target.GetComponent<IDamageable>() != null)
        {
            if (GetCanDealDamage())
            {
                FindObjectOfType<GameManager>().AddToBulletCount();
                SetCanDealDamage(false);
                DeActivate();
            }
        }
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    public override void Refresh()
    {
        base.Refresh();
    }

    public override void SetInMotion()
    {
        base.SetInMotion();
    }

    public override string ToString()
    {
        return base.ToString();
    }


}
