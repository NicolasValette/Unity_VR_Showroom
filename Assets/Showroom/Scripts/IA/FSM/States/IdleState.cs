using Showroom.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Showroom.IA.FSM.States
{
    public class IdleState : State
    {
        public IdleState(NPCController controller) : base(controller)
        {
        }

        public override State CanSwitch()
        {
            return new PatrolState(_controller);
        }

        public override void EnterState()
        {
            //Do Nothing
        }

        public override void Execute()
        {
            //Do Nothing
        }

        public override void ExitState()
        {
            //Do Nothing
        }
    }
}
