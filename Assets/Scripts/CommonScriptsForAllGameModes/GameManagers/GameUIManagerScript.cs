using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIManagerScript : MonoBehaviour
{
    // Variables

    private GameStatsManagerScript statsRef;
    private CoreHealth coreHealthRef;

    [SerializeField] private TMP_Text coreHealthText;
    [SerializeField] private TMP_Text gameCurrencyText;
    [SerializeField] private TMP_Text waveNumberText;
    [SerializeField] private TMP_Text instructionsText;
    [SerializeField] private TMP_Text powerupInstructionsText;
    

    [SerializeField] private Animator coreHealthAnimator;
    [SerializeField] private Animator gameCurrencyAnimator;
    [SerializeField] private Animator waveNumberAnimator;
    [SerializeField] private Animator instructionsAnimator;
    [SerializeField] private Animator powerupInstructionsAnimator;


    // Functions

    private void Start() {
        statsRef = GameObject.Find("GameManagers/GameStatsManager").GetComponent<GameStatsManagerScript>();
        coreHealthRef = GameObject.FindWithTag("Core").GetComponent<CoreHealth>();
    }

    // Update the UI taking data from the stats script
    private void Update() {
        
        // Updating core health
        coreHealthText.text = ((int) coreHealthRef.coreHealth).ToString();

        // Updating game currency
        gameCurrencyText.text = ((int) statsRef.gameCurrency).ToString();

        // Updating wave number 
        waveNumberText.text = ((int) statsRef.waveNumber).ToString();      


    }

    // Function to show the wave number on increment

    public void IncrementWaveNumber(){
        waveNumberAnimator.SetTrigger("play");
    }

    // Pop health text

    public void PopCoreHealthUI(){
        coreHealthAnimator.SetTrigger("pop");
    }

    // Pop currrency text

    public void PopGameCurrencyUI(){
        gameCurrencyAnimator.SetTrigger("pop");
    }

    // Function to show instructions

    public void ShowInstructions(string info, float duration){

        instructionsText.text = info;
        instructionsAnimator.SetTrigger("enter");
        Invoke("ShowInstructionsEnd", duration);
    }

    private void ShowInstructionsEnd(){
        instructionsAnimator.SetTrigger("exit");
    }

    // Function to show powerup instructions

    public void ShowPowerupInstructions(string info, float duration){

        powerupInstructionsText.text = info;
        powerupInstructionsAnimator.SetTrigger("enter");
        Invoke("ShowPowerupInstructionsEnd", duration);

    }

    private void ShowPowerupInstructionsEnd(){
        powerupInstructionsAnimator.SetTrigger("exit");
    }









}
