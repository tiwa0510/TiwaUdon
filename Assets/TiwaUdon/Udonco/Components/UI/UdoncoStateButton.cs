
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.Udon.Common.Enums;

namespace TiwaUdon.Udonco.UI
{
    [AddComponentMenu("Udonco/UI/UdoncoStateButton")]
    public class UdoncoStateButton : UdonSharpBehaviour
    {
        [SerializeField] private bool InitialState;

        private bool state;
        
        [SerializeField] private GameObject EnableStateObject;
        [SerializeField] private GameObject DisableStateObject;
        [SerializeField] private Animator PressAnimator;
        [SerializeField] private bool playPressAnimation;

        [Header("Button")]
        [SerializeField] private Button thisButton;
        [SerializeField] private Text thisButtonText;
        
        void Start()
        {
            state = InitialState;
            UpdateStateButton();
        }

        public void UpdateStateButton()
        {
            if (EnableStateObject != null)
            {
                EnableStateObject.SetActive(state);
            }

            if (EnableStateObject != null)
            {
                DisableStateObject.SetActive(!state);
            }
        }

        public void SetState(bool setState)
        {
            state = setState;
            UpdateStateButton();
            
            if (playPressAnimation)
            {
                PlayAnimation();
            }
        }

        public void ToggleState()
        {
            state = !state;
            UpdateStateButton();
            
            if (playPressAnimation)
            {
                PlayAnimation();
            }
        }
        
        public void OnPressButton()
        {
            UpdateStateButton();
            if (playPressAnimation)
            {
                PlayAnimation();
            }
        }

        public void PlayAnimation()
        {
            if (PressAnimator != null)
            {
                PressAnimator.Play("Press", 0, 0.0f);
            }
        }
    }
}