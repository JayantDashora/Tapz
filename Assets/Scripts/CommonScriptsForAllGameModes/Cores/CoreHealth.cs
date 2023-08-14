using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreHealth : MonoBehaviour
{
    // Variables 

    [SerializeField] public float coreHealth; 

    private GameplayManagerScript gamePlayManager;

    // Functions
    private void Start() {
        gamePlayManager = GameObject.Find("GameManagers/GameplayManager").GetComponent<GameplayManagerScript>();
    }

    private void Update() {

        // Checking whether the game is over or not

        if(coreHealth <= 0){
            gamePlayManager.isGameover = true;
        }

    }
    

}
