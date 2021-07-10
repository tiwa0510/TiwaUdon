
using System;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

namespace TiwaUdon
{
    public class InstanceOwnerNameDisplay : UdonSharpBehaviour
    {
        [SerializeField] private Text DisplayText;
        [SerializeField] private string Content = "";
        [SerializeField] private string Term = "{Name}";

        private void Start()
        {
            SendCustomEventDelayedSeconds(nameof(SetInstanceOwnerName), 1f);
        }

        public void SetInstanceOwnerName()
        {
            VRCPlayerApi[] players = new VRCPlayerApi[VRCPlayerApi.GetPlayerCount()];
            VRCPlayerApi.GetPlayers(players);

            DisplayText.text = "";

            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].isInstanceOwner)
                {
                    DisplayText.text = Content.Replace(Term, players[i].displayName);
                }
            }
        }
    }
}