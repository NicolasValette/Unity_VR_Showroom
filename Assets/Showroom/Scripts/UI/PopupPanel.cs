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
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PopupInfo()
        {
            Debug.Log("Appear");

            _infoPanelAnim.SetTrigger(_isPop ? "Disappear" : "Appear");
            _isPop = !_isPop;
        }
    }
}
