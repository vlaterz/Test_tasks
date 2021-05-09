using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Task02.Scripts
{
    public class CubeController : MonoBehaviour, IPooledObject
    {
        private InputField _speedIf;
        private InputField _distanceIf;

        private float _speed;
        private float _distance;
        private DateTime _startTime;

        public void OnObjectCreate()
        {
            _speedIf = GameObject.Find("Speed").GetComponent<InputField>();
            _distanceIf = GameObject.Find("Distance").GetComponent<InputField>();
        }

        public void OnObjectSpawn()
        {
            _speed = _speedIf.text.Length == 0 ? 0f : Convert.ToSingle(_speedIf.text);
            if(Math.Abs(_speed) < 0.01) gameObject.SetActive(false); //Если скорость оооочень мелкая, считаем, что объект не двигается и отключаем его
            _distance = _distanceIf.text.Length == 0 ? 0f : Convert.ToSingle(_distanceIf.text);
            _startTime = DateTime.Now;
        }

        void Update()
        {
            if(_speed * (DateTime.Now - _startTime).TotalSeconds >= _distance)
                gameObject.SetActive(false);
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }

    }
}
