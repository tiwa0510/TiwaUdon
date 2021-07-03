using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using UdonSharp;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/Core/Commands/SetLayer")]
    public class SetLayer : UdonSharpBehaviour
    {
        [SerializeField] private GameObject Receiver;
        [SerializeField] private LayerMask SetValue;
        private CustomEventInvoker invoker;

        private void Start()
        {
            SetupCustomEventInvoker(nameof(SetLayerObject));
        }

        public void SetLayerObject()
        {
            Receiver.layer = SetValue;
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
