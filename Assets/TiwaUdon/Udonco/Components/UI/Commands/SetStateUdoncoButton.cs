using TiwaUdon.Udonco.UI;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using UdonSharp;

namespace TiwaUdon.Udonco.UI
{
    [AddComponentMenu("Udonco/UI/Commands/SetStateUdoncoButton")]
    public class SetStateUdoncoButton : UdonSharpBehaviour
    {
        [SerializeField] private UdoncoButton Receiver;
        [SerializeField] private bool Operation;
        [SerializeField] private bool IsToggle;
        
        private CustomEventInvoker invoker;

        private void Start()
        {
            SetupCustomEventInvoker(nameof(SetState));
        }

        public void SetState()
        {
            if (IsToggle)
            {
                Receiver.ToggleState();
            }
            else
            {
                Receiver.SetState(Operation);
            }
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
