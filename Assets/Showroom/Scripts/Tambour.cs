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
            if (collision.gameObject.CompareTag("Haptic"))
            {
                _drumSoundAudioSource.Play();
                collision.gameObject.GetComponent<GrabbableObject>().SendHapticFeedback();
            }
        }
    }
}
