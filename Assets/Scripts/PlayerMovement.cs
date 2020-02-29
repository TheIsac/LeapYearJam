using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed;

	private Animator anim;

	private void Awake()
	{
		anim = GetComponent<Animator>();
	}

	void Update()
    {
		HandleMovement();
		HandleSlowdown();
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

		if (direction.magnitude > 0)
			anim.SetBool("Walking", true);
		else
			anim.SetBool("Walking", false);

	}

	private void HandleSlowdown()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			TimeManager.instance.SetTimeScaleTarget(0.1f);
		}
		else
		{
			TimeManager.instance.SetTimeScaleTarget(1f);
		}
	}
}
