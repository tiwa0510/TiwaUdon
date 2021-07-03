
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon.Common.Enums;

namespace TiwaUdon.PlayerCounter
{
    public class PlayerCounterManager : UdonSharpBehaviour
    {
        [SerializeField] private PlayerCounter[] playerCounters;

        public override void OnPlayerJoined(VRCPlayerApi player)
        {
            SendCustomEventDelayedSeconds(nameof(UpdatePlayerCount), 1f, EventTiming.Update);
        }

        public override void OnPlayerLeft(VRCPlayerApi player)
        {
            SendCustomEventDelayedSeconds(nameof(UpdatePlayerCount), 1f, EventTiming.Update);
        }

        public void UpdatePlayerCount()
        {
            int count = VRCPlayerApi.GetPlayerCount();
            for (int i = 0; i < playerCounters.Length; i++)
            {
                playerCounters[i].UpdateCounterText(count);
            }
        }
    }
}