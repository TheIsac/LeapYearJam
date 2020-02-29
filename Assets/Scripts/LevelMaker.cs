using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaker : MonoBehaviour
{
    private GameObject holder;
    public int levelNumber;
    public Queue<BulletSpawner> spawners;
    public List<SpawnData> spawnerDataList;

    // Start is called before the first frame update
    void Start()
    {
        holder = new GameObject("@SpawnerHolder");
        spawners = new Queue<BulletSpawner>();
        for (int i = 0; i < 128; i++)
        {
            BulletSpawner spawner = new GameObject("@Spawner").AddComponent<BulletSpawner>();
            spawners.Enqueue(spawner);
            spawner.pool = FindObjectOfType<BulletPool>();
            spawner.transform.SetParent(holder.transform);
        }
    }

    public void SpawnLevel()
    {
        levelNumber++;
        for (int i = 0; i < levelNumber; i++)
        {
            BulletSpawner spawner = spawners.ReQueue();
            spawner.transform.position = Vector3.zero;
            spawner.transform.position += (Vector3)Random.insideUnitCircle.normalized * 8f;
            spawner.data = spawnerDataList.GetRandom();
            spawner.inUse = true;
            spawner.SpawnAngled();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SpawnLevel();
        }
    }
}
