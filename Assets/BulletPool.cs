using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public const int poolSize = 128;
    private GameObject defaultBulletHolder;
    private GameObject largeBulletHolder;

    public Bullet defaultBullet;
    public Bullet largeBullet;

    public Dictionary<int, Queue<Bullet>> bulletPoolDictionary;



    private void Awake()
    {
        defaultBulletHolder = new GameObject("@DefaultBulletHolder");
        largeBulletHolder = new GameObject("@LargeBulletHolder");


        bulletPoolDictionary = new Dictionary<int, Queue<Bullet>>();
        bulletPoolDictionary.Add(1, new Queue<Bullet>());
        bulletPoolDictionary.Add(2, new Queue<Bullet>());

        for (int i = 0; i < poolSize; i++)
        {
            Bullet db = Instantiate(defaultBullet);
            Bullet lb = Instantiate(largeBullet);

            db.Initialize();
            db.DeActivate();

            lb.Initialize();
            lb.DeActivate();

            bulletPoolDictionary[1].Enqueue(db);
            bulletPoolDictionary[2].Enqueue(lb);


            db.transform.SetParent(defaultBulletHolder.transform);
            lb.transform.SetParent(largeBulletHolder.transform);
        }
    }

    public Bullet GetBullet(SpawnData.BulletTypes bulletType)
    {
        Debug.Log((int)bulletType);
        return bulletPoolDictionary[(int)bulletType].ReQueue();
    }
}
