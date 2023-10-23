using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverButtonsScript : MonoBehaviour
{
    // Variables

    [SerializeField] private AudioClip buttonClickEffect;

    [SerializeField] private Animator closingBannerAnimator;
    [SerializeField] private float transitionDelayHomeButton;
    [SerializeField] private Button rewardButton;


    // Functions
    public void HomeButtonTrigger(){
        GameAudioManager.instance.PlaySoundEffect(buttonClickEffect, 15f);
        closingBannerAnimator.SetBool("canClose", true);
        Invoke("HomeButton",transitionDelayHomeButton);
    }

    public void HomeButton(){
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void RewardButton(){
        AdsManager.instance.ShowRewardedAd();
        rewardButton.gameObject.SetActive(false);
    }
}
