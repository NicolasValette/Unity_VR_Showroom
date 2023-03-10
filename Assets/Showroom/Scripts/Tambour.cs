using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Showroom
{
    public class Tambour : MonoBehaviour
    {
    

        private AudioSource _drumSoundAudioSource;

        public static event Action OnDrumming;
        private void Start()
        {
            _drumSoundAudioSource = GetComponent<AudioSource>();
        }
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Collision");
            if (collision.gameObject.CompareTag("Haptic"))
            {
                Debug.Log("Boum");
                _drumSoundAudioSource.Play();
                //_controller.SendHapticImpulse(0.7f,0.1f);
                //OnDrumming?.Invoke();
                collision.gameObject.GetComponent<GrabbableObject>().SendHapticFeedback();
            }
        }
    }
}
