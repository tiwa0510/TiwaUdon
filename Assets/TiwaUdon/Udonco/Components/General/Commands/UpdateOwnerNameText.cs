using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using UdonSharp;

namespace TiwaUdon.Udonco.General
{
    [AddComponentMenu("Udonco/General/Commands/UpdateOwnerNameText")]
    public class UpdateOwnerNameText : UdonSharpBehaviour
    {
        [SerializeField] private ObjectOwnerNameDisplay objectOwnerNameDisplay;
        private CustomEventInvoker invoker;

        private void Start()
        {
            SetupCustomEventInvoker(nameof(UpdateOwnerNameDisplay));
        }

        public void UpdateOwnerNameDisplay()
        {
            objectOwnerNameDisplay.SetObjectOwnerName();
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
