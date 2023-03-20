using Showroom.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Showroom.IA.FSM.States
{
    public class GreetingsState : State
    {
        public GreetingsState(NPCController controller) : base(controller)
        {
        }


        public override void EnterState()
        {
            //Do Nothing
        }

        public override void Execute()
        {
            _controller.Greetings();
        }

        public override void ExitState()
        {
            //Do Nothing
        }
        public override State CanSwitch()
        {
            return _controller.IsGreetingsOver() ? new PatrolState(_controller) : null;
        }
    }
}
