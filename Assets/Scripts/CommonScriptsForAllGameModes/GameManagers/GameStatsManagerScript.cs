using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatsManagerScript : MonoBehaviour
{
    // Game Stats

    [HideInInspector] public int gameCurrency;
    public int waveNumber = 1;
    [HideInInspector] public int highScore;

    // References 

    private CoreHealth coreHealthScriptRef;

    // Functions

    private void Start() {

        coreHealthScriptRef = GameObject.FindWithTag("Core").GetComponent<CoreHealth>();
        highScore = PlayerPrefs.GetInt("HIGHSCORE");

    }

    private void Update() {

        if(waveNumber > highScore){
            // Add game juice here for the new highscore
            PlayerPrefs.SetInt("HIGHSCORE", waveNumber);
            PlayerPrefs.Save();
        }

        Data.thisGameScore = waveNumber;

    }




}