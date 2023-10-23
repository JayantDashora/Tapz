using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonsScript : MonoBehaviour
{
    // Variables

    [SerializeField] private Animator closingBannerAnimator;
    [SerializeField] private float transitionDelayPlayButton;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject chooseCoreScreen;
    [SerializeField] private float transitionDelayChooseCoreButton;
    [SerializeField] private AudioClip buttonClickEffect;

    private bool adShown = false; // Add this variable to track if the ad has been shown

    // Functions

    // (ChooseCore Button) Setup the choose core scene

    public void ChooseCoreTrigger()
    {
        GameAudioManager.instance.PlaySoundEffect(buttonClickEffect, 15f);
        closingBannerAnimator.SetBool("canClose", true);
        Invoke("ChooseCore", transitionDelayChooseCoreButton);
    }

    public void ChooseCore()
    {
        mainMenu.SetActive(false);
        chooseCoreScreen.SetActive(true);
    }

    public void ShowAd()
    {
        if (!adShown)
        {
            AdsManager.instance.ShowInterstitialAd();
            adShown = true;
        }
    }
}
