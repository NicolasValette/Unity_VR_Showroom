using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Showroom
{
    [RequireComponent(typeof(XRBaseInteractable))]
    public class GrabbableObject : MonoBehaviour
    {
        private void OnEnable()
        {
            //Tambour.OnDrumming += SendHapticFeedback;
        }
        private void OnDisable()
        {
            //Tambour.OnDrumming -= SendHapticFeedback;
        }

        public void SendHapticFeedback()
        {
            XRBaseInteractable xrbi = (XRBaseInteractable) GetComponent<XRBaseInteractable>();
            XRBaseControllerInteractor hand = (XRBaseControllerInteractor)xrbi.GetOldestInteractorSelecting();
            if (hand != null)
            {
                hand.SendHapticImpulse(0.7f, 0.1f);
            }
        }
        public void Grab()
        {
            Debug.Log("Grab");
        }
        public void Acti()
        {
            Debug.Log("Acti");
        }
    }
}