using System;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using UdonSharp;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/Core/EventTrigger/UdoncoOnTriggerStayEvent")]
    public class UdoncoOnTriggerStayEvent : UdonSharpBehaviour 
    {
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private CustomEventInvoker[] Invokers;

        private void OnTriggerStay(Collider other)
        {
            if (((1 << other.gameObject.layer) & (layerMask.value)) != 0)
            {
                for (int i = 0; i < Invokers.Length; i++)
                {
                    Invokers[i].param_collider = other;
                    Invokers[i].InvokeCustomEvent();
                }
            }
        }
    }
}
