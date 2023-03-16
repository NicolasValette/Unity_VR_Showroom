using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Showroom.UI
{
    public class PopupPanel : MonoBehaviour
    {
        [SerializeField]
        private Animator _infoPanelAnim;

        private bool _isPop = false;
        public bool IsPop { get => _isPop; }

        public void PopupInfo()
        {
            Debug.Log("Appear");

            _infoPanelAnim.SetTrigger(_isPop ? "Disappear" : "Appear");
            _isPop = !_isPop;
        }
    }
}
