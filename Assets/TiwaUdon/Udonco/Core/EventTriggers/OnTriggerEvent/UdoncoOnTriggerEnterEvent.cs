using System;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using UdonSharp;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/Core/EventTrigger/UdoncoOnTriggerEnterEvent")]
    public class UdoncoOnTriggerEnterEvent : UdonSharpBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private CustomEventInvoker[] Invokers;

        private void OnTriggerEnter(Collider other)
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
