using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetLoader : MonoBehaviour
{
    public static Object LoadAsset(string path)
    {
        var obj = Resources.Load(path);
        if (obj)
            return obj;
        else
        {
            Debug.LogWarning("Object @: " + path + " doesn't exist");
            return null;
        }

    }
}
