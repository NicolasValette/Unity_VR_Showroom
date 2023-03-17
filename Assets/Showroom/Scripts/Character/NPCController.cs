using UnityEngine.AI;
using UnityEngine;
using System.Collections.Generic;

namespace Showroom.Character
{
    public class NPCController : MonoBehaviour
    {
        [SerializeField]
        private List<Transform> _navpoints;
        [SerializeField]
        private Animator _anim;

        private NavMeshAgent _agent;


        // Start is called before the first frame update
        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.SetDestination(_navpoints[0].position);
            _navpoints.RemoveAt(0);
            
        }

        // Update is called once per frame
        void Update()
        {
            _anim.SetFloat("Speed", _agent.velocity.magnitude);

            if (_navpoints.Count > 0 && _agent.remainingDistance <= _agent.stoppingDistance*3f)
            {
                
                    _agent.SetDestination(_navpoints[0].position);
                    _navpoints.RemoveAt(0);
            }
        }
    }
}