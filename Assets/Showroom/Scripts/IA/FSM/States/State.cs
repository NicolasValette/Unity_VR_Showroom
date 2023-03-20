using Showroom.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Showroom.IA.FSM.States
{
    public abstract class State
    {
        protected NPCController _controller;
        public State (NPCController controller)
        {
            _controller = controller;
        }
        public abstract void EnterState();
        public abstract void Execute();
        public abstract void ExitState();
        public abstract State CanSwitch();
    }
}
