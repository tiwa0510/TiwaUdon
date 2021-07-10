
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

namespace TiwaUdon
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
    }
}
