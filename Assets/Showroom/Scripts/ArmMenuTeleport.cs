using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Showroom
{
    public class ArmMenuTeleport : MonoBehaviour
    {
        [Space]
        [SerializeField]
        private TeleportationProvider _teleportationProvider;


        public void Teleport(TeleportationAnchor destination)
        {
            Debug.Log("Teleport");
            TeleportRequest telleportRequest = new TeleportRequest()
            {
                destinationRotation = destination.teleportAnchorTransform.rotation,
                destinationPosition = destination.teleportAnchorTransform.position,
                requestTime = Time.time,
                matchOrientation = destination.matchOrientation
            };

            _teleportationProvider.QueueTeleportRequest(telleportRequest);
        }
    }
}
