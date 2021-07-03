
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

[AddComponentMenu("Udonco/UI/UdoncoObjectStateButton")]
public class UdoncoObjectStateButton : UdonSharpBehaviour
{
    [SerializeField] private GameObject StateTarget;

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
        state = StateTarget.activeSelf;
        UpdateStateButton();
    }

    public void UpdateStateButton()
    {
        state = StateTarget.activeSelf;
        
        if (EnableStateObject != null)
        {
            EnableStateObject.SetActive(state);
        }

        if (EnableStateObject != null)
        {
            DisableStateObject.SetActive(!state);
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
