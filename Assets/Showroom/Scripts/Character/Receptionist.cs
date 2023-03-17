using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Showroom.Character
{
    public class Receptionist : MonoBehaviour
    {
        [SerializeField]
        private Transform _playerTransform; // Player to welcome
        [SerializeField]
        private Animator _anim;
        [SerializeField]
        private float _greetingsDistance;
        [SerializeField]
        private Showroom.UI.PopupPanel _popupPanel;
        private NavMeshAgent _agent;
        private bool _isGreetings = false;
        // Start is called before the first frame update
        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.SetDestination(_playerTransform.position);

        }

        // Update is called once per frame
        void Update()
        {
            _anim.SetFloat("Speed", _agent.velocity.magnitude);

            if (!_isGreetings && _agent.remainingDistance < _greetingsDistance) // Greetings animation
            {
                Debug.Log("Greetings");
                _agent.SetDestination(transform.position);
                _isGreetings = true;
                _popupPanel.PopupInfo();
                _anim.SetTrigger("ToGreetings");
            }

        }

      
    }
}
