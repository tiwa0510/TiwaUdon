using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using UdonSharp;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/Core/EventTrigger/UdoncoOnPlayerTriggerExitEvent")]
    public class UdoncoOnPlayerTriggerExitEvent : UdonSharpBehaviour 
    {
        [SerializeField] private bool isLocalPlayerOnly;
        [SerializeField] private CustomEventInvoker[] Invokers;

        public override void OnPlayerTriggerExit(VRCPlayerApi player)
        {
            if(isLocalPlayerOnly && Networking.LocalPlayer != player) return;
            
            for (int i = 0; i < Invokers.Length; i++)
            {
                Invokers[i].InvokeCustomEvent();
            }
        }
    }
}
