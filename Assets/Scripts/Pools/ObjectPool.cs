using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : Component
{
    public static ObjectPool<T> Instance { get; private set; }

    private Queue<T> objectPool;
    [SerializeField] private T objectPrefab;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    private void OnEnable()
    {
        objectPool = new Queue<T>();
    }

    private void AddToPool()
    {
        T objectToPool = Instantiate(objectPrefab);
        objectToPool.gameObject.SetActive(false);
        objectPool.Enqueue(objectToPool);
    }

    public T GetFromPool(Vector3 _position, Quaternion _rotation)
    {
        if(objectPool.Count == 0)
        {
            AddToPool();
        }
        T objectFromPool = objectPool.Dequeue();
        objectFromPool.transform.position = _position;
        objectFromPool.transform.rotation = _rotation;
        objectFromPool.gameObject.SetActive(true);
        return objectFromPool;
    }

    public void ReturnToPool(T objectToPool)
    {
        objectToPool.gameObject.SetActive(false);
        objectPool.Enqueue(objectToPool);
    }
}
