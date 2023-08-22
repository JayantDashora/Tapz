using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlowdownScript : MonoBehaviour
{
    // Variables

    [SerializeField] private float lifetime;
    [SerializeField] private float slowdownFactor;

    private DefensiveCore4Script coreScriptRef;


    void Start(){

        coreScriptRef = GameObject.FindWithTag("Core").GetComponent<DefensiveCore4Script>();
        Slowdown();
        Invoke("SelfDestruct", lifetime);
    }

    // Functions 

    private void Update() {

        Time.timeScale += (1f/lifetime) * Time.deltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale,0f,1f);
        Gamejuice();

    }

    // Slowdown the game 

    private void Slowdown(){
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;       
    }

    // Game juice

    private void Gamejuice(){
        // Add game juice here (Some sort of time slowdown effect)
    }


    // Destroy gameobject 

    private void SelfDestruct(){
        // Add game juice here
        coreScriptRef.isUsingSpecialAttack = false;
        Destroy(gameObject);
    }
}
