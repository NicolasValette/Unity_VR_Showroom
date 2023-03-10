using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Showroom
{
    public class Alarm : MonoBehaviour
    {
        [SerializeField]
        private GameObject _light;
        [SerializeField]
        private float _rotationSpeed = 20f;

        private float _rotationAngle = 0f;
        private bool _isAlarm = true;

        // Update is called once per frame
        void Update()
        {
            if (_isAlarm)
            {
                _rotationAngle = ((_rotationAngle + _rotationSpeed) * Time.deltaTime) % 360f;
                _light.transform.Rotate(new Vector3(_rotationAngle, 0f, 0f));
            }
        }
    }
}
