
using System;
using TiwaUdon.Udonco;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace TiwaUdon.Udonco.HitBox
{
    [AddComponentMenu("Udonco/HitBox/HitBox")]
    public class HitBox : UdonSharpBehaviour
    {
        public bool isTargetLocalPlayer;

        public Transform targetObject;
        private Vector3 targetPos;

        public Transform pointA;
        public Transform pointB;
        public Transform pointC;
        public Transform pointD;
        public float height = 1;

        private Vector3 HitBoxRF;
        private Vector3 HitBoxLB;

        public bool isStayTarget;

        private UdoncoOnEnterHitBoxEvent onEnter;
        private UdoncoOnExitHitBoxEvent onExit;

        void Start()
        {
            UpdateHitbox();
            onEnter = GetComponent<UdoncoOnEnterHitBoxEvent>();
            onExit = GetComponent<UdoncoOnExitHitBoxEvent>();
        }

        private void FixedUpdate()
        {
            if (isTargetLocalPlayer)
            {
                if (Networking.LocalPlayer == null) return;
                targetPos = Networking.LocalPlayer.GetPosition();
            }
            else
            {
                if (targetObject == null) return;
                targetPos = targetObject.position;
            }

            var prevState = isStayTarget;
            isStayTarget = HitBoxLB.x <= targetPos.x && targetPos.x <= HitBoxRF.x &&
                           HitBoxLB.z <= targetPos.z && targetPos.z <= HitBoxRF.z &&
                           transform.position.y <= targetPos.y && targetPos.y <= transform.position.y + height;
            if (prevState != isStayTarget)
            {
                if (isStayTarget)
                {
                    if (onEnter != null)
                    {
                        onEnter.OnEnterUdonHitbox();
                    }
                }
                else
                {
                    if (onExit != null)
                    {
                        onExit.OnExitUdonHitbox();
                    }
                }
            }
        }

        void UpdateHitbox()
        {
            HitBoxRF.x = GetMax4(pointA.position.x, pointB.position.x, pointC.position.x, pointD.position.x);
            HitBoxRF.z = GetMax4(pointA.position.z, pointB.position.z, pointC.position.z, pointD.position.z);
            HitBoxLB.x = GetMin4(pointA.position.x, pointB.position.x, pointC.position.x, pointD.position.x);
            HitBoxLB.z = GetMin4(pointA.position.z, pointB.position.z, pointC.position.z, pointD.position.z);
        }

        float GetMax4(float f1, float f2, float f3, float f4)
        {
            return Mathf.Max(f4, Mathf.Max(f3, Mathf.Max(f1, f2)));
        }

        float GetMin4(float f1, float f2, float f3, float f4)
        {
            return Mathf.Min(f4, Mathf.Min(f3, Mathf.Min(f1, f2)));
        }
    }
}