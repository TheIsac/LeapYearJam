using System.Collections.Generic;
using UnityEngine;

public static class QueueExtensions
{

    public static T ReQueue<T>(this Queue<T> queue)
    {
        T obj = queue.Dequeue();
        queue.Enqueue(obj);
        return obj;
    }
}