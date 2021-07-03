using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using UdonSharp;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/Core/Commands/PlayAnimator")]
    public class PlayAnimator : UdonSharpBehaviour
    {
        [SerializeField] private Animator Receiver;
        [SerializeField] private string StateName;
        [SerializeField] private int layer;
        [SerializeField] private float normalizedTime;
        private CustomEventInvoker invoker;

        private void Start()
        {
            SetupCustomEventInvoker(nameof(Play));
        }

        public void Play()
        {
            Receiver.Play(StateName, layer, normalizedTime);
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
