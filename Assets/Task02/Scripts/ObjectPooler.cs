using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Task02.Scripts
{
    public interface IPooledObject
    {
        void OnObjectSpawn();
        void OnObjectCreate();
    }

    public class ObjectPooler : MonoBehaviour
    {
        [Serializable]
        public class Pool
        {
            public string Tag;
            public GameObject Prefab;
            public int Size;
        }

        public List<Pool> Pools;
        public Dictionary<string, Queue<GameObject>> PoolDictionary;

        #region SINGLETONE
        public static ObjectPooler Instance;
        private void Awake() => Instance = this;
        #endregion

        void Start()
        {
            PoolDictionary = new Dictionary<string, Queue<GameObject>>();
            foreach (var pool in Pools)
            {
                var objectPool = new Queue<GameObject>();
                for (var i = 0; i < pool.Size; i++)
                {
                    var obj = Instantiate(pool.Prefab, transform);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                    obj.GetComponent<IPooledObject>().OnObjectCreate();
                }
                PoolDictionary.Add(pool.Tag, objectPool);
            }
        }

        public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
        {
            if (!PoolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning("Pool with tag: " + tag + " does not exist");
                return null;
            }

            var objectToSpawn = PoolDictionary[tag].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            var pooledObj = objectToSpawn.GetComponent<IPooledObject>();
            pooledObj?.OnObjectSpawn();

            PoolDictionary[tag].Enqueue(objectToSpawn);
            return objectToSpawn;
        }
    }
}