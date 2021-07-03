using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using UdonSharp;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/Core/Commands/SetAnimationFloat")]
    public class SetAnimationFloat : UdonSharpBehaviour 
    {
        [SerializeField] private Animator Receiver;
        [SerializeField] private string ParameterName;
        [SerializeField] private float SetValue;
        private CustomEventInvoker invoker;

        private void Start()
        {
            SetupCustomEventInvoker(nameof(SetFloat));
        }

        public void SetFloat()
        {
            Receiver.SetFloat(ParameterName, SetValue);
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
