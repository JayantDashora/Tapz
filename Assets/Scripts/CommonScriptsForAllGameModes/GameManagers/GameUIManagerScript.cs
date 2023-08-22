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


    }

}
