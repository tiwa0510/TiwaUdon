
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

    void Start()
    {
        if (StateTarget != null)
        {
            state = StateTarget.activeSelf;
        }

        UpdateStateButton();
    }

    public void UpdateStateButton()
    {
        if (StateTarget != null)
        {
            state = StateTarget.activeSelf;
        }

        if (EnableStateObject != null)
        {
            EnableStateObject.SetActive(state);
        }

        if (DisableStateObject != null)
        {
            DisableStateObject.SetActive(!state);
        }
    }

    public void OnClickButtonEvent()
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
