using System.Collections;
using System.Collections.Generic;
using UdonSharp;
using UnityEngine;
using VRC.Udon;
using VRC.Udon.Common.Enums;
using VRC.Udon.Common.Interfaces;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/Invoker/CustomEventInvoker")]
    public class CustomEventInvoker : UdonSharpBehaviour
    {
        private UdonSharpBehaviour target;
        private string eventName;

        [SerializeField] private float DelayTime;
        [SerializeField] private bool IsNetwork;
        [SerializeField] private NetworkEventTarget NetworkEventTarget;

        public void SetupCustomEvent(UdonSharpBehaviour _target, string _eventName)
        {
            target = _target;
            eventName = _eventName;
        }

        public void InvokeCustomEvent()
        {
            if (IsNetwork)
            {
                target.SendCustomNetworkEvent(NetworkEventTarget, eventName);
            }
            else
            {
                if (DelayTime <= 0)
                {
                    target.SendCustomEvent(eventName);
                }
                else
                {
                    target.SendCustomEventDelayedSeconds(eventName, DelayTime);
                }
            }
        }
    }
}