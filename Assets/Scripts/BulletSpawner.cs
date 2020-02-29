using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public SpawnData data;
    public BulletPool pool;


    private GameObject holder;
    public bool inUse;
    private bool initialized;

    Vector2 VectorFromAngle(float theta)
    {
        return new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
    }

    public void SpawnAngled()
    {
        for (int i = 0; i < data.amount; i++)
        {
            Bullet b = pool.GetBullet(data.type);
            b.Refresh();

            Vector2 angle = -((Vector2)this.transform.position - Vector2.zero).normalized;
            angle = angle + (UnityEngine.Random.insideUnitCircle.normalized * 0.4f);
            angle = angle.normalized;

            b.Activate(this.transform.position, angle, data.delay);
        }

        inUse = false;
    }

    //  public void Spawn(Vector2 position, Vector2 direction, int amount = 1, float delay = 0f, float offsetFromCenter = 0f)
    //  {
    //      for (int i = 0; i < amount; i++)
    //      {
    //          Bullet b = pool.ReQueue();
    //          b.Refresh();
    //
    //          float offsetAngle = ((Mathf.PI * 2) / amount);
    //          offsetAngle = offsetAngle * i;
    //          Vector2 pos = position + (VectorFromAngle(offsetAngle).normalized * offsetFromCenter);
    //          b.Activate(pos, direction, delay);
    //      }
    //  }

    public void Update()
    {
        if (!inUse) return;

        if (Input.GetKeyDown(KeyCode.F) && data != null)
        {
            SpawnAngled();
            // Spawn(transform.position, Vector2.right, 20, 2, 4f);
        }
    }


}
