
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;

namespace TiwaUdon.WorldUtility
{
    public class PlayerSetVoiceDistanceFar : UdonSharpBehaviour
    {
        [SerializeField] private Slider SettingSlider;
        [SerializeField] private Text DisplayText;
        [SerializeField] private string Content;
        [SerializeField] private string Term = "{Value}";

        private void Start()
        {
            DisplayText.text = Content.Replace(Term, SettingSlider.value.ToString());
        }

        public void OnSliderValueChanged()
        {
            VRCPlayerApi[] players = new VRCPlayerApi[VRCPlayerApi.GetPlayerCount()];
            VRCPlayerApi.GetPlayers(players);

            for (int i = 0; i < players.Length; i++)
            {
                players[i].SetVoiceDistanceFar(SettingSlider.value);
            }
            DisplayText.text = Content.Replace(Term, SettingSlider.value.ToString());
        }
    }
}
