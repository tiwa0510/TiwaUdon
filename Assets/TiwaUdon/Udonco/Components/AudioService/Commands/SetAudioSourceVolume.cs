using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/Core/Commands/SetAudioSourceVolume")]
    public class SetAudioSourceVolume : UdonSharpBehaviour
    {
        [SerializeField] private AudioSource Receiver;
        [SerializeField] private float Volume;

        private CustomEventInvoker invoker;

        private void Start()
        {
            SetupCustomEventInvoker(nameof(SetVolume));
        }

        public void SetVolume()
        {
            Receiver.volume = Volume;
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