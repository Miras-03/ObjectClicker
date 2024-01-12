using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class ObjectPooler : MonoBehaviour
{
    [SerializeField] private List<Object> objects;
    private Dictionary<string, Queue<Transform>> poolDictionary = new Dictionary<string, Queue<Transform>>();

    public void CreateObject(Transform parent)
    {
        foreach (var item in objects)
        {
            Queue<Transform> queue = new Queue<Transform>();
            for (int i = 0; i < item.quantity; i++)
            {
                Transform prefab = Instantiate(item.prefab, parent);
                prefab.gameObject.SetActive(false);
                queue.Enqueue(prefab);
            }
            poolDictionary.Add(item.tag, queue);
        }
    }

    public Transform GetObject(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning($"There's no object with tag {tag}");
            return null;
        }

        Transform pooledObject = poolDictionary[tag].Peek();
        pooledObject.gameObject.SetActive(true);
        return pooledObject;
    }

    [Serializable]
    internal struct Object
    {
        public Transform prefab;
        public string tag;
        public int quantity;
    }
}
