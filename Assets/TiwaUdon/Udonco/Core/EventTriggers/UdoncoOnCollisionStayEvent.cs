using System;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using UdonSharp;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/Core/EventTrigger/UdoncoOnCollisionStayEvent")]
    public class UdoncoOnCollisionStayEvent : UdonSharpBehaviour 
    {
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private CustomEventInvoker[] Invokers;

        private void OnCollisionStay(Collision other)
        {
            if (((1 << other.gameObject.layer) & (layerMask.value)) != 0)
            {
                for (int i = 0; i < Invokers.Length; i++)
                {
                    Invokers[i].param_collision = other;
                    Invokers[i].InvokeCustomEvent();
                }
            }
        }
    }
}
