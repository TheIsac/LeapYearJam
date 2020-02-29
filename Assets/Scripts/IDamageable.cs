using UnityEngine;

internal interface IDamageable
{
    void TakeDamage(int damage, Vector2 direction);
}