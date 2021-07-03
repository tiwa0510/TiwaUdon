using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using UdonSharp;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/Core/EventTrigger/UdoncoOnPlayerJoinedEvent")]
    public class UdoncoOnPlayerJoinedEvent : UdonSharpBehaviour 
    {
        [SerializeField] private bool isLocalPlayerOnly;
        [SerializeField] private CustomEventInvoker[] Invokers;

        public override void OnPlayerJoined(VRCPlayerApi player)
        {
            if(isLocalPlayerOnly && Networking.LocalPlayer != player) return;
            
            for (int i = 0; i < Invokers.Length; i++)
            {
                Invokers[i].InvokeCustomEvent();
            }
        }
    }
}
