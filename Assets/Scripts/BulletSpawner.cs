using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{


    private const int poolSize = 64;
    private Queue<Bullet> pool;
    [SerializeField] private Bullet bulletPrefab;

    private void Awake()
    {
        IntializePool();
    }

    private void IntializePool()
    {
        pool = new Queue<Bullet>();
        for (int i = 0; i < poolSize; i++)
        {
            Bullet b = Instantiate(bulletPrefab);
            b.Initialize();
            pool.Enqueue(b);
        }
    }

    public void Spawn(Vector2 position, Vector2 direction, float delay = 0f)
    {
        Bullet b = pool.ReQueue();
        b.Refresh();
        b.Invoke("Initialize", delay);
    }


}
