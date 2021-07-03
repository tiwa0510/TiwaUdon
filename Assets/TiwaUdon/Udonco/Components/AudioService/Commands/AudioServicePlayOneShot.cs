using System;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using UdonSharp;
using VRC.Udon.Serialization.OdinSerializer.Utilities;

namespace TiwaUdon.Udonco.AudioService
{
    [AddComponentMenu("Udonco/AudioService/Commands/AudioServicePlayOneShot")]
    public class AudioServicePlayOneShot : UdonSharpBehaviour
    {
        [SerializeField] private SoundEffectAudioService Receiver;
        [SerializeField] private string AudioChipName;

        private CustomEventInvoker invoker;

        private void Start()
        {
            SetupCustomEventInvoker(nameof(PlaySoundEffect));
        }

        public void PlaySoundEffect()
        {
            if (Receiver == null)
            {
                return;
            }
            Receiver.PlaySoundEffect(AudioChipName, true);
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
