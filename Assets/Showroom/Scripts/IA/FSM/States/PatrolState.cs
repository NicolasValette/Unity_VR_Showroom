using Showroom.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Showroom.IA.FSM.States
{
    public class PatrolState : State
    {
        private float _runningTime;
        private bool _canFall;
        public PatrolState(NPCController controller) : base(controller)
        {
        }

        public override void EnterState()
        {
            _runningTime = 0f;
            _canFall = false;
            _controller.StartCoroutine(WaitBeforeFalling());
            _controller.InitPatrolling();
        }

        public override void Execute()
        {
            _runningTime += Time.deltaTime;
            _controller.PatrolBehaviour();
        }

        public override void ExitState()
        {
            _controller.StopPatrol();
        }
        public override State CanSwitch()
        {
            int rand = Random.Range(0, 100);
            if (_controller.CanFall && _canFall && rand < _runningTime % 10)
            {
                Debug.Log("Fall");
                return new FallState(_controller);
            }
            return (_controller.MetPlayer && !_controller.HasGreeted) ? new GreetingsState(_controller) : null;
        }

        public IEnumerator WaitBeforeFalling()
        {
            yield return new WaitForSeconds(_controller.TimeBetweenFall);
            _canFall = true;
        }
    }
}
