using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtonsScript : MonoBehaviour
{
    // Variables

    [SerializeField] private AudioClip buttonClickEffect;

    [SerializeField] private Animator closingBannerAnimator;
    [SerializeField] private float transitionDelayHomeButton;


    // Functions
    public void HomeButtonTrigger(){
        GameAudioManager.instance.PlaySoundEffect(buttonClickEffect, 15f);
        closingBannerAnimator.SetBool("canClose", true);
        Invoke("HomeButton",transitionDelayHomeButton);
    }

    public void HomeButton(){
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
