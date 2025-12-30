using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
    private Queue<T> pool = new Queue<T>();
    private T[] prefabs;
    private Transform parent;

    public ObjectPool(T[] prefabs, int count, Transform parent)
    {
        this.prefabs = prefabs;
        this.parent = parent;

        for (int i = 0; i < count; i++)
        {
            var chance = Random.Range(0, prefabs.Length);
            T obj = GameObject.Instantiate(prefabs[chance], parent);
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public T Get()
    {
        T obj = pool.Count > 0 ? pool.Dequeue() : CreateNewObject();;
        if (obj.gameObject == null) return null;
        obj.gameObject.SetActive(true);
        return obj;
    }
   private T CreateNewObject()
    {
        var chance = Random.Range(0, prefabs.Length);
        var obj = GameObject.Instantiate(prefabs[chance], parent);
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
        return obj;
    }
    public void Return(T obj)
    {
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
}