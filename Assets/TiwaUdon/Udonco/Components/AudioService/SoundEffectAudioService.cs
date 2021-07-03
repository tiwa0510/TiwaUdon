
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace TiwaUdon.Udonco.AudioService
{
    [AddComponentMenu("Udonco/AudioService/SoundEffectAudioService")]
    public class SoundEffectAudioService : UdonSharpBehaviour
    {
        [SerializeField] AudioSource AudioSource;
        [SerializeField] AudioClip DefaultAudioClip;
        [SerializeField] AudioClip[] CustomAudioClip;
        [SerializeField] string[] CustomAudioClipName;

        public void PlaySoundEffect(string chipName, bool playDefaultSE)
        {
            int index = -1;
            for (int i = 0; i < CustomAudioClipName.Length; i++)
            {
                if (chipName == CustomAudioClipName[i])
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                if (playDefaultSE)
                {
                    AudioSource.PlayOneShot(DefaultAudioClip);
                }
                return;
            }

            AudioSource.PlayOneShot(CustomAudioClip[index]);
        }
    }
}