using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using UdonSharp;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/Core/Commands/SetAnimationTrigger")]
    public class SetAnimationTrigger : UdonSharpBehaviour
    {
        [SerializeField] private Animator Receiver;
        [SerializeField] private string ParameterName;
        private CustomEventInvoker invoker;

        private void Start()
        {
            SetupCustomEventInvoker(nameof(SetTrigger));
        }

        public void SetTrigger()
        {
            Receiver.SetTrigger(ParameterName);
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
