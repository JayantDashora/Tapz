using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManagerScript : MonoBehaviour
{

    // Variables

    public bool isGameover = false;
    [SerializeField] private int gameOverSceneIndex; 

    private void Update() {
        if(isGameover == true){

            // Check whether the game is over or not
            // Move to next scene
            // Add scene transition effects here

            SceneManager.LoadScene(gameOverSceneIndex, LoadSceneMode.Single);
        }
    }



}
