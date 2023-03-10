using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Showroom
{
    public class UILookAt : MonoBehaviour
    {
        [SerializeField]
        private Transform _targetToLookAt;

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(_targetToLookAt);
        }
    }
}
