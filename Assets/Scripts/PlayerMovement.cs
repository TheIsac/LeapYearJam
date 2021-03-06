﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public static Transform me;

    private Animator anim;
	private SpriteRenderer sprRen;

    private void Awake()
    {
        me = this.transform;
        anim = GetComponent<Animator>();
		sprRen = GetComponent<SpriteRenderer>();
	}

    void Update()
    {
        HandleMovement();
        HandleSlowdown();
        HandleOutOfBounds();
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

		if (direction.x > 0)
			sprRen.flipX = false;
		if (direction.x < 0)
			sprRen.flipX = true;
	}

	private void HandleSlowdown()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift))
        {
            TimeManager.instance.SetTimeScaleTarget(0.1f);
        }
        else
        {
            TimeManager.instance.SetTimeScaleTarget(1f);
        }
    }

    private void HandleOutOfBounds()
    {
        Vector3 playerPos = transform.position;

        if (playerPos.x < -8.5f)
            playerPos.x = -8.5f;

        if (playerPos.x > 8.5f)
            playerPos.x = 8.5f;

        if (playerPos.y < -4.5f)
            playerPos.y = -4.5f;

        if (playerPos.y > 4.5f)
            playerPos.y = 4.5f;

        transform.position = playerPos;
    }
}
