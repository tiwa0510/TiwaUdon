using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using UdonSharp;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/Core/Commands/SetMaterial")]
    public class SetMaterial : UdonSharpBehaviour
    {
        [SerializeField] private Renderer Receiver;
        [SerializeField] private Material SetValue;
        private CustomEventInvoker invoker;

        private void Start()
        {
            SetupCustomEventInvoker(nameof(SetMaterialRenderer));
        }

        public void SetMaterialRenderer()
        {
            Receiver.sharedMaterial = SetValue;
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
