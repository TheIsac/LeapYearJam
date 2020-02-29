using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnData", menuName = "SpawnData", order = 0)]
public class SpawnData : ScriptableObject
{
    public int amount;
    public float delay;
    public enum BulletTypes { Default = 1, Large = 2 };
    public BulletTypes type;
}
