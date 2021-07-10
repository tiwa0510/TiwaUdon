using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;

namespace TiwaUdon
{
    public class ObjectOwnerNameDisplay : UdonSharpBehaviour
    {
        [SerializeField] private GameObject Target;
        [SerializeField] private Text DisplayText;
        [SerializeField] private string Content = "";
        [SerializeField] private string Term = "{Name}";

        public override void OnPlayerJoined(VRCPlayerApi player)
        {
            SendCustomEventDelayedSeconds(nameof(SetObjectOwnerName), 1f);
        }

        public override void OnPlayerLeft(VRCPlayerApi player)
        {
            SendCustomEventDelayedSeconds(nameof(SetObjectOwnerName), 1f);
        }

        public void SetObjectOwnerName()
        {
            DisplayText.text = Content.Replace(Term, Networking.GetOwner(Target).displayName);
        }
    }
}
