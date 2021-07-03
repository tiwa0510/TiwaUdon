using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;

namespace TiwaUdon.WorldUtility
{
    public class MasterNameDisplay : UdonSharpBehaviour
    {
        [SerializeField] private Text DisplayText;
        [SerializeField] private string Content = "";
        [SerializeField] private string Term = "{MasterName}";

        public override void OnPlayerJoined(VRCPlayerApi player)
        {
            DisplayText.text = Content.Replace(Term, Networking.GetOwner(gameObject).displayName);
        }

        public override void OnPlayerLeft(VRCPlayerApi player)
        {
            DisplayText.text = Content.Replace(Term, Networking.GetOwner(gameObject).displayName);
        }
    }
}
