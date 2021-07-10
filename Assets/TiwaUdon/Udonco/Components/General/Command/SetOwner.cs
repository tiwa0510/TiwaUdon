using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using UdonSharp;

namespace TiwaUdon.Udonco.General
{
    [AddComponentMenu("Udonco/General/Commands/SetOwner")]
    public class SetOwner : UdonSharpBehaviour
    {
        [SerializeField] private GameObject Receiver;
        
        private CustomEventInvoker invoker;

        private void Start()
        {
            SetupCustomEventInvoker(nameof(OwnerSet));
        }

        public void OwnerSet()
        {
            Networking.SetOwner(Networking.LocalPlayer, Receiver);
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
