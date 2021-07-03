using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using UdonSharp;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/Core/Commands/SetAnimatorEnable")]
    public class SetAnimatorEnable : UdonSharpBehaviour 
    {
        [SerializeField] private Animator[] Receivers;
        [SerializeField] private bool Operation;
        [SerializeField] private bool IsToggle;
        private CustomEventInvoker invoker;

        private void Start()
        {
            SetupCustomEventInvoker(nameof(SetEnable));
        }

        public void SetEnable()
        {
            if (IsToggle)
            {
                for (int i = 0; i < Receivers.Length; i++)
                {
                    Receivers[i].enabled = !Receivers[i].enabled;
                }
            }
            else
            {
                for (int i = 0; i < Receivers.Length; i++)
                {
                    Receivers[i].enabled = Operation;
                }
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
