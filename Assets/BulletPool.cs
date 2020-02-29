using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public const int poolSize = 60;
    private GameObject defaultBulletHolder;
    private GameObject largeBulletHolder;
    private GameObject greatBulletHolder;
    private GameObject scoreBulletHolder;

    public Bullet defaultBullet;
    public Bullet GreatBullet;
    public Bullet largeBullet;
    public Bullet scoreBullet;

    public Dictionary<int, Queue<Bullet>> bulletPoolDictionary;



    private void Awake()
    {
        defaultBulletHolder = new GameObject("@DefaultBulletHolder");
        largeBulletHolder = new GameObject("@LargeBulletHolder");
        greatBulletHolder = new GameObject("@greatBulletHolder");
        scoreBulletHolder = new GameObject("@scoreBulletHolder");

        bulletPoolDictionary = new Dictionary<int, Queue<Bullet>>();
        bulletPoolDictionary.Add(1, new Queue<Bullet>());
        bulletPoolDictionary.Add(2, new Queue<Bullet>());
        bulletPoolDictionary.Add(3, new Queue<Bullet>());
        bulletPoolDictionary.Add(4, new Queue<Bullet>());


        for (int i = 0; i < poolSize; i++)
        {
            Bullet db = Instantiate(defaultBullet);
            Bullet lb = Instantiate(largeBullet);
            Bullet gb = Instantiate(GreatBullet);
            Bullet sb = Instantiate(scoreBullet);

            db.Initialize();
            db.DeActivate();

            lb.Initialize();
            lb.DeActivate();

            gb.Initialize();
            gb.DeActivate();

            sb.Initialize();
            sb.DeActivate();

            bulletPoolDictionary[1].Enqueue(db);
            bulletPoolDictionary[2].Enqueue(lb);
            bulletPoolDictionary[3].Enqueue(gb);
            bulletPoolDictionary[4].Enqueue(sb);

            db.transform.SetParent(defaultBulletHolder.transform);
            lb.transform.SetParent(largeBulletHolder.transform);
            gb.transform.SetParent(greatBulletHolder.transform);
            sb.transform.SetParent(scoreBulletHolder.transform);

        }
    }

    public Bullet GetBullet(SpawnData.BulletTypes bulletType)
    {
        return bulletPoolDictionary[(int)bulletType].ReQueue();
    }
}
