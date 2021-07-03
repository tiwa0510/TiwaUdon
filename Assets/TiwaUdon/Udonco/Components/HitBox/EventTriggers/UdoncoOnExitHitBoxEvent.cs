
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace TiwaUdon.Udonco.HitBox
{
    [AddComponentMenu("Udonco/HitBox/EventTrigger/UdoncoOnExitHitBoxEvent")]
    public class UdoncoOnExitHitBoxEvent : UdonSharpBehaviour
    {
        [SerializeField] private CustomEventInvoker[] Invokers;

        public void OnExitUdonHitbox()
        {
            for (int i = 0; i < Invokers.Length; i++)
            {
                Invokers[i].InvokeCustomEvent();
            }
        }
    }
}