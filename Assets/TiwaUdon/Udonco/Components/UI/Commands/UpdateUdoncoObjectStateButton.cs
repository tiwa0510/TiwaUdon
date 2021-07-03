
using UdonSharp;
using UnityEngine;
using UnityEngine.Timeline;

namespace TiwaUdon.Udonco.UI
{
    [AddComponentMenu("Udonco/UI/Commands/UpdateUdoncoObjectStateButton")]
    public class UpdateUdoncoObjectStateButton : UdonSharpBehaviour
    {
        [SerializeField] private UdoncoObjectStateButton[] objectStateReceivers;
        
        private CustomEventInvoker invoker;

        private void Start()
        {
            SetupCustomEventInvoker(nameof(UpdateAll));
        }

        public void UpdateAll()
        {
            for (int i = 0; i < objectStateReceivers.Length; i++)
            {
                objectStateReceivers[i].UpdateStateButton();
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