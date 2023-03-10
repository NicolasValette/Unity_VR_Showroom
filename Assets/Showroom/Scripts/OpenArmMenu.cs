using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Showroom
{
    public class OpenArmMenu : MonoBehaviour
    {
        [SerializeField]
        private InputActionReference _toggleLeftMenu;
        [SerializeField]
        private GameObject _leftMenu;
        [SerializeField]
        private InputActionReference _toggleRightMenu;
        [SerializeField]
        private GameObject _rightMenu;

        private void OnEnable()
        {
            _toggleLeftMenu.action.started += ToggleLeftMenu;
            _toggleRightMenu.action.started += ToggleRightMenu;
        }
        private void OnDisable()
        {
            _toggleLeftMenu.action.started -= ToggleLeftMenu;
            _toggleRightMenu.action.started -= ToggleRightMenu;
        }

        public void ToggleLeftMenu(InputAction.CallbackContext context)
        {
            Debug.Log("LeftMenu");
            _leftMenu.SetActive(!_leftMenu.activeSelf);
        }
        public void ToggleRightMenu(InputAction.CallbackContext context)
        {
            Debug.Log("RightMenu");
            _rightMenu.SetActive(!_rightMenu.activeSelf);
        }
        public void TeleportPaytowin()
        {
            Debug.Log("Teleport");
        }
    }
}
