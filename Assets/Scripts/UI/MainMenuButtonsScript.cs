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

    // Functions

    // (ChooseCore Button) Setup the choose core scene

    public void ChooseCoreTrigger(){
        closingBannerAnimator.SetBool("canClose", true);
        Invoke("ChooseCore",transitionDelayChooseCoreButton);
    }    

    public void ChooseCore(){
        mainMenu.SetActive(false);
        chooseCoreScreen.SetActive(true);
    }

}
