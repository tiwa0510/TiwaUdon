
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/Core/EventTrigger/UdoncoOnPlayerTriggerEnterEvent")]
    public class UdoncoOnPlayerTriggerEnterEvent : UdonSharpBehaviour
    {
        [SerializeField] private bool isLocalPlayerOnly;
        [SerializeField] private CustomEventInvoker[] Invokers;

        public override void OnPlayerTriggerEnter(VRCPlayerApi player)
        {
            if(isLocalPlayerOnly && Networking.LocalPlayer != player) return;
            
            for (int i = 0; i < Invokers.Length; i++)
            {
                Invokers[i].InvokeCustomEvent();
            }
        }
    }
}