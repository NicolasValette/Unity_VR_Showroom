using Showroom.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Showroom.IA.FSM.States
{
    public class FallState : State
    {
        private float _fallingTime;
        private float _fallingStartTime;
        public FallState(NPCController controller) : base(controller)
        {
        }

        public override State CanSwitch()
        {
            return (_fallingTime > _controller.StandingTime) ? new StandUpState(_controller) : null;
        }

        public override void EnterState()
        {
            _fallingStartTime = Time.time;

            _controller.Falling();
        }

        public override void Execute()
        {
            _fallingTime = Time.time - _fallingStartTime;
        }

        public override void ExitState()
        {
            _fallingTime = 0;
        }
    }
}