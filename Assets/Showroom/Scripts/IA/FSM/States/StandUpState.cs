using Showroom.Character;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace Showroom.IA.FSM.States
{
    public class StandUpState : State
    {
        public StandUpState(NPCController controller) : base(controller)
        {
        }

        public override State CanSwitch()
        {
            return _controller.IsStandingOver() ? new PatrolState(_controller) : null;
        }

        public override void EnterState()
        {
            //Do Nothing
        }

        public override void Execute()
        {
            _controller.StandUp();
        }

        public override void ExitState()
        {
            //Do Nothing
        }
    }
}