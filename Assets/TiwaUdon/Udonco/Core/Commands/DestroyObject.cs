using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using UdonSharp;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/Core/Commands/DestroyObject")]
    public class DestroyObject : UdonSharpBehaviour
    {
        [SerializeField] private GameObject[] Receivers;
        private CustomEventInvoker invoker;

        private void Start()
        {
            SetupCustomEventInvoker(nameof(DestroyReceivers));
        }

        public void DestroyReceivers()
        {
            for (int i = 0; i < Receivers.Length; i++)
            {
                Destroy(Receivers[i]);
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
