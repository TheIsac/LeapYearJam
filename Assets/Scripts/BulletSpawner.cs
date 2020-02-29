using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{


    private const int poolSize = 64;
    private Queue<Bullet> pool;

    private GameObject holder;

    [SerializeField] private Bullet bulletPrefab;

    private void Awake()
    {
        IntializePool();
    }

    private void IntializePool()
    {
        holder = new GameObject("@BulletHolder");
        holder.transform.position = Vector3.zero;
        pool = new Queue<Bullet>();
        for (int i = 0; i < poolSize; i++)
        {
            Bullet b = Instantiate(bulletPrefab);
            b.transform.SetParent(holder.transform);
            b.Initialize();
            b.DeActivate();
            pool.Enqueue(b);
        }
    }

    Vector2 VectorFromAngle(float theta)
    {
        return new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
    }

    public void Spawn(Vector2 position, Vector2 direction, int amount = 1, float delay = 0f, float offsetFromCenter = 0f)
    {
        for (int i = 0; i < amount; i++)
        {
            Bullet b = pool.ReQueue();
            b.Refresh();


            float offsetAngle = ((Mathf.PI * 2) / amount);
            offsetAngle = offsetAngle * i;
            Vector2 pos = position + (VectorFromAngle(offsetAngle).normalized * offsetFromCenter);
            b.Activate(pos, direction, delay);
        }
    }

    public void Update()
    {


        if (Input.GetKeyDown(KeyCode.F))
        {
            Spawn(transform.position, Vector2.right, 20, 2, 4f);
        }
    }


}
