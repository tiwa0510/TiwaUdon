
using TiwaUdon.Udonco.UI;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/UI/EventTrigger/UdoncoOnClickButtonEvent")]
    public class UdoncoOnClickButtonEvent : UdonSharpBehaviour
    {
        [SerializeField] private CustomEventInvoker[] Invokers;

        public void OnClickButtonEvent()
        {
            for (int i = 0; i < Invokers.Length; i++)
            {
                Invokers[i].InvokeCustomEvent();
            }
        }
    }
}