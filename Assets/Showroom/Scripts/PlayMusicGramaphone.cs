using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

namespace Showroom
{
    public class PlayMusicGramaphone : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _musicSource;
        [SerializeField]
        private XRLever _lever;

        private void OnEnable()
        {
            _lever.onLeverActivate.AddListener(Play);
            _lever.onLeverDeactivate.AddListener(Stop);


        }
        private void OnDisable()
        {
            _lever.onLeverActivate.RemoveListener(Play);
            _lever.onLeverDeactivate.RemoveListener(Stop);


        }

        public void Play()
        {
            Debug.Log("Play");
            _musicSource.Play();
        }
        public void Stop()
        {
            Debug.Log("Stop");
            _musicSource.Stop();
        }
    }
}
