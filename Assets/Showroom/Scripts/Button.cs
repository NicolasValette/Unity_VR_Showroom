using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.OpenXR.Input;

namespace Showroom
{
    public class Button : MonoBehaviour
    {
        [SerializeField]
        private XRLever _lever;
        [SerializeField]
        private Animator _infoPanelAnim;
        [SerializeField]
        private XRPushButton _pushButton;
        [SerializeField]
        private VideoPlayer _videoPlayer;
        [SerializeField]
        private TeleportationAnchor _teleportationAnchor;
        [SerializeField]
        private TeleportationProvider _teleportationProvider;

        private bool _isPop = false;

        private void OnEnable()
        {
            _lever.onLeverActivate.AddListener(Activate);
            _lever.onLeverActivate.AddListener(Teleport);
            _lever.onLeverDeactivate.AddListener(Deactivate);

            _pushButton.onPress.AddListener(Activate);
            _pushButton.onRelease.AddListener(Deactivate);
        }
        private void OnDisable()
        {
            _lever.onLeverActivate.RemoveListener(Activate);
            _lever.onLeverActivate.RemoveListener(Teleport);
            _lever.onLeverDeactivate.RemoveListener(Deactivate);

            _pushButton.onPress.RemoveListener(Activate);
            _pushButton.onRelease.RemoveListener(Deactivate);
        }
        public void Activate()
        {
            Debug.Log("Activate");
        }
        public void Deactivate()
        {
            Debug.Log("Deactivate");
        }
        public void PopupInfo()
        {
            Debug.Log("Appear");

            _infoPanelAnim.SetTrigger(_isPop ? "Disappear" : "Appear");
            _isPop = !_isPop;
        }
        public void Play()
        {
            Debug.Log("Play");
            _videoPlayer.Play();
        }

        public void Teleport()
        {
            Debug.Log("TP");
            TeleportRequest tr;
            tr.destinationRotation = _teleportationAnchor.teleportAnchorTransform.rotation;
            tr.destinationPosition = _teleportationAnchor.teleportAnchorTransform.position;
            tr.requestTime = 10f;
            tr.matchOrientation = _teleportationAnchor.matchOrientation;

            _teleportationProvider.QueueTeleportRequest(tr);

        }
    }
}
