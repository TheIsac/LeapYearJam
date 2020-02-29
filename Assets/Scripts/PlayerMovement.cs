using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed;

    void Update()
    {
		HandleMovement();
    }

	private void HandleMovement()
	{
		Vector3 direction = Vector3.zero;

		if (Input.GetAxis("Horizontal") > 0)
		{
			direction += Vector3.right;
		}
		if (Input.GetAxis("Horizontal") < 0)
		{
			direction += Vector3.left;
		}

		if (Input.GetAxis("Vertical") > 0)
		{
			direction += Vector3.up;
		}
		if (Input.GetAxis("Vertical") < 0)
		{
			direction += Vector3.down;
		}

		direction.Normalize();
		transform.position += direction * Time.deltaTime * speed;
	}

	private void TriggerDeath()
	{
		
	}

}
