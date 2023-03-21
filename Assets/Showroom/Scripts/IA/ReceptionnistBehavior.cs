using Showroom.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Showroom.IA
{
    public enum ReceptionistState
    {
        None,
        Patrol,
        Greetings
    }
    public class ReceptionnistBehavior : MonoBehaviour
    {
        [SerializeField]
        private ReceptionistState _state;
        private ReceptionistState _nextState;

        private NPCController _npcController;

        private void Start()
        {
            _npcController = GetComponent<NPCController>();
        }
        private void Update()
        {
            Behaviour();
            if (CheckForTransition())
            {
                Transition();
            }
            
        }

        private bool CheckForTransition()
        {
            switch (_state)
            {
                case ReceptionistState.None:
                    _nextState = ReceptionistState.Patrol;
                    return true;
                case ReceptionistState.Patrol:
                    if (_npcController.MetPlayer && !_npcController.HasGreeted)
                    {
                        _nextState = ReceptionistState.Greetings;
                        return _npcController.MetPlayer;
                    }
                    break;
                case ReceptionistState.Greetings:
                    if (_npcController.IsGreetingsOver())
                    {
                        _nextState = ReceptionistState.Patrol;
                        return true;
                    }
                    break;       
            }
            return false;
        }

        private void Transition()
        {
            EndState();
            Debug.Log("Transition from " + _state.ToString() + " to " + _nextState.ToString());
            _state = _nextState;
            StartState();
        }
        private void StartState()
        {
            switch (_state)
            {
                case ReceptionistState.None:
                    //TODO 
                    break;
                case ReceptionistState.Patrol:
                    _npcController.InitPatrolling();
                    break;
                case ReceptionistState.Greetings:
                    break;
            }
        }
        private void EndState()
        {
            switch (_state)
            {
                case ReceptionistState.None:
                    //TODO condition
                    break;
                case ReceptionistState.Patrol:
                    _npcController.StopPatrol();
                    break;
                case ReceptionistState.Greetings:
                    //TODO condition
                    break;
            }
        }
        private void Behaviour()
        {
            switch (_state)
            {
                case ReceptionistState.None:
                    //TODO
                    break;
                case ReceptionistState.Patrol:
                    _npcController.PatrolBehaviour();
                    break;
                case ReceptionistState.Greetings:
                    _npcController.Greetings();
                    break;
            }
        }
    }
}
