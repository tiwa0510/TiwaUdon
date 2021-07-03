
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace TiwaUdon.PlayerCounter
{
    public class PlayerCounter : UdonSharpBehaviour
    {
        [SerializeField] private Text activeCountText;

        public void UpdateCounterText(int count)
        {
            activeCountText.text = count.ToString("D2");
        }
    }
}