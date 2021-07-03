
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace TiwaUdon.Udonco.HitBox
{
    [AddComponentMenu("Udonco/HitBox/EventTrigger/UdoncoOnEnterHitBoxEvent")]
    public class UdoncoOnEnterHitBoxEvent : UdonSharpBehaviour
    {
        [SerializeField] private CustomEventInvoker[] Invokers;

        public void OnEnterUdonHitbox()
        {
            for (int i = 0; i < Invokers.Length; i++)
            {
                Invokers[i].InvokeCustomEvent();
            }
        }
    }
}
