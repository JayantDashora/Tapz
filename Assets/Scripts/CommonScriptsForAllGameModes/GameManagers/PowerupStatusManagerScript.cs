using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupStatusManagerScript : MonoBehaviour
{
    // Variables

    [HideInInspector] public int powerupChoice;

    [SerializeField] private GameObject landmine;

    [SerializeField] private int waveNumberBoostAmount;
    [SerializeField] private int gameCurrencyBoostAmount;

    float lastTapTime = 0f;
    float doubleTapThreshold = 0.3f;

    protected CoreHealth coreHealthScriptRef;
    private GameStatsManagerScript statsRef;

    // Functions 

    private void Start() {
        coreHealthScriptRef = GameObject.FindWithTag("Core").GetComponent<CoreHealth>();
        statsRef = GameObject.Find("GameManagers/GameStatsManager").GetComponent<GameStatsManagerScript>();
    }

    private void Update() {

        // LANDMINE POINTER POWERUP
        if(powerupChoice == 4){             
            UserInput();
        } 
        // REPLENISH CORE HEALTH POWERUP
        else if(powerupChoice == 5){
            ReplenishCore();
        }
        // WAVE NUMBER BOOST POWERUP
        else if(powerupChoice == 6){
            BoostWaveNumber();
            powerupChoice = 0;
        }
        // GAME CURRENCY BOOST POWERUP
        else if(powerupChoice == 7){
            BoostGameCurrency();
            powerupChoice = 0;
        }
        // RANDOM GIFT POWERUP
        else if(powerupChoice == 8){
            RandomGift();
            powerupChoice = 0;
        }


    }

    // LANDMINE POINTER POWERUP 


    // Taking user input for landmine pointer
    private void UserInput(){


        // Checks whether the player is touching the screen or not 

        if(Input.touchCount > 0){

            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if(touch.phase == TouchPhase.Began){


                // Add game juice here to make the tap feel more responsive

                if((Time.time - lastTapTime <= doubleTapThreshold) && (Physics2D.OverlapCircleAll(touchPosition,0.1f).Length == 0)){

                    // Add game juice here
                    Instantiate(landmine,touchPosition,Quaternion.identity);

                }

                else{
                    lastTapTime = Time.time;
                }

            }
        }


    }


    // REPLENISH CORE HEALTH POWERUP 

    // Replenish core health

    private void ReplenishCore(){
        //Add game juice here for healing the core
        coreHealthScriptRef.coreHealth = 100;
    }



    // WAVE NUMBER BOOST POWERUP 

    // Boost wave number

    private void BoostWaveNumber(){
        //Add game juice here for the boost 
        statsRef.waveNumber += waveNumberBoostAmount;
    }


    // GAME CURRENCY BOOST POWERUP

    // Boost currency 

    private void BoostGameCurrency(){
        // Add game juice here for the boost
        statsRef.gameCurrency += gameCurrencyBoostAmount;
    }


    // RANDOM GIFT POWERUP

    // Gives random gift to the player 

    private void RandomGift(){
        
        int choice = Random.Range(0,3);

        if(choice == 0){
            // Add game juice here 
            statsRef.waveNumber += Random.Range(10,15);
        }
        else if(choice == 1){
            // Add game juice here 
            statsRef.gameCurrency += Random.Range(20,30);
        }
        else if(choice == 2){
            // Add game juice here 
            coreHealthScriptRef.coreHealth = 100;
        }
    }


}
