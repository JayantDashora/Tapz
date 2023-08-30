using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManagerScript : MonoBehaviour
{

    // Variables

    [SerializeField] GameObject sceneTransitionEffect;
    [SerializeField] private float sceneTransitionDelay;

    [HideInInspector] public bool isGameover = false; 
    [HideInInspector] public bool nextSceneTriggered = false;

    private Vector3 center = new Vector3(0,0,0);

    private void Update() {
        if(isGameover == true && nextSceneTriggered == false){

            // Check whether the game is over or not
            // Move to next scene
            // Add scene transition effects here

            SceneTransition();
            Invoke("NextScene", sceneTransitionDelay);
            nextSceneTriggered = true;
        }
    }

    // Move to the next scene

    private void NextScene(){
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

    // Scene transition effect

    private void SceneTransition(){
        // Add other effects here
        sceneTransitionEffect.SetActive(true);
        sceneTransitionEffect.GetComponent<Animator>().SetTrigger("start");
    }



}
