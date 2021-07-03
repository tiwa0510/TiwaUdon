using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using UdonSharp;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/Core/EventTrigger/UdoncoOnPickupUseDownEvent")]
    public class UdoncoOnPickupUseDownEvent : UdonSharpBehaviour 
    {
        [SerializeField] private CustomEventInvoker[] Invokers;

        public override void OnPickupUseDown()
        {
            for (int i = 0; i < Invokers.Length; i++)
            {
                Invokers[i].InvokeCustomEvent();
            }
        }
    }
}
