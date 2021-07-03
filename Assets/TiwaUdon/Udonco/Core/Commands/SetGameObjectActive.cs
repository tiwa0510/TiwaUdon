
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace TiwaUdon.Udonco
{
    [AddComponentMenu("Udonco/Core/Commands/SetGameObjectActive")]
    public class SetGameObjectActive : UdonSharpBehaviour
    {
        [SerializeField] private GameObject[] Receivers;
        [SerializeField] private bool Operation;
        [SerializeField] private bool IsToggle;
        
        private CustomEventInvoker invoker;

        private void Start()
        {
            SetupCustomEventInvoker(nameof(SetActive));
        }
        
        public void SetActive()
        {
            if (IsToggle)
            {
                for (int i = 0; i < Receivers.Length; i++)
                {
                    Receivers[i].SetActive(!Receivers[i].activeSelf);
                }
            }
            else
            {
                for (int i = 0; i < Receivers.Length; i++)
                {
                    Receivers[i].SetActive(Operation);
                }
            }
        }
        
        private void SetupCustomEventInvoker(string eventName)
        {
            invoker = GetComponent<CustomEventInvoker>();
            if (invoker != null)
            {
                invoker.SetupCustomEvent(this, eventName);
            }
        }
    }
}
