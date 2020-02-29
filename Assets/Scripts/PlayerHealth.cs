using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
	public int life;
	public GameManager gameManager;

	private PlayerMovement playerMovement;
	private Animator anim;

	private void Awake()
	{
		if (gameManager == null)
			gameManager = FindObjectOfType<GameManager>();

		playerMovement = GetComponent<PlayerMovement>();
		anim = GetComponent<Animator>();
	}

	public void TakeDamage(int damage, Vector2 direction)
	{
		
		HandleDamage(damage);
	}

	private void HandleDamage(int damage)
	{
		life -= damage;
		if (life <= 0)
		{
			gameManager.GameOver();
			playerMovement.enabled = false;
			anim.SetBool("Dead", true);
			enabled = false;
		}
	}
}
