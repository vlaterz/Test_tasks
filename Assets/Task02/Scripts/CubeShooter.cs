using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Task02.Scripts
{
    public class CubeShooter : MonoBehaviour
    {
        public InputField TimeBetweenSpawns;

        public static CubeShooter Instance;
        void Awake() => Instance = this;
        void Start()
        {
            StartCoroutine(SpawnCoroutine());
        }

        public IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                ObjectPooler.Instance.SpawnFromPool("Cube", transform.position, Quaternion.identity);
                var seconds = TimeBetweenSpawns.text.Length == 0 ? 0f : Convert.ToSingle(TimeBetweenSpawns.text);
                yield return new WaitForSeconds(seconds);
            }
        }
    }
}
