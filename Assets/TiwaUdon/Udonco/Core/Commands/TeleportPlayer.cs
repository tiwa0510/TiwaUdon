
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/Core/Commands/TeleportPlayer")]
    public class TeleportPlayer : UdonSharpBehaviour
    {
        [SerializeField] private Transform TeleportPoint;

        private CustomEventInvoker invoker;

        private void Start()
        {
            SetupCustomEventInvoker(nameof(Teleport));
        }

        public void Teleport()
        {
            Networking.LocalPlayer.TeleportTo(TeleportPoint.position, TeleportPoint.rotation);
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