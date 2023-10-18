using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManagerScript : MonoBehaviour
{
    // Variables 

    private int enemyAccess = 3;
    private Camera mainCamera;

    [SerializeField] private int budget = 50;
    [SerializeField] private int budgetGainPerWave;
    [SerializeField] private List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private List<int> enemiesCost = new List<int>();

    private bool case1bool = true;
    private bool case2bool = true;
    private bool case3bool = true;

    private bool case4bool = true;

    private bool case8bool = true;

    private bool case15bool = true;
    private bool case20bool = true;

    private bool case28bool = true;
    private bool case35bool = true;
    

    // References

    private GameStatsManagerScript statsRef;
    private GameUIManagerScript uiManager;

    void Start(){
        statsRef = GameObject.Find("GameManagers/GameStatsManager").GetComponent<GameStatsManagerScript>();
        uiManager = GameObject.Find("GameManagers/GameUIManager").GetComponent<GameUIManagerScript>();
        mainCamera = Camera.main;
    }

    void Update(){
        
        // Check whether enemies are left or not

        if((GameObject.FindGameObjectsWithTag("Enemy").Length == 0)){
            SpawnNewWave();
        }

        // Changing difficulty with waves 

        switch(statsRef.waveNumber){

            case 1:
                enemyAccess = 3;
                if(case1bool == true){
                    uiManager.ShowInstructions("TAP ON ENEMIES TO ELIMINATE THEM. DIFFERENT ENEMIES NEED DIFFERENT NUMBER OF TAPS.", 10f);
                    case1bool = false;
                }
                break;

            case 2:
                if(case2bool == true){
                    uiManager.ShowInstructions("RANDOM POWER-UPS WILL SPAWN IN GAME, BUT USING THEM TO DEFEAT ENEMIES WILL NOT EARN YOU MONEY.", 10f);
                    case2bool = false;
                }
                break;

            case 3:
                if(case3bool == true){
                    uiManager.ShowInstructions("THE CORE WILL PLAY A SPECIAL ANIMATION WHEN YOU CAN AFFORD THE SPECIAL ATTACK, DOUBLE TAP THE CORE TO BUY IT.", 10f);
                    case3bool = false;
                }
                break;

            case 4:
                if(case4bool == true){
                    uiManager.ShowInstructions("SURVIVE FOR AS LONG AS YOU CAN. I CHALLENGE YOU TO CROSS LEVEL 50", 10f);
                    case4bool = false;
                }
                break;

        
            case 8:
                enemyAccess = 5;
                if(case8bool == true){
                    case8bool = false;
                }
                break;

            case 15:
                enemyAccess = 7;
                if(case15bool == true){
                    uiManager.ShowInstructions("AVOID TAPPING ON THE BLUE ENEMIES.", 25f);
                    case15bool = false;
                }
                break;

            case 20:
                enemyAccess = 9;
                if(case20bool == true){
                    case20bool = false;
                }
                break;

            case 28:
                enemyAccess = 12;
                if(case28bool == true){
                    case28bool = false;
                }
                break;

            case 35:
                enemyAccess = 14;
                if(case35bool == true){
                    case35bool = false;
                }
                break;
        }
        
    }

    // Spawn a new wave
    private void SpawnNewWave(){

        int tempBudget = budget;

        while(tempBudget > 0){
            for(int i = 0; i < enemyAccess ; i++){
                if(tempBudget - enemiesCost[i] >= 0){

                    int choice = Random.Range(0,2);

                    if(choice == 1){

                        if((i == 9) || (i == 10)){

                            Vector3 spawnPointTurret = Vector3.zero;

                            spawnPointTurret.x = Random.Range(0.1f, 0.9f);
                            spawnPointTurret.y = Random.Range(0.1f, 0.9f);

                            Vector3 worldSpawnPointTurret = Camera.main.ViewportToWorldPoint(spawnPointTurret);
                            worldSpawnPointTurret.z = 0;

                            // Spawning the turret enemy on a random location

                            Instantiate(enemies[i], worldSpawnPointTurret, transform.rotation);
                            tempBudget -= enemiesCost[i];

                        }

                        else{

                            // Spawning the enemy on a random location

                            Instantiate(enemies[i], GenerateSpawnPoint(), transform.rotation);
                            tempBudget -= enemiesCost[i];

                        }


                    }

                }
            }
        }



        // Increase the budget for the next wave
        budget += budgetGainPerWave;

        statsRef.waveNumber++;

        // Add game juice here to display the new wave number

        uiManager.IncrementWaveNumber();

    }


    // Generate a random spawn point for the enemy
    private Vector3 GenerateSpawnPoint(){
    
        int side = Random.Range(0,4);

        // IF SIDE = 0 => SPAWN ON LEFT SIDE OF THE SCREEN
        // IF SIDE = 1 => SPAWN ON TOP SIDE OF THE SCREEN
        // IF SIDE = 2 => SPAWN ON RIGHT SIDE OF THE SCREEN
        // IF SIDE = 3 => SPAWN ON BOTTOM SIDE OF THE SCREEN

        Vector3 spawnPoint = Vector3.zero;

        switch(side){

            case 0:
                // LEFT
                spawnPoint.x = 0;
                spawnPoint.y = Random.value; 
                spawnPoint.x -= 0.2f;            
                break;

            case 1:
                // TOP
                spawnPoint.y = 1;
                spawnPoint.x = Random.value; 
                spawnPoint.y += 0.15f;  
                break;
                                
            case 2:
                // RIGHT
                spawnPoint.x = 1;
                spawnPoint.y = Random.value;  
                spawnPoint.x += 0.2f;
                
                break;

            case 3:
                // BOTTOM
                spawnPoint.y = 0;
                spawnPoint.x = Random.value; 
                spawnPoint.y -= 0.15f;
                break;
                                
        }


        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 0;

        return worldSpawnPoint;
    }

}
