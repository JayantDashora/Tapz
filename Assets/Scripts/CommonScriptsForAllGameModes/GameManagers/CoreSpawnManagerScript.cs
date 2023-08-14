using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreSpawnManagerScript : MonoBehaviour
{
    // Variables

    private int coreChoice;

    private Vector3 center = new Vector3(0,0,0);

    // Defensive core references

    [SerializeField] private GameObject dcore1;
    [SerializeField] private GameObject dcore2;
    [SerializeField] private GameObject dcore3;
    [SerializeField] private GameObject dcore4;

    // Offensive core references

    [SerializeField] private GameObject acore1;
    [SerializeField] private GameObject acore2;
    [SerializeField] private GameObject acore3;
    [SerializeField] private GameObject acore4;

    //Functions

    private void Awake() {

        // Setting the value of core choice to the match the choice made by the user in the menu 
        coreChoice = 8;
        SpawnCore();
    }

    // Spawn the core

    private void SpawnCore(){

        switch(coreChoice){

            case 1:
                CoreSpawnEffect();
                Instantiate(dcore1,center,Quaternion.identity);
                break;

            case 2:
                CoreSpawnEffect();
                Instantiate(dcore2,center,Quaternion.identity);
                break;

            case 3:
                CoreSpawnEffect();
                Instantiate(dcore3,center,Quaternion.identity);
                break;

            case 4:
                CoreSpawnEffect();
                Instantiate(dcore4,center,Quaternion.identity);
                break;

            case 5:
                CoreSpawnEffect();
                Instantiate(acore1,center,Quaternion.identity);
                break;

            case 6:
                CoreSpawnEffect();
                Instantiate(acore2,center,Quaternion.identity);
                break;

            case 7:
                CoreSpawnEffect();
                Instantiate(acore3,center,Quaternion.identity);
                break;

            case 8:
                CoreSpawnEffect();
                Instantiate(acore4,center,Quaternion.identity);
                break;

        }
    }

    // Game juice for the core spawn (Effect when the core spawns)

    private void CoreSpawnEffect(){
        // Add game juice here
    }

}
