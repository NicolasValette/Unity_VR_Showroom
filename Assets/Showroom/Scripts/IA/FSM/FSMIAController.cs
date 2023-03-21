using Showroom.Character;
using Showroom.IA.FSM.States;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Showroom.IA.FSM
{
    [RequireComponent(typeof(NPCController))]
    public class FSMIAController : MonoBehaviour
    {
        private State _currentState;

        // Start is called before the first frame update
        void Start()
        {
            _currentState= new IdleState(GetComponent<NPCController>());
        }
        // Update is called once per frame
        void Update()
        {
            _currentState.Execute();
            CheckForChange();
        }
        private void CheckForChange()
        {
            State newState = _currentState.CanSwitch();
            if (newState != null)
            {
                ChangeState(newState);
            }
        }
        private void ChangeState(State state)
        {
            string initialState = _currentState.GetType().ToString();
            _currentState.ExitState();
            _currentState = state;
            _currentState.EnterState();
            Debug.Log("State Change from + " + initialState + " to " + _currentState.GetType());
        }
    }
}
