using UnityEngine.AI;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using Showroom.UI;
using Showroom.Datas;

namespace Showroom.Character
{
    public class NPCController : MonoBehaviour
    {
        [SerializeField]
        private List<Transform> _navpoints;
        [SerializeField]
        private Animator _anim;
        private int _actualNavpoint = 0;
        private NavMeshAgent _agent;
        [SerializeField]
        private float _jumpSpeed = 10f;
        [SerializeField]
        private float _timeOfStanding = 5f;
        [SerializeField]
        private float _timeBetweenFall = 60f;
        [SerializeField]
        private CharacterData _characterData;
        [SerializeField]
        private bool _canFall = false;
        private bool _isJumping = false;
        private bool _metPlayer = false;
        private bool _hasGreeted = false;
        public bool MetPlayer { get => _metPlayer; }
        public bool HasGreeted { get => _hasGreeted; }
        public float StandingTime { get => _timeOfStanding; }
        public float TimeBetweenFall { get => _timeBetweenFall; }
        public bool CanFall { get => _canFall; }


        // Start is called before the first frame update
        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.speed = _characterData.MovementSpeed;

        }
        // Update is called once per frame
        void Update()
        {
            var keyboard = Keyboard.current;

            if (!_isJumping && keyboard.spaceKey.wasPressedThisFrame) //getkeydown
            {
                Debug.Log("Jump");
                _isJumping = true;
                GetComponent<Rigidbody>().AddForce(Vector3.up * _jumpSpeed, ForceMode.Impulse);
                _anim.SetTrigger("Jump");
            }
            if (keyboard.fKey.wasPressedThisFrame) //getkeydown
            {
                Debug.Log("Fall");

                _anim.SetTrigger("Falling");
            }
        }


        #region Patrolling
        public void InitPatrolling()
        {
            _agent.isStopped = false;
            _agent.SetDestination(_navpoints[_actualNavpoint].position);
        }
        public void PatrolBehaviour()
        {
            _anim.SetFloat("Speed", _agent.velocity.magnitude);

            if (_agent.remainingDistance <= _agent.stoppingDistance * 3f)
            {
                _actualNavpoint++;
                if (_actualNavpoint >= _navpoints.Count)
                {
                    _actualNavpoint = 0;
                }
                Debug.Log("Destination(Pat) = " + _actualNavpoint);
                _agent.SetDestination(_navpoints[_actualNavpoint].position);
            }
        }
        public void StopPatrol()
        {
            _agent.isStopped = true;
        }
        #endregion

        #region Greetings
        public void Greetings()
        {
            //  _popupPanel.PopupInfo();
            if (!_hasGreeted)
            {
                _anim.SetTrigger("ToGreetings");
                _hasGreeted = true;
            }

        }

        public bool IsGreetingsOver()
        {
            Debug.Log("time : " + _anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            return (_anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1 >= 0.99f) ? true : false;
        }
        public void GreetingsOver()
        {
            _metPlayer = false;
        }
        #endregion

        #region Fall
        public void Falling()
        {
            _anim.SetTrigger("Falling");
        }
        #endregion
        #region StandUp
        public void StandUp()
        {
            _anim.SetTrigger("StandingUp");
        }
        public bool IsStandingOver()
        {
            // Debug.Log("Is Standing Over (etat = "+ _anim.GetCurrentAnimatorStateInfo(0).fullPathHash + " : " + !_anim.GetCurrentAnimatorStateInfo(0).IsName("Standing Up"));
            //return (!_anim.GetCurrentAnimatorStateInfo(0).IsName("Standing Up")) ? true : false;
            
            return (_anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1 >= 0.99f) ? true : false;
        }
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            for (int i = 0; i < _characterData.GreetingsTags.Count; i++)
            {
                if (other.CompareTag(_characterData.GreetingsTags[i].ToString()))
                {
                    _metPlayer = true;
                }
            }
        }


    }
}