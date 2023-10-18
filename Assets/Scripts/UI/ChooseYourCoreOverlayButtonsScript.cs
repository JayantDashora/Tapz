using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseYourCoreOverlayButtonsScript : MonoBehaviour
{
    // Variables

    [SerializeField] private Animator closingBannerAnimator;
    [SerializeField] private float transitionDelayPlayButton;
    [SerializeField] private AudioClip buttonClickEffect;

    // Functions for all the different buttons 

    // DefensiveCore 1 (Use button)

    public void DefensiveCore1UseButton(){
        Data.chosenCoreIndex = 1;
        PlayGameTrigger();
    }


    // DefensiveCore 2 (Use button)

    public void DefensiveCore2UseButton(){
        Data.chosenCoreIndex = 2;
        PlayGameTrigger();
    }

    // DefensiveCore 3 (Use button)

    public void DefensiveCore3UseButton(){
        Data.chosenCoreIndex = 3;
        PlayGameTrigger();
    }

    // DefensiveCore 4 (Use button)

    public void DefensiveCore4UseButton(){
        Data.chosenCoreIndex = 4;
        PlayGameTrigger();
    }
    
    
    
    // OffensiveCore 1 (Use button)

    public void OffensiveCore1UseButton(){
        Data.chosenCoreIndex = 5;
        PlayGameTrigger();
    }

    // OffensiveCore 2 (Use button)
    
    public void OffensiveCore2UseButton(){
        Data.chosenCoreIndex = 6;
        PlayGameTrigger();
    }

    // OffensiveCore 3 (Use button)
    public void OffensiveCore3UseButton(){
        Data.chosenCoreIndex = 7;
        PlayGameTrigger();
    }

    // OffensiveCore 4 (Use button)

    public void OffensiveCore4UseButton(){
        Data.chosenCoreIndex = 8;
        PlayGameTrigger();
    }

    // (Play Button) Load the next scene 

    public void PlayGameTrigger(){
        GameAudioManager.instance.PlaySoundEffect(buttonClickEffect, 4f);
        closingBannerAnimator.SetBool("canClose", true);
        Invoke("PlayGame",transitionDelayPlayButton);
    }

    public void PlayGame(){
        SceneManager.LoadScene("Maingame", LoadSceneMode.Single);
    }





}
