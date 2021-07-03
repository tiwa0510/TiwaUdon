using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using UdonSharp;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/Core/Commands/SetAnimationBool")]
    public class SetAnimationBool : UdonSharpBehaviour
    {
        [SerializeField] private Animator Receiver;
        [SerializeField] private string ParameterName;
        [SerializeField] private bool SetValue;
        private CustomEventInvoker invoker;

        private void Start()
        {
            SetupCustomEventInvoker(nameof(SetBool));
        }

        public void SetBool()
        {
            Receiver.SetBool(ParameterName, SetValue);
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
