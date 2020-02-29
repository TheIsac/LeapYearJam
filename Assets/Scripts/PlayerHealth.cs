using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
	public int life;

	private void Respawn()
	{

	}

	public void TakeDamage(int damage, Vector2 direction)
	{
		life -= damage;
	}
}
