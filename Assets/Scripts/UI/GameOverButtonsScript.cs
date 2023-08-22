using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtonsScript : MonoBehaviour
{
    // Variables

    [SerializeField] private Animator closingBannerAnimator;
    [SerializeField] private float transitionDelayHomeButton;


    // Functions
    public void HomeButtonTrigger(){
        closingBannerAnimator.SetBool("canClose", true);
        Invoke("HomeButton",transitionDelayHomeButton);
    }

    public void HomeButton(){
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
