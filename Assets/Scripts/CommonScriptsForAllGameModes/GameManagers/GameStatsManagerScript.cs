using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatsManagerScript : MonoBehaviour
{
    // Game Stats

    [HideInInspector] public int gameCurrency;
    [HideInInspector] public int waveNumber = 1;
    [SerializeField] private float scoreMultiplier;

    // References 

    private CoreHealth coreHealthScriptRef;

    // Functions

    private void Start() {

        coreHealthScriptRef = GameObject.FindWithTag("Core").GetComponent<CoreHealth>();

    }

    private void Update() {
        Debug.Log("Game Currency: " + gameCurrency.ToString() + "             Core Health: " + coreHealthScriptRef.coreHealth.ToString() + "             Wave Number: " + waveNumber.ToString());

    }




}