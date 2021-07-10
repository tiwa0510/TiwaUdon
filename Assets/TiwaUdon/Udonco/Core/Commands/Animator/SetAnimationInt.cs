using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using UdonSharp;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/Core/Commands/SetAnimationInt")]
    public class SetAnimationInt : UdonSharpBehaviour
    {
        [SerializeField] private Animator Receiver;
        [SerializeField] private string ParameterName;
        [SerializeField] private int SetValue;
        
        private CustomEventInvoker invoker;

        private void Start()
        {
            SetupCustomEventInvoker(nameof(SetInt));
        }

        public void SetInt()
        {
            Receiver.SetInteger(ParameterName, SetValue);
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
