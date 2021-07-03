
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

namespace TiwaUdon.WorldUtility
{
    public class WorldSetting : UdonSharpBehaviour
    {
        [SerializeField] private bool useLegacyLocomotion;
        [SerializeField] private float jumpPower = 3;
        [SerializeField] private float strafeSpeed = 2;
        [SerializeField] private float walkSpeed = 2;
        [SerializeField] private float runSpeed = 4;

        void Start()
        {
            if (Networking.LocalPlayer == null) return;
            
            Networking.LocalPlayer.SetJumpImpulse(jumpPower);
            Networking.LocalPlayer.SetStrafeSpeed(strafeSpeed);
            Networking.LocalPlayer.SetWalkSpeed(walkSpeed);
            Networking.LocalPlayer.SetRunSpeed(runSpeed);
            if (useLegacyLocomotion)
            {
                Networking.LocalPlayer.UseLegacyLocomotion();
            }
        }

        public void SetJumpPower(float set)
        {
            if (Networking.LocalPlayer == null) return;
            jumpPower = set;
            Networking.LocalPlayer.SetJumpImpulse(jumpPower);
        }

        public float GetJumpPower()
        {
            return jumpPower;
        }
        
        public void SetStrafeSpeed(float set)
        {
            if (Networking.LocalPlayer == null) return;
            strafeSpeed = set;
            Networking.LocalPlayer.SetStrafeSpeed(strafeSpeed);
        }

        public float GetStrafeSpeed()
        {
            return strafeSpeed;
        }
        
        public void SetWalkSpeed(float set)
        {
            if (Networking.LocalPlayer == null) return;
            walkSpeed = set;
            Networking.LocalPlayer.SetWalkSpeed(walkSpeed);
        }

        public float GetWalkSpeed()
        {
            return walkSpeed;
        }
        
        public void SetRunSpeed(float set)
        {
            if (Networking.LocalPlayer == null) return;
            runSpeed = set;
            Networking.LocalPlayer.SetRunSpeed(runSpeed);
        }

        public float GetRunSpeed()
        {
            return runSpeed;
        }
    }
}
