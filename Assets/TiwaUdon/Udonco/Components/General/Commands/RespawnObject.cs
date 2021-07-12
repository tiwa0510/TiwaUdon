using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using UdonSharp;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/General/Commands/RespownObject")]
    public class RespawnObject : UdonSharpBehaviour
    {
        [SerializeField] private Transform Receiver;
        [SerializeField] private Transform RespownPoint;
        [SerializeField] private bool UseSelfStartPosition;

        private Vector3 respawnPosition;
        private Quaternion respawnRotation;
        
        private CustomEventInvoker invoker;

        private void Start()
        {
            if (UseSelfStartPosition)
            {
                respawnPosition = Receiver.transform.position;
                respawnRotation = Receiver.transform.rotation;
            }
            else
            {
                respawnPosition = RespownPoint.transform.position;
                respawnRotation = RespownPoint.transform.rotation;
            }
            SetupCustomEventInvoker(nameof(Respawn));
        }

        public void Respawn()
        {
            Receiver.transform.position = respawnPosition;
            Receiver.transform.rotation = respawnRotation;
        }
        
        private void SetupCustomEventInvoker(string eventName)
        {
            invoker = GetComponent<CustomEventInvoker>();
            if (invoker != null)
            {
                invoker.SetupCustomEvent(this, eventName);
            }
        }
    }
}
