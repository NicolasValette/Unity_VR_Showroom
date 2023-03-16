using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Showroom.Anim
{


    public class AnimationLauncher : MonoBehaviour
    {
        [SerializeField]
        private Animator _anim;

        [SerializeField]
        private float _jumpSpeed = 10f;
        [SerializeField]
        [Range(0f, 10f)]
        float speed = 0f;

        private float speedForward = 0f;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            var keyboard = Keyboard.current;
          
            if (keyboard.spaceKey.wasPressedThisFrame) //getkeydown
            {
                Debug.Log("Jump");
               // GetComponent<Rigidbody>().AddForce(Vector3.up * _jumpSpeed, ForceMode.Impulse);
                _anim.SetTrigger("Jump");
            }

            if (keyboard.upArrowKey.isPressed) // = getkey
            {
                speedForward = Mathf.Clamp(speedForward + 1f * Time.timeScale, 0, 5);
            }
            else if (keyboard.downArrowKey.isPressed)
            {
                speedForward = Mathf.Clamp(speedForward - 1f * Time.timeScale, -1,0);
            }
            _anim.SetFloat("Speed", speedForward);
        }
    }
}