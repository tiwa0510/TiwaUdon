
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/Core/EventTrigger/UdoncoInteractEvent")]
    public class UdoncoInteractEvent : UdonSharpBehaviour
    {
        [SerializeField] private CustomEventInvoker[] Invokers;

        public override void Interact()
        {
            for (int i = 0; i < Invokers.Length; i++)
            {
                Invokers[i].InvokeCustomEvent();
            }
        }
    }
}